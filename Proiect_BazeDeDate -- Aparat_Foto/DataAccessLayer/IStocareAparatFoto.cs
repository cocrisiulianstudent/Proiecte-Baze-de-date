using LibrarieModele;

using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareAparatFoto : IStocareFactory
    {
        List<AparateFoto> GetAparateFoto();
        AparateFoto GetAparatFoto(int id);
        bool AddAparatFoto(AparateFoto a);
        bool UpdateAparatFoto(AparateFoto a);
        bool DeleteAparatFoto(int id);
        int GetNextIdAparatFoto();
    }
}
