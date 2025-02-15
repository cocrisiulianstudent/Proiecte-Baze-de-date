﻿using System.Data;
using System.Configuration;
using Oracle.DataAccess.Client;
using System;
using System.Windows.Forms;

namespace NivelAccesDate
{
    /// <summary>
    /// contine metode generice de interogare, respectiv actualizare a bazei de date
    /// </summary>
    public static class SqlDBHelper
    {
        private const int EROARE_LA_EXECUTIE = 0;

        private static string _connectionString = null;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.AppSettings.Get("StringConectareBD");
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// executa o instructiune de tip SELECT
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns>returneaza valorile primite ca un obiect generic de tip 'DataSet'</returns>
        public static DataSet ExecuteDataSet(string sql, CommandType cmdType, params OracleParameter[] parameters)
        {
            using (DataSet ds = new DataSet())
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.CommandType = cmdType;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    try
                    {
                        new OracleDataAdapter(cmd).Fill(ds);
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Exceptie: " + ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// executa instructiuni INSERT/UPDATE/DELETE 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns> returneaza 'true' daca instructiunea a fost executata cu success</returns>
        public static bool ExecuteNonQuery(string sql, CommandType cmdType, params OracleParameter[] parameters)
        {
            int rezult = EROARE_LA_EXECUTIE;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.CommandType = cmdType;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    try
                    {
                        cmd.Connection.Open();
                        rezult = cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Exceptie: " + ex.Message);
                    }
                }
            }
            return Convert.ToBoolean(rezult);
        }
        public static void Commit()
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    OracleTransaction transaction = conn.BeginTransaction();
                    transaction.Commit();
                }
                catch (OracleException ex)
                {
                    throw new Exception("OracleException: " + ex.Message, ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception: " + ex.Message, ex);
                }
            }
        }
        public static int GetNextIdClient()
        {
            int urmatorulId = 0;
            string query = "SELECT seq_Clienti.nextVal FROM dual";

            using (DataSet ds = ExecuteDataSet(query, CommandType.Text))
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    urmatorulId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }

            return urmatorulId;
        }
        public static int GetNextIdAparatFoto()
        {
            int urmatorulId = 0;
            string query = "SELECT seq_AparateFoto.nextVal FROM dual";

            using (DataSet ds = ExecuteDataSet(query, CommandType.Text))
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    urmatorulId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }

            return urmatorulId;
        }
        public static int GetNextIdInchirieriAparateFoto()
        {
            int urmatorulId = 0;
            string query = "SELECT seq_InchirieriAparateFoto.nextVal FROM dual";

            using (DataSet ds = ExecuteDataSet(query, CommandType.Text))
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    urmatorulId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }

            return urmatorulId;
        }
    }
}
