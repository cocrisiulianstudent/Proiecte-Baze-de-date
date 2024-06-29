using System;
using System.Data;

namespace LibrarieModele
{
    public class TerenSportiv
    {
        public int Id_Teren { get; set; }
        public string Denumire { get; set; }
        public decimal Suprafata { get; set; }
        public string Tip_Sport { get; set; }
        public string Adresa { get; set; }

        public TerenSportiv()
        { }

        public TerenSportiv(int idTeren, string denumire, decimal suprafata, string tipSport, string adresa)
        {
            Id_Teren = idTeren;
            Denumire = denumire;
            Suprafata = suprafata;
            Tip_Sport = tipSport;
            Adresa = adresa;
        }

        public TerenSportiv(DataRow linieDB)
        {
            Id_Teren = Convert.ToInt32(linieDB["id_teren"]);
            Denumire = linieDB["denumire"].ToString();
            Suprafata = Convert.ToDecimal(linieDB["suprafata"]);
            Tip_Sport = linieDB["tip_sport"].ToString();
            Adresa = linieDB["adresa"].ToString();
        }
    }
}
