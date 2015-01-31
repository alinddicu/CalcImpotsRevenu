namespace Test
{
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class ImpotResultTest
    {
        [TestMethod]
        public void GivenEmptyMontantsParTranchesAnd0MontantWhenEqualsThenReturnTrue()
        {
            var r1 = new ImpotResult(new double[] { }, 0);
            var r2 = new ImpotResult(new double[] { }, 0);

            Check.That(r1).IsEqualTo(r2);
        }

        [TestMethod]
        public void GivenEmptyMontantsParTranchesAndDifferentMontantWhenEqualsThenReturnFalse()
        {
            var r1 = new ImpotResult(new double[] { }, 23);
            var r2 = new ImpotResult(new double[] { }, -23);

            Check.That(r1).IsNotEqualTo(r2);
        }

        [TestMethod]
        public void GivenEqualMontantsParTranchesAnd0MontantWhenEqualsThenReturnTrue()
        {
            var r1 = new ImpotResult(new double[] { -1, 1, 1000 }, 0);
            var r2 = new ImpotResult(new double[] { -1, 1, 1000 }, 0);

            Check.That(r1).IsEqualTo(r2);
        }

        [TestMethod]
        public void GivenDifferentMontantsParTranchesAnd0MontantWhenEqualsThenReturnFalse()
        {
            var r1 = new ImpotResult(new double[] { -1000 }, 0);
            var r2 = new ImpotResult(new double[] { -1, 1, 1000 }, 0);

            Check.That(r1).IsNotEqualTo(r2);
        }

        [TestMethod]
        public void GivenDifferentMontantsParTranchesAndDifferentMontantWhenEqualsThenReturnFalse()
        {
            var r1 = new ImpotResult(new double[] { -1000 }, 8);
            var r2 = new ImpotResult(new double[] { -1, 1, 1000 }, 0);

            Check.That(r1).IsNotEqualTo(r2);
        }

        [TestMethod]
        public void GivenNullMontantsParTranchesAndEqualMontantWhenEqualsThenReturnTrue()
        {
            var r1 = new ImpotResult(null, 8);
            var r2 = new ImpotResult(null, 8);

            Check.That(r1).IsEqualTo(r2);
        }

        [TestMethod]
        public void GivenExclusiveLeftOrRightNullMontantsParTranchesAndEqualMontantWhenEqualsThenReturnFalse()
        {
            var r1 = new ImpotResult(new double[] {}, 8);
            var r2 = new ImpotResult(null, 8);

            Check.That(r1).IsNotEqualTo(r2);

            r1 = new ImpotResult(null, 8);
            r2 = new ImpotResult(new double[] { }, 8);

            Check.That(r1).IsNotEqualTo(r2);
        }
    }
}
