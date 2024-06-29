using System;
using System.Collections.Generic;
using System.Data;

using LibrarieModele;

using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareAparateFoto : IStocareAparatFoto
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<AparateFoto> GetAparateFoto()
        {
            var result = new List<AparateFoto>();
            var dsAparateFoto = SqlDBHelper.ExecuteDataSet("SELECT * FROM AparateFoto", CommandType.Text);

            foreach (DataRow linieDB in dsAparateFoto.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new AparateFoto(linieDB));
            }
            return result;
        }

        public AparateFoto GetAparatFoto(int id)
        {
            AparateFoto result = null;
            var dsAparateFoto = SqlDBHelper.ExecuteDataSet("SELECT * FROM AparateFoto WHERE ID_Aparat = :ID_Aparat", CommandType.Text,
                new OracleParameter(":ID_Aparat", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsAparateFoto.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsAparateFoto.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new AparateFoto(linieDB);
            }
            return result;
        }

        public bool AddAparatFoto(AparateFoto a)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO AparateFoto (ID_Aparat, Nume_Model, Descriere, Disponibilitate, Tarif_Zi) VALUES (:ID_Aparat, :Nume_Model, :Descriere, :Disponibilitate, :Tarif_Zi)", CommandType.Text,
                new OracleParameter(":ID_Aparat", OracleDbType.Int32, a.ID_Aparat, ParameterDirection.Input),
                new OracleParameter(":Nume_Model", OracleDbType.Varchar2, a.Nume_Model, ParameterDirection.Input),
                new OracleParameter(":Descriere", OracleDbType.Varchar2, a.Descriere, ParameterDirection.Input),
                new OracleParameter(":Disponibilitate", OracleDbType.Int32, a.Disponibilitate ? 1 : 0, ParameterDirection.Input),
                new OracleParameter(":Tarif_Zi", OracleDbType.Single, a.Tarif_Zi, ParameterDirection.Input));
        }

        public bool UpdateAparatFoto(AparateFoto a)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE AparateFoto SET Nume_Model = :Nume_Model, Descriere = :Descriere, Disponibilitate = :Disponibilitate, Tarif_Zi = :Tarif_Zi WHERE ID_Aparat = :ID_Aparat", CommandType.Text,
                new OracleParameter(":Nume_Model", OracleDbType.Varchar2, a.Nume_Model, ParameterDirection.Input),
                new OracleParameter(":Descriere", OracleDbType.Varchar2, a.Descriere, ParameterDirection.Input),
                new OracleParameter(":Disponibilitate", OracleDbType.Int32, a.Disponibilitate ? 1 : 0, ParameterDirection.Input),
                new OracleParameter(":Tarif_Zi", OracleDbType.Single, a.Tarif_Zi, ParameterDirection.Input),
                new OracleParameter(":ID_Aparat", OracleDbType.Int32, a.ID_Aparat, ParameterDirection.Input));
        }

        public bool DeleteAparatFoto(int id)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM AparateFoto WHERE ID_Aparat = :ID_Aparat", CommandType.Text,
                new OracleParameter(":ID_Aparat", OracleDbType.Int32, id, ParameterDirection.Input));
        }

        public int GetNextIdAparatFoto()
        {
            return SqlDBHelper.GetNextIdClient();
        }
    }
}
