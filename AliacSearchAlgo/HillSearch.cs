using System;
using System.Collections;
using System.Windows.Forms;
using AISearchSample;

namespace AliacSearchAlgo
{
    class HillSearch
    {
        private ArrayList nodes;  // Store the nodes
        private bool startInitialized = false;  // To track if the start node is initialized

        public HillSearch(ArrayList nodes)
        {
            this.nodes = nodes;  // Initialize the nodes
        }

        public void setStart(Node startNode)
        {
            startNode.Start = true;  // Mark the specified node as the start
        }

        public void setGoal(Node goalNode)
        {
            goalNode.Goal = true;  // Mark the specified node as the goal
        }

        public Node search()
        {
            ArrayList neighbors = null;
            double[] heuristics;
            int startIndex = 0;

            // Find the start index if not already initialized
            if (!startInitialized)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (((Node)nodes[i]).Start == true)
                    {
                        startIndex = i;  // Get the index of the start node
                        break;  // Exit the loop once the start node is found
                    }
                }
                startInitialized = true;  // Mark that the start node has been initialized
            }

            // Start the Hill Climbing search
            do
            {
                // Get neighbors of the current node
                neighbors = ((Node)nodes[startIndex]).getNeighbor();
                ((Node)nodes[startIndex]).Expanded = true;  // Mark the current node as expanded
                heuristics = calculate(neighbors, ((Node)nodes[startIndex]));

                double minHeuristic = double.MaxValue;  // Set initial minimum heuristic to max value
                int nextNodeIndex = -1;  // Index of the next node to explore

                // Find the best neighbor with the minimum heuristic value
                for (int y = 0; y < neighbors.Count; y++)
                {
                    if (((Node)neighbors[y]).Expanded == false)  // Ensure we haven't expanded this node yet
                    {
                        if (heuristics[y] < minHeuristic)  // Check if this heuristic is less than current min
                        {
                            minHeuristic = heuristics[y];  // Update minimum heuristic
                            nextNodeIndex = y;  // Update the next node index
                        }
                    }
                }

                // If no valid neighbor found, break the loop
                if (nextNodeIndex == -1)
                {
                    MessageBox.Show("No further nodes to explore.");
                    return null;  // Exit if no better neighbor is found
                }

                // Update the current node index to the best neighbor found
                for (int x = 0; x < nodes.Count; x++)
                {
                    if (((Node)nodes[x]).Name.Equals(((Node)neighbors[nextNodeIndex]).Name))
                    {
                        ((Node)nodes[x]).Origin = ((Node)nodes[startIndex]);  // Set origin for path tracking
                        startIndex = x;  // Move to the best neighbor
                        break;  // Exit the loop after updating the index
                    }
                }

            } while (!((Node)nodes[startIndex]).Goal);  // Continue until goal is reached

            MessageBox.Show("Found: " + ((Node)nodes[startIndex]).Name);
            ((Node)nodes[startIndex]).Expanded = true;  // Mark the goal node as expanded
            return ((Node)nodes[startIndex]);  // Return the goal node
        }

        public double[] calculate(ArrayList nodes, Node start)
        {
            double[] heuristics = new double[nodes.Count];
            int deltaX, deltaY;

            // Calculate the heuristic values based on the Euclidean distance
            for (int i = 0; i < heuristics.Length; i++)
            {
                deltaX = Math.Abs(start.X - ((Node)nodes[i]).X);
                deltaY = Math.Abs(start.Y - ((Node)nodes[i]).Y);
                heuristics[i] = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));  // Euclidean distance
            }

            return heuristics;  // Return the array of heuristic values
        }
    }
}
