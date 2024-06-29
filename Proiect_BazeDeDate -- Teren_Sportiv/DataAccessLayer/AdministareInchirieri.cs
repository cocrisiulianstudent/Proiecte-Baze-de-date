using System;
using System.Collections.Generic;
using System.Data;

using LibrarieModele;


using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareInchirieri : IStocareInchirieri
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Inchiriere> GetInchirieri()
        {
            var result = new List<Inchiriere>();
            var dsInchirieri = SqlDBHelper.ExecuteDataSet("select * from Inchirieri", CommandType.Text);

            foreach (DataRow linieBD in dsInchirieri.Tables[PRIMUL_TABEL].Rows)
            {
                var inchiriere = new Inchiriere(linieBD);
                result.Add(inchiriere);
            }
            return result;
        }

        public Inchiriere GetInchiriere(int id)
        {
            Inchiriere result = null;
            var dsInchiriere = SqlDBHelper.ExecuteDataSet("select * from Inchirieri where Id_Inchiriere = :Id_Inchiriere", CommandType.Text,
                new OracleParameter(":Id_Inchiriere", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsInchiriere.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsInchiriere.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Inchiriere(linieBD);
            }
            return result;
        }

        public bool AddInchiriere(Inchiriere i)
        {
            try
            {
                return SqlDBHelper.ExecuteNonQuery(
                    "INSERT INTO Inchirieri (ID_INCHIRIERE, ID_TEREN, ID_UTILIZATOR, DATA_INCEPUT, DATA_SFARSIT, PRET) VALUES (seq_Inchirieri.nextval, :Id_Teren, :Id_Utilizator, :Data_Inceput, :Data_Sfarsit, :Pret)", CommandType.Text,
                    new OracleParameter(":Id_Teren", OracleDbType.Int32, i.Id_Teren, ParameterDirection.Input),
                    new OracleParameter(":Id_Utilizator", OracleDbType.Int32, i.Id_Utilizator, ParameterDirection.Input),
                    new OracleParameter(":Data_Inceput", OracleDbType.Date, i.Data_Inceput, ParameterDirection.Input),
                    new OracleParameter(":Data_Sfarsit", OracleDbType.Date, i.Data_Sfarsit, ParameterDirection.Input),
                    new OracleParameter(":Pret", OracleDbType.Decimal, i.Pret, ParameterDirection.Input)
                );
            }
            catch (OracleException ex)
            {
                // Log the error message and rethrow the exception
                Console.WriteLine($"OracleException: {ex.Message}");
                throw;
            }
        }

        public bool UpdateInchiriere(Inchiriere i)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Inchirieri SET Id_Teren = :Id_Teren, Id_Utilizator = :Id_Utilizator, Data_Inceput = :Data_Inceput, Data_Sfarsit = :Data_Sfarsit, Pret = :Pret WHERE Id_Inchiriere = :Id_Inchiriere", CommandType.Text,
                new OracleParameter(":Id_Teren", OracleDbType.Int32, i.Id_Teren, ParameterDirection.Input),
                new OracleParameter(":Id_Utilizator", OracleDbType.Int32, i.Id_Utilizator, ParameterDirection.Input),
                new OracleParameter(":Data_Inceput", OracleDbType.Date, i.Data_Inceput, ParameterDirection.Input),
                new OracleParameter(":Data_Sfarsit", OracleDbType.Date, i.Data_Sfarsit, ParameterDirection.Input),
                new OracleParameter(":Pret", OracleDbType.Decimal, i.Pret, ParameterDirection.Input),
                new OracleParameter(":Id_Inchiriere", OracleDbType.Int32, i.Id_Inchiriere, ParameterDirection.Input)
            );
        }

        public bool DeleteInchiriere(int id)
        {
            using (OracleConnection conn = new OracleConnection(SqlDBHelper.ConnectionString))
            {
                conn.Open();
                OracleTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (OracleCommand cmdUtilizator = new OracleCommand("DELETE FROM Inchirieri WHERE id_inchiriere = :id_inchiriere", conn))
                    {
                        cmdUtilizator.CommandType = CommandType.Text;
                        cmdUtilizator.Parameters.Add(new OracleParameter(":id_inchiriere", OracleDbType.Int32, id, ParameterDirection.Input));
                        cmdUtilizator.Transaction = transaction;
                        cmdUtilizator.ExecuteNonQuery();
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
        public int GetNextIdInchiriere()
        {
            return SqlDBHelper.GetNextIdInchirieri();
        }
    }
}
