using System;

public static class Utilities
{
    /// <summary>
    /// Continuously reads input from the console until a valid integer is entered.
    /// </summary>
    /// <returns>A valid integer entered by the user.</returns>
    public static int GetValidIntegerInput()
    {
        while (true)
        {
            // Read a line of input from the console.
            string input = Console.ReadLine();
            // Attempt to parse the input as an integer.
            if (int.TryParse(input, out int result))
            {
                // Return the parsed integer if successful.
                return result;
            }
            // Inform the user that the input was invalid and prompt again.
            Console.WriteLine("Invalid input. Please enter a valid integer:");
        }
    }

    /// <summary>
    /// Prompts the user for a valid node index within the specified range.
    /// </summary>
    /// <param name="nodes">The total number of nodes in the graph.</param>
    /// <returns>A valid node index between 0 and nodes - 1.</returns>
    public static int GetValidNodeInput(int nodes)
    {
        while (true)
        {
            // Retrieve a valid integer using the helper method.
            int node = GetValidIntegerInput();
            // Check if the node index is within the acceptable range.
            if (node >= 0 && node < nodes)
            {
                return node;
            }
            // Inform the user of the valid node index range if the input is out of bounds.
            Console.WriteLine($"Invalid node. Node index must be between 0 and {nodes - 1}. Please try again:");
        }
    }

    /// <summary>
    /// Ensures the user inputs a valid edge for an unweighted graph in the format "u v".
    /// </summary>
    /// <param name="nodes">The total number of nodes in the graph.</param>
    /// <returns>A tuple containing the two valid node indices for the edge.</returns>
    public static (int, int) GetValidEdgeInput(int nodes)
    {
        while (true)
        {
            // Prompt the user to enter an edge.
            Console.Write("Enter edge (Format: u v): ");
            // Read the input and split it into parts using whitespace as a separator.
            string[] edge = Console.ReadLine().Split();

            // Validate that exactly two values are entered, both are integers, and within the valid range.
            if (edge.Length == 2 &&
                int.TryParse(edge[0], out int u) &&
                int.TryParse(edge[1], out int v) &&
                u >= 0 && u < nodes &&
                v >= 0 && v < nodes)
            {
                return (u, v);
            }
            // Notify the user about the correct format and valid range if input is invalid.
            Console.WriteLine($"Invalid edge input. Please enter two integers between 0 and {nodes - 1}, separated by a space.");
        }
    }

    /// <summary>
    /// Ensures the user inputs a valid weighted edge for a graph in the format "u v weight".
    /// </summary>
    /// <param name="nodes">The total number of nodes in the graph.</param>
    /// <returns>A tuple containing the two valid node indices and the positive integer weight for the edge.</returns>
    public static (int, int, int) GetValidWeightedEdgeInput(int nodes)
    {
        while (true)
        {
            // Prompt the user to enter a weighted edge.
            Console.Write("Enter weighted edge (Format: u v weight): ");
            // Read the input and split it into parts.
            string[] edge = Console.ReadLine().Split();

            // Validate that exactly three values are entered, the first two are valid node indices,
            // and the third is a positive integer weight.
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
            // Inform the user about the correct input format and valid ranges if input is invalid.
            Console.WriteLine($"Invalid weighted edge input. Please enter two node indices between 0 and {nodes - 1}, followed by a positive integer weight.");
        }
    }

    /// <summary>
    /// Displays the computed influence score in a formatted manner.
    /// </summary>
    /// <param name="graphType">A string indicating the type of graph ("Unweighted" or "Weighted").</param>
    /// <param name="node">The node for which the influence score was computed.</param>
    /// <param name="score">The calculated influence score.</param>
    public static void PrintInfluenceScore(string graphType, int node, double score)
    {
        // Output the influence score to the console formatted to two decimal places.
        Console.WriteLine($"{graphType} Influence Score for Node {node}: {score:F2}");
    }
}
