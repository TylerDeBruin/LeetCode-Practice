using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class FindMedianSortedArraysSolution
    {
        //Each sorted in ascending order, different sizes m and n
        //Put together, sort - find the median.
        //Need to do this in O( log (m + n) )
        //Log means Binary search
        //https://neetcode.io/problems/median-of-two-sorted-arrays
        //Binary Search to Partition the arrays into 2 parts. 
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var totalSize = nums1.Length + nums2.Length;
            var leftPartitionSize = totalSize / 2;

            int[] smallerArray = nums1;
            int[] biggerArray = nums2;

            if(smallerArray.Length > biggerArray.Length)
            {
                smallerArray = nums2;
                biggerArray = nums1;
            }


            var left = 0;
            var right = smallerArray.Length ;
            while(true)
            {
                int i = (left + right) / 2; //i should be smaller

                int j = leftPartitionSize - i;

                var smallerArrayLeft = i > 0 ? smallerArray[i-1] : int.MinValue;
                var smallerArrayRight = i < smallerArray.Length ? smallerArray[i] : int.MaxValue;


                var biggerArrayLeft = j > 0 ? biggerArray[j-1] : int.MinValue;
                var biggerArrayRight = j < biggerArray.Length ? biggerArray[j] : int.MaxValue;


                if(smallerArrayLeft <= biggerArrayRight && biggerArrayLeft <= smallerArrayRight)
                {
                    //Handle Odd Case: 
                    if(totalSize % 2 != 0)
                    {
                        return Math.Min(smallerArrayRight, biggerArrayRight);
                    }
                    else
                    {
                        return (Math.Max(smallerArrayLeft, biggerArrayLeft) + Math.Min(smallerArrayRight, biggerArrayRight)) / 2.0;
                    }
                }
                else if (smallerArrayLeft > biggerArrayRight)
                {
                    right = i - 1;
                }
                else
                {
                    left = i + 1;
                }

            }


        }



        [Fact]
        public void Test1()
        {
            var s = new int[] { 1, 2 };
            var t = new int[] { 3 };

            var actual = FindMedianSortedArrays(s, t);

            Assert.Equal(actual, 2.0);
        }

        [Fact]
        public void Test2()
        {
            var s = new int[] { 1, 3 };
            var t = new int[] { 2, 4 };

            var actual = FindMedianSortedArrays(s, t);

            Assert.Equal(actual, 2.5);
        }

        [Fact]
        public void Test3()
        {
            var s = new int[] { 1, 2 };
            var t = new int[] { 3, 4 };

            var actual = FindMedianSortedArrays(s, t);

            Assert.Equal(actual, 2.5);
        }
    }
}