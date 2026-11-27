namespace algorithms.mission1;

public static class BubbleSort
{
    private static readonly decimal shrinkFactor = 1.247m;

    public static void CombCocktailSort<T>(this IList<T> items, IComparer<T>? comparer = null, Action<SortStep<T>>? onStep = null)
    {
        ArgumentNullException.ThrowIfNull(items);

        comparer ??= Comparer<T>.Default;

        int count = items.Count;
        int gap = count;
        bool swapped = true;

        while (gap > 1 || swapped)
        {
            swapped = false;

            gap = Math.Max(1, (int)(gap / shrinkFactor));

            for (int i = 0; i < count - gap; i++)
            {
                if (comparer.Compare(items[i], items[i + gap]) > 0)
                {
                    (items[i], items[i + gap]) = (items[i + gap], items[i]);

                    swapped = true;
                }

                onStep?.Invoke(new SortStep<T>(items, i, i + gap));
            }

            gap = Math.Max(1, (int)(gap / shrinkFactor));

            for (int i = count - 1; i >= gap; i--)
            {
                if (comparer.Compare(items[i - gap], items[i]) > 0)
                {
                    (items[i - gap], items[i]) = (items[i], items[i - gap]);

                    swapped = true;
                }

                onStep?.Invoke(new SortStep<T>(items, i - gap, i));
            }
        }

        onStep?.Invoke(new SortStep<T>(items));
    }
}
