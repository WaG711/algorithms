namespace algorithms.mission5;

public record Edge(int To, int Weight);

public class Graph
{
    private readonly List<Edge>[] adjacencyList;

    public int VertexCount { get; }

    public Graph(int vertexCount)
    {
        VertexCount = vertexCount;

        adjacencyList = new List<Edge>[vertexCount + 1];

        for (int i = 0; i <= vertexCount; i++)
        {
            adjacencyList[i] = new List<Edge>();
        }
    }

    public void AddEdge(int from, int to, int weight)
    {
        adjacencyList[from].Add(new Edge(to, weight));
        adjacencyList[to].Add(new Edge(from, weight));
    }

    public IReadOnlyList<Edge> GetNeighbors(int vertex)
    {
        return adjacencyList[vertex];
    }
}
