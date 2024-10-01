using System;
using System.Collections;

namespace AISearchSample
{
    [Serializable]
    class Node
    {
        private string name;        // Node name
        private int value;          // Value associated with the node
        private bool moved;         // Indicates if the node has been moved
        private bool goal;          // Indicates if this node is the goal
        private bool expanded;      // Indicates if this node has been expanded
        private bool start;         // Indicates if this node is the start
        private ArrayList neighbors; // List of neighboring nodes
        private int x;              // X coordinate of the node
        private int y;              // Y coordinate of the node
        private Node origin;        // Previous node in the path

        public Node()
        {
            name = "";
            value = 0;
            origin = null;
            goal = expanded = start = false;
            neighbors = new ArrayList();
            x = 0;
            y = 0;
            moved = false;
        }

        public bool Moved
        {
            get { return moved; }
            set { moved = value; }
        }

        public Node Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Value
        {
            get { return value; }
            set { value = value; }
        }

        public bool Expanded
        {
            get { return expanded; }
            set { expanded = value; }
        }

        public bool Goal
        {
            get { return goal; }
            set { goal = value; }
        }

        public bool Start
        {
            get { return start; }
            set { start = value; }
        }

        // Method to get neighbors of the node
        public ArrayList getNeighbor()
        {
            return neighbors; // Return the list of neighbors
        }

        // Method to add a neighbor to this node
        public void addNeighbor(Node n)
        {
            this.neighbors.Add(n); // Add the neighbor node
        }

        // Method to remove a neighbor from this node
        public void removeNeighbor(Node n)
        {
            this.neighbors.Remove(n); // Remove the neighbor node
        }

        // Method to compare two nodes for equality
        public bool Equals(Node n)
        {
            return this.name.Equals(n.Name, StringComparison.OrdinalIgnoreCase); // Compare names
        }
    }
}
