using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareTerenuriSportive : IStocareFactory
    {
        List<TerenSportiv> GetTerenuriSportive();
        TerenSportiv GetTerenSportiv(int id);
        bool AddTerenSportiv(TerenSportiv t);
        bool UpdateTerenSportiv(TerenSportiv t);
        bool DeleteTerenSportiv(int id);
        int GetNextIdTerenSportiv();
    }
}
