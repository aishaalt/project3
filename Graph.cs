using System;
using System.Collections.Generic;

/// <summary>
/// Represents a graph that supports both unweighted and weighted edges.
/// </summary>
public class Graph
{
    // Total number of nodes (vertices) in the graph.
    private int nodes;

    // Adjacency list for unweighted edges.
    // Each index corresponds to a node, and the list at that index contains all neighbouring nodes.
    private List<int>[] adjacencyList;

    // Adjacency list for weighted edges.
    // Each index corresponds to a node, and the list at that index contains tuples where the first element
    // is the neighbouring node and the second element is the weight of the edge.
    private List<(int, int)>[] weightedAdjacencyList;

    /// <summary>
    /// Initialises a new instance of the Graph class with a specified number of nodes.
    /// Allocates memory for both unweighted and weighted adjacency lists.
    /// </summary>
    /// <param name="nodes">The number of nodes (vertices) in the graph.</param>
    public Graph(int nodes)
    {
        this.nodes = nodes;

        // Initialise the arrays for unweighted and weighted adjacency lists.
        adjacencyList = new List<int>[nodes];
        weightedAdjacencyList = new List<(int, int)>[nodes];

        // For each node, create a new list for storing adjacent nodes.
        for (int i = 0; i < nodes; i++)
        {
            adjacencyList[i] = new List<int>();
            weightedAdjacencyList[i] = new List<(int, int)>();
        }
    }

    /// <summary>
    /// Adds an undirected edge between two nodes in the unweighted graph.
    /// </summary>
    /// <param name="u">The first node index.</param>
    /// <param name="v">The second node index.</param>
    public void AddEdgeUnweighted(int u, int v)
    {
        // Add each node to the other's list to represent an undirected edge.
        adjacencyList[u].Add(v);
        adjacencyList[v].Add(u);
    }

    /// <summary>
    /// Adds an undirected weighted edge between two nodes.
    /// </summary>
    /// <param name="u">The first node index.</param>
    /// <param name="v">The second node index.</param>
    /// <param name="weight">The weight of the edge connecting the nodes.</param>
    public void AddEdgeWeighted(int u, int v, int weight)
    {
        // For weighted graphs, add a tuple containing the neighbour and the weight.
        weightedAdjacencyList[u].Add((v, weight));
        weightedAdjacencyList[v].Add((u, weight));
    }

    /// <summary>
    /// Retrieves the unweighted adjacency list of the graph.
    /// </summary>
    /// <returns>An array where each element is a list of integers representing neighbouring nodes.</returns>
    public List<int>[] GetAdjacencyList() => adjacencyList;

    /// <summary>
    /// Retrieves the weighted adjacency list of the graph.
    /// </summary>
    /// <returns>
    /// An array where each element is a list of tuples.
    /// Each tuple contains a neighbouring node and the corresponding edge weight.
    /// </returns>
    public List<(int, int)>[] GetWeightedAdjacencyList() => weightedAdjacencyList;
}
