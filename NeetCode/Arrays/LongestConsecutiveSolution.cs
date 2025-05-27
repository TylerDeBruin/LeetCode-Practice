using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;

namespace NeetCode.Arrays
{
    public class LongestConsecutiveSolution
    {
        public int LongestConsecutive(int[] nums)
        {
            //Add everything to a dictionary.
            var lookup = new Dictionary<int, int>();

            foreach (int i in nums)
            {
                if(!lookup.ContainsKey(i))
                {
                    lookup.Add(i, 1);
                }
            }

            //See if i + 1 is a key in the dictionary. Infintiely loop until you stop finding i=i+1
            foreach (int i in lookup.Keys)
            {
                var iteratedMax = 1;

                var keyToCheck = i + 1;

                while (lookup.ContainsKey(keyToCheck))
                {
                    lookup[i]++;

                    keyToCheck += 1;
                }
            }

            //Sort by thhe Values, grab the largest one.
            var resultList = lookup.OrderByDescending(x => x.Value).ToList().FirstOrDefault().Value;

            return resultList;
        }
    }
}