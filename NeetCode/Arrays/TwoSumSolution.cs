using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class TwoSumSolution
    {
        //https://leetcode.com/problems/two-sum/description/
        public int[] TwoSum(int[] nums, int target)
        {
            var lookup = new Dictionary<int, int>();

            for (int i = nums.Length-1; i >= 0; i--)
            {
                if(!lookup.ContainsKey(nums[i]))
                {
                    lookup.Add(nums[i], i);
                }
            }

            int[] result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                var match = target - nums[i];

                if (lookup.ContainsKey(match) && i != lookup[match])
                {
                    result[0] = i;
                    result[1] = lookup[match];
                    break;
                }
            }

            return result;
        }


        [Fact]
        public void Test1()
        {
            var nums = new int[] { 3, 4, 5, 6 };
            var target = 7;

            var actual = TwoSum(nums, target);

            Assert.Equal(actual[0], 0);
            Assert.Equal(actual[1], 1);
        }

        [Fact]
        public void Test2()
        {
            var nums = new int[] { 4, 5, 6 };
            var target = 10;

            var actual = TwoSum(nums, target);

            Assert.Equal(actual[0], 0);
            Assert.Equal(actual[1], 2);
        }

        [Fact]
        public void Test3()
        {
            var nums = new int[] { 5,5 };
            var target = 10;

            var actual = TwoSum(nums, target);

            Assert.Equal(actual[0], 0);
            Assert.Equal(actual[1], 1);
        }

        [Fact]
        public void Test4()
        {
            var nums = new int[] { 1,3,4,2 };
            var target = 6;

            var actual = TwoSum(nums, target);

            Assert.Equal(actual[0], 2);
            Assert.Equal(actual[1], 3);
        }
    }
}