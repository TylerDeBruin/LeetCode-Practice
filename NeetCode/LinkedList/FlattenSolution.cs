using System;
using System.ComponentModel.DataAnnotations;
using ExpectedObjects;
using NeetCode.BinaryTreeDepthSolution;

namespace NeetCode.LinkedList
{
    public class FlattenSolution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public void Flatten(TreeNode root)
        {

            if (root != null)
            {
                var flattenedList = new List<TreeNode>();

                FlattenRecursive(root, flattenedList);

                for (int i = 0; i < flattenedList.Count - 1; i++)
                {
                    flattenedList[i].left = null;
                    flattenedList[i].right = flattenedList[i + 1];
                }

                flattenedList[flattenedList.Count - 1].left = null;
            }
        }

        private void FlattenRecursive(TreeNode node, List<TreeNode> result)
        {
            if (node == null)
                return;

            result.Add(node);

            FlattenRecursive(node.left, result);
            FlattenRecursive(node.right, result);
        }
    }
}