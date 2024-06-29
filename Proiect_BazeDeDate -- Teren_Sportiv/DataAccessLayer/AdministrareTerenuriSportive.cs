using System;
using System.Collections.Generic;
using System.Data;
using LibrarieModele;

using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareTerenuriSportive : IStocareTerenuriSportive
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<TerenSportiv> GetTerenuriSportive()
        {
            var result = new List<TerenSportiv>();
            var dsTerenuriSportive = SqlDBHelper.ExecuteDataSet("SELECT * FROM Terenuri_Sportive", CommandType.Text);

            foreach (DataRow linieDB in dsTerenuriSportive.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new TerenSportiv(linieDB));
            }
            return result;
        }

        public TerenSportiv GetTerenSportiv(int id)
        {
            TerenSportiv result = null;
            var dsTerenuriSportive = SqlDBHelper.ExecuteDataSet("SELECT * FROM Terenuri_Sportive WHERE id_teren = :ID_TerenSportiv", CommandType.Text,
                new OracleParameter(":ID_TerenSportiv", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsTerenuriSportive.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsTerenuriSportive.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new TerenSportiv(linieDB);
            }
            return result;
        }

        public bool AddTerenSportiv(TerenSportiv t)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO Terenuri_Sportive VALUES (:ID_Teren, :Denumire, :Suprafata, :Tip_Sport, :Adresa)", CommandType.Text,
                new OracleParameter(":ID_Teren", OracleDbType.Int32, t.Id_Teren, ParameterDirection.Input),
                new OracleParameter(":Denumire", OracleDbType.Varchar2, t.Denumire, ParameterDirection.Input),
                new OracleParameter(":Suprafata", OracleDbType.Decimal, t.Suprafata, ParameterDirection.Input),
                new OracleParameter(":Tip_Sport", OracleDbType.Varchar2, t.Tip_Sport, ParameterDirection.Input),
                new OracleParameter(":Adresa", OracleDbType.Varchar2, t.Adresa, ParameterDirection.Input));
        }

        public bool UpdateTerenSportiv(TerenSportiv t)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Terenuri_Sportive SET Denumire = :Denumire, Suprafata = :Suprafata, Tip_Sport = :Tip_Sport, Adresa = :Adresa WHERE id_teren = :ID_TerenSportiv", CommandType.Text,
                new OracleParameter(":Denumire", OracleDbType.Varchar2, t.Denumire, ParameterDirection.Input),
                new OracleParameter(":Suprafata", OracleDbType.Decimal, t.Suprafata, ParameterDirection.Input),
                new OracleParameter(":Tip_Sport", OracleDbType.Varchar2, t.Tip_Sport, ParameterDirection.Input),
                new OracleParameter(":Adresa", OracleDbType.Varchar2, t.Adresa, ParameterDirection.Input),
                new OracleParameter(":ID_TerenSportiv", OracleDbType.Int32, t.Id_Teren, ParameterDirection.Input));
        }

        public bool DeleteTerenSportiv(int idTerenSportiv)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM Terenuri_Sportive WHERE id_teren = :ID_TerenSportiv", CommandType.Text,
                new OracleParameter(":ID_TerenSportiv", OracleDbType.Int32, idTerenSportiv, ParameterDirection.Input)
            );
        }
        public int GetNextIdTerenSportiv()
        {
            return SqlDBHelper.GetNextIdTerenSportiv();
        }
    }
}
