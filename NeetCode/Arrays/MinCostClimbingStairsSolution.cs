using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class MinCostClimbingStairsSolution
    {
        //https://leetcode.com/problems/min-cost-climbing-stairs/
        public int MinCostClimbingStairs(int[] cost)
        {
            var memo = new int[cost.Length];
            Array.Fill(memo, -1);

            return Math.Min(DepthFirstSearch(cost, 0, memo), DepthFirstSearch(cost, 1, memo));
        }

        private int DepthFirstSearch(int[] cost, int startIndex, int[] memoization)
        {
            if (startIndex > cost.Length - 1) return 0;

            //Return the already computed cost of taking a step from this position.
            if (memoization[startIndex] != -1) return memoization[startIndex];

            //If its not in the memoization array, then compute it and store it. 
            memoization[startIndex] = cost[startIndex] + Math.Min(DepthFirstSearch(cost, startIndex + 1, memoization), DepthFirstSearch(cost, startIndex + 2, memoization));

            return memoization[startIndex];
        }
    }
}