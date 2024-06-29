using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareInchirieri : IStocareFactory
    {
        List<Inchiriere> GetInchirieri();
        Inchiriere GetInchiriere(int id);
        bool AddInchiriere(Inchiriere i);
        bool UpdateInchiriere(Inchiriere i);
        bool DeleteInchiriere(int id);
        int GetNextIdInchiriere();
    }
}
