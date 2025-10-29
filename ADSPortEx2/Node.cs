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
        private T data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T item)
        {
            // Node instantiation will declare node with empty children
            data = item;
            Right = null;
            Left = null;
        }

        public T Data
        {
            get { return data; }
            set { Data = value; }
        }

    } // End of class
}
