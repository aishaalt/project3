using System;
using System.Collections.Generic;

public class Graph
{
    private int nodes;
    private List<int>[] adjacencyList;
    private List<(int, int)>[] weightedAdjacencyList;

    public Graph(int nodes)
    {
        this.nodes = nodes;
        adjacencyList = new List<int>[nodes];
        weightedAdjacencyList = new List<(int, int)>[nodes];

        for (int i = 0; i < nodes; i++)
        {
            adjacencyList[i] = new List<int>();
            weightedAdjacencyList[i] = new List<(int, int)>();
        }
    }

    public void AddEdgeUnweighted(int u, int v)
    {
        adjacencyList[u].Add(v);
        adjacencyList[v].Add(u);
    }

    public void AddEdgeWeighted(int u, int v, int weight)
    {
        weightedAdjacencyList[u].Add((v, weight));
        weightedAdjacencyList[v].Add((u, weight));
    }

    public List<int>[] GetAdjacencyList() => adjacencyList;
    public List<(int, int)>[] GetWeightedAdjacencyList() => weightedAdjacencyList;
}
