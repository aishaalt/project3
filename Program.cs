using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose Graph Type (1 = Unweighted, 2 = Weighted):");
        int graphType = Utilities.GetValidIntegerInput();

        Console.WriteLine("Enter Number of Nodes:");
        int nodes = Utilities.GetValidIntegerInput();

        Graph graph = new Graph(nodes);

        Console.WriteLine("Enter Number of Edges:");
        int edges = Utilities.GetValidIntegerInput();

        if (graphType == 1)
        {
            Console.WriteLine("Enter Edges (Format: u v):");
            for (int i = 0; i < edges; i++)
            {
                (int u, int v) = Utilities.GetValidEdgeInput(nodes);
                graph.AddEdgeUnweighted(u, v);
            }

            Console.WriteLine("Enter Node to Compute Influence Score:");
            int node = Utilities.GetValidNodeInput(nodes);

            double score = InfluenceScoreCalculator.ComputeInfluenceScoreUnweighted(graph, node);
            Utilities.PrintInfluenceScore("Unweighted", node, score);
        }
        else if (graphType == 2)
        {
            Console.WriteLine("Enter Weighted Edges (Format: u v weight):");
            for (int i = 0; i < edges; i++)
            {
                (int u, int v, int weight) = Utilities.GetValidWeightedEdgeInput(nodes);
                graph.AddEdgeWeighted(u, v, weight);
            }

            Console.WriteLine("Enter Node to Compute Influence Score:");
            int node = Utilities.GetValidNodeInput(nodes);

            double score = InfluenceScoreCalculator.ComputeInfluenceScoreWeighted(graph, node);
            Utilities.PrintInfluenceScore("Weighted", node, score);
        }
        else
        {
            Console.WriteLine("Invalid Graph Type!");
        }
    }
}
