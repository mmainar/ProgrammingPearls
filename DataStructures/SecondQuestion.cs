using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SecondQuestion
    {
        public int solution(int[] A)
        {
            if (A.Length < 2)
            {
                return -1;
            }

            int maxPerimeter = -1; // Default value if no triangle can be formed
            int perimeter = 0;

            // Takes: O(N log N) assuming quicksort/mergesort on the OrderBy Linq implementation
            var sorted = A.OrderByDescending(i => i).ToArray();

            // 0 <= P < Q < R < N
            // Takes O(N)
            for (int i = 0; i < sorted.Length - 3; i++)
            {
                int pVal = sorted[i];
                int qVal = sorted[i + 1];
                int rVal = sorted[i + 2];

                // 1) A[p] + A[q] > A[r] since sorted is in descending order
                // 3) A[r] + A[p] > A[q] since sorted is in descending order
                // We need to check that the remaining condition (2) holds
                if (qVal + rVal > pVal)
                {
                    // Triangle found
                    perimeter = pVal + qVal + rVal;
                    if (perimeter > maxPerimeter)
                    {
                        maxPerimeter = perimeter;
                    }
                }
            }
            // Total worst-case runtime is O(N log N)
            return maxPerimeter;
        }
    }
}
