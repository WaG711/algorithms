using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.mission3;

public static class BracketSequence
{
    public static int FindMinDeletions(string sequence, Action<SequenceStep<char>>? onStep = null)
    {
        var items = sequence.ToCharArray();

        var stack = new Stack<int>();
        var removed = new List<int>();
        var matched = new List<int>();

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == '(')
            {
                stack.Push(i);
            }
            else if (stack.Count > 0)
            {
                matched.Add(stack.Pop());
                matched.Add(i);
            }
            else
            {
                removed.Add(i);
            }

            onStep?.Invoke(new SequenceStep<char>(items, i, matched.ToArray(), removed.ToArray()));
        }

        removed.AddRange(stack);

        onStep?.Invoke(new SequenceStep<char>(items, HighlightedIndices: matched.ToArray(), RemovedIndices: removed.ToArray()));

        return removed.Count;
    }
}