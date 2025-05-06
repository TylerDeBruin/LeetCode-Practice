using System.Numerics;

namespace BitManipulation.BitManipulation
{
    public class AddTwoNumbers
    {
        //https://neetcode.io/problems/reverse-bits
        //Iterate through the n value, checking if the bits are set
        //If they are, set the bit at 31-i
        public uint ReverseBits(uint n)
        {
            uint result = 0;

            for (int i = 0; i < 32; i++)
            {
                var bitToSwap = (uint)(n & 1 << i);

                if(bitToSwap!=0)
                {
                    result |= (uint) 1 << 31 - i;
                }
            }

            return result;
        }


        [Fact]
        public void Test1()
        {
            var expected = 2818572288u;

            var actual = ReverseBits(21u);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            var expected = 964176192u;

            var actual = ReverseBits(43261596u);

            Assert.Equal(expected, actual);
        }
    }
}