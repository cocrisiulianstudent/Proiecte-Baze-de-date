using InterfataUtilizator; // Importă namespace-ul pentru interfața utilizatorului

using LibrarieModele; // Importă namespace-ul pentru modelele de date

using NivelAccesDate; // Importă namespace-ul pentru nivelul de acces la date

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DotNetOracle
{
    public partial class FormaInchirieriAparatFoto : Form
    {
        private const int PRIMA_COLOANA = 0; // Constantă pentru indexul primei coloane din DataGridView
        private const bool SUCCES = true; // Constantă pentru succes în operațiile de adăugare/modificare/ștergere

        // Inițializare stocare pentru operațiuni legate de închirieri de aparate foto, aparate foto și clienți
        IStocareInchirieriAparateFoto stocareInchirieri = (IStocareInchirieriAparateFoto)new StocareFactory().GetTipStocare(typeof(InchirieriAparateFoto));
        IStocareAparatFoto stocareAparateFoto = (IStocareAparatFoto)new StocareFactory().GetTipStocare(typeof(AparateFoto));
        IStocareClienti stocareClienti = (IStocareClienti)new StocareFactory().GetTipStocare(typeof(Clienti));

        // Constructorul formularului
        public FormaInchirieriAparatFoto()
        {
            InitializeComponent();

            // Verificare inițializare corectă a stocării
            if (stocareInchirieri == null || stocareClienti == null || stocareAparateFoto == null)
            {
                MessageBox.Show("Eroare la initializare");
            }

            // Încărcare închirieri existente și populare combobox-uri pentru clienți și aparate foto
            IncarcaInchirieri();
            PopuleazaComboBoxClienti();
            PopuleazaComboBoxAparateFoto();
        }

        // Eveniment de click pe butonul pentru meniul principal
        private void btnMeniu_Click(object sender, EventArgs e)
        {
            // Salvare modificări în baza de date (exemplu: SqlDBHelper.Commit())
            SqlDBHelper.Commit();

            // Deschide formularul principal (înapoi la FormaAfisare) și ascunde formularul curent
            FormaAfisare f = new FormaAfisare();
            f.Show();
            this.Hide();
        }

        // Validare format dată folosind formatele specificate
        private bool ValidateDateFormat(string dateText, out DateTime parsedDate)
        {
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

        // Funcție pentru curățarea TextBox-urilor formularului
        private void curataTextBoxuri()
        {
            txtDataInceput.Text = "";
            txtDataSfarsit.Text = "";
        }

        // Eveniment de click pe butonul pentru adăugarea unei închirieri de aparat foto
        private void btnAdaugareInchiriereAparatFoto_Click(object sender, EventArgs e)
        {
            try
            {
                // Obține ID-urile selectate pentru client și aparat foto din ComboBox-uri
                int idClient = (int)cmbClienti.SelectedValue;
                int idAparatFoto = (int)cmbAparateFoto.SelectedValue;

                // Verifică selecția validă a unui client și a unui aparat foto
                if (idClient != -1 && idAparatFoto != -1)
                {
                    // Validare format dată pentru data de început
                    DateTime dataInceput;
                    if (!ValidateDateFormat(txtDataInceput.Text, out dataInceput))
                        return;

                    // Validare format dată pentru data de sfârșit
                    DateTime dataSfarsit;
                    if (!ValidateDateFormat(txtDataSfarsit.Text, out dataSfarsit))
                        return;

                    // Verificare ca data de sfârșit să fie după data de început
                    if (dataSfarsit <= dataInceput)
                    {
                        MessageBox.Show("Data de sfârșit trebuie să fie după data de început.");
                        return;
                    }

                    // Creare obiect InchirieriAparateFoto cu datele introduse
                    var inchiriere = new InchirieriAparateFoto
                    {
                        ID_Client = idClient,
                        ID_Aparat = idAparatFoto,
                        Data_Inceput = dataInceput,
                        Data_Sfarsit = dataSfarsit
                    };

                    // Adăugare închiriere în baza de date
                    var rezultat = stocareInchirieri.AddInchiriereAparatFoto(inchiriere);
                    if (rezultat == SUCCES)
                    {
                        MessageBox.Show("Închiriere adăugată cu succes.");
                        curataTextBoxuri();
                    }
                    else
                    {
                        MessageBox.Show("Eroare la adăugarea închirierii.");
                    }
                }
                else
                {
                    MessageBox.Show("Selectați un client și un aparat foto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepție: " + ex.Message);
            }

            // Reîncărcare închirieri după adăugarea unei noi închirieri
            IncarcaInchirieri();
        }

        // Eveniment de click pe butonul pentru modificarea unei închirieri de aparat foto
        private void btnModificaInchiriereAparatFoto_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifică dacă este selectată o închiriere pentru modificare în DataGridView
                if (dataGridInchirieriAparateFoto.SelectedRows.Count > 0)
                {
                    // Obține ID-ul închirierii selectate pentru modificare
                    int idInchiriere = Convert.ToInt32(dataGridInchirieriAparateFoto.SelectedRows[0].Cells["ID_Inchiriere"].Value);

                    // Validare format dată pentru data de început
                    DateTime dataInceput;
                    if (!ValidateDateFormat(txtDataInceput.Text, out dataInceput))
                        return;

                    // Validare format dată pentru data de sfârșit
                    DateTime dataSfarsit;
                    if (!ValidateDateFormat(txtDataSfarsit.Text, out dataSfarsit))
                        return;

                    // Verificare ca data de sfârșit să fie după data de început
                    if (dataSfarsit <= dataInceput)
                    {
                        MessageBox.Show("Data de sfârșit trebuie să fie după data de început.");
                        return;
                    }

                    // Creare obiect InchirieriAparateFoto cu datele actualizate
                    InchirieriAparateFoto inchiriereModificata = new InchirieriAparateFoto
                    {
                        ID_Client = (int)cmbClienti.SelectedValue,
                        ID_Aparat = (int)cmbAparateFoto.SelectedValue,
                        Data_Inceput = dataInceput,
                        Data_Sfarsit = dataSfarsit
                    };

                    // Verificare selecție validă a unui client și a unui aparat foto pentru modificare
                    if (inchiriereModificata.ID_Client != -1 && inchiriereModificata.ID_Aparat != -1)
                    {
                        // Obținere închiriere existentă pentru actualizare
                        InchirieriAparateFoto inchiriereExistenta = stocareInchirieri.GetInchiriereAparatFoto(idInchiriere);

                        if (inchiriereExistenta != null)
                        {
                            // Actualizare date în închirierea existentă
                            inchiriereExistenta.ID_Client = inchiriereModificata.ID_Client;
                            inchiriereExistenta.ID_Aparat = inchiriereModificata.ID_Aparat;
                            inchiriereExistenta.Data_Inceput = inchiriereModificata.Data_Inceput;
                            inchiriereExistenta.Data_Sfarsit = inchiriereModificata.Data_Sfarsit;

                            // Actualizare în baza de date
                            bool rezultat = stocareInchirieri.UpdateInchiriereAparatFoto(inchiriereExistenta);

                            if (rezultat)
                            {
                                MessageBox.Show("Închiriere modificată cu succes.");
                                curataTextBoxuri();
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
                        MessageBox.Show("Selectați un client și un aparat foto.");
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

            // Reîncărcare închirieri după modificarea unei închirieri
            IncarcaInchirieri();
        }

        // Eveniment de click pe butonul pentru ștergerea unei închirieri de aparat foto
        private void btnStergereInchiriereAparatFoto_Click(object sender, EventArgs e)
        {
            // Verificare dacă este selectată o închiriere pentru ștergere în DataGridView
            if (dataGridInchirieriAparateFoto.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridInchirieriAparateFoto.SelectedRows)
                {
                    // Obținere ID închiriere pentru ștergere
                    int idInchiriere = Convert.ToInt32(row.Cells["ID_Inchiriere"].Value);
                    try
                    {
                        // Ștergere închiriere din baza de date
                        if (stocareInchirieri.DeleteInchiriereAparatFoto(idInchiriere))
                        {
                            MessageBox.Show("Închirierea a fost ștearsă cu succes.");
                            curataTextBoxuri();
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

            // Reîncărcare închirieri după ștergerea uneia sau mai multor închirieri
            IncarcaInchirieri();
        }

        // Eveniment de selecție a unei închirieri în DataGridView
        private void dataGridInchirieriAparateFoto_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridInchirieriAparateFoto.SelectedRows.Count > 0)
            {
                // Obținere ID închiriere selectată pentru detalii
                int idInchiriere = Convert.ToInt32(dataGridInchirieriAparateFoto.SelectedRows[0].Cells["ID_Inchiriere"].Value);
                try
                {
                    // Obținere detalii închiriere după ID pentru afișare în ComboBox-uri și TextBox-uri
                    var detalii = GetDetaliiInchiriereById(idInchiriere);

                    if (detalii != null)
                    {
                        cmbClienti.SelectedValue = detalii.ID_Client;
                        cmbAparateFoto.SelectedValue = detalii.ID_Aparat;
                        txtDataInceput.Text = detalii.Data_Inceput.ToString("dd-MM-yyyy");
                        txtDataSfarsit.Text = detalii.Data_Sfarsit.ToString("dd-MM-yyyy");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        // Eveniment de click pe conținutul unei celule din DataGridView
        private void dataGridInchirieriAparateFoto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obținere indexul rândului curent
                int currentRowIndex = e.RowIndex;

                // Obținere ID închiriere din prima coloană a rândului curent
                int idInchiriere = Convert.ToInt32(dataGridInchirieriAparateFoto[PRIMA_COLOANA, currentRowIndex].Value);

                try
                {
                    // Obținere detalii închiriere după ID pentru afișare în ComboBox-uri și TextBox-uri
                    var detalii = GetDetaliiInchiriereById(idInchiriere);

                    if (detalii != null)
                    {
                        cmbClienti.SelectedValue = detalii.ID_Client;
                        cmbAparateFoto.SelectedValue = detalii.ID_Aparat;
                        txtDataInceput.Text = detalii.Data_Inceput.ToString("dd-MM-yyyy");
                        txtDataSfarsit.Text = detalii.Data_Sfarsit.ToString("dd-MM-yyyy");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        // Funcție pentru popularea ComboBox-ului pentru clienți
        private void PopuleazaComboBoxClienti()
        {
            // Obținere listă de clienți din stocare
            var clienti = stocareClienti.GetClienti();

            // Creare listă de clienți cu nume complet (Nume + Prenume) pentru afișare în ComboBox
            var clientiCuNumeComplet = clienti.Select(c => new
            {
                c.ID_Client,
                NumeComplet = $"{c.Nume_Client} {c.Prenume_Client}"
            }).ToList();

            // Setare sursă de date pentru ComboBox-ul de clienți
            cmbClienti.DataSource = clientiCuNumeComplet;
            cmbClienti.DisplayMember = "NumeComplet";
            cmbClienti.ValueMember = "ID_Client";
        }

        // Funcție pentru popularea ComboBox-ului pentru aparate foto
        private void PopuleazaComboBoxAparateFoto()
        {
            // Obținere listă de aparate foto din stocare
            var aparateFoto = stocareAparateFoto.GetAparateFoto();

            // Setare sursă de date pentru ComboBox-ul de aparate foto
            cmbAparateFoto.DataSource = aparateFoto;
            cmbAparateFoto.DisplayMember = "Nume_Model";
            cmbAparateFoto.ValueMember = "ID_Aparat";
        }

        // Funcție pentru încărcarea închirierilor în DataGridView
        private void IncarcaInchirieri()
        {
            try
            {
                // Obținere detalii pentru toate închirierile
                var detaliiInchirieri = GetDetaliiInchirieri();

                // Verificare existență închirieri
                if (detaliiInchirieri != null && detaliiInchirieri.Any())
                {
                    // Creare listă anonimă pentru afișare în DataGridView
                    var lista = detaliiInchirieri.Select(d => new
                    {
                        d.ID_Inchiriere,
                        d.ID_Client,
                        d.ID_Aparat,
                        d.Nume_Client,
                        d.Model_Aparat,
                        d.Data_Inceput,
                        d.Data_Sfarsit
                    }).ToList();

                    // Setare sursă de date pentru DataGridView
                    dataGridInchirieriAparateFoto.DataSource = lista;

                    // Ascundere coloane nedorite din DataGridView
                    dataGridInchirieriAparateFoto.Columns["ID_Client"].Visible = false;
                    dataGridInchirieriAparateFoto.Columns["ID_Aparat"].Visible = false;
                    dataGridInchirieriAparateFoto.Columns["ID_Inchiriere"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        // Funcție pentru obținerea detaliilor pentru toate închirierile
        public List<dynamic> GetDetaliiInchirieri()
        {
            // Obținere listă de clienți, aparate foto și închirieri din stocare
            var clienti = stocareClienti.GetClienti();
            var aparateFoto = stocareAparateFoto.GetAparateFoto();
            var inchirieri = stocareInchirieri.GetInchirieriAparateFoto();

            // Join pentru a obține detaliile complete ale fiecărei închirieri
            var detalii = from i in inchirieri
                          join c in clienti on i.ID_Client equals c.ID_Client
                          join a in aparateFoto on i.ID_Aparat equals a.ID_Aparat
                          select new
                          {
                              i.ID_Inchiriere,
                              c.ID_Client,
                              a.ID_Aparat,
                              Nume_Client = c.Nume_Client + " " + c.Prenume_Client,
                              Model_Aparat = a.Nume_Model,
                              i.Data_Inceput,
                              i.Data_Sfarsit
                          };

            return detalii.ToList<dynamic>(); // Returnare listă de detalii
        }

        // Funcție pentru obținerea detaliilor unei închirieri după ID
        public dynamic GetDetaliiInchiriereById(int idInchiriere)
        {
            // Obținere listă de închirieri, clienți și aparate foto din stocare
            var inchirieri = stocareInchirieri.GetInchirieriAparateFoto();
            var clienti = stocareClienti.GetClienti();
            var aparateFoto = stocareAparateFoto.GetAparateFoto();

            // Join și filtrare pentru a obține detalii complete ale închirierii cu ID specificat
            var detalii = from i in inchirieri
                          join c in clienti on i.ID_Client equals c.ID_Client
                          join a in aparateFoto on i.ID_Aparat equals a.ID_Aparat
                          where i.ID_Inchiriere == idInchiriere
                          select new
                          {
                              i.ID_Inchiriere,
                              c.ID_Client,
                              a.ID_Aparat,
                              Nume_Client = c.Nume_Client + " " + c.Prenume_Client,
                              Model_Aparat = a.Nume_Model,
                              i.Data_Inceput,
                              i.Data_Sfarsit
                          };

            return detalii.FirstOrDefault(); // Returnare detalii prima închiriere găsită după ID
        }
    }
}