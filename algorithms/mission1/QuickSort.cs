namespace algorithms.mission1;

public static class QuickSort
{
    public static void HoareSort<T>(this IList<T> items, IComparer<T>? comparer = null, Action<SortStep<T>>? onStep = null)
    {
        ArgumentNullException.ThrowIfNull(items);

        comparer ??= Comparer<T>.Default;

        Sort(items, 0, items.Count - 1, comparer, onStep);

        onStep?.Invoke(new SortStep<T>(items));
    }

    private static void Sort<T>(IList<T> items, int left, int right, IComparer<T> comparer, Action<SortStep<T>>? onStep)
    {
        if (left >= right)
        {
            return;
        }

        int partition = Partition(items, left, right, comparer, onStep);

        Sort(items, left, partition, comparer, onStep);
        Sort(items, partition + 1, right, comparer, onStep);
    }

    private static int Partition<T>(IList<T> items, int left, int right, IComparer<T> comparer, Action<SortStep<T>>? onStep)
    {
        T pivot = MedianOfThree(items, left, right, comparer);

        int i = left - 1;
        int j = right + 1;

        onStep?.Invoke(new SortStep<T>(items, Enumerable.Range(left, right - left + 1).ToArray()));

        while (true)
        {
            do
            {
                i++;
            }
            while (comparer.Compare(items[i], pivot) < 0);

            do
            {
                j--;
            }
            while (comparer.Compare(items[j], pivot) > 0);

            if (i >= j)
            {
                return j;
            }

            (items[i], items[j]) = (items[j], items[i]);

            onStep?.Invoke(new SortStep<T>(items, i, j));
        }
    }

    private static T MedianOfThree<T>(IList<T> items, int left, int right, IComparer<T> comparer)
    {
        int middle = left + (right - left) / 2;

        T a = items[left];
        T b = items[middle];
        T c = items[right];

        if (comparer.Compare(a, b) > 0)
        {
            (a, b) = (b, a);
        }

        if (comparer.Compare(a, c) > 0)
        {
            (a, c) = (c, a);
        }

        if (comparer.Compare(b, c) > 0)
        {
            (b, c) = (c, b);
        }

        return b;
    }
}
