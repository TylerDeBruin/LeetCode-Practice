using System.Numerics;
using System.Text;
using ExpectedObjects;

namespace NeetCode.GraphTraversal
{
    public class MaxAreaOfIslandSolution
    {
        //https://neetcode.io/problems/max-area-of-island
        public int MaxAreaOfIsland(int[][] grid)
        {
            int area = int.MinValue;

            for(int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    area = Math.Max(area, DepthFirstSearch(i, j, grid));
                }
            }

            return area;
        }

        private int DepthFirstSearch(int i, int j, int[][] grid)
        {
            if (i >= grid.Length || j >= grid[0].Length) 
                return 0;

            if (i < 0 || j < 0)
                return 0;

            if (grid[i][j] == 0) 
                return 0;

            //Make sure to visit the island.
            grid[i][j] = 0;

            var up = DepthFirstSearch(i - 1, j, grid);
            var down = DepthFirstSearch(i + 1, j, grid);
            var left = DepthFirstSearch(i, j - 1, grid);
            var right = DepthFirstSearch(i, j + 1, grid);

            var result = 1 + up + down + left + right;

            return result;
        }


        [Fact]
        public void Test1()
        {
            var grid = new int[][]
            {
                  new int[]{0,1,1,0,1},
                  new int[]{1,0,1,0,1},
                  new int[]{0,1,1,0,1},
                  new int[]{0,1,0,0,1}
            };

            var expected = 6;

            var actual = MaxAreaOfIsland(grid);

            expected.ToExpectedObject().ShouldMatch(actual);
        }


        [Fact]
        public void Test2()
        {
            var grid = new int[][]
            {
                  new int[]{1,1,1,1,1},
            };

            var expected = 5;

            var actual = MaxAreaOfIsland(grid);

            expected.ToExpectedObject().ShouldMatch(actual);
        }


        [Fact]
        public void Test3()
        {
            var grid = new int[][]
            {
                new int[]{0,0,1,0,0,0,0,1,0,0,0,0,0},
                new int[]{0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[]{0,1,1,0,1,0,0,0,0,0,0,0,0},
                new int[]{0,1,0,0,1,1,0,0,1,0,1,0,0},
                new int[]{0,1,0,0,1,1,0,0,1,1,1,0,0},
                new int[]{0,0,0,0,0,0,0,0,0,0,1,0,0},
                new int[]{0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[]{0,0,0,0,0,0,0,1,1,0,0,0,0}
            };

            var expected = 6;

            var actual = MaxAreaOfIsland(grid);

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}