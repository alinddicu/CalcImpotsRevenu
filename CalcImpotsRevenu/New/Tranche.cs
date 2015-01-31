namespace New
{
    using System.Globalization;

    public class Tranche
    {
        private readonly double _taux;
        private readonly double _limiteSup;

        public Tranche(double limiteInf, double limiteSup, double taux)
        {
            LimiteInf = limiteInf;
            _limiteSup = limiteSup;
            _taux = taux;
        }

        public double LimiteInf { get; private set; }

        public double CalculerMontant(double revenu)
        {
            if (revenu < LimiteInf)
            {
                return 0;
            }

            if (revenu >= _limiteSup)
            {
                return (_limiteSup - LimiteInf) * _taux;
            }

            return (revenu - LimiteInf) * _taux;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "LimiteInf:{0} _limiteSup:{1}", LimiteInf, _limiteSup);
        }
    }
}
