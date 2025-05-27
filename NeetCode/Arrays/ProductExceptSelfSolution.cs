using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class ProductExceptSelfSolution
    {
        //https://leetcode.com/problems/product-of-array-except-self/description/
        //Watch for edge cases around zero.
        public int[] ProductExceptSelf(int[] nums)
        {
            var multiplicationResult = 1;

            foreach (int i in nums)
            {
                multiplicationResult *= i;
            }

            var result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    var element = 1;

                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (i != j)
                        {
                            element *= nums[j];
                        }
                    }

                    result.Add(element);
                }
                else
                {
                    var element = multiplicationResult / nums[i];

                    result.Add(element);
                }

            }

            return result.ToArray();
        }
    }
}