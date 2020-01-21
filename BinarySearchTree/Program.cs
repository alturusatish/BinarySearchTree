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

            Console.WriteLine("InOder Traversal - Recursion : ");
            bst.InOrderTraversal(bst.Root);

            Console.WriteLine("\n InOder Traversal - Iterative: ");
            bst.InOderTraversalIterative(bst.Root);

            Console.WriteLine("\n Sum of Nodes :" + bst.SumOfNodes(bst.Root));

            Console.WriteLine("\n Height of Binary Search Tree :" + bst.HeightOfBST(bst.Root));

            Console.WriteLine("\n Maximum element in Binary Search Tree: " + bst.MaximumElement(bst.Root));


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

        public void InOderTraversalIterative(Node root)
        {
            Stack<Node> nodeStack = new Stack<Node>();

            while (true)
            {
                while(root != null)
                {
                    nodeStack.Push(root);
                    root = root.Left;
                }

                if (nodeStack.Count == 0)
                    break;

                var node = nodeStack.Pop();

                Console.WriteLine(node.Data + "\t");

                root = node.Right;

            }
        }

        /// <summary>
        /// Calculate sum of nodes in binary search tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumOfNodes(Node root)
        {
            if (root == null)
                return 0;
            int sum = root.Data + SumOfNodes(root.Left) + SumOfNodes(root.Right);
            return sum;
        }

        /// <summary>
        ///  Height of BST = 1 + maximum path fromm leaf to root
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int HeightOfBST(Node root)
        {
            if (root == null)
                return 0;

            int leftHeight = HeightOfBST(root.Left);
            int rightHeight = HeightOfBST(root.Right);
            if (leftHeight > rightHeight)
            {
                return leftHeight + 1;
            }
            else
                return rightHeight + 1;
        }

        /// <summary>
        /// Find maximum element in a binary search tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaximumElement(Node root)
        {
            int max = Int32.MinValue;

            int value = 0;
            if(root != null)
            {
                value = root.Data;
                int leftMax = MaximumElement(root.Left);
                int rightMax = MaximumElement(root.Right);
                if (leftMax > rightMax)
                    max = leftMax;
                else
                    max = rightMax;
                if (max < value)
                    max = value;
            }

            return max;            
        }
    }
}
