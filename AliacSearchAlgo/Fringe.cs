using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AliacSearchAlgo;

namespace AISearchSample
{
    class Fringe : Fringes
    {
        Stack<Node> s; // Use a stack for DFS

        public Fringe()
        {
            s = new Stack<Node>(); // Initialize the stack
        }

        // Add node to the stack (push)
        public void add(Node n, Node origin)
        {
            n.Origin = origin;
            s.Push(n); // Push node onto the stack for DFS
        }

        // Remove node from the stack (pop)
        public Node remove()
        {
            if (s.Count != 0)
                return s.Pop(); // Pop the node (LIFO)
            return null;
        }
    }
}
