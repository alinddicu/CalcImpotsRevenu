namespace Common
{
    using System;

    public class ImpotResult
    {
        public ImpotResult(Double[] montantParTranches, Double montantTotal)
        {
            MontantParTranches = montantParTranches;
            MontantTotal = montantTotal;
        }

        public Double[] MontantParTranches { get; private set; }

        public Double MontantTotal { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals((ImpotResult)obj);
        }

        private bool Equals(ImpotResult other)
        {
            return MontantTotal.Equals(other.MontantTotal)
                && Equals(MontantParTranches, other.MontantParTranches);
        }

        private static bool Equals(double[] left, double[] right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if ((left != null && right == null) || (left == null && right != null))
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (var i = 0; i < left.Length; i++)
            {
                if (!left[i].Equals(right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return MontantParTranches == null? 1 : MontantParTranches.GetHashCode() * MontantTotal.GetHashCode();
            }
        }
    }
}
