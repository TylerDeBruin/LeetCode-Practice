using System.Numerics;
using System.Text;
using ExpectedObjects;

namespace NeetCode.GraphTraversal
{
    public class SubsetsSolution
    {
        //https://neetcode.io/problems/subsets
        //2^n amount of subsets, where n is the length of the subset
        //Greedy Algorithm
        public List<List<int>> Subsets(int[] nums)
        {
            var result = new List<List<int>>();
            var subset = new List<int>(); //EmptySet

            //Take in the Set, the startpoint (index 0), The result, and the initial subset (empty set)
            DepthFirstSearch(nums, 0, result, subset);

            return result;
        }

        //Treat it as a DFS traversal, where at each point the left path will take a subset containing the number
        //And the right path removes the number.
        private void DepthFirstSearch(int[] set, int startIndex, List<List<int>> result, List<int> subset)
        {
            if (startIndex >= set.Length)
            {
                //Return the subset, end of the graph
                var completedSubset = new List<int>(subset);
                result.Add(completedSubset);
            }
            else
            {
                //Take the Left Branch
                subset.Add(set[startIndex]);
                DepthFirstSearch(set, startIndex + 1, result, subset);

                //Take the path without this value, by removing it
                subset.RemoveAt(subset.Count - 1);
                DepthFirstSearch(set, startIndex + 1, result, subset);
            }
        }





        [Fact]
        public void Test1()
        {
            var l1 = new int[] { 1, 2, 3};

            var expected = new int[][]
            {
                new int[0],
                new int[1]{1},
                new int[1]{2},
                new int[2]{1,2},
                new int[1]{3},
                new int[2]{1,3},
                new int[2]{2,3},
                new int[3]{1,2,3}
            };

            var actual = Subsets(l1);

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void Test2()
        {
            var l1 = new int[] { 7 };

            var expected = new int[][]
            {
                new int[0],
                new int[1]{7}
            };

            var actual = Subsets(l1);

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}