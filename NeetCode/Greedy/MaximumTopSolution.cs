using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace NeetCode.Greedy
{
    public class MaximumTopSolution
    {
        //https://leetcode.com/problems/maximize-the-topmost-element-after-k-moves/
        public int MaximumTop(int[] nums, int k)
        {
            //Nothing to do, return -1
            if (nums.Length <= 0)
                return -1;

            //No moves, return the top.
            if (k == 0)
                return nums[0];

            //You can only remove the top - so the second will become the top.
            if (k == 1)
            {
                if (nums.Length > 1)
                    return nums[1];
                else
                    return -1;
            }

            //You have 1 element, you have to remove 
            //So if you have 2 moves - you'll put that number back in
            //Otherwise you pop it, and now you have nothing.
            if (nums.Length == 1)
            {
                if (k % 2 == 0)
                    return nums[0];
                else if (k % 2 == 1)
                    return -1;
            }

            int max = nums.Take(k - 1).Max();
            if (k < nums.Length)
                max = Math.Max(max, nums[k]);

            return max;
        }

    }
}