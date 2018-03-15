using System;
using System.Text;

namespace GeneticTSP
{
    public class LinkedList<T>
    {

        protected LinkedListNode<T> Root;
        protected LinkedListNode<T> Last;
        public int Count { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var node = Root;

            while (node != null)
            {
                sb.Append("{ " + node.Data + " } ");
                node = node.Next;

                if (node == Root)
                    break;
            }

            return sb.ToString();
        }

        public T this[int index]
        {
            get
            {
                var node = GetAt(index);
                if (node == null)
                    throw new ArgumentOutOfRangeException();

                return node.Data;
            }
            set
            {
                var node = GetAt(index);
                if (node == null)
                    throw new ArgumentOutOfRangeException();

                node.Data = value;
            }
        }

        public LinkedListNode<T> GetAt(int index)
        {
            var current = Root;

            for (int i = 0; i < index; i++)
            {
                if (current == null)
                    return null;

                current = current.Next;

                if (current == Root)
                    return null;
            }

            return current;
        }

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new LinkedListNode<T>(data);
                Last = Root;
            }
            else
            {
                Last.Next = new LinkedListNode<T>(data);
                Last.Next.Previous = Last;
                Last = Last.Next;

                Last.Next = Root;
                Root.Previous = Last;
            }

            Count++;
        }

        public void Remove(T data)
        {
            if (Root == null)
                return;

            if (Root == Last && Root.Data.Equals(data))
            {
                Root = Last = null;
                Count--;
                return;
            }

            var current = Root;
            while (!current.Data.Equals(data))
            {
                current = current.Next;
                if (current == Root) // Not found and we're back to the root
                    return;
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;

            if (Root == current)
            {
                Root = Root.Next;
            }
            else if (Last == current)
            {
                Last = Last.Previous;
            }

            Count--;
        }

        public LinkedListNode<T> Find(T data)
        {
            if (Root == null)
                return null;

            var current = Root;

            while (!current.Data.Equals(data))
            {
                current = current.Next;

                if (current == Root)
                    return null;
            }

            return current;
        }

    }

    public class LinkedListNode<T>
    {

        public T Data { get; set; }

        public LinkedListNode(T data)
        {
            Data = data;
        }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Previous { get; set; }

    }
}