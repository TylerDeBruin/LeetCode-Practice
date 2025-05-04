using System.Threading.Tasks;

namespace TestProject1
{
    public class Solution
    {
        public List<int> PartitionLabels(string s)
        {
            var encounteredDictionary = new Dictionary<char, int>();


            for(int i = 0; i < s.Length; i++)
            {
                char letter = s[i];

                if (encounteredDictionary.ContainsKey(letter) )
                {
                    encounteredDictionary[letter] = i;
                }
                else
                {
                    encounteredDictionary.Add(letter, i);
                }
            }

            var result = new List<int>();

            int size = 0;
            int currentEnd = 0;
            for (int i = 0; i < s.Length; i++)
            {
                size += 1;

                char letter = s[i];

                if (encounteredDictionary[letter] >= currentEnd)
                {
                    currentEnd = encounteredDictionary[letter];
                }

                if (currentEnd == i)
                {
                    result.Add(size);

                    size = 0;
                }
            }

            return result;
        }



        [Fact]
        public async Task Test1()
        {
            var input = "xyxxyzbzbbisl";

            var expected = new List<int> { 5, 5, 1, 1, 1 };

            var actual = PartitionLabels(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Test2()
        {
            var input = "abcabc";

            var expected = new List<int> { 6 };

            var actual = PartitionLabels(input);

            Assert.Equal(expected, actual);
        }
    }
}