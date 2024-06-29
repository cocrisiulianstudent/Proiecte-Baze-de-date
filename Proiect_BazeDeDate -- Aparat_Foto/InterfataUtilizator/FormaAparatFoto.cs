using InterfataUtilizator;

using LibrarieModele;

using NivelAccesDate;

using System;
using System.Linq;
using System.Windows.Forms;

namespace DotNetOracle
{
    public partial class FormaAparatFoto : Form
    {
        private const bool SUCCES = true;
        private const int PRIMA_COLOANA = 0;

        // Inițializarea stocării pentru aparat foto utilizând Factory și Interfețe specifice
        IStocareAparatFoto stocareAparatFoto = (IStocareAparatFoto)new StocareFactory().GetTipStocare(typeof(AparateFoto));

        public FormaAparatFoto()
        {
            InitializeComponent();

            // Adaugă eveniment pentru click pe celule în datagridview
            dataGridAparatFoto.CellClick += DataGridAparatFoto_CellClick;

            // Verificare dacă stocarea pentru aparat foto a fost inițializată corect
            if (stocareAparatFoto == null)
            {
                MessageBox.Show("Eroare la initializare");
            }

            // Încarcă lista de aparate foto la inițializarea formularului
            IncarcaAparateFoto();
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

        private void Exit_Click(object sender, EventArgs e)
        {
            // Închide aplicația la apăsarea butonului Exit
            Application.Exit();
        }

        private void curataTextBoxuri()
        {
            // Curăță textele din TextBox-urile formularului
            txtNumeModel.Text = "";
            txtDescriere.Text = "";
            txtTarifZi.Text = "";
            checkBoxDisponibilitate.Checked = false;
        }
        private void btnAdaugareAparatFoto_Click(object sender, EventArgs e)
        {
            try
            {
                // Obține ID-ul următor pentru aparatul foto
                int idAparatFoto = stocareAparatFoto.GetNextIdAparatFoto();
                // Verifică dacă aparatul foto este disponibil
                bool disponibilitate = checkBoxDisponibilitate.Checked;

                // Adaugă un nou aparat foto folosind datele introduse în formular
                var rezultat = stocareAparatFoto.AddAparatFoto(new AparateFoto(
                    idAparatFoto,
                    txtNumeModel.Text,
                    txtDescriere.Text,
                    disponibilitate,
                    float.Parse(txtTarifZi.Text)
                ));

                // Verifică rezultatul adăugării și afișează mesaje corespunzătoare
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Aparat foto adăugat cu succes");
                    curataTextBoxuri();
                }
                else
                {
                    MessageBox.Show("Eroare la adăugarea aparatului foto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepție: " + ex.Message);
            }

            // Reîncarcă lista de aparate foto după operația de adăugare
            IncarcaAparateFoto();
        }


        private void btnModificaAparatFoto_Click(object sender, EventArgs e)
        {
            // Verifică dacă a fost selectat un rând în datagridview pentru modificare
            if (dataGridAparatFoto.SelectedRows.Count > 0)
            {
                try
                {
                    // Obține ID-ul aparatului foto selectat pentru modificare
                    int idAparatFoto = Convert.ToInt32(dataGridAparatFoto.SelectedRows[0].Cells["ID_Aparat"].Value);
                    string numeModel = txtNumeModel.Text;
                    string descriere = txtDescriere.Text;
                    bool disponibilitate = checkBoxDisponibilitate.Checked;
                    float tarifZi = float.Parse(txtTarifZi.Text);

                    // Crează un obiect AparateFoto cu datele actualizate
                    AparateFoto aparatFoto = new AparateFoto
                    {
                        ID_Aparat = idAparatFoto,
                        Nume_Model = numeModel,
                        Descriere = descriere,
                        Disponibilitate = disponibilitate,
                        Tarif_Zi = tarifZi
                    };

                    // Actualizează aparatul foto în baza de date
                    bool rezultat = stocareAparatFoto.UpdateAparatFoto(aparatFoto);

                    // Verifică rezultatul actualizării și afișează mesaje corespunzătoare
                    if (rezultat)
                    {
                        MessageBox.Show("Aparat foto actualizat cu succes!");
                        curataTextBoxuri();
                    }
                    else
                    {
                        MessageBox.Show("Eroare la actualizarea aparatului foto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepție: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selectați un aparat foto pentru a-l modifica.");
            }

            // Reîncarcă lista de aparate foto după operația de modificare
            IncarcaAparateFoto();
        }


        private void btnStergereAparatFoto_Click(object sender, EventArgs e)
        {
            // Verifică dacă au fost selectate rânduri pentru ștergere în datagridview
            if (dataGridAparatFoto.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridAparatFoto.SelectedRows)
                {
                    // Obține ID-ul aparatului foto pentru ștergere
                    int idAparatFoto = Convert.ToInt32(row.Cells["ID_Aparat"].Value);
                    string numeModel = row.Cells["Nume_Model"].Value.ToString();

                    try
                    {
                        // Șterge aparatul foto din baza de date
                        if (stocareAparatFoto.DeleteAparatFoto(idAparatFoto))
                        {
                            MessageBox.Show($"Aparatul foto {numeModel} a fost șters cu succes.");
                            curataTextBoxuri();
                        }
                        else
                        {
                            MessageBox.Show("Eroare la ștergerea aparatului foto.");
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
                MessageBox.Show("Selectați un aparat foto pentru a-l șterge.");
            }

            // Reîncarcă lista de aparate foto după operația de ștergere
            IncarcaAparateFoto();
        }

        private void IncarcaAparateFoto()
        {
            // Obține lista completă de aparate foto și le afișează în datagridview
            var administrareAparateFoto = new AdministrareAparateFoto();
            var listaAparateFoto = administrareAparateFoto.GetAparateFoto();
            dataGridAparatFoto.DataSource = listaAparateFoto;

            // Ascunde coloana ID_Aparat pentru a nu fi vizibilă utilizatorului
            dataGridAparatFoto.Columns["ID_Aparat"].Visible = false;
        }

        private void DataGridAparatFoto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obține indexul rândului curent selectat în datagridview
                int currentRowIndex = e.RowIndex;
                // Obține ID-ul aparatului foto din rândul selectat
                int idAparatFoto = Convert.ToInt32(dataGridAparatFoto[PRIMA_COLOANA, currentRowIndex].Value);

                try
                {
                    // Obține detaliile aparatului foto și le afișează în formular
                    var detalii = GetDetaliiAparatFoto(idAparatFoto);

                    if (detalii != null)
                    {
                        txtNumeModel.Text = detalii.Nume_Model;
                        txtDescriere.Text = detalii.Descriere;
                        checkBoxDisponibilitate.Checked = detalii.Disponibilitate;
                        txtTarifZi.Text = detalii.Tarif_Zi.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }


        private void dataGridAparatFoto_SelectionChanged(object sender, EventArgs e)
        {
            // Verifică dacă s-a schimbat selecția în datagridview pentru a actualiza detaliile în formular
            if (dataGridAparatFoto.SelectedRows.Count > 0)
            {
                // Obține ID-ul aparatului foto selectat
                int idAparatFoto = Convert.ToInt32(dataGridAparatFoto.SelectedRows[0].Cells["ID_Aparat"].Value);

                try
                {
                    // Obține detaliile aparatului foto și le afișează în formular
                    var detalii = GetDetaliiAparatFoto(idAparatFoto);

                    if (detalii != null)
                    {
                        txtNumeModel.Text = detalii.Nume_Model;
                        txtDescriere.Text = detalii.Descriere;
                        checkBoxDisponibilitate.Checked = detalii.Disponibilitate;
                        txtTarifZi.Text = detalii.Tarif_Zi.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public dynamic GetDetaliiAparatFoto(int idAparatFoto)
        {
            // Obține detaliile aparatului foto pe baza ID-ului specificat
            var aparateFoto = stocareAparatFoto.GetAparateFoto();
            var detalii = from t in aparateFoto
                          where t.ID_Aparat == idAparatFoto
                          select new
                          {
                              t.ID_Aparat,
                              t.Nume_Model,
                              t.Descriere,
                              t.Disponibilitate,
                              t.Tarif_Zi
                          };
            return detalii.FirstOrDefault();
        }
    }
}