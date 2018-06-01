using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    // Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
    // For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/631/

    public partial class Solution
    {
        public void PrintTree(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode node = q.Dequeue();

                if (node == null) { Console.Write("null, "); continue; }
                else { Console.Write(node.val + ", "); }
                
                q.Enqueue(node.left);
                q.Enqueue(node.right);

            }

            Console.WriteLine();
        }

        public void SortedArrayToBST()
        {
            int[] bstArray = new int[5] { -10, -3, 0, 5, 9 };
            TreeNode result = SortedArrayToBST(bstArray);
            PrintTree(result);
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null) { return null; }
            if (nums.Length == 0) { return null; }

            return SortedArrayToBSTHelper(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBSTHelper(int[] nums, int start, int end)
        {
            int mid = (int)Math.Ceiling((start + end) / 2.0);
            TreeNode node = new TreeNode(nums[mid]);

            int leftStart = start;
            int leftEnd = mid - 1;
            if (leftEnd - leftStart >= 0)
            {
                node.left = SortedArrayToBSTHelper(nums, leftStart, leftEnd);
            }

            int rightStart = mid + 1;
            int rightEnd = end;
            if (rightEnd - rightStart >= 0)
            {
                node.right = SortedArrayToBSTHelper(nums, rightStart, rightEnd);
            }

            return node;
        }
    }
}
