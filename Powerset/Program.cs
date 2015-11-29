using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Powerset
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new List<int> { 1, 2, 3 };
            var powersetRecur = PowersetRecursive(set);
            var powersetIter = PowersetIterative(set);
            Console.WriteLine(Print(powersetRecur));
            Console.WriteLine(Print(powersetIter));
            Console.ReadLine();
        }       

        private static List<List<int>> PowersetRecursive(List<int> set)
        {
            var result = new List<List<int>>();

            // Base case
            if (!set.Any())
            {
                // Add the empty set
                result.Add(new List<int>());
                return result;
            }

            // Recursive case
            // Will exist, since otherwise we would have returned before on the base case
            int head = set.Last();
            // Get the tail of the set by skipping the head or first item
            List<int> tail = set.Take(set.Count() - 1).ToList();
            List<List<int>> subsets = PowersetRecursive(tail);
            result.AddRange(subsets);

            // Need to create a copy (i.e. clone); 
            var newSubsets = new List<List<int>>(subsets);
            foreach (List<int> subset in subsets)
            {
                var newSubset = new List<int>(subset);
                newSubset.Add(head);
                newSubsets.Add(newSubset);
            }
            result = newSubsets;
            return result;
        }

        private static List<List<int>> PowersetIterative(List<int> set)
        {
            var result = new List<List<int>>();

            // Add the empty set
            result.Add(new List<int>());

            // Loop through all the items on the input set
            foreach (int item in set)
            {
                var newPs = new List<List<int>>(result);
                foreach (List<int> subset in result)
                {
                    List<int> newSubset = new List<int>(subset);
                    newSubset.Add(item);
                    newPs.Add(newSubset);
                }

                result = newPs;
            }

            return result;
        }

        private static string Print(List<List<int>> powerset)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            for (int j = 0; j < powerset.Count(); j++)
            {
                List<int> subset = powerset.ElementAt(j);
                sb.Append("{");
                for (int i = 0; i < subset.Count(); i++) 
                {
                    int element = subset.ElementAt(i);
                    sb.Append(element);
                    if (i < subset.Count() -1)
                      sb.Append(',');
                }
                sb.Append("}");
                if (j < powerset.Count() -1)
                  sb.Append(',');
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
