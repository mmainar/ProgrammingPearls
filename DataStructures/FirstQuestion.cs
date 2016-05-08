using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class FirstQuestion
    {
        public class Tree
        {
            public int x;
            public Tree l, r;
        }

        public int solution(Tree T)
        {
            if (T == null)
            {
                return 0;
            }

            return 1 + GetTotalVisibleNodes(T.l, T.x) + GetTotalVisibleNodes(T.r, T.x);
        }

        private int GetTotalVisibleNodes(Tree T, int maxValue)
        {
            if (T == null)
            {
                return 0;
            }

            if (T.x >= maxValue)
            {
                return 1 + GetTotalVisibleNodes(T.l, T.x) + GetTotalVisibleNodes(T.r, T.x);
            }
            else
            {
                return GetTotalVisibleNodes(T.l, maxValue) + GetTotalVisibleNodes(T.r, maxValue);
            }
        }
    }
}
