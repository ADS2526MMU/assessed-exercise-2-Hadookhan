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
        public void InOrder(ref string buffer)
        {
            DFS(root, "in", ref buffer);
        }

        public void PreOrder(ref string buffer)
        {
            DFS(root, "pre", ref buffer);
        }

        public void PostOrder(ref string buffer)
        {
            DFS(root, "post", ref buffer);
        }

        private void DFS(Node<T> item, string type, ref string buffer)
        {
            if (item == null)
            {
                return;
            }

            if (type == "in")
            {
                DFS(item.Left, type, ref buffer);
                buffer += item.Data.ToString() + ", ";
                DFS(item.Right, type, ref buffer);
            } else if (type == "pre")
            {
                buffer += item.Data.ToString() + ",";
                DFS(item.Left, type, ref buffer);
                DFS(item.Right, type, ref buffer);
            } else if (type == "post")
            {
                DFS(item.Left, type, ref buffer);
                DFS(item.Right, type, ref buffer);
                buffer += item.Data.ToString() + ",";
            } else
            {
                throw new Exception("No such DFS method");
            }
        }

        //Free space, use as necessary to address task requirements... 





    } // End of class
}
