using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode.BinaryTreeDepthSolution
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class BinaryTreeDepthSolution
    {
        //https://neetcode.io/problems/depth-of-binary-tree
        public int MaxDepth(TreeNode root)
        {
            return DepthFirstSearch(root, 0);
        }

        private int DepthFirstSearch(TreeNode root, int index)
        {
            if (root == null)
                return index;

            index++;

            return Math.Max(DepthFirstSearch(root.left, index), DepthFirstSearch(root.right, index));
        }
    }

} 
