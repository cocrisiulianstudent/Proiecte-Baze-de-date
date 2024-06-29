using InterfataUtilizator;

using LibrarieModele;

using NivelAccesDate;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetOracle
{
    public partial class FormaClienti : Form
    {
        // Inițializarea stocării pentru clienți utilizând Factory și Interfețe specifice
        IStocareClienti stocareClienti = (IStocareClienti)new StocareFactory().GetTipStocare(typeof(Clienti));

        public FormaClienti()
        {
            InitializeComponent();

            // Încarcă lista de clienți la inițializarea formularului
            IncarcaClienti();
            // Adaugă eveniment pentru click pe celule în datagridview
            dataGridClienti.CellClick += dataGridClienti_SelectionChanged;
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            // Salvare modificări în baza de date (exemplu: SqlDBHelper.Commit())
            SqlDBHelper.Commit();

            // Deschide formularul principal (înapoi la FormaAfisare) și ascunde formularul curent
            FormaAfisare f = new FormaAfisare();
            f.Show();
            this.Hide();
        }

        private void curataTextBoxuri()
        {
            // Curăță textele din TextBox-urile formularului
            txtNumeClient.Text = "";
            txtPrenumeClient.Text = "";
            txtTelefon.Text = "";
            txtEmail.Text = "";
        }

        private bool ValidareDateUtilizator(string nume, string prenume, string email, string telefon)
        {
            // Validare nume să conțină doar litere
            if (!Regex.IsMatch(nume, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Numele poate conține doar litere.");
                return false;
            }

            // Validare prenume să conțină doar litere
            if (!Regex.IsMatch(prenume, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Prenumele poate conține doar litere.");
                return false;
            }

            // Validare numărul de telefon să fie format din 10 cifre
            if (!Regex.IsMatch(telefon, @"^\d{10}$"))
            {
                MessageBox.Show("Numărul de telefon trebuie să conțină exact 10 cifre.");
                return false;
            }

            // Validare să existe caracterul '@' în adresa de email
            if (!email.Contains("@"))
            {
                MessageBox.Show("Adresa de email trebuie să conțină caracterul '@'.");
                return false;
            }

            // Toate validările sunt trecute cu succes
            return true;
        }

        private void btnAdaugareClient_Click(object sender, EventArgs e)
        {
            try
            {
                // Validare date utilizator folosind funcția definită
                if (!ValidareDateUtilizator(txtNumeClient.Text, txtPrenumeClient.Text, txtEmail.Text, txtTelefon.Text))
                {
                    return; // Ieșim din funcție dacă datele nu sunt valide
                }

                // Obține ID-ul următor pentru client
                int idClient = stocareClienti.GetNextIdClient();

                // Crează un obiect Clienti cu datele introduse în formular
                var client = new Clienti(
                    idClient,
                    txtNumeClient.Text,
                    txtPrenumeClient.Text,
                    int.Parse(txtTelefon.Text),
                    txtEmail.Text
                );

                // Adaugă clientul în baza de date
                var rezultat = stocareClienti.AddClient(client);

                // Verifică rezultatul adăugării și afișează mesaje corespunzătoare
                if (rezultat == true)
                {
                    MessageBox.Show("Client adăugat cu succes.");
                    curataTextBoxuri();
                }
                else
                {
                    MessageBox.Show("Eroare la adăugarea clientului.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepție: " + ex.Message);
            }

            // Reîncarcă lista de clienți după operația de adăugare
            IncarcaClienti();
        }

        private void btnModificaClient_Click(object sender, EventArgs e)
        {
            // Verifică dacă a fost selectat un client pentru modificare în datagridview
            if (dataGridClienti.SelectedRows.Count > 0)
            {
                try
                {
                    // Validare date utilizator folosind funcția definită
                    if (!ValidareDateUtilizator(txtNumeClient.Text, txtPrenumeClient.Text, txtEmail.Text, txtTelefon.Text))
                    {
                        return; // Ieșim din funcție dacă datele nu sunt valide
                    }

                    // Obține ID-ul clientului selectat pentru modificare
                    int idClient = Convert.ToInt32(dataGridClienti.SelectedRows[0].Cells["ID_Client"].Value);

                    // Crează un obiect Clienti cu datele actualizate
                    var clientModificat = new Clienti
                    {
                        ID_Client = idClient,
                        Nume_Client = txtNumeClient.Text,
                        Prenume_Client = txtPrenumeClient.Text,
                        Telefon = int.Parse(txtTelefon.Text),
                        Email = txtEmail.Text
                    };

                    // Actualizează clientul în baza de date
                    bool rezultat = stocareClienti.UpdateClient(clientModificat);

                    // Verifică rezultatul actualizării și afișează mesaje corespunzătoare
                    if (rezultat)
                    {
                        MessageBox.Show("Client modificat cu succes.");
                        curataTextBoxuri();
                    }
                    else
                    {
                        MessageBox.Show("Eroare la modificarea clientului.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepție: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selectați un client pentru a-l modifica.");
            }

            // Reîncarcă lista de clienți după operația de modificare
            IncarcaClienti();
        }

        private void btnStergereClient_Click(object sender, EventArgs e)
        {
            // Verifică dacă a fost selectat un client pentru ștergere în datagridview
            if (dataGridClienti.SelectedRows.Count > 0)
            {
                try
                {
                    // Obține ID-ul clientului pentru ștergere
                    int idClient = Convert.ToInt32(dataGridClienti.SelectedRows[0].Cells["ID_Client"].Value);

                    // Șterge clientul din baza de date
                    bool rezultat = stocareClienti.DeleteClient(idClient);

                    // Verifică rezultatul ștergerii și afișează mesaje corespunzătoare
                    if (rezultat)
                    {
                        MessageBox.Show("Client șters cu succes.");
                        curataTextBoxuri();
                    }
                    else
                    {
                        MessageBox.Show("Eroare la ștergerea clientului.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepție: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selectați un client pentru a-l șterge.");
            }

            // Reîncarcă lista de clienți după operația de ștergere
            IncarcaClienti();
        }

        private void IncarcaClienti()
        {
            try
            {
                // Obține lista de clienți și le afișează în datagridview
                var clienti = stocareClienti.GetClienti();
                if (clienti != null && clienti.Any())
                {
                    var lista = clienti.Select(c => new
                    {
                        c.ID_Client,
                        c.Nume_Client,
                        c.Prenume_Client,
                        c.Telefon,
                        c.Email
                    }).ToList();

                    dataGridClienti.DataSource = lista;
                    dataGridClienti.Columns["ID_Client"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridClienti_SelectionChanged(object sender, EventArgs e)
        {
            // Verifică dacă s-a schimbat selecția în datagridview pentru a actualiza detaliile în formular
            if (dataGridClienti.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridClienti.SelectedRows[0];
                txtNumeClient.Text = Convert.ToString(selectedRow.Cells["Nume_Client"].Value);
                txtPrenumeClient.Text = Convert.ToString(selectedRow.Cells["Prenume_Client"].Value);
                txtTelefon.Text = Convert.ToString(selectedRow.Cells["Telefon"].Value);
                txtEmail.Text = Convert.ToString(selectedRow.Cells["Email"].Value);
            }
        }
    }
}