using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode.Arrays
{
    public class RotateArraySolution
    {
        //https://leetcode.com/problems/rotate-array/?envType=study-plan-v2&envId=top-interview-150
        public void Rotate(int[] nums, int k)
        {
            //K bounded to length of the array
            k = k % nums.Length;

            //Reverse the whole array
            //[1,2,3,4,5] Rotated by 2 becomes [4, 5, 1, 2, 3]
            //-> [5,4,3,2,1]
            ReverseInPlace(nums, 0, nums.Length - 1);
            //->[4,5,3,2,1]
            ReverseInPlace(nums, 0, k - 1);
            //->[4,5,1,2,3]
            ReverseInPlace(nums, k, nums.Length - 1);
        }

        private void ReverseInPlace(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int valueToCopy = nums[start];
                nums[start] = nums[end];
                nums[end] = valueToCopy;
                start++;
                end--;
            }
        }
    }

} 
