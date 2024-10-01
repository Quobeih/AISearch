using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AliacSearchAlgo;

namespace AISearchSample
{
    class Search
    {
        Fringes fringe;
        ArrayList n;
        bool start = false;

        public Search(ArrayList nodes, int type)
        {
            if (type == 1) // DFS
                fringe = new Fringe(); // Fringe is stack-based (DFS)
            if (type == 2) // BFS
                fringe = new Fringe2(); // Fringe2 is queue-based (BFS)
            n = nodes;
        }

        // Mark a node as the start node
        public void setStart(Node n)
        {
            n.Start = true;
        }

        // Mark a node as the goal node
        public void setGoal(Node n)
        {
            n.Goal = true;
        }

        // The BFS search method
        public Node search()
        {
            Node explored = null;

            // Find the start node and add it to the fringe (queue for BFS)
            for (int i = 0; i < n.Count; i++)
            {
                if (((Node)n[i]).Start == true)
                {
                    fringe.add(((Node)n[i]), null); // Add the start node to the queue
                }
            }

            Node explorer = null;
            ArrayList temp;
            Object[] t;

            // BFS loop - process nodes in queue (FIFO)
            while ((explorer = fringe.remove()) != null)
            {
                // Check if the current node is the goal
                if (explorer.Goal == true)
                {
                    explorer.Expanded = true; // Mark it as expanded
                    MessageBox.Show("Goal found: " + explorer.Name);
                    explored = explorer; // Store the explored node
                    break; // Exit the loop, goal is found
                }

                // Get all neighboring nodes (adjacent connections)
                temp = explorer.getNeighbor();
                t = temp.ToArray();

                // Add each unvisited neighbor to the queue (FIFO)
                for (int i = 0; i < t.Length; i++)
                {
                    if (((Node)t[i]).Expanded != true) // Check if the node is not yet expanded
                    {
                        fringe.add((Node)t[i], explorer); // Add neighbor to the queue
                    }
                }

                explorer.Expanded = true; // Mark the current node as expanded
                explored = explorer; // Keep track of the last expanded node
            }

            // Return the last explored node (goal or failure)
            return explored;
        }

        // Similar method to search one node at a time (stepwise execution)
        public Node searchone()
        {
            Node explored = null;

            // Find the start node and add it to the fringe (if not done already)
            if (!start)
            {
                for (int i = 0; i < n.Count; i++)
                {
                    if (((Node)n[i]).Start == true)
                    {
                        fringe.add(((Node)n[i]), null);
                    }
                }
                start = true; // Mark start as true to avoid adding start node again
            }

            Node explorer = null;
            ArrayList temp;
            Object[] t;

            // Process the next node in the queue
            if ((explorer = fringe.remove()) != null)
            {
                // Check if it's the goal
                if (explorer.Goal == true)
                {
                    explorer.Expanded = true;
                    explored = explorer; // Goal found
                }

                // Explore its neighbors and add unexpanded ones to the queue
                temp = explorer.getNeighbor();
                t = temp.ToArray();
                for (int i = 0; i < t.Length; i++)
                {
                    if (((Node)t[i]).Expanded != true)
                        fringe.add((Node)t[i], explorer);
                }
                explorer.Expanded = true; // Mark as expanded
                explored = explorer;
            }

            // Return the current explored node
            return explored;
        }
    }
}
