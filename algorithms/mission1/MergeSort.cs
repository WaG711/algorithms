namespace algorithms.mission1;

public static class MergeSort
{
    public static void BottomUpSort<T>(this IList<T> items, IComparer<T>? comparer = null, Action<SortStep<T>>? onStep = null)
    {
        ArgumentNullException.ThrowIfNull(items);

        comparer ??= Comparer<T>.Default;

        var count = items.Count;
        var buffer = new T[count];

        for (long width = 1; width < count; width *= 2)
        {
            for (long start = 0; start < count; start += 2 * width)
            {
                var left = (int)start;
                var middle = (int)Math.Min(start + width, count);
                var right = (int)Math.Min(start + 2 * width, count);

                if (middle == right)
                {
                    continue;
                }

                Merge(items, buffer, left, middle, right, comparer, onStep);
            }
        }

        onStep?.Invoke(new SortStep<T>(items));
    }

    private static void Merge<T>(IList<T> items, T[] buffer, int left, int middle, int right, IComparer<T> comparer, Action<SortStep<T>>? onStep)
    {
        var i = left;
        var j = middle;
        var k = left;

        var highlightedIndices = Enumerable
            .Range(left, right - left)
            .ToArray();

        onStep?.Invoke(new SortStep<T>(items, highlightedIndices));

        while (i < middle && j < right)
        {
            if (comparer.Compare(items[i], items[j]) <= 0)
            {
                buffer[k++] = items[i++];
            }
            else
            {
                buffer[k++] = items[j++];
            }
        }

        while (i < middle)
        {
            buffer[k++] = items[i++];
        }

        while (j < right)
        {
            buffer[k++] = items[j++];
        }

        for (int index = left; index < right; index++)
        {
            items[index] = buffer[index];

            onStep?.Invoke(new SortStep<T>(items, highlightedIndices));
        }
    }
}
