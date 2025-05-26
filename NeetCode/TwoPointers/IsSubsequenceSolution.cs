using System.Threading.Tasks;

namespace NeetCode.TwoPointers
{
    public class IsSubsequenceSolution
    {
        public bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            var newSequencePointer = 0;

            for (int i = 0; i < t.Length; i++)
            {
                if (s[newSequencePointer] == t[i])
                    newSequencePointer++;

                if (newSequencePointer >= s.Length)
                    return true;
            }

            return false;
        }
    }
}