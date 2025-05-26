using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NeetCode.Arrays
{
    public class FindKthLargestSolution
    {



        public int FindKthLargest(int[] nums, int k)
        {
            var sortedList = new SortedList<int, List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                var key = nums[i];

                if (sortedList.ContainsKey(key))
                {
                    sortedList[key].Add(i);
                }
                else
                {
                    sortedList.Add(key, new List<int>{ i });
                }
            }

            int elementN = 0;
            foreach (var key in sortedList.Keys.Reverse())
            {
                if (k - elementN <= sortedList[key].Count)
                    return key;

                elementN += sortedList[key].Count;
            }

            throw new Exception();
        }


        [Fact]
        public void Test1()
        {
            Assert.Equal(4, FindKthLargest(new int[]{ 2, 3, 1, 5, 4 }, 2));
        }
    }


}
