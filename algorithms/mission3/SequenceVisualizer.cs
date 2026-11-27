namespace algorithms.mission3;

public record SequenceStep<T>(
    IList<T> Items,
    int? CurrentIndex = null,
    int[]? HighlightedIndices = null,
    int[]? RemovedIndices = null,
    int[]? Result = null);

public static class SequenceVisualizer
{
    private const int Delay = 300;

    public static void Draw<T>(SequenceStep<T> step)
    {
        Console.Clear();

        var width = Math.Max(4, step.Items.Select(x => x?.ToString()?.Length ?? 0)
            .DefaultIfEmpty(0)
            .Max() + 2);

        for (int i = 0; i < step.Items.Count; i++)
        {
            Console.Write(Center(i.ToString(), width));
        }

        Console.WriteLine();

        for (int i = 0; i < step.Items.Count; i++)
        {
            Console.ForegroundColor = GetColor(step, i);
            Console.Write(Center(step.Items[i]?.ToString() ?? "", width));
        }

        Console.ResetColor();
        Console.WriteLine();

        if (step.Result != null)
        {
            foreach (int value in step.Result)
            {
                Console.Write(Center(value == -2 ? "-" : value.ToString(), width));
            }

            Console.WriteLine();
        }

        Thread.Sleep(Delay);
    }

    private static ConsoleColor GetColor<T>(SequenceStep<T> step, int index)
    {
        if (step.RemovedIndices?.Contains(index) == true)
        {
            return ConsoleColor.Red;
        }

        if (step.CurrentIndex == index)
        {
            return ConsoleColor.Yellow;
        }

        if (step.HighlightedIndices?.Contains(index) == true)
        {
            return ConsoleColor.Green;
        }

        return ConsoleColor.Gray;
    }

    private static string Center(string value, int width)
    {
        var padding = Math.Max(0, width - value.Length);
        var left = padding / 2;
        var right = padding - left;

        return new string(' ', left) + value + new string(' ', right);
    }
}
