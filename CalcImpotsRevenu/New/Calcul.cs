namespace New
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class Calcul
    {
        private readonly ParametresEtat _parametresEtat;

        public Calcul(ParametresEtat parametresEtat)
        {
            _parametresEtat = parametresEtat;
        }

        public ImpotResult Calculer(double revenuNet)
        {
            return new ImpotResult(
                CalculerMontantParTranches(revenuNet).ToArray(),
                CalculerImpotRevenu(revenuNet));
        }

        private IEnumerable<double> CalculerMontantParTranches(double netImposable)
        {
            var apresAbattement = netImposable * (1 - _parametresEtat.TauxAbattement);

            return _parametresEtat.Tranches
                .OrderBy(t => t.LimiteInf)
                .Select(t => t.CalculerMontant(apresAbattement));
        }

        private double CalculerImpotRevenu(double netImposable)
        {
            var impotsParTranche = CalculerMontantParTranches(netImposable);
            return impotsParTranche.Sum(montantParTranche => montantParTranche);
        }
    }
}
