using System.Threading.Tasks;

namespace NeetCode.TwoPointers
{
    public class TwoSumSolution
    {
        //https://neetcode.io/problems/two-integer-sum-ii
        //Start at end, shift right if the number target is larger - otherwise shift the left pointer.
        public int[] TwoSum(int[] numbers, int target)
        {

            var left = 0;
            var right = numbers.Length - 1;

            while(true)
            {
                var leftValue = numbers[left];
                var rightValue = numbers[right];

                var sum = leftValue + rightValue;

                if (sum == target)
                    return new int[] { left + 1, right + 1 };

                if (sum > target)
                    right--;

                if (sum < target)
                    left++;
            }

            throw new Exception();
        }
    }
}