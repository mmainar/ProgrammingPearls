using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    [TestFixture]
    public class Stack
    {
        public int solution(string S)
        {
            int minInteger = 0;
            int maxInteger = (1 << 20) - 1;
              Stack<int> stack = new Stack<int>();
            foreach (string op in S.Split(' '))
            {
                if (op == "DUP")
                {
                    if (!stack.Any())
                    {
                        return -1;
                    }
                    stack.Push(stack.Peek());
                }
                else if (op == "POP")
                {
                    if (!stack.Any())
                    {
                        return -1;
                    }
                    stack.Pop();
                }
                else if (op == "+")
                {
                    if (stack.Count() < 2)
                    {
                        return -1;
                    }
                    var top = stack.Pop();
                    var nextTop = stack.Pop();
                    var sum = top + nextTop;
                    if (sum > maxInteger)
                    {
                        // Overflow
                        return -1;
                    }
                    stack.Push(sum);
                }
                else if (op == "-")
                {
                    if (stack.Count() < 2)
                    {
                        return -1;
                    }
                    var top = stack.Pop();
                    var nextTop = stack.Pop();
                    var diff = top - nextTop;
                    if (diff < minInteger)
                    {
                        // Overflow
                        return -1;
                    }
                    stack.Push(diff);
                }
                else
                {
                    int number;
                    if (!int.TryParse(op, out number))
                    {
                        return -1;
                    }
                    if (number < minInteger || number > maxInteger)
                    {
                        return -1;
                    }
                    stack.Push(number);
                }
            }

            if (!stack.Any())
            {
                return -1;
            }

            return stack.Pop();
        }

        [Test]
        public void TestOk()
        {
            var input = "13 DUP 4 POP 5 DUP + DUP + -";
            Assert.AreEqual(7, solution(input));
        }

        [Test]
        public void TestEmptyStackEnd()
        {
            var input = "1 1 + POP";
            Assert.AreEqual(-1, solution(input));
        }

        [Test]
        public void TestOverflow()
        {
            var input = "1048576 1 +";
            Assert.AreEqual(-1, solution(input));
        }

        [Test]
        public void TestUnderflow()
        {
            var input = "1 1048576 -";
            Assert.AreEqual(-1, solution(input));
        }

        [Test]
        public void TestError1()
        {
            var input = "5 6 + -";
            Assert.AreEqual(-1, solution(input));
        }

        [Test]
        public void TestError2()
        {
            var input = "3 DUP 5 - -";
            Assert.AreEqual(-1, solution(input));
        }
    }
}
