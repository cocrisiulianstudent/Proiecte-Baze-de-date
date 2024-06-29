using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;
using InterfataUtilizator;

namespace DotNetOracle
{
    public partial class FormaAfisare : Form
    {
        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        // Inițializarea stocării pentru aparat foto, clienți și închirieri utilizând Factory și Interfețe specifice
        IStocareAparatFoto stocareAparateFoto = (IStocareAparatFoto)new StocareFactory().GetTipStocare(typeof(AparateFoto));
        IStocareClienti stocareClienti = (IStocareClienti)new StocareFactory().GetTipStocare(typeof(Clienti));
        IStocareInchirieriAparateFoto stocareInchirieriAparateFoto = (IStocareInchirieriAparateFoto)new StocareFactory().GetTipStocare(typeof(InchirieriAparateFoto));

        public FormaAfisare()
        {
            InitializeComponent();

            // Verificare dacă stocarea pentru aparat foto, clienți sau închirieri a fost inițializată corect
            if (stocareAparateFoto == null || stocareClienti == null || stocareInchirieriAparateFoto == null)
            {
                MessageBox.Show("Eroare la initializare");
            }

            // Afisează catalogul de închirieri în momentul deschiderii formularului
            AfiseazaCatalog();
        }

        private void FormaAfisare_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Închiderea aplicației la închiderea formularului
            Application.Exit();
        }

        private void btnFormularClient_Click(object sender, EventArgs e)
        {
            // Deschide formularul pentru gestionarea clienților și ascunde formularul curent
            FormaClienti f = new FormaClienti();
            f.Show();
            this.Hide();
        }

        private void btnFormAparatFoto_Click(object sender, EventArgs e)
        {
            // Deschide formularul pentru gestionarea aparatelor foto și ascunde formularul curent
            FormaAparatFoto f = new FormaAparatFoto();
            f.Show();
            this.Hide();
        }

        private void btnFormInchiriere_Click(object sender, EventArgs e)
        {
            // Deschide formularul pentru gestionarea închirierilor aparatelor foto și ascunde formularul curent
            FormaInchirieriAparatFoto f = new FormaInchirieriAparatFoto();
            f.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Închide aplicația la apăsarea butonului Exit
            Application.Exit();
        }

        private void AfiseazaCatalog()
        {
            try
            {
                // Obține detaliile completate ale închirierilor aparatelor foto
                var detaliiInchirieriAparateFoto = GetDetaliiInchirieriAparateFoto();

                // Verifică dacă există înregistrări de afișat
                if (detaliiInchirieriAparateFoto != null && detaliiInchirieriAparateFoto.Any())
                {
                    // Crează o listă anonimă cu detaliile necesare pentru afișare în datagridview
                    var lista = detaliiInchirieriAparateFoto.Select(d => new
                    {
                        d.ID_Inchiriere,
                        d.ID_Client,
                        d.ID_Aparat,
                        Nume_Complet = d.Nume_Complet,
                        d.Email,
                        d.Telefon,
                        Marca_Model = $"{d.Nume_Model} - {d.Descriere}",
                        d.Disponibilitate,
                        d.Tarif_Zi,
                        Data_Inceput = d.Data_Inceput.ToString("dd/MM/yyyy"),
                        Data_Sfarsit = d.Data_Sfarsit.ToString("dd/MM/yyyy"),
                        Pret_Total = (d.Data_Sfarsit - d.Data_Inceput).Days * d.Tarif_Zi
                    }).ToList();

                    // Atribuie lista datagridview-ului pentru afișare
                    dataGridInchirieriAparateFoto.DataSource = lista;

                    // Ascunde coloanele ID și Detalii de disponibilitate
                    dataGridInchirieriAparateFoto.Columns["ID_Inchiriere"].Visible = false;
                    dataGridInchirieriAparateFoto.Columns["ID_Client"].Visible = false;
                    dataGridInchirieriAparateFoto.Columns["ID_Aparat"].Visible = false;
                    dataGridInchirieriAparateFoto.Columns["Disponibilitate"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                // Gestionare excepții în cazul unei erori în timpul afișării catalogului
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public List<dynamic> GetDetaliiInchirieriAparateFoto()
        {
            // Obține lista de închirieri complete
            var clienti = stocareClienti.GetClienti();
            var aparateFoto = stocareAparateFoto.GetAparateFoto();
            var inchirieriAparateFoto = stocareInchirieriAparateFoto.GetInchirieriAparateFoto();

            // Obține detalii specifice pentru afișare combinând datele din toate sursele
            var detalii = from i in inchirieriAparateFoto
                          join u in clienti on i.ID_Client equals u.ID_Client
                          join a in aparateFoto on i.ID_Aparat equals a.ID_Aparat
                          select new
                          {
                              i.ID_Inchiriere,
                              u.ID_Client,
                              u.Nume_Client,
                              u.Prenume_Client,
                              u.Email,
                              u.Telefon,
                              Nume_Complet = $"{u.Nume_Client} {u.Prenume_Client}",
                              a.ID_Aparat,
                              a.Nume_Model,
                              a.Descriere,
                              a.Disponibilitate,
                              a.Tarif_Zi,
                              i.Data_Inceput,
                              i.Data_Sfarsit,
                          };

            return detalii.ToList<dynamic>();
        }

        public dynamic GetDetaliiInchiriereAparatFotoById(int idInchiriere)
        {
            // Obține detalii de închiriere pentru un ID specificat
            var inchirieriAparateFoto = stocareInchirieriAparateFoto.GetInchirieriAparateFoto();
            var clienti = stocareClienti.GetClienti();
            var aparateFoto = stocareAparateFoto.GetAparateFoto();

            // Filtrează închirierea bazată pe ID-ul specificat și obține detaliile asociate
            var detalii = from i in inchirieriAparateFoto
                          join u in clienti on i.ID_Client equals u.ID_Client
                          join a in aparateFoto on i.ID_Aparat equals a.ID_Aparat
                          where i.ID_Inchiriere == idInchiriere
                          select new
                          {
                              i.ID_Inchiriere,
                              u.ID_Client,
                              u.Nume_Client,
                              u.Prenume_Client,
                              u.Email,
                              u.Telefon,
                              a.Descriere,
                              a.Disponibilitate,
                              a.Tarif_Zi,
                              i.Data_Inceput,
                              i.Data_Sfarsit,
                          };

            return detalii.FirstOrDefault();
        }
    }
}
