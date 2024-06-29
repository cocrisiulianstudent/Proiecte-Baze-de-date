using InterfataUtilizator;

using LibrarieModele;

using NivelAccesDate;

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DotNetOracle
{
    public partial class FormaUtilizator : Form
    {
        private const bool SUCCES = true;
        private const int PRIMA_COLOANA = 0;

        // Inițializarea stocării utilizatorilor folosind Factory și Interfața specifică
        IStocareUtilizatori stocareUtilizator = (IStocareUtilizatori)new StocareFactory().GetTipStocare(typeof(Utilizator));

        public FormaUtilizator()
        {
            InitializeComponent();

            // Verificare dacă stocarea utilizatorilor a fost inițializată corect
            if (stocareUtilizator == null)
            {
                MessageBox.Show("Eroare la initializare");
            }

            // Încărcarea inițială a utilizatorilor în datagridview
            IncarcaUtilizatori();

            // Ascunderea coloanei "Id_Utilizator" din datagridview (pentru a nu fi vizibilă utilizatorului)
            dataGridUtilizator.Columns["Id_Utilizator"].Visible = false;
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            // Salvarea modificărilor în baza de date (ipotetic)
            SqlDBHelper.Commit();

            // Deschiderea formularului pentru afișarea listei de utilizatori
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

        private bool ValidareDateUtilizator(string nume, string prenume, string email, string telefon)
        {
            // Verificare ca numele să conțină doar litere
            if (!Regex.IsMatch(nume, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Numele poate conține doar litere.");
                return false;
            }

            // Verificare ca prenumele să conțină doar litere
            if (!Regex.IsMatch(prenume, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Prenumele poate conține doar litere.");
                return false;
            }

            // Verificare ca numărul de telefon să fie format din exact 10 cifre
            if (!Regex.IsMatch(telefon, @"^\d{10}$"))
            {
                MessageBox.Show("Numărul de telefon trebuie să conțină exact 10 cifre.");
                return false;
            }

            // Verificare existență caracter '@' în adresa de email
            if (!email.Contains("@"))
            {
                MessageBox.Show("Adresa de email trebuie să conțină caracterul '@'.");
                return false;
            }

            // Toate validările sunt trecute cu succes
            return true;
        }

        private void btnAdaugareUtilizator_Click(object sender, EventArgs e)
        {
            try
            {
                // Validare date utilizator înainte de adăugare
                if (!ValidareDateUtilizator(txtNume.Text, txtPrenume.Text, txtEmail.Text, txtTelefon.Text))
                {
                    return; // Ieșire din funcție dacă datele nu sunt valide
                }

                // Obținerea următorului ID disponibil pentru utilizator
                int idUtilizator = stocareUtilizator.GetNextIdUtilizator();

                // Adăugarea unui nou utilizator în baza de date
                var rezultat = stocareUtilizator.AddUtilizator(new Utilizator(
                    idUtilizator,
                    txtNume.Text,
                    txtPrenume.Text,
                    txtEmail.Text,
                    txtTelefon.Text
                ));

                // Verificare rezultat operație de adăugare
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Utilizator adăugat cu succes!");
                }
                else
                {
                    MessageBox.Show("Eroare la adăugarea utilizatorului.");
                }
            }
            catch (Exception ex)
            {
                // Gestionare excepții în timpul adăugării utilizatorului
                MessageBox.Show("Excepție: " + ex.Message);
            }

            // Reîncărcarea listei de utilizatori în datagridview
            IncarcaUtilizatori();
        }

        private void btnModificaUtilizator_Click(object sender, EventArgs e)
        {
            if (dataGridUtilizator.SelectedRows.Count > 0)
            {
                try
                {
                    // Validare date utilizator înainte de modificare
                    if (!ValidareDateUtilizator(txtNume.Text, txtPrenume.Text, txtEmail.Text, txtTelefon.Text))
                    {
                        return; // Ieșire din funcție dacă datele nu sunt valide
                    }

                    // Obținerea ID-ului utilizatorului selectat pentru modificare
                    int id_utilizator = Convert.ToInt32(dataGridUtilizator.SelectedRows[0].Cells["id_utilizator"].Value);

                    // Obținerea datelor actualizate ale utilizatorului
                    string nume = txtNume.Text;
                    string prenume = txtPrenume.Text;
                    string email = txtEmail.Text;
                    string telefon = txtTelefon.Text;

                    // Crearea unui obiect Utilizator cu datele actualizate
                    Utilizator utilizator = new Utilizator
                    {
                        Id_Utilizator = id_utilizator,
                        Nume = nume,
                        Prenume = prenume,
                        Email = email,
                        Telefon = telefon
                    };

                    // Actualizarea utilizatorului în baza de date
                    bool rezultat = stocareUtilizator.UpdateUtilizator(utilizator);

                    // Verificare rezultat operație de actualizare
                    if (rezultat)
                    {
                        MessageBox.Show("Utilizator actualizat cu succes!");
                    }
                    else
                    {
                        MessageBox.Show("Eroare la actualizarea utilizatorului.");
                    }
                }
                catch (Exception ex)
                {
                    // Gestionare excepții în timpul actualizării utilizatorului
                    MessageBox.Show("Excepție: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selectați un utilizator pentru a-l modifica.");
            }

            // Reîncărcarea listei de utilizatori în datagridview
            IncarcaUtilizatori();
        }

        private void btnStergereUtilizator_Click(object sender, EventArgs e)
        {
            if (dataGridUtilizator.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridUtilizator.SelectedRows)
                {
                    // Obținerea ID-ului utilizatorului selectat pentru ștergere
                    int id_utilizator = Convert.ToInt32(row.Cells["id_utilizator"].Value);

                    // Obținerea numelui complet al utilizatorului pentru afișare în mesaj
                    string numeComplet = row.Cells["nume"].Value.ToString() + " " + row.Cells["prenume"].Value.ToString();
                    MessageBox.Show($"Utilizator selectat: {numeComplet}");

                    try
                    {
                        // Ștergerea utilizatorului din baza de date
                        if (stocareUtilizator.DeleteUtilizator(id_utilizator))
                        {
                            MessageBox.Show($"Utilizatorul {numeComplet} a fost șters cu succes.");
                        }
                        else
                        {
                            MessageBox.Show("Eroare la ștergerea utilizatorului.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Gestionare excepții în timpul ștergerii utilizatorului
                        MessageBox.Show($"Excepție: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați un utilizator pentru a-l șterge.");
            }

            // Reîncărcarea listei de utilizatori în datagridview
            IncarcaUtilizatori();
        }

        private void IncarcaUtilizatori()
        {
            // Încărcarea utilizatorilor din baza de date în datagridview
            var administrareUtilizatori = new AdministrareUtilizatori();
            var listaUtilizatori = administrareUtilizatori.GetUtilizatori();
            dataGridUtilizator.DataSource = listaUtilizatori;
        }

        private void dataGridUtilizator_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manipularea evenimentului de click pe o celulă din datagridview
            if (e.RowIndex >= 0)
            {
                int currentRowIndex = e.RowIndex;
                int id_utilizator = Convert.ToInt32(dataGridUtilizator[PRIMA_COLOANA, currentRowIndex].Value);

                try
                {
                    // Obținerea detaliilor utilizatorului selectat și afișarea acestora în controalele formularului
                    var detalii = GetDetaliiUtilizatorById(id_utilizator);

                    if (detalii != null)
                    {
                        txtNume.Text = detalii.Nume;
                        txtPrenume.Text = detalii.Prenume;
                        txtEmail.Text = detalii.Email;
                        txtTelefon.Text = detalii.Telefon;
                    }
                }
                catch (Exception ex)
                {
                    // Gestionarea excepțiilor în timpul obținerii detaliilor utilizatorului
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void dataGridUtilizator_SelectionChanged(object sender, EventArgs e)
        {
            // Manipularea evenimentului de schimbare a selecției în datagridview
            if (dataGridUtilizator.SelectedRows.Count > 0)
            {
                int id_utilizator = Convert.ToInt32(dataGridUtilizator.SelectedRows[0].Cells["id_utilizator"].Value);

                try
                {
                    // Obținerea detaliilor utilizatorului selectat și afișarea acestora în controalele formularului
                    var detalii = GetDetaliiUtilizatorById(id_utilizator);

                    if (detalii != null)
                    {
                        txtNume.Text = detalii.Nume;
                        txtPrenume.Text = detalii.Prenume;
                        txtEmail.Text = detalii.Email;
                        txtTelefon.Text = detalii.Telefon;
                    }
                }
                catch (Exception ex)
                {
                    // Gestionarea excepțiilor în timpul obținerii detaliilor utilizatorului
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public dynamic GetDetaliiUtilizatorById(int id_utilizator)
        {
            // Obținerea detaliilor unui utilizator specificat prin id
            var utilizatori = stocareUtilizator.GetUtilizatori();
            var detalii = from u in utilizatori
                          where u.Id_Utilizator == id_utilizator
                          select new
                          {
                              u.Id_Utilizator,
                              u.Nume,
                              u.Prenume,
                              u.Email,
                              u.Telefon
                          };
            return detalii.FirstOrDefault();
        }
    }
}
