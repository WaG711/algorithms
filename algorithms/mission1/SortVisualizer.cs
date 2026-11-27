using System.Numerics;

namespace algorithms.mission1;

public record SortStep<T>(IList<T> Items, params int[] HighlightedIndices);

public static class SortVisualizer
{
    private const int MaxHeight = 15;
    private const int Delay = 150;

    public static void Draw<T>(SortStep<T> step) where T : INumber<T>
    {
        Console.Clear();

        if (step.Items.Count == 0)
        {
            return;
        }

        var minValue = decimal.CreateChecked(step.Items.Min()!);
        var maxValue = decimal.CreateChecked(step.Items.Max()!);

        var columnWidth = Math.Max(4, step.Items.Max(x => x.ToString()!.Length) + 2);

        for (int height = MaxHeight; height > 0; height--)
        {
            for (int i = 0; i < step.Items.Count; i++)
            {
                Console.ForegroundColor = GetColor(step, i);

                decimal value = decimal.CreateChecked(step.Items[i]);

                var scaledHeight = maxValue != minValue
                    ? 1 + (int)Math.Round(
                        (value - minValue)
                        / (maxValue - minValue)
                        * (MaxHeight - 1))
                    : MaxHeight;

                Console.Write(scaledHeight >= height
                    ? Center("██", columnWidth)
                    : new string(' ', columnWidth));
            }

            Console.WriteLine();
        }

        Console.ResetColor();

        foreach (var item in step.Items)
        {
            Console.Write(Center(item.ToString()!, columnWidth));
        }

        Console.WriteLine();

        Thread.Sleep(Delay);
    }

    private static ConsoleColor GetColor<T>(SortStep<T> step, int index)
    {
        if (step.HighlightedIndices.Length == 0)
        {
            return ConsoleColor.Green;
        }

        if (step.HighlightedIndices.Contains(index))
        {
            return ConsoleColor.Yellow;
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
