using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class PlusOneSolution
    {
        //https://leetcode.com/problems/plus-one/
        public int[] PlusOne(int[] digits)
        {
            //The incoming digits is a number, but stored in an array.
            //Split it apart, increment one, turn it back into an array.
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                //Start from the end, increment the ending number by 1 until encountering a 9.
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            // If all digits were, add a 1 to the start. 999 -> 1000
            var result = new int[digits.Length + 1];
            result[0] = 1;
            return result;
        }


        [Fact]
        public void Test1()
        {
            var nums = new int[] { 1, 2, 3, 4 };
            var expected = new int[] { 1, 2, 3, 5 }; ;

            var actual = PlusOne(nums);

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [Fact]
        public void Test2()
        {
            var nums = new int[] { 1, 9, 0, 9, 9, 9 };
            var expected = new int[] { 1, 9, 1, 0, 0, 0 }; ;

            var actual = PlusOne(nums);

            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}