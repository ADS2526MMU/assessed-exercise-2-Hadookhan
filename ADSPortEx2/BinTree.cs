using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Binary Tree implementation for Assessed Exercise 2

    //Hints : 
    //Use lecture materials from Week 4B
    // and lab sheet 'Lab 5: BinTree and BSTree' to aid with implementation...

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
        public void InOrder()
        {
            DFS(root, "in");
        }

        public void PreOrder()
        {
            DFS(root, "pre");
        }

        public void PostOrder()
        {
            DFS(root, "post");
        }

        // DFS function for all tree order traversals
        private void DFS(Node<T> item, string type)
        {
            if (item == null)
            {
                return;
            }

            if (type == "in")
            {
                DFS(item.Left, type);
                Console.WriteLine(item.Data.ToString());
                DFS(item.Right, type);
            } else if (type == "pre")
            {
                Console.WriteLine(item.Data.ToString());
                DFS(item.Left, type);
                DFS(item.Right, type);
            } else if (type == "post")
            {
                DFS(item.Left, type);
                DFS(item.Right, type);
                Console.WriteLine(item.Data.ToString());
            } else
            {
                throw new Exception("No such DFS method");
            }
        }

        // BFS just because I wanted to add it
        public void BFS()
        {
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

        //Free space, use as necessary to address task requirements... 





    } // End of class
}
