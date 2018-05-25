using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    /*
    Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
    Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function.
    https://leetcode.com/explore/interview/card/top-interview-questions-easy/93/linked-list/553/
    */

     //Definition for singly-linked list.
     public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }
     
    public partial class Solution
    {
        public void DeleteNode(ListNode node)
        {

            if (node == null) return;
            if (node.next == null) return; // node was the tail

            while (node.next != null)
            {
                node.val = node.next.val;

                if (node.next.next != null)
                {
                    node = node.next;
                }
                else
                {
                    node.next = null;
                    break;
                }
            }

        }
    }
}
