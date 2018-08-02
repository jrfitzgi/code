using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Trees.Implementation
{
    class TrieNode
    {
        public TrieNode[] Children;
        public bool IsLeaf;

        public TrieNode()
        {
            this.Children = new TrieNode[26];
            this.IsLeaf = false;
        }
    }

    class Trie
    {
        public static void Run()
        {
            Trie trie = new Trie();

            string word = "hello";
            trie.Insert(word);
            Console.WriteLine($"Does {word} exist? {trie.Search(word)}");

            word = "hell";
            Console.WriteLine($"Does {word} exist? {trie.Search(word)}");
            trie.Insert(word);
            Console.WriteLine($"Does {word} exist? {trie.Search(word)}");

        }

        private TrieNode Root;

        public Trie()
        {
            Root = new TrieNode();
        }

        public void Insert(string s)
        {
            this.InsertHelper(s, 0, this.Root);
        }

        private void InsertHelper(string s, int start, TrieNode root)
        {
            if (start >= s.Length)
            {
                root.IsLeaf = true;
                return;
            }

            int ascii = s[start] - 'a';
            
            if (root.Children[ascii] == null)
            {
                root.Children[ascii] = new TrieNode();
            }

            InsertHelper(s, start + 1, root.Children[ascii]);

        }

        public bool Search(string s)
        {
            TrieNode node = this.Root;

            for (int i=0; i < s.Length; i++)
            {
                int ascii = s[i] - 'a';

                if (node.Children[ascii] != null)
                {
                    // keep going
                    node = node.Children[ascii];

                }
                else
                {
                    return false;
                }
            }

            return node.IsLeaf;
        }
    }
}
