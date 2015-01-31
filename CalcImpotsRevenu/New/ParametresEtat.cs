namespace New
{
    using System.Collections.Generic;

    public class ParametresEtat
    {
        public ParametresEtat(double tauxAbattement)
        {
            Tranches = new List<Tranche>();
            TauxAbattement = tauxAbattement;
        }

        public List<Tranche> Tranches { get; private set; }

        public double TauxAbattement { get; private set; }

        public void AjouterTranche(double limiteInf, double limiteSup, double taux)
        {
            Tranches.Add(new Tranche(limiteInf, limiteSup, taux));
        }
    }
}
