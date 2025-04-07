using System;
using System.Collections.Generic;

public static class Algorithms
{
    public static int[] BFS(Graph graph, int start)
    {
        int nodes = graph.GetAdjacencyList().Length;
        int[] distances = new int[nodes];
        bool[] visited = new bool[nodes];
        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < nodes; i++) distances[i] = int.MaxValue;
        distances[start] = 0;
        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();
            foreach (int neighbour in graph.GetAdjacencyList()[currentNode])
            {
                if (!visited[neighbour])
                {
                    visited[neighbour] = true;
                    distances[neighbour] = distances[currentNode] + 1;
                    queue.Enqueue(neighbour);
                }
            }
        }
        return distances;
    }

    public static int[] Dijkstra(Graph graph, int start)
    {
        int nodes = graph.GetWeightedAdjacencyList().Length;
        int[] distances = new int[nodes];
        bool[] visited = new bool[nodes];
        PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();

        for (int i = 0; i < nodes; i++) distances[i] = int.MaxValue;
        distances[start] = 0;
        pq.Enqueue((start, 0), 0);

        while (pq.Count > 0)
        {
            var (currentNode, currentDistance) = pq.Dequeue();
            if (visited[currentNode]) continue;
            visited[currentNode] = true;

            foreach (var (neighbour, weight) in graph.GetWeightedAdjacencyList()[currentNode])
            {
                int newDistance = distances[currentNode] + weight;
                if (newDistance < distances[neighbour])
                {
                    distances[neighbour] = newDistance;
                    pq.Enqueue((neighbour, newDistance), newDistance);
                }
            }
        }
        return distances;
    }
}
