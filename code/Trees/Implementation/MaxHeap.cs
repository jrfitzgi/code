using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.Trees.Implementation
{
    public class MaxHeap
    {
        protected int[] Data;

        public MaxHeap(int[] data)
        {
            this.Data = data;
            this.Heapify();
        }

        protected int Parent(int i)
        {
            return (i - 1) / 2;
        }

        protected int LeftChild(int i)
        {
            return 2 * i + 1;
        }

        protected int RightChild(int i)
        {
            return 2 * i + 2;
        }

        protected void Heapify()
        {
            // start at the last parent
            int lastChild = Data.Length - 1;
            int start = Parent(lastChild);

            while (start >= 0)
            {
                SiftDown(start);
                start--;
            }
        }

        // SiftDown every node
        protected void SiftDown(int root)
        {
            while (LeftChild(root) < Data.Length) // check that root has at least one child
            {
                // check if we need to sift down
                int swapWith = root;
                if (Data[LeftChild(root)] > Data[root])
                {
                    swapWith = LeftChild(root);
                }

                if (RightChild(root) < Data.Length && Data[RightChild(root)] > Data[LeftChild(root)])
                {
                    swapWith = RightChild(root);
                }

                // swap
                if (root != swapWith)
                {
                    int temp = Data[root];
                    Data[root] = Data[swapWith];
                    Data[swapWith] = temp;

                    root = swapWith; // repeat with the child that we swapped with
                }
                else
                {
                    return;
                }
            }
        }

        public int PeekMax()
        {
            return Data[0];
        }

        public void PopMax()
        {
            int last = Data.Length - 1;
            Data[0] = Data[last];
            Heapify();
        }

        public void Insert(int key)
        {
            // TODO: be smarter about resizing array
            int[] newData = new int[Data.Length + 1];
            Array.Copy(Data, newData, Data.Length);
            Data = newData;
            newData[newData.Length - 1] = key;
            Heapify();
        }

        public void Delete(int key)
        {
            int toDelete = -1;
            for (int i=0; i < Data.Length; i++)
            {
                if (Data[i] == key)
                {
                    toDelete = i;
                    break;
                }
            }

            if (toDelete != -1)
            {
                Data[toDelete] = Data[Data.Length - 1];
            }

            int[] newData = new int[Data.Length - 1];
            Array.Copy(Data, newData, newData.Length);
            Data = newData;
            Heapify();
        }

    }
}
