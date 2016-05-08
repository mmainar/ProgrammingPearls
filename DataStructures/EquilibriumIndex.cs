using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    [TestFixture]
    public class EquilibriumIndex
    {
        public int solution(int[] A)
        {
            long[] sum = new long[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                if (i == 0)
                {
                    sum[i] = A[i];
                }
                else
                {
                    sum[i] = A[i] + sum[i - 1];
                }
            }
            long lowerSum = 0;
            long upperSum;
            for (int i = 0; i < A.Length; i++)
            {
                if (i == 0)
                {
                    lowerSum = 0;
                    upperSum = sum[A.Length - 1] - A[i];
                }
                else if (i == A.Length - 1)
                {
                    lowerSum = sum[A.Length - 1] - A[i];
                    upperSum = 0;
                }
                else 
                {
                    lowerSum = sum[i - 1];
                    upperSum = sum[A.Length - 1] - lowerSum - A[i];
                }
                if (upperSum == lowerSum)
                {
                    // Equi index found
                    return i;
                }
            }
            return -1;
        }

        [Test]
        public void EmptyArray_NoIndex()
        {
            var emptyArry = new int[0];

            var result = solution(emptyArry);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void SingleElementArray()
        {
            var singleElementArray = new int[1] { 0 };

            var result = solution(singleElementArray);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TwoElementsArray()
        {
            var arr = new int[2] { -1, 1 };

            var result = solution(arr);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void MultipleElementsArray()
        {
            var arr = new int[] { -1, 3, -4, 5, 1, -6, 2, 1  };

            var result = solution(arr);
            Assert.AreEqual(1, result);
        }
    }
}
