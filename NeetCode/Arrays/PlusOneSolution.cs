using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class PlusOneSolution
    {
        public int[] PlusOne(int[] digits)
        {
            var plusOne = long.Parse(string.Join("", digits)) + 1;

            var split = plusOne.ToString().ToCharArray();

            var result = split.Select(x => Convert.ToInt32(x.ToString())).ToArray();


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

    }
}