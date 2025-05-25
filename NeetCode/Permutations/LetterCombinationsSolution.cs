using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeetCode.Permutations
{
    public class LetterCombinationsSolution
    {
        private readonly Dictionary<char, List<char>> _lookup;

        public LetterCombinationsSolution()
        {
            _lookup = new Dictionary<char, List<char>>
            {
                { '2', new List<char> { 'a', 'b', 'c' } },
                { '3', new List<char> { 'd', 'e', 'f' } },
                { '4', new List<char> { 'g', 'h', 'i' } },
                { '5', new List<char> { 'j', 'k', 'l' } },
                { '6', new List<char> { 'm', 'n', 'o' } },
                { '7', new List<char> { 'p', 'q', 'r', 's' } },
                { '8', new List<char> { 't', 'u', 'v' } },
                { '9', new List<char> { 'w', 'x', 'y', 'z' } },
            };
        }

        //https://neetcode.io/problems/combinations-of-a-phone-number
        public List<string> LetterCombinations(string digits)
        {
            //Given digits, determine possible charactes on a phone.
            //Permutation = Recursive steps.
            var result = new List<string>();

            Recursive(digits.ToCharArray().ToList(), "", result);

            return result;
        }

        private void Recursive(List<char> remainingDigits, string subset, List<string> result)
        {
            //Base case, Digits are empty.
            if (remainingDigits.Count <= 0)
            {
                if (subset != "")
                {
                    result.Add(subset);
                }
                return;
            }

            var nextDigit = remainingDigits[0];

            var characters = _lookup[nextDigit];

            var remaining = new List<char>(remainingDigits);
            remaining.RemoveAt(0);

            for (int i = 0; i < characters.Count; i++)
            {
                var newSubset = subset + characters[i];

                Recursive(remaining, newSubset, result);
            }
        }




        //[Fact]
        //public async Task Test1()
        //{
        //    var result = LetterCombinationsSolution(new int[] { 1, 2, 3 });
        //}
    }
}