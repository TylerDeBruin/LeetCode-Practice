using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class MinCostClimbingStairsSolution
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            return Math.Min(DepthFirstSearch(cost, 0), DepthFirstSearch(cost, 1));
        }

        private int DepthFirstSearch(int[] cost, int startIndex)
        {
            if (startIndex > cost.Length - 1) return 0;

            var result = cost[startIndex] + Math.Min(DepthFirstSearch(cost, startIndex + 1), DepthFirstSearch(cost, startIndex + 2));

            return result;
        }
    }
}