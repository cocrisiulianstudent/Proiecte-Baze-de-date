using System;
using System.Data;

namespace LibrarieModele
{
    public class Utilizator
    {
        public int Id_Utilizator { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public string NumeComplet => $"{Nume} {Prenume}";
        public Utilizator()
        { }

        public Utilizator(int idUtilizator, string nume, string prenume, string email, string telefon)
        {
            Id_Utilizator = idUtilizator;
            Nume = nume;
            Prenume = prenume;
            Email = email;
            Telefon = telefon;
        }

        public Utilizator(DataRow linieBD)
        {
            Id_Utilizator = Convert.ToInt32(linieBD["id_utilizator"]);
            Nume = linieBD["nume"].ToString();
            Prenume = linieBD["prenume"].ToString();
            Email = linieBD["email"].ToString();
            Telefon = linieBD["telefon"].ToString();
        }
    }
}
