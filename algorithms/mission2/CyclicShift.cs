namespace algorithms.mission2;

public static class CyclicShift
{
    public static int FindMinRightShift(string s, string t, Action<SearchStep>? onStep = null)
    {
        if (s.Length != t.Length)
        {
            return -1;
        }

        if (s == t)
        {
            return 0;
        }

        int n = s.Length;

        var indices = SubstringSearch.KmpSearch(s + s, t, onStep);

        int minShift = int.MaxValue;

        foreach (int index in indices)
        {
            int shift = (n - index) % n;
            minShift = Math.Min(minShift, shift);
        }

        return minShift == int.MaxValue ? -1 : minShift;
    }
}
