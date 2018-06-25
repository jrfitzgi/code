using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.LinkedList.AddTwoNumbers
{
    // You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
    // You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/107/linked-list/783/

    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode l3 = result;

            while (true)
            {
                l3.next = new ListNode(0);
                l3.val = SumNodes(l1, l2) + l3.val;
                if (l3.val >= 10)
                {
                    l3.val = l3.val - 10;
                    l3.next.val = 1;
                }

                if (l1 != null) { l1 = l1.next; }
                if (l2 != null) { l2 = l2.next; }
                if (l1 == null && l2 == null) // at the end of both lists
                {
                    if (l3.next.val == 0) // if we didn't carry over a 1, remove the last node which contains 0
                    {
                        l3.next = null;
                    }
                    break;
                }

                l3 = l3.next;

            }

            return result;
        }

        private int SumNodes(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null) { return 0; }
            if (l1 == null) { return l2.val; }
            if (l2 == null) { return l1.val; }

            return l1.val + l2.val;
        }
    }
}
