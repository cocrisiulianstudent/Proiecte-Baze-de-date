using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using LibrarieModele;

using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareUtilizatori : IStocareUtilizatori
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Utilizator> GetUtilizatori()
        {
            var result = new List<Utilizator>();
            var dsUtilizatori = SqlDBHelper.ExecuteDataSet("select * from Utilizatori", CommandType.Text);

            foreach (DataRow linieDB in dsUtilizatori.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Utilizator
                {
                    Id_Utilizator = Convert.ToInt32(linieDB["id_utilizator"]),
                    Nume = linieDB["nume"].ToString(),
                    Prenume = linieDB["prenume"].ToString(),
                    Email = linieDB["email"].ToString(),
                    Telefon = linieDB["telefon"].ToString()
                });
            }
            return result;
        }

        public Utilizator GetUtilizator(int id)
        {
            Utilizator result = null;
            var dsUtilizator = SqlDBHelper.ExecuteDataSet("select * from Utilizatori where id_utilizator = :id_utilizator", CommandType.Text,
                new OracleParameter(":id_utilizator", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsUtilizator.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsUtilizator.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Utilizator
                {
                    Id_Utilizator = Convert.ToInt32(linieDB["id_utilizator"]),
                    Nume = linieDB["nume"].ToString(),
                    Prenume = linieDB["prenume"].ToString(),
                    Email = linieDB["email"].ToString(),
                    Telefon = linieDB["telefon"].ToString()
                };
            }
            return result;
        }

        public bool AddUtilizator(Utilizator utilizator)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO Utilizatori (id_utilizator, nume, prenume, email, telefon) VALUES (seq_Utilizatori.nextval, :Nume, :Prenume, :Email, :Telefon)", CommandType.Text,
                new OracleParameter(":Nume", OracleDbType.Varchar2, utilizator.Nume, ParameterDirection.Input),
                new OracleParameter(":Prenume", OracleDbType.Varchar2, utilizator.Prenume, ParameterDirection.Input),
                new OracleParameter(":Email", OracleDbType.Varchar2, utilizator.Email, ParameterDirection.Input),
                new OracleParameter(":Telefon", OracleDbType.Varchar2, utilizator.Telefon, ParameterDirection.Input));
        }

        public bool UpdateUtilizator(Utilizator utilizator)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Utilizatori SET nume = :Nume, prenume = :Prenume, email = :Email, telefon = :Telefon WHERE id_utilizator = :IdUtilizator", CommandType.Text,
                new OracleParameter(":Nume", OracleDbType.Varchar2, utilizator.Nume, ParameterDirection.Input),
                new OracleParameter(":Prenume", OracleDbType.Varchar2, utilizator.Prenume, ParameterDirection.Input),
                new OracleParameter(":Email", OracleDbType.Varchar2, utilizator.Email, ParameterDirection.Input),
                new OracleParameter(":Telefon", OracleDbType.Varchar2, utilizator.Telefon, ParameterDirection.Input),
                new OracleParameter(":IdUtilizator", OracleDbType.Int32, utilizator.Id_Utilizator, ParameterDirection.Input));
        }

        public bool DeleteUtilizator(int id)
        {
            using (OracleConnection conn = new OracleConnection(SqlDBHelper.ConnectionString))
            {
                conn.Open();
                OracleTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (OracleCommand cmdUtilizator = new OracleCommand("DELETE FROM Utilizatori WHERE id_utilizator = :id_utilizator", conn))
                    {
                        cmdUtilizator.CommandType = CommandType.Text;
                        cmdUtilizator.Parameters.Add(new OracleParameter(":id_utilizator", OracleDbType.Int32, id, ParameterDirection.Input));
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

        public int GetNextIdUtilizator()
        {
            return SqlDBHelper.GetNextIdUtilizator();
        }
    }
}
