using System.Threading.Tasks;

namespace NeetCode.TwoPointers
{
    public class MaxAreaSolution
    {
        public int MaxArea(int[] heights)
        {
            int left = 0, right = heights.Length-1;

            var result = 0;

            while (left < right)
            {
                var leftVal = heights[left];
                var rightVal = heights[right];

                var x = Math.Min(leftVal, rightVal);
                var y = right - left;

                var area = x * y;

                result = Math.Max(area, result);

                if (leftVal >= rightVal)
                {
                    right--;
                }
                else if (leftVal < rightVal)
                {
                    left++;
                }
            }

            return result;
        }

    }
}