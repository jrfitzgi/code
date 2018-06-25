using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.LinkedList.GetIntersectionNode
{
    //Write a program to find the node at which the intersection of two singly linked lists begins.


    //For example, the following two linked lists:

    //A:          a1 → a2
    //                   ↘
    //                     c1 → c2 → c3
    //                   ↗            
    //B:     b1 → b2 → b3
    //begin to intersect at node c1.


    //Notes:

    //If the two linked lists have no intersection at all, return null.
    //The linked lists must retain their original structure after the function returns.
    //You may assume there are no cycles anywhere in the entire linked structure.
    //Your code should preferably run in O(n) time and use only O(1) memory.

    // https://leetcode.com/explore/interview/card/top-interview-questions-medium/107/linked-list/785/

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
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            if (headA == null || headB == null) { return null; }

            int lenA = GetLength(headA);
            int lenB = GetLength(headB);

            ListNode s; // short
            ListNode l; // long

            if (lenA >= lenB)
            {
                l = headA;
                s = headB;
            }
            else
            {
                l = headB;
                s = headA;
            }

            for (int i = 0; i < Math.Abs(lenA - lenB); i++) // advance the long pointer to align with short pointer
            {
                l = l.next;
            }

            while (l != null) // could use either long or short here since they're aligned from the tail
            {
                if (l.val == s.val)
                {
                    return l;
                }

                l = l.next;
                s = s.next;
            }

            return null; // no intersection


        }

        private int GetLength(ListNode n)
        {
            int length = 0;

            while (n != null)
            {
                length++;
                n = n.next;
            }

            return length;
        }
    }
}
