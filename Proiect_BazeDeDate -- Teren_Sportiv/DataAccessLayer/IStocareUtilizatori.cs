using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareUtilizatori : IStocareFactory
    {
        List<Utilizator> GetUtilizatori();
        Utilizator GetUtilizator(int id);
        bool AddUtilizator(Utilizator u);
        bool UpdateUtilizator(Utilizator u);
        bool DeleteUtilizator(int id);
        int GetNextIdUtilizator();
    }
}
