using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeetCode.Permutations
{
    public class PermuteSolution
    {
        //https://neetcode.io/problems/permutations
        public List<List<int>> Permute(int[] nums)
        {
            //Recrusion, Foreach, Take a random other number. Bruteforce is a triple loop.
            var result = new List<List<int>>();

            CalculatePermutation(nums.ToList(), new List<int>(), result);

            return result;

        }

        private void CalculatePermutation(List<int> numsToTake, List<int> subset, List<List<int>> result)
        {
            //If Nums to take is empty, add it to the result
            if (numsToTake.Count <= 0)
            {
                result.Add(subset);
                return;
            }
            
            for(int i =0; i < numsToTake.Count; i++)
            {
                var newOptions = new List<int>(numsToTake);
                newOptions.RemoveAt(i);

                var newSubset = new List<int>(subset);
                var addedElement = numsToTake[i];
                newSubset.Add(addedElement);

                CalculatePermutation(newOptions, newSubset, result);
            }
        }

        [Fact]
        public async Task Test1()
        {
            var result = Permute(new int[] { 1, 2, 3 });
        }
    }
}