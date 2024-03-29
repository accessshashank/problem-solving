﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class LLOperations
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of linked list : ");
            int size = int.Parse(Console.ReadLine());
            var numArray = new int[size];
            
            for(int i=1; i<=size; i++)
            {
                Console.Write("Enter value for Node {0} : ", i);
                numArray[i - 1] = int.Parse(Console.ReadLine());
            }

            LinkedList ll = LLHelper.CreateLinkedList(numArray);

            Console.WriteLine("Display !");
            LLHelper.Display(ll.Head);
            

            Console.WriteLine();

            Console.WriteLine("Recursive Display !");
            RecursiveDisplay(ll.Head);
            Console.WriteLine();

            
            var sum = SumElements(ll);

            Console.WriteLine("Sum of elements is : {0}", sum);

            var maxValue = LargestNumber(ll);

            Console.WriteLine("Largest of elements is : {0}", maxValue);

            SearchAnElement(ll);

            ll = MoveSearchedNodeToHead(ll);

            Console.WriteLine("IMPORTANT >> : Searched element moved to HEAD, Reprinting MODIFIED LL");

            LLHelper.Display(ll.Head);
            Console.WriteLine();

            ll = InsertNodeAtBegining(ll);
            LLHelper.Display(ll.Head);
            Console.WriteLine();

            ll = InsertNodeAtNthPosition(ll);
            LLHelper.Display(ll.Head);
            Console.WriteLine();

            ll = InsertNodeAtNthPositionRecursive(ll);
            LLHelper.Display(ll.Head);
            Console.WriteLine();
        }

        private static LinkedList InsertNodeAtNthPosition(LinkedList ll)
        {
            int position = 3;
            Console.WriteLine("Inserting node 200 at 3rd position");
            Node node = new Node();
            node.Value = 200;
            var temp = ll.Head;
            for(int i=1; i<position-1;i++)
            {
                temp = temp.Next;
            }

            node.Next = temp.Next;
            temp.Next = node;

            return ll;
        }

        private static LinkedList InsertNodeAtNthPositionRecursive(LinkedList ll)
        {
            int position = 3;
            Console.WriteLine("Inserting node 1200 at 4th position recursively");
             Helper(ll, ll.Head, position, 1200);

            return ll;
        }

        private static void Helper(LinkedList ll, Node current, int position, int value)
        {
            if(position == 0)
            {
                Node node = new Node();
                node.Value = value;
                node.Next = current.Next;
                current.Next = node;
                // return node;
                return;
            }

            Helper(ll, current.Next, position - 1, value);
        }

        private static LinkedList InsertNodeAtBegining(LinkedList ll)
        {
            Console.WriteLine("Inserting node 500 in begining");
            var temp = ll.Head;
            var node = new Node();
            node.Value = 500;
            node.Next = ll.Head;
            ll.Head = node;

            return ll;
        }

        private static LinkedList MoveSearchedNodeToHead(LinkedList ll)
        {
            Console.WriteLine("Moving serched element to HEAD : ");
            Console.Write("Enter element to be searched : ");
            int element = int.Parse(Console.ReadLine());
            Node previous = null;
            Node current = ll.Head;
            Node head = ll.Head;

            while(current != null)
            {
                if(current.Value == element)
                {
                    if(current == head)
                    {
                        break;
                    }

                    previous.Next = current.Next;
                    current.Next = head;
                    ll.Head = current;
                    break;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
            return ll;
        }

        private static void SearchAnElement(LinkedList ll)
        {
            Console.Write("Enter element to be searched : ");
            int element = int.Parse(Console.ReadLine());

            var temp = ll.Head;
            bool found = false;
            int counter = 0;
            while(temp != null)
            {
                counter++;
                if(temp.Value == element)
                {
                    found = true;
                    break;
                }
                temp = temp.Next;
            }

            if (found) Console.WriteLine("Element {0} found at Node {1}", element, counter);
            else Console.WriteLine("Element not found");
        }

        private static int LargestNumber(LinkedList ll)
        {
            var temp = ll.Head;
            int maxValue = int.MinValue;

            while(temp != null)
            {
                if(temp.Value > maxValue)
                {
                    maxValue = temp.Value;
                }
                temp = temp.Next;
            }

            return maxValue;
        }

        private static int SumElements(LinkedList ll)
        {
            var temp = ll.Head;
            int sum = 0;

            while(temp != null)
            {
                sum = sum + temp.Value;
                temp = temp.Next;
            }

            return sum;
        }

        private static void RecursiveDisplay(Node node)
        {
            if (node == null) return;
            else
            {
                Console.Write(node.Value + "->");
                RecursiveDisplay(node.Next);
            }
        }

    }

    public class LLHelper
    {
        public static LinkedList CreateLinkedList(int[] numArray)
        {
            var ll = new LinkedList(numArray.Length);
            var node = new Node();
            node.Value = numArray[0];
            node.Next = null;
            ll.Head = node;
            ll.Tail = node;

            for (int i = 1; i < numArray.Length; i++)
            {
                var temp = new Node();
                temp.Value = numArray[i];
                temp.Next = null;
                ll.Tail.Next = temp;
                ll.Tail = temp;
            }

            return ll;
        }

        public static DoublyLinkedList CreateDoublyLinkedList(int[] numArray)
        {
            var dll = new DoublyLinkedList(numArray.Length);
            var node = new DoublyNode();
            node.Value = numArray[0];
            node.Previous = null;
            node.Next = null;
            dll.Head = node;
            dll.Tail = node;

            for (int i = 1; i < numArray.Length; i++)
            {
                var temp = new DoublyNode();
                temp.Value = numArray[i];
                temp.Next = null;
                temp.Previous = dll.Tail;
                dll.Tail.Next = temp;
                dll.Tail = temp;
            }

            return dll;
        }

        public static void Display(Node node)
        {
            while (node != null)
            {
                Console.Write(node.Value + "->");
                node = node.Next;
            }
        }

        public static void DisplayDoublyForward(DoublyNode node)
        {
            while (node != null)
            {
                Console.Write(node.Value + "->");
                node = node.Next;
            }
        }

        public static void DisplayDoublyBackward(DoublyNode node)
        {
            while (node != null)
            {
                Console.Write(node.Value + "<-");
                node = node.Previous;
            }
        }
    }

    public class LinkedList
    {
        public LinkedList(int size)
        {
            Length = size;
        }
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Length { get; private set; }
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedList(int size)
        {
            Length = size;
        }
        public DoublyNode Head { get; set; }
        public DoublyNode Tail { get; set; }
        public int Length { get; private set; }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    public class DoublyNode
    {
        public DoublyNode Previous { get; set; }
        public int Value { get; set; }
        public DoublyNode Next { get; set; }
    }
}
