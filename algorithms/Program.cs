using algorithms.mission1;
using algorithms.mission2;
using algorithms.mission3;

namespace algorithms
{
    internal class Program
    {
        static void Main()
        {
            /*/// mission 1
            var random = new Random();

            var numbers = Enumerable.Range(0, 15)
                .Select(_ => random.Next(-100000, 100001) / 100m)
                .ToArray();

            var expected = numbers.OrderBy(x => x).ToArray();
            //numbers.CombCocktailSort(onStep: SortVisualizer.Draw);
            //numbers.BottomUpSort(onStep: SortVisualizer.Draw);
            numbers.HoareSort(onStep: SortVisualizer.Draw);

            bool isCorrect = numbers.SequenceEqual(expected);
            Console.WriteLine(isCorrect);
            ///*/

            /*/// mission 2
            string s = Console.ReadLine()!;
            string t = Console.ReadLine()!;

            //var result = SubstringSearch.KmpSearch(s, t, onStep: SearchVisualizer.Draw);
            //Console.WriteLine(string.Join(" ", result));

            Console.WriteLine(CyclicShift.FindMinRightShift(s, t, onStep: SearchVisualizer.Draw));
            ///*/

            /*/// mission 3
            //string sequence = Console.ReadLine()!;
            //Console.WriteLine(BracketSequence.FindMinDeletions(sequence, onStep: SequenceVisualizer.Draw));
            int n = int.Parse(Console.ReadLine()!);
            var numbers = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = NextSmallerElement.FindIndices(numbers, onStep: SequenceVisualizer.Draw);
            Console.WriteLine(string.Join(" ", result));
            ///*/
            
            /// mission 4
            
        }
    }
}
