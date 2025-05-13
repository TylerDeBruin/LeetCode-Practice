using System.Numerics;
using System.Text;
using System.Xml.Linq;
using ExpectedObjects;
using NeetCode.BinaryTreeDepthSolution;

namespace NeetCode.GraphTraversal
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

    public class KthSmallestValueSolution
    {
        //https://neetcode.io/problems/kth-smallest-integer-in-bst
        public int KthSmallest(TreeNode root, int k)
        {
            var result = new List<int>();

            var stack = new Stack<TreeNode>();

            stack.Push(root);

            TreeNode node = stack.Pop();
            while (node != null)
            {
                if (node.left != null) stack.Push(node.left);
                if (node.right != null) stack.Push(node.right);

                result.Add(node.val);

                stack.TryPop(out node);
            }

            result.Sort();

            return result[k - 1];
        }


        [Fact]
        public void Test1()
        {
            var l1 = new TreeNode(2);

            l1.right = new TreeNode(1); 

            l1.left = new TreeNode(3);

            var actual = KthSmallest(l1, 1);

            Assert.Equal(1, actual);
        }
    }
}