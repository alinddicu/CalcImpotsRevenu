using System.Globalization;

namespace New
{
    using System;

    public class Tranche
    {
        private readonly double _taux;

        public Tranche(double limiteInf, double limiteSup, double taux)
        {
            LimiteInf = limiteInf;
            LimiteSup = limiteSup;
            _taux = taux;
        }

        public double LimiteInf { get; private set; }

        public double LimiteSup { get; private set; }

        public double CalculerMontantImpotParTranche()
        {
            return (LimiteSup - LimiteInf) * _taux / 100;
        }

        public double CalculerMontantDerniereTranche(double revenu)
        {
            return (revenu - LimiteInf) * _taux / 100;
        }

        public double CalculerMontant(double revenu)
        {
            if (revenu >= LimiteSup)
            {
                return (LimiteSup - LimiteInf) * _taux;
            }

            if (revenu - LimiteInf < 0)
            {
                return 0;
            }

            return (revenu - LimiteInf) * _taux;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "LimiteInf:{0} LimiteSup:{1}", LimiteInf, LimiteSup);
        }
    }
}
