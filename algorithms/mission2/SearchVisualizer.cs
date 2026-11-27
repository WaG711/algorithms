namespace algorithms.mission2;

public record SearchStep(
    string Text,
    string Pattern,
    int TextIndex,
    int PatternIndex);

public static class SearchVisualizer
{
    private const int Delay = 300;

    public static void Draw(SearchStep step)
    {
        Console.Clear();

        int start = step.TextIndex - step.PatternIndex;

        for (int i = 0; i < step.Text.Length; i++)
        {
            Console.Write($"{i,3}");
        }

        Console.WriteLine();

        for (int i = 0; i < step.Text.Length; i++)
        {
            Console.ForegroundColor = GetColor(step, i);

            Console.Write($"{step.Text[i],3}");
        }

        Console.ResetColor();
        Console.WriteLine();

        Console.Write(new string(' ', start * 3));

        for (int i = 0; i < step.Pattern.Length; i++)
        {
            Console.ForegroundColor = i < step.PatternIndex
                ? ConsoleColor.Green
                : ConsoleColor.Gray;

            if (i == step.PatternIndex)
            {
                Console.ForegroundColor = step.Text[step.TextIndex] == step.Pattern[i]
                        ? ConsoleColor.Yellow
                        : ConsoleColor.Red;
            }

            Console.Write($"{step.Pattern[i],3}");
        }

        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine();

        Thread.Sleep(Delay);
    }

    private static ConsoleColor GetColor(SearchStep step, int index)
    {
        if (index == step.TextIndex)
        {
            return step.Text[index] == step.Pattern[step.PatternIndex]
                ? ConsoleColor.Yellow
                : ConsoleColor.Red;
        }

        int start = step.TextIndex - step.PatternIndex;

        if (index >= start && index < step.TextIndex)
        {
            return ConsoleColor.Green;
        }

        return ConsoleColor.Gray;
    }
}
