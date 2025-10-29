using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    class Node<T> where T : IComparable
    {
        // Each Node will have a value and two children
        public T Item { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T item)
        {
            // Node instantiation will declare node with empty children
            Item = item;
            Right = null;
            Left = null;
        }

        public T Data
        {
            get { return Data; }
            set { Data = Item; }
        }

    } // End of class
}
