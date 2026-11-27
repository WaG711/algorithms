namespace algorithms.mission2;

public static class SubstringSearch
{
    public static List<int> KmpSearch(string text, string pattern, Action<SearchStep>? onStep = null)
    {
        var result = new List<int>();
        var prefix = BuildPrefixFunction(pattern);

        int j = 0;

        for (int i = 0; i < text.Length; i++)
        {
            while (j > 0 && text[i] != pattern[j])
            {
                onStep?.Invoke(new SearchStep(text, pattern, i, j));

                j = prefix[j - 1];
            }

            onStep?.Invoke(new SearchStep(text, pattern, i, j));

            if (text[i] == pattern[j])
            {
                j++;
            }

            if (j == pattern.Length)
            {
                result.Add(i - pattern.Length + 1);

                j = prefix[j - 1];
            }
        }

        return result;
    }

    private static int[] BuildPrefixFunction(string pattern)
    {
        var prefix = new int[pattern.Length];

        for (int i = 1; i < pattern.Length; i++)
        {
            int j = prefix[i - 1];

            while (j > 0 && pattern[i] != pattern[j])
            {
                j = prefix[j - 1];
            }

            if (pattern[i] == pattern[j])
            {
                j++;
            }

            prefix[i] = j;
        }

        return prefix;
    }
}
