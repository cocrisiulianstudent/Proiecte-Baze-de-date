using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareClienti : IStocareClienti
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Clienti> GetClienti()
        {
            var result = new List<Clienti>();
            var dsClienti = SqlDBHelper.ExecuteDataSet("SELECT * FROM Clienti", CommandType.Text);

            foreach (DataRow linieDB in dsClienti.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Clienti(linieDB));
            }
            return result;
        }

        public Clienti GetClient(int id)
        {
            Clienti result = null;
            var dsClienti = SqlDBHelper.ExecuteDataSet("SELECT * FROM Clienti WHERE ID_Client = :ID_Client", CommandType.Text,
                new OracleParameter(":ID_Client", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsClienti.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsClienti.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Clienti(linieDB);
            }
            return result;
        }

        public bool AddClient(Clienti c)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO Clienti (ID_Client, Nume_Client, Prenume_Client, Telefon, Email) VALUES (:ID_Client, :Nume_Client, :Prenume_Client, :Telefon, :Email)", CommandType.Text,
                new OracleParameter(":ID_Client", OracleDbType.Int32, c.ID_Client, ParameterDirection.Input),
                new OracleParameter(":Nume_Client", OracleDbType.Varchar2, c.Nume_Client, ParameterDirection.Input),
                new OracleParameter(":Prenume_Client", OracleDbType.Varchar2, c.Prenume_Client, ParameterDirection.Input),
                new OracleParameter(":Telefon", OracleDbType.Int64, c.Telefon, ParameterDirection.Input),
                new OracleParameter(":Email", OracleDbType.Varchar2, c.Email, ParameterDirection.Input));
        }

        public bool UpdateClient(Clienti c)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Clienti SET Nume_Client = :Nume_Client, Prenume_Client = :Prenume_Client, Telefon = :Telefon, Email = :Email WHERE ID_Client = :ID_Client", CommandType.Text,
                new OracleParameter(":Nume_Client", OracleDbType.Varchar2, c.Nume_Client, ParameterDirection.Input),
                new OracleParameter(":Prenume_Client", OracleDbType.Varchar2, c.Prenume_Client, ParameterDirection.Input),
                new OracleParameter(":Telefon", OracleDbType.Int64, c.Telefon, ParameterDirection.Input),
                new OracleParameter(":Email", OracleDbType.Varchar2, c.Email, ParameterDirection.Input),
                new OracleParameter(":ID_Client", OracleDbType.Int32, c.ID_Client, ParameterDirection.Input));
        }

        public bool DeleteClient(int id)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM Clienti WHERE ID_Client = :ID_Client", CommandType.Text,
                new OracleParameter(":ID_Client", OracleDbType.Int32, id, ParameterDirection.Input)
            );
        }

        public int GetNextIdClient()
        {
            return SqlDBHelper.GetNextIdClient();
        }
    }
}
