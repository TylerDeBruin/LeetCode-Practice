using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class LongestConsecutiveSolution
    {
        public int LongestConsecutive(int[] nums)
        {
            var lookup = new Dictionary<int, int>();

            foreach (int i in nums)
            {
                if(!lookup.ContainsKey(i))
                {
                    lookup.Add(i, 1);
                }
            }

            foreach (int i in lookup.Keys)
            {

                var keyToCheck = i + 1;

                while (lookup.ContainsKey(keyToCheck))
                {
                    lookup[i]++;

                    keyToCheck += 1;
                }
            }

            var resultList = lookup.OrderByDescending(x => x.Value).ToList().FirstOrDefault().Value;

            return resultList;
        }
    }
}