using System.Threading.Tasks;

namespace NeetCode.TwoPointers
{
    public class LongestPalindromeSolution
    {
        public string LongestPalindrome(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                int start = 0;
                int end = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    int evenPalindrome = ExpandFromCenter(s, i, i);
                    int oddPalindrome = ExpandFromCenter(s, i, i + 1);

                    int len = Math.Max(evenPalindrome, oddPalindrome);

                    if (len > end - start)
                    {
                        start = i - (len - 1) / 2;
                        end = i + len / 2;
                    }
                }

                return s.Substring(start, end - start + 1);
            }

            return "";

        }

        private int ExpandFromCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            var resultLength = right - left - 1;

            return resultLength;
        }

        [Fact]
        public void Test1()
        {
            var input = "babad";

            var actual = LongestPalindrome(input);

            Assert.Equal("aba", actual);
        }

        [Fact]
        public void Test2()
        {
            var input = "cbbd";

            var actual = LongestPalindrome(input);

            Assert.Equal("bb", actual);
        }
    }
}