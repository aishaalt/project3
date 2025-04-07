public static class InfluenceScoreCalculator
{
    public static double ComputeInfluenceScoreUnweighted(Graph graph, int node)
    {
        int[] distances = Algorithms.BFS(graph, node);
        int totalDistance = 0;

        foreach (int d in distances) if (d != int.MaxValue) totalDistance += d;
        return (graph.GetAdjacencyList().Length - 1) / (double)totalDistance;
    }

    public static double ComputeInfluenceScoreWeighted(Graph graph, int node)
    {
        int[] distances = Algorithms.Dijkstra(graph, node);
        int totalDistance = 0;

        foreach (int d in distances) if (d != int.MaxValue) totalDistance += d;
        return (graph.GetWeightedAdjacencyList().Length - 1) / (double)totalDistance;
    }
}
