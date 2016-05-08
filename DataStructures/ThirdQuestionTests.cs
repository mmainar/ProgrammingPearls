using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    [TestFixture]
    public class ThirdQuestionTests
    {
        ThirdQuestion question = new ThirdQuestion();

        [Test]
        public void Test()
        {
            var arr = new int[] { 30, 20, 10 };

            var result = question.solution(arr);
            Assert.AreEqual(0, result);

            arr = new int[] { 2,2,2,2,1,2, -1, 2,1,3 };
            result = question.solution(arr);
            Assert.AreEqual(4, result);
        }
    }
}
