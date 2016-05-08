using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class ThirdQuestion
    {
        public int solution(int[] A)
        {
            // Precondition: A is non empty
            int sliceStart = 0;
            int sliceSize = 0;
            int maxSlice = 0;
            int maxSliceStart = 0;

            int sliceEnd = 0;

            if (A.Length == 1)
            {
                return maxSliceStart;
            }

            for (int i = 0; i < A.Length - 2; i++)
            {
                if (A[i] < A[i+1])
                {
                    sliceSize++;
                }
                else // Ascending slice finished
                {
                    sliceEnd = i;
                    // Assert sliceSize == sliceEnd - sliceStart + 1
                    if (sliceSize > maxSlice)
                    {
                        maxSlice = sliceSize;
                        maxSliceStart = sliceStart;
                    }
                    sliceSize = 0;
                    sliceStart = i + 1;
                }
            }

            return maxSliceStart;
        }
    }
}
