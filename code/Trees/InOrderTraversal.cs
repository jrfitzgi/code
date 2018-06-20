using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Trees
{
    // Given a binary tree, return the inorder traversal of its nodes' values.
    // Can you do it iteratively?
    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/786/

    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public partial class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            InorderTraversal_Iterative(list, root);
            return list;
        }

        private void InorderTraversal_Iterative(IList<int> list, TreeNode root)
        {
            if (root == null) { return; }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;

            while (node != null || stack.Count() > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }

                node = stack.Pop();
                list.Add(node.val);
                node = node.right;

            }
        }

        private void InorderTraversal_Recursive(IList<int> list, TreeNode node)
        {
            if (node == null) { return; }


            if (node.left != null)
            {
                InorderTraversal_Recursive(list, node.left);
            }

            list.Add(node.val);

            if (node.right != null)
            {
                InorderTraversal_Recursive(list, node.right);
            }
        }
    }
}
