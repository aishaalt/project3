/// <summary>
/// A static class for computing the influence score of a node in a graph.
/// The influence score is calculated as the ratio of the number of other nodes
/// in the graph to the total distance from the target node to all other reachable nodes.
/// A higher score indicates that the node is, on average, closer to all other nodes.
/// </summary>
public static class InfluenceScoreCalculator
{
    /// <summary>
    /// Computes the influence score for a given node in an unweighted graph.
    /// The score is calculated using Breadth-First Search (BFS) to determine the shortest
    /// number of edges (or steps) required to reach each node.
    /// </summary>
    /// <param name="graph">The unweighted graph on which to calculate the influence score.</param>
    /// <param name="node">The index of the node for which the influence score is computed.</param>
    /// <returns>
    /// A double representing the influence score. The score is defined as:
    /// (number of other nodes in the graph) / (total distance from the target node to all reachable nodes).
    /// </returns>
    public static double ComputeInfluenceScoreUnweighted(Graph graph, int node)
    {
        // Get the shortest distances from the target node to all other nodes using BFS.
        int[] distances = Algorithms.BFS(graph, node);
        int totalDistance = 0;

        // Sum the distances for all reachable nodes (ignoring nodes with int.MaxValue, which indicate unreachable nodes).
        foreach (int d in distances)
            if (d != int.MaxValue)
                totalDistance += d;

        // Calculate and return the influence score.
        // The denominator is the sum of distances, and the numerator is the total number of other nodes.
        return (graph.GetAdjacencyList().Length - 1) / (double)totalDistance;
    }

    /// <summary>
    /// Computes the influence score for a given node in a weighted graph.
    /// The score is calculated using Dijkstra's algorithm to determine the shortest path distances
    /// considering the edge weights.
    /// </summary>
    /// <param name="graph">The weighted graph on which to calculate the influence score.</param>
    /// <param name="node">The index of the node for which the influence score is computed.</param>
    /// <returns>
    /// A double representing the influence score. It is defined as:
    /// (number of other nodes in the graph) / (total weighted distance from the target node to all reachable nodes).
    /// </returns>
    public static double ComputeInfluenceScoreWeighted(Graph graph, int node)
    {
        // Get the shortest weighted distances from the target node using Dijkstra's algorithm.
        int[] distances = Algorithms.Dijkstra(graph, node);
        int totalDistance = 0;

        // Sum the distances for all reachable nodes (ignoring nodes with int.MaxValue, which indicate unreachable nodes).
        foreach (int d in distances)
            if (d != int.MaxValue)
                totalDistance += d;

        // Calculate and return the influence score.
        // The numerator represents the number of other nodes in the graph.
        return (graph.GetWeightedAdjacencyList().Length - 1) / (double)totalDistance;
    }
}
