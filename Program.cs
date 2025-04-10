using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to choose the type of graph (unweighted or weighted).
        Console.WriteLine("Choose Graph Type (1 = Unweighted, 2 = Weighted):");
        int graphType = Utilities.GetValidIntegerInput();

        // Prompt the user to enter the total number of nodes in the graph.
        Console.WriteLine("Enter Number of Nodes:");
        int nodes = Utilities.GetValidIntegerInput();

        // Create a new graph instance with the specified number of nodes.
        Graph graph = new Graph(nodes);

        // Prompt the user to enter the number of edges to be added to the graph.
        Console.WriteLine("Enter Number of Edges:");
        int edges = Utilities.GetValidIntegerInput();

        // If the graph is unweighted:
        if (graphType == 1)
        {
            // Inform the user about the input format for unweighted edges.
            Console.WriteLine("Enter Edges (Format: u v):");
            for (int i = 0; i < edges; i++)
            {
                // Get a valid edge input (two nodes: u and v) from the user.
                (int u, int v) = Utilities.GetValidEdgeInput(nodes);
                // Add an undirected edge between node u and node v.
                graph.AddEdgeUnweighted(u, v);
            }

            // Prompt the user to select a node for which to compute the influence score.
            Console.WriteLine("Enter Node to Compute Influence Score:");
            int node = Utilities.GetValidNodeInput(nodes);

            // Compute the influence score for the selected node using the unweighted approach.
            double score = InfluenceScoreCalculator.ComputeInfluenceScoreUnweighted(graph, node);
            // Print the computed influence score to the console.
            Utilities.PrintInfluenceScore("Unweighted", node, score);
        }
        // If the graph is weighted:
        else if (graphType == 2)
        {
            // Inform the user about the input format for weighted edges.
            Console.WriteLine("Enter Weighted Edges (Format: u v weight):");
            for (int i = 0; i < edges; i++)
            {
                // Get a valid weighted edge input (two nodes and a weight) from the user.
                (int u, int v, int weight) = Utilities.GetValidWeightedEdgeInput(nodes);
                // Add an undirected weighted edge between node u and node v with the specified weight.
                graph.AddEdgeWeighted(u, v, weight);
            }

            // Prompt the user to select a node for which to compute the influence score.
            Console.WriteLine("Enter Node to Compute Influence Score:");
            int node = Utilities.GetValidNodeInput(nodes);

            // Compute the influence score for the selected node using the weighted approach.
            double score = InfluenceScoreCalculator.ComputeInfluenceScoreWeighted(graph, node);
            // Print the computed influence score to the console.
            Utilities.PrintInfluenceScore("Weighted", node, score);
        }
        // If an invalid graph type is selected, notify the user.
        else
        {
            Console.WriteLine("Invalid Graph Type!");
        }
    }
}
