using System.Threading.Tasks;
using System.Collections.Generic;

namespace NeetCode.HashTable
{
    public class PairSumsSolution
    {
        public static int numberOfWays(int[] arr, int k)
        {
            var hashSet = new HashSet<int>();

            foreach (var i in arr)
            {
                hashSet.Add(i);
            }

            var result = 0;

            foreach (var i in arr)
            {
                var target = k - i;

                if (hashSet.Contains(target))
                {
                    result++;
                }
            }

            return result/2;
        }
    }
}