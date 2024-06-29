using LibrarieModele;

using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareInchirieriAparateFoto : IStocareFactory
    {
        List<InchirieriAparateFoto> GetInchirieriAparateFoto();
        InchirieriAparateFoto GetInchiriereAparatFoto(int id);
        bool AddInchiriereAparatFoto(InchirieriAparateFoto i);
        bool UpdateInchiriereAparatFoto(InchirieriAparateFoto i);
        bool DeleteInchiriereAparatFoto(int id);
        int GetNextIdInchirieriAparateFoto();
    }
}
