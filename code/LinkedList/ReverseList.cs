using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    // Reverse a singly linked list.
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/93/linked-list/560/

    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public partial class Solution
    {
        public ListNode ReverseList_Recursive(ListNode head)
        {

            if (head == null) return head;
            if (head.next == null) return head;

            ListNode newHead = ReverseList_Recursive(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;

        }


        public ListNode ReverseList_Iterative(ListNode head)
        {
            ListNode current = head;
            ListNode previous = null;

            while (current != null)
            {
                ListNode tempNext = current.next;
                current.next = previous;
                previous = current;
                current = tempNext;
            }

            return previous;
        }
    }
}
