using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace NeetCode.Meta
{
    public class RemoveDuplicatesSolution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 0)
                return 0;

            int left = 1;
            int right = 1;

            while (right < nums.Length)
            {
                if (nums[right] != nums[left - 1])
                {
                    nums[left] = nums[right];
                    left++;
                }
                right++;
            }

            return left;
        }
    }
}