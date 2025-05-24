using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace NeetCode.BinarySearch
{
    public class RotatedBinarySearchSolution
    {
        public int Search(int[] nums, int target)
        {
            var pivot = FindPivot(nums);

            int left, right;

            // If array is not rotated at all
            if (pivot == 0 || target < nums[0])
            {
                // Search in the second half
                left = pivot;
                right = nums.Length - 1;
            }
            else
            {
                // Search in the first half
                left = 0;
                right = pivot - 1;
            }
            
            while (left <= right)
            {
                var mid = (right + left) / 2;

                var middleValue = nums[mid];

                if (middleValue == target)
                    return mid;

                if (middleValue < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        private int FindPivot(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var mid = (right + left) / 2;

                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        [Fact]
        public void FindPivot_Test1()
        {
            Assert.Equal(4, FindPivot(new int[] { 3, 4, 5, 6, 1, 2 }));
        }

        [Fact]
        public void FindPivot_Test2()
        {
            Assert.Equal(3, FindPivot(new int[] { 3, 5, 6, 0, 1, 2 }));
        }

        [Fact]
        public void FindPivot_Test3()
        {
            Assert.Equal(4, FindPivot(new int[] { 4, 5, 6, 7, 0, 1, 2 }));
        }

        [Fact]
        public void FindPivot_Test4()
        {
            Assert.Equal(0, FindPivot(new int[] { 1 }));
        }

        [Fact]
        public void FindPivot_Test5()
        {
            Assert.Equal(0, FindPivot(new int[] { 1, 3 }));
        }

        [Fact]
        public void FindPivot_Test6()
        {
            Assert.Equal(1, FindPivot(new int[] { 3, 1 }));
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(4, Search(new int[] { 3, 4, 5, 6, 1, 2 }, 1));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(-1, Search(new int[] { 3, 5, 6, 0, 1, 2 }, 4));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(4, Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(-1, Search(new int[] { 1 }, 0));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(1, Search(new int[] { 1, 3 }, 3));
        }

        [Fact]
        public void Test6()
        {
            Assert.Equal(0, Search(new int[] { 3, 1}, 3));
        }
    }
}