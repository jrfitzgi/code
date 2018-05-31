using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    /*
    Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/627/
    */

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

        public void IsSymmetric()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(5);

            bool result = IsSymmetric(root);
            Console.WriteLine("IsSymmetric: " + result);
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return CompareNodes(root.left, root.right);
        }

        public bool CompareNodes(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) { return true; }
            else if (left == null || right == null) { return false; }
            else if (left.val != right.val) { return false; }

            bool nodesMatch = CompareNodes(left.left, right.right) && CompareNodes(left.right, right.left);

            return nodesMatch;

        }

        public bool IsSymmetric_Iterative(TreeNode root)
        {
            if (root == null) return true;

            // which level of the tree we are one
            int level = 0;
            int nodesInLevel = (int)Math.Pow(2, level);
            int?[] treeLevel = new int?[nodesInLevel];
            int i = 0;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode node = q.Dequeue();
                if (node != null)
                {
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }

                treeLevel[i] = node == null ? (int?)null : node.val;
                i++;

                if (i == nodesInLevel) // we filled up this level
                {
                    if (IsLevelSymmetric(treeLevel) == false)
                    {
                        return false;
                    }

                    // reset everything for the next level
                    level++;
                    nodesInLevel = (int)Math.Pow(2, level);
                    treeLevel = new int?[nodesInLevel];
                    i = 0;
                }
            }

            return true;
        }

        private bool IsLevelSymmetric(int?[] treeLevel)
        {
            for (int i = 0; i < treeLevel.Length / 2; i++)
            {
                if (treeLevel[i] != treeLevel[treeLevel.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
