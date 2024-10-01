using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AliacSearchAlgo;

namespace AISearchSample
{
    class Fringe2 : Fringes
    {
        // Use a queue for BFS
        Queue<Node> queue;

        public Fringe2()
        {
            queue = new Queue<Node>(); // Initialize queue
        }

        // Add node to the queue (enqueue)
        public void add(Node n, Node origin)
        {
            n.Origin = origin;
            queue.Enqueue(n); // Enqueue node for BFS
        }

        // Remove node from the front of the queue (dequeue)
        public Node remove()
        {
            if (queue.Count != 0)
                return queue.Dequeue(); // Dequeue the node in FIFO order
            return null;
        }
    }
}
