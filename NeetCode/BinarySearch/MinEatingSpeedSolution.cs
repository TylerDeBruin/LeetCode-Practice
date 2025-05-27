using System.Linq;
using System.Threading.Tasks;

namespace NeetCode.BinarySearch
{
    public class MinEatingSpeedSolution
    {
        //https://leetcode.com/problems/koko-eating-bananas/submissions/1645520947/
        //Simplified - Binary search the rate at which bananas can be eaten.
        //Piles is the Piles of bananas, of size i_th - While h is the number of hours to eat the bananas.
        public int MinEatingSpeed(int[] piles, int h)
        {
            //Binary search 'guesses' to minimize the result.

            //h is the max, while 1 is the min.
            var left = 1;
            var right = piles.Max();

            //Minimize the value K;
            //Assume the default rate 0;
            var result = right;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                long totalHours = 0;

                foreach (int pile in piles)
                {
                    totalHours += ((long)pile + mid - 1) / mid; // Ceiling without using Math
                }

                if (totalHours <= h)
                {
                    result = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
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