using InterfataUtilizator;

using LibrarieModele;

using NivelAccesDate;

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DotNetOracle
{
    public partial class FormaTerenSportiv : Form
    {
        private const bool SUCCES = true;
        private const int PRIMA_COLOANA = 0;
        // Inițializarea stocării terenurilor sportive folosind Factory și Interfața specifică
        IStocareTerenuriSportive stocareTerenuri = (IStocareTerenuriSportive)new StocareFactory().GetTipStocare(typeof(TerenSportiv));

        public FormaTerenSportiv()
        {
            InitializeComponent();
            // Verificare dacă stocarea terenurilor sportive a fost inițializată corect
            if (stocareTerenuri == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
            // Încărcare inițială a terenurilor sportive în datagridview
            IncarcaTerenuriDeSport();
            // Ascunderea coloanei "Id_Teren" din datagridview (pentru a nu fi vizibilă utilizatorului)
            dataGridTerenSportiv.Columns["Id_Teren"].Visible = false;
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            // Salvare modificări în baza de date (ipotetic)
            SqlDBHelper.Commit();
            // Deschiderea formularului pentru afișarea listei de terenuri sportive
            FormaAfisare f = new FormaAfisare();
            f.Show();
            // Ascunderea formularului curent
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // Închiderea aplicației
            Application.Exit();
        }

        private bool ValidareDateTeren(string denumire, string tipsport, string suprafata)
        {
            // Validarea numelui terenului sportiv (să conțină doar litere)
            if (!Regex.IsMatch(denumire, @"^[A-Za-z]+$"))
            {
                MessageBox.Show("Denumirea trebuie să conțină doar litere.");
                return false;
            }

            // Validarea tipului de sport (să conțină doar litere)
            if (!Regex.IsMatch(tipsport, @"^[A-Za-z]+$"))
            {
                MessageBox.Show("Tipul sportului trebuie să conțină doar litere.");
                return false;
            }

            // Validarea suprafeței (să fie un număr întreg)
            int suprafataInt;
            if (!int.TryParse(suprafata, out suprafataInt))
            {
                MessageBox.Show("Suprafața trebuie să fie exprimată ca număr întreg.");
                return false;
            }

            // Toate verificările au trecut
            return true;
        }

        private void btnAdaugareTerenSportiv_Click(object sender, EventArgs e)
        {
            try
            {
                // Validare preînregistrare înainte de adăugare
                if (!ValidareDateTeren(txtDenumire.Text, txtTipSport.Text, txtSuprafata.Text))
                {
                    return;
                }
                // Obținerea următorului id disponibil pentru terenul sportiv
                int idTerenSport = stocareTerenuri.GetNextIdTerenSportiv();
                // Adăugarea unui nou teren sportiv în baza de date
                var rezultat = stocareTerenuri.AddTerenSportiv(new TerenSportiv(
                    idTerenSport,
                    txtDenumire.Text,
                    int.Parse(txtSuprafata.Text),
                    txtTipSport.Text,
                    txtAdresa.Text
                ));
                // Verificarea rezultatului operației de adăugare
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Teren de Sport adaugat");
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare Teren de Sport");
                }
            }
            catch (Exception ex)
            {
                // Gestionarea excepțiilor în timpul adăugării terenului sportiv
                MessageBox.Show("Exceptie" + ex.Message);
            }
            // Reîncărcarea listei de terenuri sportive în datagridview
            IncarcaTerenuriDeSport();
        }

        private void btnModificaTerenSportiv_Click(object sender, EventArgs e)
        {
            if (dataGridTerenSportiv.SelectedRows.Count > 0)
            {
                try
                {
                    // Obținerea id-ului terenului sportiv selectat pentru modificare
                    int idTerenSportiv = Convert.ToInt32(dataGridTerenSportiv.SelectedRows[0].Cells["id_teren"].Value);
                    string denumire = txtDenumire.Text;
                    int suprafata = int.Parse(txtSuprafata.Text);
                    string tipSport = txtTipSport.Text;
                    string adresa = txtAdresa.Text;

                    // Crearea unui obiect TerenSportiv cu datele actualizate
                    TerenSportiv terenSportiv = new TerenSportiv
                    {
                        Id_Teren = idTerenSportiv,
                        Denumire = denumire,
                        Suprafata = suprafata,
                        Tip_Sport = tipSport,
                        Adresa = adresa
                    };

                    // Actualizarea terenului sportiv în baza de date
                    bool rezultat = stocareTerenuri.UpdateTerenSportiv(terenSportiv);

                    // Verificarea rezultatului operației de actualizare
                    if (rezultat)
                    {
                        MessageBox.Show("Teren de Sport actualizat cu succes!");
                        // Reîncărcarea listei de terenuri sportive în datagridview
                        IncarcaTerenuriDeSport();
                    }
                    else
                    {
                        MessageBox.Show("Eroare la actualizarea Teren de Sport.");
                    }
                }
                catch (Exception ex)
                {
                    // Gestionarea excepțiilor în timpul actualizării terenului sportiv
                    MessageBox.Show("Exceptie: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selectați un Teren de Sport pentru a-l modifica.");
            }
        }

        private void btnStergereTerenSportiv_Click(object sender, EventArgs e)
        {
            if (dataGridTerenSportiv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridTerenSportiv.SelectedRows)
                {
                    // Obținerea id-ului terenului sportiv selectat pentru ștergere
                    int idTerenSportiv = Convert.ToInt32(row.Cells["id_teren"].Value);
                    string denumire = row.Cells["denumire"].Value.ToString();
                    MessageBox.Show($"Terenul de Sport selectat: {denumire}");

                    try
                    {
                        // Ștergerea terenului sportiv din baza de date
                        if (stocareTerenuri.DeleteTerenSportiv(idTerenSportiv))
                        {
                            MessageBox.Show($"Terenul de Sport {denumire} a fost șters cu succes.");
                            // Reîncărcarea listei de terenuri sportive în datagridview
                            IncarcaTerenuriDeSport();
                        }
                        else
                        {
                            MessageBox.Show("Eroare la ștergerea terenului.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Gestionarea excepțiilor în timpul ștergerii terenului sportiv
                        MessageBox.Show($"Eroare: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați un Teren de Sport pentru a-l șterge.");
            }
        }

        private void IncarcaTerenuriDeSport()
        {
            // Încărcarea terenurilor sportive din baza de date în datagridview
            var administrareTerenuriSportive = new AdministrareTerenuriSportive();
            var listaTerenuriSportive = administrareTerenuriSportive.GetTerenuriSportive();
            dataGridTerenSportiv.DataSource = listaTerenuriSportive;
        }

        private void dataGridTerenSportiv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manipularea evenimentului de click pe celule în datagridview
            if (e.RowIndex >= 0)
            {
                int currentRowIndex = e.RowIndex;
                // Obținerea id-ului terenului sportiv din celula selectată
                int idTerenSportiv = Convert.ToInt32(dataGridTerenSportiv[PRIMA_COLOANA, currentRowIndex].Value);

                try
                {
                    // Obținerea detaliilor terenului sportiv selectat și afișarea acestora în controalele formularului
                    var detalii = GetDetaliiTerenSportiv(idTerenSportiv);

                    if (detalii != null)
                    {
                        txtDenumire.Text = detalii.Denumire;
                        txtSuprafata.Text = detalii.Suprafata.ToString();
                        txtTipSport.Text = detalii.Tip_Sport;
                        txtAdresa.Text = detalii.Adresa;
                    }
                }
                catch (Exception ex)
                {
                    // Gestionarea excepțiilor în timpul obținerii detaliilor terenului sportiv
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void dataGridTerenSportiv_SelectionChanged(object sender, EventArgs e)
        {
            // Manipularea evenimentului de schimbare a selecției în datagridview
            if (dataGridTerenSportiv.SelectedRows.Count > 0)
            {
                int idTerenSportiv = Convert.ToInt32(dataGridTerenSportiv.SelectedRows[0].Cells["id_teren"].Value);

                try
                {
                    // Obținerea detaliilor terenului sportiv selectat și afișarea acestora în controalele formularului
                    var detalii = GetDetaliiTerenSportiv(idTerenSportiv);

                    if (detalii != null)
                    {
                        txtDenumire.Text = detalii.Denumire;
                        txtSuprafata.Text = detalii.Suprafata.ToString();
                        txtTipSport.Text = detalii.Tip_Sport;
                        txtAdresa.Text = detalii.Adresa;
                    }
                }
                catch (Exception ex)
                {
                    // Gestionarea excepțiilor în timpul obținerii detaliilor terenului sportiv
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public dynamic GetDetaliiTerenSportiv(int idTerenSportiv)
        {
            // Obținerea detaliilor unui teren sportiv specificat prin id
            var terenSportiv = stocareTerenuri.GetTerenuriSportive();
            var detalii = from t in terenSportiv
                          where t.Id_Teren == idTerenSportiv
                          select new
                          {
                              t.Id_Teren,
                              t.Denumire,
                              t.Suprafata,
                              t.Tip_Sport,
                              t.Adresa
                          };
            return detalii.FirstOrDefault();
        }
    }
}
