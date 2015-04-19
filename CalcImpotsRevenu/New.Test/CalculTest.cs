namespace New.Test
{
    using NFluent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CalculTest
    {
        private const int LimiteSup0 = 0;
        private const double Taux0 = 0.0;
        private const int LimiteSup1 = 5964;
        private const double Taux1 = 0.055;
        private const int LimiteSup2 = 11897;
        private const double Taux2 = 0.140;
        private const int LimiteSup3 = 26421;
        private const double Taux3 = 0.300;
        private const int LimiteSup4 = 70831;
        private const double Taux4 = 0.41;
        private const int LimiteSup5 = int.MaxValue;

        [TestMethod]
        public void Given30940NetImposableEtAbattementStandardWhenCalculerThenReturn2787()
        {
            var paramEtat = new ParametresEtat(0.1);
            paramEtat.AjouterTranche(LimiteSup0, LimiteSup1, Taux0);
            paramEtat.AjouterTranche(LimiteSup1, LimiteSup2, Taux1);
            paramEtat.AjouterTranche(LimiteSup2, LimiteSup3, Taux2);
            paramEtat.AjouterTranche(LimiteSup3, LimiteSup4, Taux3);
            paramEtat.AjouterTranche(LimiteSup4, LimiteSup5, Taux4);

            var calcul = new Calcul(paramEtat);
            var resultCalcul = calcul.Calculer(30940);
            Check.That(resultCalcul.MontantTotal).IsEqualTo(2787.175);
            Check.That(resultCalcul.MontantParTranches[0]).IsEqualTo(0);
            Check.That(resultCalcul.MontantParTranches[1]).IsEqualTo(326.315);
            Check.That(resultCalcul.MontantParTranches[2]).IsEqualTo(2033.3600000000001);
            Check.That(resultCalcul.MontantParTranches[3]).IsEqualTo(427.5);
            Check.That(resultCalcul.MontantParTranches[4]).IsEqualTo(0);
        }

        [TestMethod]
        public void Given32786WhenCalculerThenReturn3285v595()
        {
            var paramEtat = new ParametresEtat(0.1);
            paramEtat.AjouterTranche(LimiteSup0, LimiteSup1, Taux0);
            paramEtat.AjouterTranche(LimiteSup1, LimiteSup2, Taux1);
            paramEtat.AjouterTranche(LimiteSup2, LimiteSup3, Taux2);
            paramEtat.AjouterTranche(LimiteSup3, LimiteSup4, Taux3);
            paramEtat.AjouterTranche(LimiteSup4, LimiteSup5, Taux4);

            var calcul = new Calcul(paramEtat);
            var resultCalcul = calcul.Calculer(32786);

            Check.That(resultCalcul.MontantTotal).IsEqualTo(3285.5950000000007);
        }
    }
}
