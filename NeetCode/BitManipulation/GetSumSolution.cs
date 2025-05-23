using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using ExpectedObjects;

namespace NeetCode.BitManipulation
{
    public class GetSumSolution
    {
        public int GetSum(int a, int b)
        {
            while( b!=0)
            {
                var carry = (a & b) << 1;

                a = (a ^ b);

                b = carry;
            }

            return a;
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(2, GetSum(1, 1));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(11, GetSum(4, 7));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(50, GetSum(20, 30));
        }
    }
}