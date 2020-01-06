using System;

namespace stacks
{
    interface StackInterface<T>
    {
        public void push(T data);
        public T pop();
        public T peek();
        public void printStack();
        public int getLength();
    }

    class LLStack<T> : StackInterface<T>
    {
        private class Node
        {
            public T data;
            public Node next;

            public Node()
            {
                data = default;
                next = null;
            }

            public Node(T data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }

        private Node head;
        private int length;

        public LLStack()
        {
            head = null;
            length = 0;
        }

        public void push(T data)
        {
            if(head == null)
            {
                head = new Node(data, null);
                return;
            }
            head = new Node(data, head);
            length++;
        }

        public T pop()
        {
            if(head == null)
            {
                Console.WriteLine("List is empty.");
                return default;
            }
            T ret = head.data;
            head = head.next;
            length--;
            return ret;

        }

        public T peek()
        {
            return head.data;
        }

        public void printStack()
        {
            for(Node printNode = head; printNode != null; printNode = printNode.next)
            {
                Console.WriteLine(Convert.ToString(printNode.data));
            }
        }

        public int getLength()
        {
            return this.length;
        }
    }

    class ArrStack<T> : StackInterface<T>
    {
        private T[] arr;
        private int headInd;
        private readonly int DEF_LEN = 256;

        public ArrStack()
        {
            init(DEF_LEN);
        }

        public ArrStack(int size)
        {
            init(size);
        }

        private void init(int size)
        {
            if (size < 1)
            {
                Console.WriteLine("Length of array must be greater than zero.");
                return;
            }
            arr = new T[size];
            headInd = 0;
        }

        public void push(T data)
        {
            if (headInd == arr.Length)
            {
                Console.WriteLine("List is full.");
                return;
            }
            arr[headInd++] = data;
        }

        public T pop()
        {
            if (headInd == 0)
            {
                Console.WriteLine("List is empty.");
                return default;
            }
            return arr[--headInd];
        }

        public T peek()
        {
            return arr[headInd - 1];
        }

        public void printStack()
        {
            for(int i = 0; i < headInd; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public int getLength()
        {
            return headInd - 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StackInterface<String> sta = new ArrStack<String>();
            sta.push("Hello");
            sta.push("World");
            sta.push("!");
            Console.WriteLine("Hello world stack.");
            sta.printStack();
            String p = sta.pop();
            Console.WriteLine("\nStack after popping once.");
            sta.printStack();
            Console.WriteLine("\nItem that was popped: {0}", p);
            Console.WriteLine("\nCurrent head: {0}", sta.peek());
        }
    }
}
