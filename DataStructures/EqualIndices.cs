using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    [TestFixture]
    public class EqualIndices
    {
        public int solution(int[] A)
        {
            // Pre-processing of the input to compute list of indices for each unique entry
            // This requires O(N) time
            // O(N) extra memory, where N = A.Length
            // The list of indices will be sorted by construction
            Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < A.Length; i++)
            {
                var item = A[i];
                if (dict.ContainsKey(item))
                {
                    var indices = dict[item];
                    indices.Add(i);
                }
                else
                {
                    dict.Add(item, new HashSet<int> { i });
                }
            }

            // Compute number of identical pairs on the array
            // This requires O(N * log N) time since indices lists are sorted
            // assuming Count does binary search
            int identicalPairs = 0;
            for (int i = 0; i < A.Length; i++)
            {
                var item = A[i];
                var indices = dict[item];
                int index = indices.ToList().BinarySearch(i);
                identicalPairs += indices.Count() - (index + 1);
               // identicalPairs += indices.Count(idx => idx > i);
            }

            const int maxIdenticalPairs = 1000000000;
            if (identicalPairs > maxIdenticalPairs)
            {
                return maxIdenticalPairs;
            }

            return identicalPairs;
        }

        [Test]
        public void Test()
        {
            var arr = new int[] { 3, 5, 6, 3, 3, 5 };
            Assert.AreEqual(4, solution(arr));
        }

        [Test]
        public void TestArraySameNumber()
        {
            var arr = new int[] { 3, 3,3,3,3,3,3,3,3,3,3,3,3,3,3 };
            Assert.AreEqual(105, solution(arr));
        }

        [Test]
        public void TestSingleElementArray()
        {
            var arr = new int[] { 3 };
            Assert.AreEqual(0, solution(arr));
        }

        [Test]
        public void TestEmptyArray()
        {
            var arr = new int[] { };
            Assert.AreEqual(0, solution(arr));
        }
    }
}
