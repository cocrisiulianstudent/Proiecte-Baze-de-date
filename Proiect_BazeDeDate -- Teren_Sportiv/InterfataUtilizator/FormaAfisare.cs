using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;
using DotNetOracle;
using System.Collections.Generic;

namespace InterfataUtilizator
{
    public partial class FormaAfisare : Form
    {
        private const int PRIMA_COLOANA = 0; // Indicele primei coloane în grid-ul de date
        private const bool SUCCES = true; // Constantă pentru succes

        // Inițializarea obiectelor pentru stocarea datelor
        IStocareTerenuriSportive stocareTerenuriSportive = (IStocareTerenuriSportive)new StocareFactory().GetTipStocare(typeof(TerenSportiv));
        IStocareUtilizatori stocareUtilizatori = (IStocareUtilizatori)new StocareFactory().GetTipStocare(typeof(Utilizator));
        IStocareInchirieri stocareInchirieri = (IStocareInchirieri)new StocareFactory().GetTipStocare(typeof(Inchiriere));

        public FormaAfisare()
        {
            InitializeComponent();

            // Verificare inițializare corectă a obiectelor de stocare
            if (stocareTerenuriSportive == null || stocareUtilizatori == null || stocareInchirieri == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }

        // Funcție apelată la încărcarea formularului
        private void FormaAfisare_Load(object sender, EventArgs e)
        {
            AfiseazaCatalog(); // Afișează catalogul de închirieri
        }

        // Acțiune la închiderea formularului
        private void FormaAfisare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Închide aplicația
        }

        // Acțiune pentru deschiderea formularului de gestionare a utilizatorilor
        private void btnFormUtilizator_Click(object sender, EventArgs e)
        {
            FormaUtilizator f = new FormaUtilizator();
            f.Show(); // Afișează formularul pentru gestionarea utilizatorilor
            this.Hide(); // Ascunde formularul curent
        }

        // Acțiune pentru deschiderea formularului de gestionare a terenurilor sportive
        private void btnFormTerenSportiv_Click(object sender, EventArgs e)
        {
            FormaTerenSportiv f = new FormaTerenSportiv();
            f.Show(); // Afișează formularul pentru gestionarea terenurilor sportive
            this.Hide(); // Ascunde formularul curent
        }

        // Acțiune pentru deschiderea formularului de gestionare a închirierilor
        private void btnFormInchiriere_Click(object sender, EventArgs e)
        {
            FormaInchiriere f = new FormaInchiriere();
            f.Show(); // Afișează formularul pentru gestionarea închirierilor
            this.Hide(); // Ascunde formularul curent
        }

        // Acțiune pentru închiderea aplicației
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Închide aplicația
        }

        // Funcție pentru afișarea catalogului de închirieri în DataGridView
        private void AfiseazaCatalog()
        {
            try
            {
                var detaliiInchirieri = GetDetaliiInchirieri(); // Obține detalii despre închirieri

                if (detaliiInchirieri != null && detaliiInchirieri.Any())
                {
                    // Creează o listă anonimă pentru a afișa în DataGridView
                    var lista = detaliiInchirieri.Select(d => new
                    {
                        d.Id_Inchiriere,
                        d.Id_Teren,
                        d.Id_Utilizator,
                        d.NumeComplet,
                        d.Email,
                        d.Telefon,
                        d.Denumire,
                        d.Suprafata,
                        d.Tip_Sport,
                        d.Adresa,
                        Data_Inceput = d.Data_Inceput.ToString("dd/MM/yyyy"),
                        Data_Sfarsit = d.Data_Sfarsit.ToString("dd/MM/yyyy"),
                        d.Pret,
                        Pret_Total = (d.Data_Sfarsit - d.Data_Inceput).Days * d.Pret
                    }).ToList();

                    // Setează sursa de date pentru DataGridView
                    dataGridInchirieri.DataSource = lista;

                    // Ascunde coloanele cu id-urile (opțional)
                    dataGridInchirieri.Columns["Id_Inchiriere"].Visible = false;
                    dataGridInchirieri.Columns["Id_Teren"].Visible = false;
                    dataGridInchirieri.Columns["Id_Utilizator"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); // Afișează mesaj de eroare în caz de excepție
            }
        }

        // Funcție pentru obținerea detalii despre toate închirierile
        public List<dynamic> GetDetaliiInchirieri()
        {
            // Obține listele de utilizatori, terenuri și închirieri
            var utilizatori = stocareUtilizatori.GetUtilizatori();
            var terenuri = stocareTerenuriSportive.GetTerenuriSportive();
            var inchirieri = stocareInchirieri.GetInchirieri();

            // Realizează o interogare pentru a obține detalii despre închirieri
            var detalii = from i in inchirieri
                          join u in utilizatori on i.Id_Utilizator equals u.Id_Utilizator
                          join t in terenuri on i.Id_Teren equals t.Id_Teren
                          select new
                          {
                              i.Id_Inchiriere,
                              t.Id_Teren,
                              u.Id_Utilizator,
                              u.NumeComplet,
                              u.Email,
                              u.Telefon,
                              t.Denumire,
                              t.Suprafata,
                              t.Tip_Sport,
                              t.Adresa,
                              i.Data_Inceput,
                              i.Data_Sfarsit,
                              i.Pret
                          };

            return detalii.ToList<dynamic>(); // Returnează rezultatul sub formă de listă dinamică
        }

        // Funcție pentru obținerea detaliilor despre o închiriere după id
        public dynamic GetDetaliiInchiriereById(int idInchiriere)
        {
            // Obține listele de închirieri, utilizatori și terenuri
            var inchirieri = stocareInchirieri.GetInchirieri();
            var utilizatori = stocareUtilizatori.GetUtilizatori();
            var terenuri = stocareTerenuriSportive.GetTerenuriSportive();

            // Realizează o interogare pentru a obține detalii despre închirierea cu id-ul specificat
            var detalii = from i in inchirieri
                          join u in utilizatori on i.Id_Utilizator equals u.Id_Utilizator
                          join t in terenuri on i.Id_Teren equals t.Id_Teren
                          where i.Id_Inchiriere == idInchiriere
                          select new
                          {
                              i.Id_Inchiriere,
                              t.Id_Teren,
                              u.Id_Utilizator,
                              u.Nume,
                              u.Prenume,
                              u.Email,
                              u.Telefon,
                              t.Denumire,
                              t.Suprafata,
                              t.Tip_Sport,
                              t.Adresa,
                              i.Data_Inceput,
                              i.Data_Sfarsit,
                              i.Pret
                          };

            return detalii.FirstOrDefault(); // Returnează primul rezultat găsit sau null dacă nu există
        }
    }
}
