using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode.MathPuzzle
{
    public class DifferenceOfSumsSolution
    {
        //https://leetcode.com/problems/difference-between-element-sum-and-digit-sum-of-an-array/description/
        public int DifferenceOfSums(int n, int m)
        {
            var nValues = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % m != 0)
                {
                    nValues += i;
                }
            }

            var mValues = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % m == 0)
                {
                    mValues += i;
                }
            }

            return nValues - mValues;
        }
    }
} 
