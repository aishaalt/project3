using System;

public static class Utilities
{
    public static int GetValidIntegerInput()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer:");
        }
    }

    public static int GetValidNodeInput(int nodes)
    {
        while (true)
        {
            int node = GetValidIntegerInput();
            if (node >= 0 && node < nodes)
            {
                return node;
            }
            Console.WriteLine($"Invalid node. Node index must be between 0 and {nodes - 1}. Please try again:");
        }
    }

    /// <summary>
    /// Ensures the user inputs a valid edge for an unweighted graph (u v).
    /// </summary>
    public static (int, int) GetValidEdgeInput(int nodes)
    {
        while (true)
        {
            Console.Write("Enter edge (Format: u v): ");
            string[] edge = Console.ReadLine().Split();

            if (edge.Length == 2 &&
                int.TryParse(edge[0], out int u) &&
                int.TryParse(edge[1], out int v) &&
                u >= 0 && u < nodes &&
                v >= 0 && v < nodes)
            {
                return (u, v);
            }
            Console.WriteLine($"Invalid edge input. Please enter two integers between 0 and {nodes - 1}, separated by a space.");
        }
    }

    public static (int, int, int) GetValidWeightedEdgeInput(int nodes)
    {
        while (true)
        {
            Console.Write("Enter weighted edge (Format: u v weight): ");
            string[] edge = Console.ReadLine().Split();

            if (edge.Length == 3 &&
                int.TryParse(edge[0], out int u) &&
                int.TryParse(edge[1], out int v) &&
                int.TryParse(edge[2], out int weight) &&
                u >= 0 && u < nodes &&
                v >= 0 && v < nodes &&
                weight > 0)
            {
                return (u, v, weight);
            }
            Console.WriteLine($"Invalid weighted edge input. Please enter two node indices between 0 and {nodes - 1}, followed by a positive integer weight.");
        }
    }

    /// <summary>
    /// Displays the influence score result in a formatted manner.
    /// </summary>
    public static void PrintInfluenceScore(string graphType, int node, double score)
    {
        Console.WriteLine($"{graphType} Influence Score for Node {node}: {score:F2}");
    }
}
