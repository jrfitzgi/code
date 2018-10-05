using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Graphs.WordLadder
{
    /*
    Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:

    Only one letter can be changed at a time.
    Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
    Note:

    Return 0 if there is no such transformation sequence.
    All words have the same length.
    All words contain only lowercase alphabetic characters.
    You may assume no duplicates in the word list.
    You may assume beginWord and endWord are non-empty and are not the same.
    Example 1:

    Input:
    beginWord = "hit",
    endWord = "cog",
    wordList = ["hot","dot","dog","lot","log","cog"]

    Output: 5

    Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
    return its length 5.

    https://leetcode.com/problems/word-ladder/description/
    */

    public class Solution
    {
        public static void Run()
        {
            string beginWord = "hot";
            string endWord = "dog";
            List<string> wordList = new List<string>() { "dog", "cog", "pot", "dot" };

            Solution s = new Solution();
            int result = s.LadderLength(beginWord, endWord, wordList);

            Console.WriteLine(result);
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            wordList.Add(beginWord);
            Dictionary<string, List<string>> graph = ConstructGraph(wordList);

            HashSet<string> visited = new HashSet<string>();
            visited.Add(beginWord);

            int pathLen = DFS(beginWord, endWord, graph, visited);
            if (pathLen == 0) { return 0; }
            else { return 1 + pathLen; }
        }

        private int DFS(string beginWord, string endWord, Dictionary<string, List<string>> graph, HashSet<string> visited)
        {
            List<string> adjacent = graph[beginWord];
            int minPath = 0;
            for (int i = 0; i < adjacent.Count(); i++)
            {
                string adjWord = adjacent[i];

                if (adjWord == endWord) { return 1; }

                if (visited.Contains(adjWord)) { continue; }
                else { visited.Add(adjWord); }

                int pathLen = DFS(adjWord, endWord, graph, visited);
                if (pathLen == 0)
                {
                    continue;
                }
                else if (minPath == 0 || pathLen < minPath)
                {
                    minPath = pathLen;
                }

            }

            if (minPath == 0) { return 0; }
            else { return minPath + 1; }
        }

        private Dictionary<string, List<string>> ConstructGraph(IList<string> wordList)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < wordList.Count(); i++)
            {
                string word = wordList[i];

                if (!graph.ContainsKey(word))
                {
                    graph.Add(word, new List<string>());
                }
            }

            for (int i = 0; i < wordList.Count(); i++)
            {
                string w1 = wordList[i];

                for (int j = i + 1; j < wordList.Count(); j++)
                {
                    string w2 = wordList[j];

                    if (IsEdge(w1, w2))
                    {
                        graph[w1].Add(w2);
                        graph[w2].Add(w1);
                    }
                }
            }

            return graph;
        }

        private bool IsEdge(string w1, string w2)
        {
            bool mismatch = false;

            for (int i = 0; i < w1.Length; i++)
            {
                if (w1[i] != w2[i])
                {
                    if (mismatch == true) { return false; }
                    else { mismatch = true; }
                }
            }

            return mismatch; // return true iff there is one mismatch
        }
    }
}
