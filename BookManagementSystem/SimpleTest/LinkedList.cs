using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTest
{
    public class LinkedList<T>
    {
        class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        Node first;
        Node last;
        public int Count { get; private set; }


        public void Add(T value)
        {
            var node = new Node() { Item = value, Next = null, Previous = last };

            if (first == null)
                first = node;
            else
                last.Next = node;

            last = node;
            Count++;

        }

        public T this [int index]
        {
            get
            {
                Node node = Locate(index);
                return node.Item;
            }

            set
            {
                Locate(index).Item = value;
            }
        }

        private Node Locate(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException($"invalid index {index}. valid values 0-{Count-1}");
            if (index == 0)
                return first;
            if (index == Count - 1)
                return last;
            Node n = first;
            for(int i=0;i<index;i++)
            {
                n = n.Next;
            }
            return n;
        }

        public T Remove(int index)
        {
            var d = Locate(index);
            if (d == first)
                first = d.Next;
            else
                d.Previous.Next = d.Next;

            if (d == last)
                last = d.Previous;
            else
                d.Next.Previous = d.Previous;
            Count--;
            return d.Item;
        }
    
        public int IndexOf(T item)
        {
            Node n = first;
            for (int i = 0; i < Count; i++)
                if (n.Item.Equals(item))
                    return i;
                else
                    n = n.Next;

            return -1;
        }
    
    }
}
