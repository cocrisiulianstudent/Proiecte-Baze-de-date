using System;
using System.Data;

namespace LibrarieModele
{
    public class InchirieriAparateFoto
    {
        public int ID_Inchiriere { get; set; }
        public int ID_Client { get; set; }
        public int ID_Aparat { get; set; }
        public DateTime Data_Inceput { get; set; }
        public DateTime Data_Sfarsit { get; set; }


        public InchirieriAparateFoto()
        { }

        public InchirieriAparateFoto(int id_inchiriere, int id_client, int id_aparat, DateTime data_inceput, DateTime data_sfarsit)
        {
            ID_Inchiriere = id_inchiriere;
            ID_Client = id_client;
            ID_Aparat = id_aparat;
            Data_Inceput = data_inceput;
            Data_Sfarsit = data_sfarsit;
        }

        public InchirieriAparateFoto(DataRow linieBD)
        {
            ID_Inchiriere = Convert.ToInt32(linieBD["ID_Inchiriere"].ToString());
            ID_Client = Convert.ToInt32(linieBD["ID_Client"].ToString());
            ID_Aparat = Convert.ToInt32(linieBD["ID_Aparat"].ToString());
            Data_Inceput = Convert.ToDateTime(linieBD["Data_Inceput"].ToString());
            Data_Sfarsit = Convert.ToDateTime(linieBD["Data_Sfarsit"].ToString());
        }
    }
}
