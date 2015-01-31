using NFluent;

namespace New.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TrancheTest
    {
        [TestMethod]
        public void Given1StTrancheWhenCalculerMontantThenReturn0()
        {
            var tranche = new Tranche(0, 5964, 0);

            Check.That(tranche.CalculerMontant(5964)).IsEqualTo(0);
            Check.That(tranche.CalculerMontant(1000)).IsEqualTo(0);
            Check.That(tranche.CalculerMontant(0)).IsEqualTo(0);
        }

        [TestMethod]
        public void Given2NdTrancheWhenCalculerMontantThenReturn()
        {
            var tranche = new Tranche(5964, 11897, 0.055);

            Check.That(tranche.CalculerMontant(5964)).IsEqualTo(0);
            Check.That(tranche.CalculerMontant(11897)).IsEqualTo((11897 - 5964) * 0.055);
            Check.That(tranche.CalculerMontant(12000)).IsEqualTo((11897 - 5964) * 0.055);
            Check.That(tranche.CalculerMontant(10000)).IsEqualTo((10000 - 5964) * 0.055);
        }
    }
}
