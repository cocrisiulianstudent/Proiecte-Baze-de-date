using System;
using System.Data;

namespace LibrarieModele
{
    public class AparateFoto
    {
        public int ID_Aparat { get; set; }
        public string Nume_Model { get; set; }
        public string Descriere { get; set; }
        public bool Disponibilitate { get; set; }
        public float Tarif_Zi { get; set; }

        public AparateFoto()
        { }

        public AparateFoto(int id_aparat, string nume_model, string descriere, bool disponibilitate, float tarif_zi)
        {
            ID_Aparat = id_aparat;
            Nume_Model = nume_model;
            Descriere = descriere;
            Disponibilitate = disponibilitate;
            Tarif_Zi = tarif_zi;
        }

        public AparateFoto(DataRow linieDB)
        {
            ID_Aparat = Convert.ToInt32(linieDB["ID_Aparat"].ToString());
            Nume_Model = linieDB["Nume_Model"].ToString();
            Descriere = linieDB["Descriere"].ToString();
            Disponibilitate = Convert.ToBoolean(linieDB["Disponibilitate"]);
            Tarif_Zi = Convert.ToSingle(linieDB["Tarif_Zi"].ToString());
        }
    }
}
