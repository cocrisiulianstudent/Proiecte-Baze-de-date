using System;
using System.Data;

namespace LibrarieModele
{
    public class Inchiriere
    {
        public int Id_Inchiriere { get; set; }
        public int Id_Teren { get; set; }
        public int Id_Utilizator { get; set; }
        public DateTime Data_Inceput { get; set; }
        public DateTime Data_Sfarsit { get; set; }
        public decimal Pret { get; set; }

        public Inchiriere() { }

        public Inchiriere(DataRow linieBD)
        {
            Id_Inchiriere = Convert.ToInt32(linieBD["id_inchiriere"]);
            Id_Teren = Convert.ToInt32(linieBD["id_teren"]);
            Id_Utilizator = Convert.ToInt32(linieBD["id_utilizator"]);
            Data_Inceput = Convert.ToDateTime(linieBD["data_inceput"]);
            Data_Sfarsit = Convert.ToDateTime(linieBD["data_sfarsit"]);
            Pret = Convert.ToDecimal(linieBD["pret"]);
        }
    }
}
