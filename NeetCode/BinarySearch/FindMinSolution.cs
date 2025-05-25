using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NeetCode.BinarySearch
{
    public class FindMinSolution
    {
        //https://neetcode.io/problems/find-minimum-in-rotated-sorted-array
        public int FindMin(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var mid = (left + right) / 2;

                var leftNumber = nums[mid];
                var rightNumber = nums[right];

                if (leftNumber > rightNumber)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return nums[left];
        }

        [Fact]
        public async Task Test1()
        {
            Assert.Equal(1, FindMin(new int[]{ 3, 4, 5, 6, 1, 2 }));
        }

        [Fact]
        public async Task Test2()
        {
            Assert.Equal(0, FindMin(new int[] { 4, 5, 0, 1, 2, 3 }));
        }


        [Fact]
        public async Task Test3()
        {
            Assert.Equal(4, FindMin(new int[] { 4, 5, 6, 7 }));
        }
    }
}