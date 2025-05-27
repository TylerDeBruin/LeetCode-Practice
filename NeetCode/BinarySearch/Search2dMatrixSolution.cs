using System.Linq;
using System.Threading.Tasks;

namespace NeetCode.BinarySearch
{
    public class Search2dMatrixSolution
    {
        //https://neetcode.io/problems/search-2d-matrix
        public bool SearchMatrix(int[][] matrix, int target)
        {
            for (int i = 0; i < matrix.Length; i++) 
            {
                if(matrix[i][0] <= target)
                {
                    if(i+1 < matrix.Length)
                    {
                        var nextIndex = matrix[i + 1][0];

                        if (target < nextIndex)
                        {
                            return BinarySearch(matrix[i], target);
                        }
                    }
                    else
                    {
                        return BinarySearch(matrix[i], target);
                    }
                }
                else
                {
                    break;
                }
            }

            return false;
        }

        private bool BinarySearch(int[] matrix, int target)
        {
            var result = Array.BinarySearch(matrix, target);

            return result > -1;
        }


        [Fact]
        public async Task Test1()
        {
            var matrix = new int[][]
            { 
                new int[] { 1,2,4,8 },
                new int[] { 10,11,12,13 },
                new int[] { 14,20,30,40 },
            };

            var actual = SearchMatrix(matrix, 10);

            Assert.True(actual);
        }

        [Fact]
        public async Task Test2()
        {
            var matrix = new int[][]
            {
                new int[] { 1,2,4,8 },
                new int[] { 10,11,12,13 },
                new int[] { 14,20,30,40 },
            };

            var actual = SearchMatrix(matrix, 15);

            Assert.False(actual);
        }

        [Fact]
        public async Task Test3()
        {
            var matrix = new int[][]
            {
                new int[] { 1 },
            };

            var actual = SearchMatrix(matrix, 1);

            Assert.True(actual);
        }
    }
}