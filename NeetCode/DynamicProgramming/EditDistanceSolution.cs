namespace NeetCode.DynamicProgramming
{
    public class EditDistanceSolution
    {
        //https://neetcode.io/problems/edit-distance
        public int MinDistance(string word1, string word2)
        {
            var matrix = new int[word1.Length+1, word2.Length+1];

            //Levenshtien distance
            //Initialize First Column to the count
            for (int i = 0; i < word1.Length+1; i++)
            {
                matrix[i, 0] = i;
            }

            //Initialize First Row to the count
            for (int j = 0; j < word2.Length+1; j++)
            {
                matrix[0, j] = j;
            }

            //3 Options:
            //matrix[i - 1][j],    # Delete
            //matrix[i][j - 1],    # Insert
            //matrix[i - 1][j - 1]   # Replace
            for (int i = 1; i < word1.Length + 1; i++)
            {
                for (int j = 1; j < word2.Length + 1; j++)
                {
                    //If the letters are equal, no change
                    //take the corner top left
                    if (word1[i-1] == word2[j-1])
                    {
                        matrix[i, j] = matrix[i-1, j-1];
                    }
                    else
                    {
                        var min1 = Math.Min(
                            matrix[i-1, j],
                            matrix[i, j-1]
                            );

                        var min2 = Math.Min(
                            min1,
                            matrix[i -1, j -1]
                            );

                        matrix[i, j] = 1 + min2;
                    }
                    
                }
            }

            return matrix[word1.Length, word2.Length];
        }

        [Fact]
        public void Test1()
        {
            var expected = 2;

            var actual = MinDistance("monkeys", "money");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            var expected = 3;

            var actual = MinDistance("neatcdee", "neetcode");

            Assert.Equal(expected, actual);
        }
    }
}