using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.AddNode(50);
            bst.AddNode(70);
            bst.AddNode(40);
            bst.AddNode(35);
            bst.AddNode(80);
            bst.AddNode(20);

            Console.WriteLine("InOder Traversal : ");
            bst.InOrderTraversal(bst.Root);

        }
    }

    class Node
    {
        public int Data { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public Node(int data)
        {
            Data = data;
            Right = null;
            Left = null;
        }

    }

    class BinarySearchTree
    {
        public Node Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public void AddNode(int data)
        {
            Node current = Root;
            Node parent = null;
            if(Root == null)
            {
                Root = new Node(data);
            }
            else
            {
                while(current != null)
                {
                    if (data < current.Data)
                    {
                        parent = current;
                        current = current.Left;
                    }
                    else if ( data > current.Data)
                    {
                        parent = current;
                        current = current.Right;
                    }
                }
                
                if( data < parent.Data)
                {
                    parent.Left = new Node(data);
                }
                else if ( data > parent.Data)
                {
                    parent.Right = new Node(data);
                }
            }
        }

        public void InOrderTraversal(Node root)
        {
            if (root.Left != null)
                InOrderTraversal(root.Left);

            Console.WriteLine(root.Data + "\t");

            if (root.Right != null)
                InOrderTraversal(root.Right);

        }
    }
}
