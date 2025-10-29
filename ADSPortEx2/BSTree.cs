using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Binary Search Tree implementation for Assessed Exercise 2

    //Hints : 
    //Use lecture materials from Week 5
    // and lab sheet 'Lab 5: BinTree and BSTree' to aid with implementation.

    class BSTree<T> : BinTree<T> where T : IComparable
    {
        public BSTree()
        {
            root = null;
        }

        public BSTree(T item)
        {
            root = new Node<T>(item);
        }

        public BSTree(Node<T> node)
        {
            root = node;
        }

        //Functions for EX.2A
        public void InsertItem(T item)
        {
            root = InsertHelper(item, root);
        }

        private Node<T> InsertHelper(T item, Node<T> tree)
        {
            if (tree == null)
            {
                return new Node<T>(item);
            }

            int val = item.CompareTo(tree.Data);

            if (val < 0)
            {
                tree.Left = InsertHelper(item, tree.Left);
            }
            else if (val > 0)
            {
                tree.Right = InsertHelper(item, tree.Right);
            }
            else
            {
                throw new Exception("Cant have duplicate values");
            }

            return tree;
        }

        public int Height()
        {
            return FindLongestPath(root);
        }

        public T EarliestGame()
        {
            return FindEarliestGame(root);
        }

        //Functions for EX.2B

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        // HELPER FUNCTIONS
        private int FindLongestPath(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Max(FindLongestPath(root.Left), FindLongestPath(root.Right));
        }

        private T FindEarliestGame(Node<T> root)
        {
            if (root.Left == null)
            {
                return root.Data;
            }

            // Furthest Left Node is always earliest game
            return FindEarliestGame(root.Left);
        }

        // I was thinking of using Math.Max, but decided to use my own implementation.
        private int Max(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }
            return b;
        }

        //Free space, use as necessary to address task requirements... 





    }// End of class
}
