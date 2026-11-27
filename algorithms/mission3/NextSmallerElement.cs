namespace algorithms.mission3;

public static class NextSmallerElement
{
    public static int[] FindIndices<T>(IList<T> items, IComparer<T>? comparer = null, Action<SequenceStep<T>>? onStep = null)
    {
        ArgumentNullException.ThrowIfNull(items);

        comparer ??= Comparer<T>.Default;

        int count = items.Count;

        var result = new int[count];
        Array.Fill(result, -2);

        var stack = new Stack<int>();

        for (int i = count - 1; i >= 0; i--)
        {
            onStep?.Invoke(new SequenceStep<T>(items, i, stack.ToArray(), Result: result));

            while (stack.Count > 0 && comparer.Compare(items[stack.Peek()], items[i]) >= 0)
            {
                stack.Pop();

                onStep?.Invoke(new SequenceStep<T>(items, i, stack.ToArray(), Result: result));
            }

            result[i] = stack.Count > 0
                ? stack.Peek()
                : -1;

            stack.Push(i);

            onStep?.Invoke(new SequenceStep<T>(items, i, stack.ToArray(), Result: result));
        }

        onStep?.Invoke(new SequenceStep<T>(items, Result: result));

        return result;
    }
}
