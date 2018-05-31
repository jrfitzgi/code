using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.LinkedList
{

    /**
     * 
     * Given a singly linked list, determine if it is a palindrome.
     * https://leetcode.com/explore/interview/card/top-interview-questions-easy/93/linked-list/772/
     * 
    /*

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
        public bool IsPalindrome_LinkedList(ListNode head)
        {

            if (head == null) return true;

            // reverse half the list
            int length = 0;
            ListNode n = head;
            while (n != null)
            {
                length++;
                n = n.next;
            }

            ListNode head2 = head;
            for (int i = 0; i < Math.Ceiling((double)length / 2); i++)
            {
                head2 = head2.next;
            }

            ListNode previous = null;
            ListNode current = head2;

            while (current != null)
            {
                ListNode tempNext = current.next;
                current.next = previous;
                previous = current;
                current = tempNext;
            }

            head2 = previous;

            // now compare head and head2, element for element
            // if there are odd number of nodes, ignore the middle one since it won't matter for palindrome
            for (int i = 0; i < length / 2; i++)
            {
                if (head.val != head2.val) { return false; }
                head = head.next;
                head2 = head2.next;
            }

            return true;

        }
    }
}
