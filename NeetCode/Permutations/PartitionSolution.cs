using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeetCode.Permutations
{
    public class PartitionSolution
    {
        public List<List<string>> Partition(string s)
        {
            //Recursion - the base case is to take every string 
            var result = new List<List<string>>();

            Recurse(s, new List<string>(), result);

            return result;
        }

        private void Recurse(string s, List<string> subset, List<List<string>> result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result.Add(subset);
                return;
            }

            var stringToPartition = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                var partition = string.Join("", stringToPartition.Take(i + 1));

                if (IsPalindrome(partition))
                {
                    var newS = string.Join("", stringToPartition.Skip(i+1).Take(stringToPartition.Length - i));

                    var newSubset = new List<string>(subset);

                    newSubset.Add(partition);

                    Recurse(newS, newSubset, result);
                }
            }
        }

        private bool IsPalindrome(string s)
        {
            int j = s.Length - 1;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[j])
                    return false;

                j--;
            }

            return true;
        }

        [Fact]
        public async Task Test1()
        {
            var result = Partition("aab");
        }
    }
}