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

        //Free space, use as necessary to address task requirements... 





    } // End of class
}
