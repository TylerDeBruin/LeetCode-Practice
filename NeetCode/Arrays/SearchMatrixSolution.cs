namespace NeetCode.Arrays
{
    public class SearchMatrixSolution
    {
        //https://leetcode.com/problems/search-a-2d-matrix/description/
        //Binary Search the first column. The binary search is capturing the index of the row 1 above
        //the row the element is actually contained in, so left -1 must be applied to find the actual row.
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var firstRowItem = new List<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                firstRowItem.Add(matrix[i][0]);
            }

            var left = 0;
            var right = firstRowItem.Count - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;

                var element = firstRowItem[mid];

                if (target < element)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            int row = left - 1;
            if (row < 0)
                return false;

            var foundIndex = Array.BinarySearch(matrix[row], target);

            var result = foundIndex >= 0;

            return result;
        }
    }

} 
