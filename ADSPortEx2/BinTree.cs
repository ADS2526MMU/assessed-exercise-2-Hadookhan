using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{

    class BinTree<T> where T : IComparable
    {

        protected Node<T> root;

        public BinTree()
        {
            // Empty tree instantiation
        }

        // My own implemented constructor for user to add item instead of node
        public BinTree(T item)
        {
            root = new Node<T>(item);
        }

        public BinTree(Node<T> node)
        {
            root = node;
        }


        //Functions for EX.2A
        public void InOrder(ref string buffer)
        {
            Console.WriteLine("\n------------------------------------");
            DFS(root, "in", ref buffer);
            Console.WriteLine("------------------------------------");
        }

        public void PreOrder(ref string buffer)
        {
            Console.WriteLine("\n------------------------------------");
            DFS(root, "pre", ref buffer);
            Console.WriteLine("------------------------------------");
        }

        public void PostOrder(ref string buffer)
        {
            Console.WriteLine("\n------------------------------------");
            DFS(root, "post", ref buffer);
            Console.WriteLine("------------------------------------");
        }

        // Keeping code consistent with similar method names
        public void LevelOrder(ref string buffer)
        {
            Console.WriteLine("\n------------------------------------");
            BFS(ref buffer);
            Console.WriteLine("------------------------------------");
        }

        // DFS function for all tree order traversals
        private void DFS(Node<T> item, string type, ref string buffer)
        {
            if (item == null)
            {
                return;
            }

            if (type == "in")
            {
                DFS(item.Left, type, ref buffer);
                Console.WriteLine(item.Data.ToString()); // To Console
                buffer += item.Data.ToString(); // To Buffer string
                DFS(item.Right, type, ref buffer);
            } else if (type == "pre")
            {
                Console.WriteLine(item.Data.ToString());
                buffer += item.Data.ToString();
                DFS(item.Left, type, ref buffer);
                DFS(item.Right, type, ref buffer);
            } else if (type == "post")
            {
                DFS(item.Left, type, ref buffer);
                DFS(item.Right, type, ref buffer);
                Console.WriteLine(item.Data.ToString());
                buffer += item.Data.ToString();
            } else
            {
                throw new Exception("No such DFS method");
            }
        }

        // BFS just because I wanted to add it
        private void BFS(ref string buffer)
        {
            // Edge case incase tree is empty (CANNOT TRAVERSE EMPTY TREE)
            if (root == null)
            {
                throw new Exception("Tree is currently empty");
            }
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            int level = 1;
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                Console.WriteLine($"\nLevel {level}: ");
                for (int i = 0; i < levelSize; i++)
                {
                    Node<T> item = queue.Dequeue();
                    Console.WriteLine(item.Data.ToString());
                    buffer += item.Data.ToString();
                    if (item.Left != null)
                    {
                        queue.Enqueue(item.Left);
                    }
                    if (item.Right != null)
                    {
                        queue.Enqueue(item.Right);
                    }

                }
                level++;
            }
        }





    } // End of class
}
