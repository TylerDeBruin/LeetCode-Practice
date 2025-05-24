using System.Linq;
using System.Threading.Tasks;

namespace NeetCode.BinarySearch
{
    public class MinEatingSpeedSolution
    {
        //https://neetcode.io/problems/eating-bananas
        //Piles is the Piles of bananas, of size i_th - While h is the number of hours to eat the bananas.
        public int MinEatingSpeed(int[] piles, int h)
        {
            //Binary search 'guesses' to minimize the result.

            //h is the max, while 1 is the min.
            var left = 1;
            var right = piles.Max();

            //Minimize the value K;
            //Assume the default rate 0;
            var result = int.MaxValue;

            while (left <= right)
            {
                var midPoint = (int)Math.Floor(((double)right + left) / 2);

                var totalHours = 0;
                for (int i = 0; i < piles.Length; i++)
                {
                    totalHours += (int)Math.Ceiling((double)piles[i] / midPoint);
                }

                //If the total hours it takes exceeds the max or matches, increment the low end.
                if (totalHours <= h)
                {
                    right = midPoint - 1;

                    result = Math.Min(result, midPoint);
                }
                else
                {
                    left = midPoint+1;
                }
            }

            return result;
        }

        [Fact]
        public async Task Test1()
        {
            Assert.Equal(2, MinEatingSpeed(new int[]{1,4,3,2}, 9));
        }

        [Fact]
        public async Task Test2()
        {
            Assert.Equal(25, MinEatingSpeed(new int[] { 25, 10, 23, 4}, 4));
        }
    }
}