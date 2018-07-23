using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Design.Codec
{

    /*
    Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

    Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

    */

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Codec
    {
        public static void Test()
        {
            TreeNode node = new TreeNode(0);
            node.left = new TreeNode(1);
            node.right = new TreeNode(2);
            node.left.left = new TreeNode(33);
            node.right.right = new TreeNode(66);

            Codec c = new Codec();
            string s = c.serialize(node);

            Console.WriteLine(s);

            TreeNode d = c.deserialize(s);
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) { return null; }

            StringBuilder sb = new StringBuilder();
            serializeHelper(root, sb);

            return sb.ToString();
        }

        private void serializeHelper(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("n,");
                return;
            }

            sb.Append(root.val + ",");
            serializeHelper(root.left, sb);
            serializeHelper(root.right, sb);
        }


        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == null) { return null; }

            string[] data2 = data.Split(',');

            int index = -1;
            return deserializeHelper(data2, ref index);
        }

        private TreeNode deserializeHelper(string[] data, ref int index)
        {
            index++;

            if (index >= data.Length - 1)
            {
                return null;
            }


            if (data[index] == "n")
            {
                return null;
            }

            
            TreeNode node = new TreeNode(Convert.ToInt32(data[index]));
            node.left = deserializeHelper(data, ref index);
            node.right = deserializeHelper(data, ref index);

            return node;
        }

    }
    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
