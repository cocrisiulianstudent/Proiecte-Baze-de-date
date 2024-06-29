using InterfataUtilizator;  // Import pentru interfața utilizatorului

using LibrarieModele;       // Import pentru modelele de date

using NivelAccesDate;       // Import pentru accesul la date

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DotNetOracle
{
    public partial class FormaInchiriere : Form
    {
        private const int PRIMA_COLOANA = 0;  // Indicele primei coloane în grid
        private const bool SUCCES = true;
        // Obiecte pentru stocarea datelor de închiriere, terenuri sportive și utilizatori
        IStocareInchirieri stocareInchirieri = (IStocareInchirieri)new StocareFactory().GetTipStocare(typeof(Inchiriere));
        IStocareTerenuriSportive stocareTerenuriSportive = (IStocareTerenuriSportive)new StocareFactory().GetTipStocare(typeof(TerenSportiv));
        IStocareUtilizatori stocareUtilizatori = (IStocareUtilizatori)new StocareFactory().GetTipStocare(typeof(Utilizator));

        public FormaInchiriere()
        {
            InitializeComponent();

            // Verificare și afișare mesaj de eroare în cazul în care stocarea nu a fost inițializată corect
            if (stocareInchirieri == null || stocareUtilizatori == null || stocareTerenuriSportive == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
            else
            {
                // Încărcare combobox-uri și lista de închirieri la inițializare
                IncarcaComboBoxUtilizatori();
                IncarcaComboBoxTerenuriSportive();
                IncarcaInscrieri();
            }
        }

        // Metodă pentru revenire la meniul principal
        private void btnMeniu_Click(object sender, EventArgs e)
        {
            SqlDBHelper.Commit();  // Comit la baza de date SQL
            FormaAfisare f = new FormaAfisare();  // Deschidere formular pentru afișarea datelor
            f.Show();
            this.Hide();  // Ascundere formularul curent
        }

        // Metodă pentru închiderea aplicației
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Validare format dată
        private bool ValidateDateFormat(string dateText, out DateTime parsedDate)
        {
            // Verificare format dată și parsare
            string[] formats = { "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" };
            if (DateTime.TryParseExact(dateText, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Formatul datei nu este valid. Folosiți formatul dd-MM-yyyy, dd/MM/yyyy sau dd.MM.yyyy.");
                parsedDate = DateTime.MinValue;
                return false;
            }
        }

        // Adăugare închiriere nouă
        private void btnAdaugareInchiriere_Click(object sender, EventArgs e)
        {
            try
            {
                // Validare și preluare date pentru închiriere
                int idUtilizator = Convert.ToInt32(cmbUtilizator.SelectedValue);
                int idTerenSportiv = Convert.ToInt32(cmbTeren.SelectedValue);

                DateTime dataInceput;
                if (!ValidateDateFormat(txtDataInceput.Text, out dataInceput))
                    return;

                DateTime dataSfarsit;
                if (!ValidateDateFormat(txtDataSfarsit.Text, out dataSfarsit))
                    return;

                if (dataSfarsit <= dataInceput)
                {
                    MessageBox.Show("Data de sfârșit trebuie să fie după data de început.");
                    return;
                }

                // Creare obiect Inchiriere și adăugare în baza de date
                var inchiriere = new Inchiriere
                {
                    Id_Utilizator = idUtilizator,
                    Id_Teren = idTerenSportiv,
                    Data_Inceput = DateTime.Parse(txtDataInceput.Text),
                    Data_Sfarsit = DateTime.Parse(txtDataSfarsit.Text),
                    Pret = decimal.Parse(txtPret.Text)
                };

                var rezultat = stocareInchirieri.AddInchiriere(inchiriere);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Închiriere adăugată cu succes.");
                }
                else
                {
                    MessageBox.Show("Eroare la adăugarea închirierii.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepție: " + ex.Message);
            }
            IncarcaInscrieri();  // Reîncărcare listă închirieri
        }

        // Modificare închiriere existentă
        private void btnModificaInchiriere_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificare și actualizare închiriere
                if (dataGridInchirieri.SelectedRows.Count > 0)
                {
                    int idInchiriere = Convert.ToInt32(dataGridInchirieri.SelectedRows[0].Cells["Id_Inchiriere"].Value);

                    Inchiriere inchiriereModificata = new Inchiriere
                    {
                        Id_Utilizator = Convert.ToInt32(cmbUtilizator.SelectedValue),
                        Id_Teren = Convert.ToInt32(cmbTeren.SelectedValue),
                        Data_Inceput = DateTime.Parse(txtDataInceput.Text),
                        Data_Sfarsit = DateTime.Parse(txtDataSfarsit.Text),
                        Pret = decimal.Parse(txtPret.Text)
                    };

                    Inchiriere inchiriereExistenta = stocareInchirieri.GetInchiriere(idInchiriere);

                    if (inchiriereExistenta != null)
                    {
                        // Actualizare date închiriere
                        inchiriereExistenta.Id_Utilizator = inchiriereModificata.Id_Utilizator;
                        inchiriereExistenta.Id_Teren = inchiriereModificata.Id_Teren;
                        inchiriereExistenta.Data_Inceput = inchiriereModificata.Data_Inceput;
                        inchiriereExistenta.Data_Sfarsit = inchiriereModificata.Data_Sfarsit;
                        inchiriereExistenta.Pret = inchiriereModificata.Pret;

                        bool rezultat = stocareInchirieri.UpdateInchiriere(inchiriereExistenta);

                        if (rezultat)
                        {
                            MessageBox.Show("Închiriere modificată cu succes.");
                        }
                        else
                        {
                            MessageBox.Show("Eroare la modificarea închirierii.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Închirierea nu a fost găsită.");
                    }
                }
                else
                {
                    MessageBox.Show("Selectați o închiriere pentru a o modifica.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepție: " + ex.Message);
            }
            IncarcaInscrieri();  // Reîncărcare listă închirieri
        }

        // Ștergere închiriere selectată
        private void btnStergereInchiriere_Click(object sender, EventArgs e)
        {
            if (dataGridInchirieri.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridInchirieri.SelectedRows)
                {
                    int idInchiriere = Convert.ToInt32(row.Cells["Id_Inchiriere"].Value);
                    string numeComplet = $"{row.Cells["Nume"].Value} {row.Cells["Prenume"].Value}";

                    try
                    {
                        // Ștergere închiriere din baza de date
                        if (stocareInchirieri.DeleteInchiriere(idInchiriere))
                        {
                            MessageBox.Show($"Închirierea utilizatorului {numeComplet} a fost ștearsă cu succes.");
                        }
                        else
                        {
                            MessageBox.Show("Eroare la ștergerea închirierii.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați o închiriere pentru a o șterge.");
            }
            IncarcaInscrieri();  // Reîncărcare listă închirieri
        }

        // Încărcare detalii închiriere la selectarea unei înregistrări din grid
        private void dataGridInchirieri_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridInchirieri.SelectedRows.Count > 0)
            {
                int idInchiriere = Convert.ToInt32(dataGridInchirieri.SelectedRows[0].Cells["Id_Inchiriere"].Value);
                try
                {
                    var detalii = GetDetaliiInchiriereById(idInchiriere);

                    if (detalii != null)
                    {
                        cmbUtilizator.SelectedValue = detalii.Id_Utilizator;
                        cmbTeren.SelectedValue = detalii.Id_Teren;
                        txtDataInceput.Text = detalii.Data_Inceput.ToString("dd-MM-yyyy");
                        txtDataSfarsit.Text = detalii.Data_Sfarsit.ToString("dd-MM-yyyy");
                        txtPret.Text = detalii.Pret.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        // Încărcare detalii închiriere la click pe celulă din grid
        private void dataGridInchirieri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int currentRowIndex = e.RowIndex;
                int idInchiriere = Convert.ToInt32(dataGridInchirieri[PRIMA_COLOANA, currentRowIndex].Value);

                try
                {
                    var detalii = GetDetaliiInchiriereById(idInchiriere);

                    if (detalii != null)
                    {
                        cmbUtilizator.SelectedValue = detalii.Id_Utilizator;
                        cmbTeren.SelectedValue = detalii.Id_Teren;
                        txtDataInceput.Text = detalii.Data_Inceput.ToString("dd-MM-yyyy");
                        txtDataSfarsit.Text = detalii.Data_Sfarsit.ToString("dd-MM-yyyy");
                        txtPret.Text = detalii.Pret.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        // Obținere ID utilizator în funcție de nume și prenume
        public int GetIdUtilizator(string nume, string prenume)
        {
            var utilizatori = stocareUtilizatori.GetUtilizatori();
            var utilizator = utilizatori.FirstOrDefault(u => u.Nume == nume && u.Prenume == prenume);
            if (utilizator != null)
            {
                return utilizator.Id_Utilizator;
            }
            else
            {
                throw new Exception("Utilizatorul nu a fost gasit.");
            }
        }

        // Obținere ID teren sportiv în funcție de denumire
        public int GetIdTerenSportiv(string denumire)
        {
            var terenuri = stocareTerenuriSportive.GetTerenuriSportive();
            var teren = terenuri.FirstOrDefault(t => t.Denumire == denumire);
            if (teren != null)
            {
                return teren.Id_Teren;
            }
            else
            {
                throw new Exception("Terenul sportiv nu a fost gasit.");
            }
        }

        // Încărcare combobox pentru utilizatori
        private void IncarcaComboBoxUtilizatori()
        {
            try
            {
                var utilizatori = stocareUtilizatori.GetUtilizatori();
                cmbUtilizator.DataSource = utilizatori;
                cmbUtilizator.DisplayMember = "NumeComplet";
                cmbUtilizator.ValueMember = "Id_Utilizator";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea utilizatorilor: " + ex.Message);
            }
        }

        // Încărcare combobox pentru terenuri sportive
        private void IncarcaComboBoxTerenuriSportive()
        {
            try
            {
                var terenuri = stocareTerenuriSportive.GetTerenuriSportive();
                cmbTeren.DataSource = terenuri;
                cmbTeren.DisplayMember = "Denumire";
                cmbTeren.ValueMember = "Id_Teren";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea terenurilor sportive: " + ex.Message);
            }
        }

        // Încărcare închirieri în grid
        private void IncarcaInscrieri()
        {
            try
            {
                var detaliiInchirieri = GetDetaliiInchirieri();
                if (detaliiInchirieri != null && detaliiInchirieri.Any())
                {
                    var lista = detaliiInchirieri.Select(d => new
                    {
                        d.Id_Inchiriere,
                        d.Id_Teren,
                        d.Id_Utilizator,
                        d.Nume,
                        d.Prenume,
                        d.Email,
                        d.Telefon,
                        d.Denumire,
                        d.Suprafata,
                        d.Tip_Sport,
                        d.Adresa,
                        d.Data_Inceput,
                        d.Data_Sfarsit,
                        d.Pret
                    }).ToList();

                    dataGridInchirieri.DataSource = lista;

                    // Ascundere coloane cu ID-uri pentru utilizator și teren sportiv
                    dataGridInchirieri.Columns["Id_Inchiriere"].Visible = false;
                    dataGridInchirieri.Columns["Id_Teren"].Visible = false;
                    dataGridInchirieri.Columns["Id_Utilizator"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        // Obținere detalii complete pentru toate închirierile
        public List<dynamic> GetDetaliiInchirieri()
        {
            var utilizatori = stocareUtilizatori.GetUtilizatori();
            var terenuri = stocareTerenuriSportive.GetTerenuriSportive();
            var inchirieri = stocareInchirieri.GetInchirieri();
            var detalii = from i in inchirieri
                          join u in utilizatori on i.Id_Utilizator equals u.Id_Utilizator
                          join t in terenuri on i.Id_Teren equals t.Id_Teren
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

            return detalii.ToList<dynamic>();
        }

        // Obținere detalii pentru o închiriere specificată prin ID
        public dynamic GetDetaliiInchiriereById(int idInchiriere)
        {
            var inchirieri = stocareInchirieri.GetInchirieri();
            var utilizatori = stocareUtilizatori.GetUtilizatori();
            var terenuri = stocareTerenuriSportive.GetTerenuriSportive();
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
            return detalii.FirstOrDefault();
        }
    }
}
