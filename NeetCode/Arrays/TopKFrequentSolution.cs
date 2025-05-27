using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class TopKFrequentSolution
    {
        //https://leetcode.com/problems/top-k-frequent-elements/description/
        public int[] TopKFrequent(int[] nums, int k)
        {
            var lookup = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if(!lookup.ContainsKey(num))
                {
                    lookup.Add(num, 1); 
                }
                else
                {
                    lookup[num]++;
                }
            }

            var orderedList = lookup.OrderByDescending(x => x.Value).ToList();

            var result = new int[k];

            for (int i = 0; i < k; i++)
            {
                result[i] = orderedList[i].Key;
            }

            return result;
        }
    }
}