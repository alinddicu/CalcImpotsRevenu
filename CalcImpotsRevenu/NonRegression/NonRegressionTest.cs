namespace Test
{
    using Common;
    using Old = CalcImpotsRevenu.Logic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class NonRegressionTest
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
        public void Given30940NetImposableWhenCalculerThenReturn2786()
        {
            var oldResults = GetOldResults();
            var newResults = GetNewResults();

            Check.That(oldResults).IsEqualTo(newResults);
        }

        private static ImpotResult GetNewResults()
        {
            var ctx = new New.ParametresEtat(0.1);
            ctx.AjouterTranche(LimiteSup0, LimiteSup1, Taux0);
            ctx.AjouterTranche(LimiteSup1, LimiteSup2, Taux1);
            ctx.AjouterTranche(LimiteSup2, LimiteSup3, Taux2);
            ctx.AjouterTranche(LimiteSup3, LimiteSup4, Taux3);
            ctx.AjouterTranche(LimiteSup4, LimiteSup5, Taux4);

            var calcul = new New.Calcul(ctx);
            var resultCalcul = calcul.Calculer(30940);

            return resultCalcul;
        }

        private static ImpotResult GetOldResults()
        {
            var ctx = new Old.Contexte(10);

            ctx.AjouterPalier(0, LimiteSup1 - 1, 0, 0);
            ctx.AjouterPalier(LimiteSup1, LimiteSup2 - 1, Taux1, 1);
            ctx.AjouterPalier(LimiteSup2, LimiteSup3 - 1, Taux2, 2);
            ctx.AjouterPalier(LimiteSup3, LimiteSup4 - 1, Taux3, 3);
            ctx.AjouterPalier(LimiteSup4, LimiteSup5, Taux4, 4);

            var calcul = new Old.Calcul(ctx);
            var resultCalcul = calcul.Calculer(30940);

            return resultCalcul;
        }
    }
}
