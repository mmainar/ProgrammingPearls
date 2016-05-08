using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    [TestFixture]
    public class PreSuffix
    {
        public int solution(string S)
        {
            int maxPrefixAndSuffixLength = 0; // By default empty string is common
            for (int i = 1; i < S.Length; i++)
            {
                string prefix = S.Substring(0, i);
                string suffix = S.Substring(S.Length - i, i);
                if (prefix == suffix && prefix.Length > maxPrefixAndSuffixLength)
                {
                    maxPrefixAndSuffixLength = prefix.Length;
                }
            }

            return maxPrefixAndSuffixLength;
        }

        [Test]
        public void TestOk()
        {
            var input = "abbaabba";
            Assert.AreEqual(4, solution(input));
        }

        [Test]
        public void TestResult0()
        {
            var input = "codility";
            Assert.AreEqual(0, solution(input));
        }

        [Test]
        public void TestLongInput()
        {
            var input = "abbaabba";
            Assert.AreEqual(4, solution(input));
        }
    }
}
