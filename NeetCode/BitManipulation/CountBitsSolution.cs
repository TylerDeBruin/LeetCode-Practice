using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using ExpectedObjects;

namespace NeetCode.BitManipulation
{
    public class CountBitsSolution
    {
        //https://neetcode.io/problems/counting-bits
        public int[] CountBits(int n)
        {
            var result = new int[n + 1];

            //Iterate from [0,n]
            for (int i = 1; i <= n; i++)
            {
                //Set the result, starting at the 1st position, 
                //define an offset of the last signficant bit from the result
                //And that, with the i positon of the current i.
                var offset = result[i >> 1];

                result[i] = offset + (i & 1);
            }

            return result;
        }

        [Fact]
        public void Test1()
        {
            var expected = new int[] { 0, 1, 1, 2, 1 };

            var actual = CountBits(4);

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}