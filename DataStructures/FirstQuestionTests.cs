using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    [TestFixture]
    public class FirstQuestionTests
    {
        FirstQuestion question = new FirstQuestion();

        [Test]
        public void EmptyArray_NoIndex()
        {
            var emptyArry = new int[0];
            int x = 0;
            var list = new List<double>();
            //var result = 8 / x;
            var result = list.Average();
          //  var result = question.solution(emptyArry);
            Assert.AreEqual(0, 0);
        }
    }
}
