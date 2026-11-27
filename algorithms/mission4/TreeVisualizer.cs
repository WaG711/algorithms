namespace algorithms.mission4;

public record TreeStep<T>(
    TreeNode<T>? Root,
    TreeNode<T>? CurrentNode = null,
    bool? IsValid = null,
    int? LeftHeight = null,
    int? RightHeight = null);

public static class TreeVisualizer
{
    private const int Delay = 500;

    public static void Draw<T>(TreeStep<T> step)
    {
        Console.Clear();

        PrintTree(step.Root, "", "", step);

        Console.WriteLine();

        if (step.LeftHeight.HasValue && step.RightHeight.HasValue)
        {
            Console.WriteLine($"Difference: {Math.Abs(step.LeftHeight.Value - step.RightHeight.Value)}");
        }

        Thread.Sleep(Delay);
    }

    private static void PrintTree<T>(TreeNode<T>? node, string indent, string branch, TreeStep<T> step)
    {
        if (node == null)
        {
            return;
        }

        PrintTree(node.Right, indent + "    ", "┌── ", step);

        Console.Write(indent);
        Console.Write(branch);

        Console.ForegroundColor = GetColor(node, step);

        Console.WriteLine(node.Value);

        Console.ResetColor();

        PrintTree(node.Left, indent + "    ", "└── ", step);
    }

    private static ConsoleColor GetColor<T>(TreeNode<T> node, TreeStep<T> step)
    {
        if (!ReferenceEquals(node, step.CurrentNode))
        {
            return ConsoleColor.Gray;
        }

        return step.IsValid switch
        {
            true => ConsoleColor.Green,
            false => ConsoleColor.Red,
            null => ConsoleColor.Yellow
        };
    }
}
