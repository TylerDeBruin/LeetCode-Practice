using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace NeetCode.Meta
{
    public class ThreeSumSolution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
           
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                // Array is sorted - Skip trying the number again if its repeated.
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;


                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Skip duplicates for second and third elements
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++; // we need a larger value
                    }
                    else
                    {
                        right--; // we need a smaller value
                    }
                }
            }

            return result;
        }
    }
}