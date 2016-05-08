using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    [TestFixture]
    public class SecondQuestionTests
    {
        SecondQuestion question = new SecondQuestion();

        [Test]
        public void EmptyArray_NoIndex()
        {
            var arr = new int[] { 30, 50, 10 };

            var result = question.solution(arr);
            Assert.AreEqual(0, result);
        }
    }
}
