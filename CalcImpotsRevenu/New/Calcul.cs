using System.Collections.Generic;
using System.Text;

namespace New
{
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
            var montantsParTranche = new List<double>();

            foreach (var tranche in _parametresEtat.Tranches.OrderBy(t => t.LimiteInf))
            {
                montantsParTranche.Add(tranche.CalculerMontant(apresAbattement));
            }

            return montantsParTranche;
        }

        private double CalculerImpotRevenu(double netImposable)
        {
            var impotsParTranche = CalculerMontantParTranches(netImposable);
            return impotsParTranche.Sum(montantParTranche => montantParTranche);
        }
    }
}
