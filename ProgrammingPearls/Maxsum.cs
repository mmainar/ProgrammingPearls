namespace ProgrammingPearls
{
    public class Maxsum
    {
        public float MaxSum1(float[] x)
        {
            float maxSoFar = 0;
            for (var i = 0; i < x.Length ; i++)
            {
                for (var j = 0; j < x.Length; j++)
                {
                    float sum = 0;
                    for (var k = i; k <= j; k++)
                    {
                        // sum is sum of x[i..j]
                        sum += x[k];
                        maxSoFar = Max(maxSoFar, sum);
                    }
                }
            }

            return maxSoFar;
        }
        public float MaxSum2a(float[] x)
        {
            float maxSoFar = 0;
            for (var i = 0; i < x.Length; i++)
            {
                float sum = 0;
                for (var j = i; j < x.Length; j++)
                {
                    // sum is sum of x[i..j]
                    sum += x[j];
                    maxSoFar = Max(maxSoFar, sum);
                }
            }

            return maxSoFar;
        }

        public float MaxSum2b(float[] x)
        {
            float[] cumarr = new float[x.Length + 1];
            for (var i = 0; i < x.Length; i++)
            {
                if (i - 1 < 0)
                {
                    cumarr[i] = 0;
                }
                else
                {
                    cumarr[i] = cumarr[i - 1] + x[i];
                }               
            }

            float maxSoFar = 0;
            for (var i = 0; i < x.Length; i++)
            {
                for (var j = i; j < x.Length; j++)
                {
                    // sum is sum of x[i..j]
                    float sum;
                    if (i - 1 < 0)
                    {
                        sum = 0;
                    }
                    else
                    {
                        sum = cumarr[j] - cumarr[i - 1];
                    }              
                    maxSoFar = Max(maxSoFar, sum);
                }
            }

            return maxSoFar;
        }

        public float MaxSum3(float[] x)
        {
            return MaxSum3Recurr(x, 0, x.Length - 1);
        }

        private float MaxSum3Recurr(float[] x, int l, int u)
        {
            if (l > u) /* 0 elemnts */
                return 0;

            if (l == u) /* 1 element */
                return Max(x[l], 0);

            int m = (l + u) / 2;
            float lmax = 0, rmax = 0, sum = 0;
            /* find max crossing to left */
            for (int i = m; i >= l; i--)
            {
                sum += x[i];
                lmax = Max(lmax, sum);
            }

            /* find max crossing to right */        
            sum = 0;
            for (int i = m + 1; i <= u; i++)
            {
                sum += x[i];
                rmax = Max(rmax, sum);
            }

            return Max(lmax + rmax, MaxSum3Recurr(x, l, m), MaxSum3Recurr(x, m + 1, u));
        }

        private float Max(float a, float b)
        {
            return a > b ? a : b;
        }

        private float Max(float a, float b, float c)
        {
            var maxFirstTwo = Max(a,b);
            return Max(maxFirstTwo, c);
        }

        public float MaxSum4(float[] x)
        {
            float maxSoFar = 0;
            float maxEndingHere = 0;
            for (int i = 0; i < x.Length; i++)
            {
                maxEndingHere = Max(maxEndingHere + x[i], 0);
                maxSoFar = Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }
    }
}
