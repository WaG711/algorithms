namespace algorithms.mission5;

public record GraphStep(
    Graph Graph,
    int? CurrentVertex = null,
    int[]? HighlightedVertices = null,
    int[]? ProcessedVertices = null,
    int[]? Distances = null,
    int[,]? DistanceMatrix = null);

public static class GraphVisualizer
{
    private const int Delay = 500;

    public static void Draw(GraphStep step)
    {
        Console.Clear();
        DrawGraph(step);
        Console.WriteLine();

        if (step.Distances != null)
        {
            DrawDistances(step);
        }

        if (step.DistanceMatrix != null)
        {
            DrawMatrix(step);
        }

        Console.ResetColor();
        Thread.Sleep(Delay);
    }

    private static void DrawGraph(GraphStep step)
    {
        for (int i = 1; i <= step.Graph.VertexCount; i++)
        {
            Console.ForegroundColor = GetColor(step, i);
            Console.Write($"[{i}]");
            Console.ResetColor();

            foreach (var edge in step.Graph.GetNeighbors(i))
            {
                Console.Write($" --({edge.Weight})--> ");
                Console.ForegroundColor = GetColor(step, edge.To);
                Console.Write($"[{edge.To}]");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }

    private static void DrawDistances(GraphStep step)
    {
        var distances = step.Distances!;
        var width = GetWidth(distances.Skip(1), step.Graph.VertexCount);

        for (int i = 1; i < distances.Length; i++)
        {
            Console.ForegroundColor = GetColor(step, i);
            Console.Write(Center(i.ToString(), width));
        }

        Console.WriteLine();

        for (int i = 1; i < distances.Length; i++)
        {
            Console.ForegroundColor = GetColor(step, i);
            Console.Write(Center(FormatDistance(distances[i]), width));
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    private static void DrawMatrix(GraphStep step)
    {
        var matrix = step.DistanceMatrix!;
        var count = step.Graph.VertexCount;
        var width = GetWidth(matrix.Cast<int>(), count);

        Console.Write(new string(' ', width));

        for (int j = 1; j <= count; j++)
        {
            Console.ForegroundColor = GetColor(step, j);
            Console.Write(Center(j.ToString(), width));
        }

        Console.ResetColor();
        Console.WriteLine();

        for (int i = 1; i <= count; i++)
        {
            Console.ForegroundColor = GetColor(step, i);
            Console.Write(Center(i.ToString(), width));

            for (int j = 1; j <= count; j++)
            {
                Console.ForegroundColor = i == step.CurrentVertex || j == step.CurrentVertex
                        ? ConsoleColor.Yellow
                        : ConsoleColor.Gray;

                if (step.HighlightedVertices?.Length == 2 &&
                    i == step.HighlightedVertices[0] &&
                    j == step.HighlightedVertices[1])
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.Write(Center(FormatDistance(matrix[i, j]), width));
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }

    private static ConsoleColor GetColor(GraphStep step, int vertex)
    {
        if (step.CurrentVertex == vertex)
        {
            return ConsoleColor.Yellow;
        }

        if (step.HighlightedVertices?.Contains(vertex) == true)
        {
            return ConsoleColor.Cyan;
        }

        if (step.ProcessedVertices?.Contains(vertex) == true)
        {
            return ConsoleColor.Green;
        }

        return ConsoleColor.Gray;
    }

    private static string FormatDistance(int distance)
    {
        return distance == int.MaxValue ? "∞" : distance.ToString();
    }

    private static int GetWidth(IEnumerable<int> distances, int vertexCount)
    {
        return Math.Max(Math.Max(6, vertexCount.ToString().Length + 2),
            distances.Max(x => FormatDistance(x).Length) + 2);
    }

    private static string Center(string value, int width)
    {
        var padding = Math.Max(0, width - value.Length);
        var left = padding / 2;
        var right = padding - left;

        return new string(' ', left) + value + new string(' ', right);
    }
}
