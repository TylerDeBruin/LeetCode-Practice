using System.Threading.Tasks;

namespace NeetCode.Arrays
{
    public class LongestConsecutiveSolution
    {
        public int LongestConsecutive(int[] nums)
        {
            var numbers = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                numbers.Add(nums[i]);
            }


            var result = new Dictionary<int, int>();

            var max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var iteratedMax = 1;

                var currentValue = nums[i];

                while (numbers.Contains(currentValue - 1))
                {
                    iteratedMax++;
                    currentValue -= 1;
                }

                currentValue = nums[i];
                while (numbers.Contains(currentValue + 1))
                {
                    iteratedMax++;
                    currentValue += 1;
                }

                max = Math.Max(max, iteratedMax);
            }

            return max;
        }


        [Fact]
        public async Task Test1()
        {
            var input = new int[] { 2, 20, 4, 10, 3, 4, 5 };

            var actual = LongestConsecutive(input);

            Assert.Equal(4, actual);
        }
    }



}