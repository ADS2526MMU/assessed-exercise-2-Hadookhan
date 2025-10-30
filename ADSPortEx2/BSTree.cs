using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{

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

        public int Height()
        {
            return FindLongestPath(root);
        }

        public T EarliestGame()
        {
            // Edge case incase tree is empty (CANNOT TRAVERSE EMPTY TREE)
            if (root == null)
            {
                throw new Exception("Tree is currently empty");
            }
            return FindEarliestGame(root);
        }

        //Functions for EX.2B

        public int Count()
        {
            return FindCount(root);
        }

        public void Update(T item)
        {
            var node = FindNode(item);
            if (node == null)
            {
                throw new Exception("Item not found in tree");
            }
            node.Data = item;
        }

        public void ListGamesWithYear(T item)
        {
            VideoGame game = item as VideoGame;
            listGamesWithYear(root, game.Releaseyear);

        }

        // Finds node by using DFS recursion and title comparison value
        public Node<T> FindNode(T item)
        {
            var node = findItem(root, item);
            return node;
        }

        // HELPER FUNCTIONS
        private void listGamesWithYear(Node<T> tree, int year)
        {
            if (tree == null)
            {
                return;
            }

            // InOrder traversal but only displaying games with same year as specified
            listGamesWithYear(tree.Left, year);
            if ((tree as VideoGame).Releaseyear == year)
            {
                Console.WriteLine(tree.Data.ToString());
            }
            listGamesWithYear(tree.Right, year);
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
                throw new Exception("Cant have duplicate titles");
            }

            return tree;
        }

        private Node<T> findItem(Node<T> tree, T item)
        {
            if (tree == null)
            {
                return null;
            }

            int val = item.CompareTo(tree.Data);

            if (val < 0)
            {
                return findItem(tree.Left, item);
            }
            else if (val > 0)
            {
                return findItem(tree.Right, item);
            }
            return tree;
        }

        private int FindLongestPath(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Max(FindLongestPath(root.Left), FindLongestPath(root.Right));
        }

        private int FindCount(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            // Returns sum of all nodes on the left and right subtrees
            return 1 + FindCount(root.Left) + FindCount(root.Right);
        }

        private T FindEarliestGame(Node<T> root)
        {
            if (root == null)
                throw new Exception("Tree is currently empty");

            // Root is the initial minimum value
            T min = root.Data;

            // Recurse to bottom of the tree
            T leftMin = FindEarliestGame(root.Left);
            T rightMin = FindEarliestGame(root.Right);

            // Backtrack up tree from left, replacing min value if any games release year has lower value
            if (leftMin != null)
            {
                // Type cast generics to VideGame
                var left = leftMin as VideoGame;
                var Min = min as VideoGame;
                if (left != null && Min != null && left.Releaseyear < Min.Releaseyear)
                    min = leftMin;
            }

            // Backtrack up tree from right, replacing min value if any games release year has lower value
            if (rightMin != null)
            {
                var right = rightMin as VideoGame;
                var Min = min as VideoGame;
                if (right != null && Min != null && right.Releaseyear < Min.Releaseyear)
                    min = rightMin;
            }

            return min;
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





    }// End of class
}
