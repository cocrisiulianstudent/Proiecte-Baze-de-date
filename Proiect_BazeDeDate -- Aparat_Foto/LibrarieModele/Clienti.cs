using System;
using System.Data;

namespace LibrarieModele
{
    public class Clienti
    {
        public int ID_Client { get; set; }
        public string Nume_Client { get; set; }
        public string Prenume_Client { get; set; }
        public long Telefon { get; set; }
        public string Email { get; set; }

        public string NumeComplet
        {
            get
            {
                return $"{Nume_Client} {Prenume_Client}";
            }
        }
        public Clienti()
        { }
        public Clienti(int id_client, string nume, string prenume, long telefon, string email)
        {
            ID_Client = id_client;
            Nume_Client = nume;
            Prenume_Client = prenume;
            Telefon = telefon;
            Email = email;
        }

        public Clienti(DataRow linieBD)
        {
            ID_Client = Convert.ToInt32(linieBD["ID_Client"].ToString());
            Nume_Client = linieBD["Nume_Client"].ToString();
            Prenume_Client = linieBD["Prenume_Client"].ToString();
            Telefon = Convert.ToInt64(linieBD["Telefon"].ToString());
            Email = linieBD["Email"].ToString();
        }
    }
}
