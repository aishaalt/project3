using System;
using System.Collections.Generic;

/// <summary>
/// This static class provides common graph algorithms including Breadth-First Search (BFS) 
/// and Dijkstra's algorithm for computing shortest paths in a graph.
/// </summary>
public static class Algorithms
{
    /// <summary>
    /// Performs a Breadth-First Search (BFS) on an unweighted graph starting from the given node.
    /// Returns an array where each index represents the distance (in number of edges) from the start node.
    /// </summary>
    /// <param name="graph">The graph represented by an adjacency list.</param>
    /// <param name="start">The starting node index for the BFS.</param>
    /// <returns>An array of distances from the start node to each node in the graph.</returns>
    public static int[] BFS(Graph graph, int start)
    {
        // Determine the total number of nodes from the adjacency list.
        int nodes = graph.GetAdjacencyList().Length;
        // Initialise the distances array; all distances start at int.MaxValue (i.e. 'infinity').
        int[] distances = new int[nodes];
        // Boolean array to track which nodes have been visited.
        bool[] visited = new bool[nodes];
        // Queue to maintain the order in which nodes are to be visited.
        Queue<int> queue = new Queue<int>();

        // Set initial distances to a very high value.
        for (int i = 0; i < nodes; i++) distances[i] = int.MaxValue;
        // The starting node is at distance 0 from itself.
        distances[start] = 0;
        // Mark the starting node as visited.
        visited[start] = true;
        // Enqueue the starting node to begin the traversal.
        queue.Enqueue(start);

        // Process nodes until there are none left in the queue.
        while (queue.Count > 0)
        {
            // Dequeue the next node to process.
            int currentNode = queue.Dequeue();
            // Iterate through each neighbour of the current node.
            foreach (int neighbour in graph.GetAdjacencyList()[currentNode])
            {
                // If the neighbour has not been visited, process it.
                if (!visited[neighbour])
                {
                    // Mark the neighbour as visited.
                    visited[neighbour] = true;
                    // Update the distance for the neighbour as one more than the current node's distance.
                    distances[neighbour] = distances[currentNode] + 1;
                    // Enqueue the neighbour for further exploration.
                    queue.Enqueue(neighbour);
                }
            }
        }
        // Return the computed distances from the start node.
        return distances;
    }

    /// <summary>
    /// Implements Dijkstra's algorithm to calculate the shortest path distances in a weighted graph
    /// starting from a specified node. Returns an array of the minimum distances to each node.
    /// </summary>
    /// <param name="graph">The weighted graph represented by a weighted adjacency list.</param>
    /// <param name="start">The starting node index for the algorithm.</param>
    /// <returns>An array containing the shortest distances from the start node to every other node.</returns>
    public static int[] Dijkstra(Graph graph, int start)
    {
        // Determine the total number of nodes using the weighted adjacency list.
        int nodes = graph.GetWeightedAdjacencyList().Length;
        // Initialise the distances array; all distances are set to int.MaxValue initially.
        int[] distances = new int[nodes];
        // Boolean array to track whether a node's shortest distance has been finalized.
        bool[] visited = new bool[nodes];
        // Priority queue to efficiently select the next node with the smallest tentative distance.
        PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();

        // Set all initial distances to a very high value.
        for (int i = 0; i < nodes; i++) distances[i] = int.MaxValue;
        // The distance from the start node to itself is zero.
        distances[start] = 0;
        // Enqueue the start node with a distance of zero.
        pq.Enqueue((start, 0), 0);

        // Continue processing nodes until the priority queue is empty.
        while (pq.Count > 0)
        {
            // Dequeue the node with the smallest tentative distance.
            var (currentNode, currentDistance) = pq.Dequeue();
            // If this node has already been visited, skip it.
            if (visited[currentNode]) continue;
            // Mark the node as visited to indicate its shortest distance is now final.
            visited[currentNode] = true;

            // Iterate over each neighbour and the corresponding weight from the current node.
            foreach (var (neighbour, weight) in graph.GetWeightedAdjacencyList()[currentNode])
            {
                // Compute the new tentative distance to this neighbour.
                int newDistance = distances[currentNode] + weight;
                // If the computed distance is less than the known distance, update it.
                if (newDistance < distances[neighbour])
                {
                    distances[neighbour] = newDistance;
                    // Enqueue the neighbour with its updated distance for further processing.
                    pq.Enqueue((neighbour, newDistance), newDistance);
                }
            }
        }
        // Return the array of shortest distances from the start node.
        return distances;
    }
}
