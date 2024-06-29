using System;
using System.Collections.Generic;
using System.Data;

using LibrarieModele;

using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareInchirieriAparateFoto : IStocareInchirieriAparateFoto
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<InchirieriAparateFoto> GetInchirieriAparateFoto()
        {
            var result = new List<InchirieriAparateFoto>();
            var dsInchirieri = SqlDBHelper.ExecuteDataSet("SELECT * FROM InchirieriAparateFoto", CommandType.Text);

            foreach (DataRow linieBD in dsInchirieri.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new InchirieriAparateFoto(linieBD));
            }
            return result;
        }

        public InchirieriAparateFoto GetInchiriereAparatFoto(int id)
        {
            InchirieriAparateFoto result = null;
            var dsInchiriere = SqlDBHelper.ExecuteDataSet("SELECT * FROM InchirieriAparateFoto WHERE ID_Inchiriere = :ID_Inchiriere", CommandType.Text,
                new OracleParameter(":ID_Inchiriere", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsInchiriere.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsInchiriere.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new InchirieriAparateFoto(linieBD);
            }
            return result;
        }

        public bool AddInchiriereAparatFoto(InchirieriAparateFoto i)
        {
            try
            {
                return SqlDBHelper.ExecuteNonQuery(
                    "INSERT INTO InchirieriAparateFoto (ID_Inchiriere, ID_Client, ID_Aparat, Data_Inceput, Data_Sfarsit) VALUES (seq_InchirieriAparateFoto.nextval, :ID_Client, :ID_Aparat, :Data_Inceput, :Data_Sfarsit)", CommandType.Text,
                    new OracleParameter(":ID_Client", OracleDbType.Int32, i.ID_Client, ParameterDirection.Input),
                    new OracleParameter(":ID_Aparat", OracleDbType.Int32, i.ID_Aparat, ParameterDirection.Input),
                    new OracleParameter(":Data_Inceput", OracleDbType.Date, i.Data_Inceput, ParameterDirection.Input),
                    new OracleParameter(":Data_Sfarsit", OracleDbType.Date, i.Data_Sfarsit, ParameterDirection.Input)
                );
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"OracleException: {ex.Message}");
                throw;
            }
        }

        public bool UpdateInchiriereAparatFoto(InchirieriAparateFoto i)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE InchirieriAparateFoto SET ID_Client = :ID_Client, ID_Aparat = :ID_Aparat, Data_Inceput = :Data_Inceput, Data_Sfarsit = :Data_Sfarsit WHERE ID_Inchiriere = :ID_Inchiriere", CommandType.Text,
                new OracleParameter(":ID_Client", OracleDbType.Int32, i.ID_Client, ParameterDirection.Input),
                new OracleParameter(":ID_Aparat", OracleDbType.Int32, i.ID_Aparat, ParameterDirection.Input),
                new OracleParameter(":Data_Inceput", OracleDbType.Date, i.Data_Inceput, ParameterDirection.Input),
                new OracleParameter(":Data_Sfarsit", OracleDbType.Date, i.Data_Sfarsit, ParameterDirection.Input),
                new OracleParameter(":ID_Inchiriere", OracleDbType.Int32, i.ID_Inchiriere, ParameterDirection.Input)
            );
        }

        public bool DeleteInchiriereAparatFoto(int id)
        {
            using (OracleConnection conn = new OracleConnection(SqlDBHelper.ConnectionString))
            {
                conn.Open();
                OracleTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (OracleCommand cmd = new OracleCommand("DELETE FROM InchirieriAparateFoto WHERE ID_Inchiriere = :ID_Inchiriere", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new OracleParameter(":ID_Inchiriere", OracleDbType.Int32, id, ParameterDirection.Input));
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public int GetNextIdInchirieriAparateFoto()
        {
            return SqlDBHelper.GetNextIdClient();
        }
    }
}
