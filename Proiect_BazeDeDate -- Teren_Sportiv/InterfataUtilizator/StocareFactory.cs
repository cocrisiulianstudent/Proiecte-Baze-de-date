using NivelAccesDate;
using System;
using System.Collections.Generic;
using System.Configuration;
using LibrarieModele;

namespace InterfataUtilizator
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public class StocareFactory
    {
        public IStocareFactory GetTipStocare(Type tipEntitate)
        {
            var formatSalvare = "BazaDateOracle";
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "BazaDateOracle":


                        if (tipEntitate == typeof(Utilizator))
                        {
                            return new AdministrareUtilizatori();
                        }
                        if (tipEntitate == typeof(TerenSportiv))
                        {
                            return new AdministrareTerenuriSportive();
                        }
                        if (tipEntitate == typeof(Inchiriere))
                        {
                            return new AdministrareInchirieri();
                        }
                        break;

                    case "BIN":
                        //instantiere clase care realizeaza salvarea in fisier binar
                        break;
                }
            }
            return null;
        }
    }
}
