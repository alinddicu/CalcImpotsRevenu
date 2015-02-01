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
            var montantParTranches = CalculerMontantParTranches(revenuNet).ToArray();
            return new ImpotResult(montantParTranches, CalculerImpotRevenu(montantParTranches));
        }

        private IEnumerable<double> CalculerMontantParTranches(double netImposable)
        {
            var netApresAbattement = netImposable * (1 - _parametresEtat.TauxAbattement);

            return _parametresEtat.Tranches
                .OrderBy(t => t.LimiteInf)
                .Select(t => t.CalculerMontant(netApresAbattement));
        }

        private static double CalculerImpotRevenu(IEnumerable<double> montantParTranches)
        {
            return montantParTranches.Sum(montantParTranche => montantParTranche);
        }
    }
}
