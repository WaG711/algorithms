namespace algorithms.mission5;

public static class Dijkstra
{
    public static int[] FindShortestPaths(Graph graph, int start, Action<GraphStep>? onStep = null)
    {
        var distances = new int[graph.VertexCount + 1];

        Array.Fill(distances, int.MaxValue);

        distances[start] = 0;

        var queue = new PriorityQueue<int, int>();
        var processed = new HashSet<int>();

        queue.Enqueue(start, 0);

        onStep?.Invoke(new GraphStep(graph, Distances: distances));

        while (queue.TryDequeue(out int current, out int distance))
        {
            if (distance > distances[current])
            {
                continue;
            }

            onStep?.Invoke(new GraphStep(graph, current, ProcessedVertices: processed.ToArray(), Distances: distances));

            foreach (var edge in graph.GetNeighbors(current))
            {
                var newDistance = distance + edge.Weight;

                if (newDistance < distances[edge.To])
                {
                    distances[edge.To] = newDistance;

                    queue.Enqueue(edge.To, newDistance);

                    onStep?.Invoke(new GraphStep(graph, current, new[] { edge.To }, processed.ToArray(), distances));
                }
            }

            processed.Add(current);

            onStep?.Invoke(new GraphStep(graph, ProcessedVertices: processed.ToArray(), Distances: distances));
        }

        return distances;
    }
}