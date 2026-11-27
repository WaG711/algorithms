using algorithms.mission1;

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
            *//*numbers.CombCocktailSort(onStep: SortVisualizer.Draw);*/
            /*numbers.BottomUpSort(onStep: SortVisualizer.Draw);*//*
            numbers.HoareSort(onStep: SortVisualizer.Draw);

            bool isCorrect = numbers.SequenceEqual(expected);
            Console.WriteLine(isCorrect);
            ///*/
            
            /// mission 2
            

        }
    }
}
