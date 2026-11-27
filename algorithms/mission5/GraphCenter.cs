namespace algorithms.mission5;

public static class GraphCenter
{
    public static int FindCenter(Graph graph, Action<GraphStep>? onStep = null)
    {
        var distances = FindShortestPaths(graph, onStep);

        var count = graph.VertexCount;
        var bestVertex = 1;
        var minDistance = int.MaxValue;

        var maximumDistances = new int[count + 1];

        Array.Fill(maximumDistances, int.MaxValue);

        for (int i = 1; i <= count; i++)
        {
            var maxDistance = 0;

            for (int j = 1; j <= count; j++)
            {
                maxDistance = Math.Max(maxDistance, distances[i, j]);
            }

            maximumDistances[i] = maxDistance;

            if (maxDistance < minDistance)
            {
                minDistance = maxDistance;
                bestVertex = i;
            }

            onStep?.Invoke(new GraphStep(graph, CurrentVertex: i, ProcessedVertices: new[] { bestVertex }, Distances: maximumDistances, DistanceMatrix: distances));
        }

        onStep?.Invoke(new GraphStep(graph, ProcessedVertices: new[] { bestVertex }, Distances: maximumDistances, DistanceMatrix: distances));

        return bestVertex;
    }

    public static int[,] FindShortestPaths(Graph graph, Action<GraphStep>? onStep = null)
    {
        var count = graph.VertexCount;

        var distances = new int[count + 1, count + 1];

        for (int i = 1; i <= count; i++)
        {
            for (int j = 1; j <= count; j++)
            {
                distances[i, j] = i == j ? 0 : int.MaxValue;
            }
        }

        for (int i = 1; i <= count; i++)
        {
            foreach (var edge in graph.GetNeighbors(i))
            {
                distances[i, edge.To] = Math.Min(distances[i, edge.To], edge.Weight);
            }
        }

        onStep?.Invoke(new GraphStep(graph, DistanceMatrix: distances));

        for (int k = 1; k <= count; k++)
        {
            onStep?.Invoke(new GraphStep(graph, CurrentVertex: k, DistanceMatrix: distances));

            for (int i = 1; i <= count; i++)
            {
                for (int j = 1; j <= count; j++)
                {
                    if (distances[i, k] == int.MaxValue ||
                        distances[k, j] == int.MaxValue)
                    {
                        continue;
                    }

                    var newDistance = distances[i, k] + distances[k, j];

                    if (newDistance < distances[i, j])
                    {
                        distances[i, j] = newDistance;
                        onStep?.Invoke(new GraphStep(graph, CurrentVertex: k, HighlightedVertices: new[] { i, j }, DistanceMatrix: distances));
                    }
                }
            }
        }

        onStep?.Invoke(new GraphStep(graph, DistanceMatrix: distances));

        return distances;
    }
}
