using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Design
{

    // Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
    // push(x) -- Push element x onto stack.
    // pop() -- Removes the element on top of the stack.
    // top() -- Get the top element.
    // getMin() -- Retrieve the minimum element in the stack.
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/98/design/562/


    //public class Node
    //{
    //    public Node() { }
    //    public Node(int val, int min) { this.val = val; this.min = min; }
    //    public int val;
    //    public int min;
    //    public Node next;

    //}

    //public class MinStack
    //{

    //    /** initialize your data structure here. */
    //    public MinStack()
    //    {

    //    }

    //    private Node top = null;

    //    public void Push(int x)
    //    {
    //        if (top == null)
    //        {
    //            top = new Node(x, x);
    //        }
    //        else
    //        {
    //            int newMin = Math.Min(top.min, x);
    //            Node newTop = new Node(x, newMin);
    //            newTop.next = top;
    //            top = newTop;
    //        }
    //    }

    //    public void Pop()
    //    {
    //        if (top == null)
    //        {
    //            return;
    //        }
    //        else
    //        {
    //            top = top.next;
    //        }
    //    }


    //    public int Top()
    //    {
    //        // in real life, if top == null then throw

    //        return top.val;
    //    }

    //    public int GetMin()
    //    {
    //        // in real life, if size is 0 then throw exception
    //        return top.min;
    //    }
    //}

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
