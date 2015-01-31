namespace CalcImpotsRevenu.Logic
{
    using System;

    public class Palier
    {
        Double _limiteInf;

        public Double LimiteInf
        {
            get { return _limiteInf; }
            set { _limiteInf = value; }
        }
        Double _limiteSup;

        public Double LimiteSup
        {
            get { return _limiteSup; }
            set { _limiteSup = value; }
        }
        Double _taux;

        public Double Taux
        {
            get { return _taux; }
            set { _taux = value; }
        }
        int _ordre;

        public int Ordre
        {
            get { return _ordre; }
            set { _ordre = value; }
        }

        public Double CalculImpotPalier()
        {
            return (LimiteSup - LimiteInf) * Taux / 100;
        }

        public Double CalculImpotPalierF(Double revenu)
        {
            return (revenu - LimiteInf) * Taux / 100;
        }
    }
}
