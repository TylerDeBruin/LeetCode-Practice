using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode.Arrays
{
    public class MajorityElementSolution
    {
        public int MajorityElement(int[] nums)
        {
            var lookup = new Dictionary<int, int>();

            foreach (var element in nums)
            {
                if (lookup.ContainsKey(element))
                {
                    lookup[element]++;
                }
                else
                {
                    lookup.Add(element, 1);
                }
            }

            return lookup.OrderByDescending(x => x.Value).First().Key;
        }
    }
} 
