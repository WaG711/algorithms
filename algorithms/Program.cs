using algorithms.mission1;
using algorithms.mission2;
using algorithms.mission3;
using algorithms.mission4;
using algorithms.mission5;

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

            var isCorrect = numbers.SequenceEqual(expected);
            Console.WriteLine(isCorrect);
            ///*/

            /*/// mission 2
            var s = Console.ReadLine()!;
            var t = Console.ReadLine()!;

            //var result = SubstringSearch.KmpSearch(s, t, onStep: SearchVisualizer.Draw);
            //Console.WriteLine(string.Join(" ", result));

            Console.WriteLine(CyclicShift.FindMinRightShift(s, t, onStep: SearchVisualizer.Draw));
            ///*/

            /*/// mission 3
            //var sequence = Console.ReadLine()!;
            //Console.WriteLine(BracketSequence.FindMinDeletions(sequence, onStep: SequenceVisualizer.Draw));
            var n = int.Parse(Console.ReadLine()!);
            var numbers = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = NextSmallerElement.FindIndices(numbers, onStep: SequenceVisualizer.Draw);
            Console.WriteLine(string.Join(" ", result));
            ///*/

            /*/// mission 4
            var numbers = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .TakeWhile(x => x != 0);

            var tree = new BinarySearchTree<int>();

            foreach (var number in numbers)
            {
                tree.Insert(number, onStep: TreeVisualizer.Draw);
            }

            //var branches = tree.GetBranches(onStep: TreeVisualizer.Draw);
            //Console.WriteLine(string.Join(" ", branches));

            Console.WriteLine(tree.IsBalanced(onStep: TreeVisualizer.Draw) ? "YES" : "NO");
            ///*/

            /// mission 5
            //var parameters = Console.ReadLine()!
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //int n = parameters[0];
            //int m = parameters[1];
            //int k = parameters[2];
            //int c = parameters[3];

            //var cities = Console.ReadLine()!
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //var graph = new Graph(n);

            //for (int i = 0; i < m; i++)
            //{
            //    var road = Console.ReadLine()!
            //        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //        .Select(int.Parse)
            //        .ToArray();

            //    graph.AddEdge(road[0], road[1], road[2]);
            //}

            //var distances = Dijkstra.FindShortestPaths(graph, c, onStep: GraphVisualizer.Draw);

            //var result = cities
            //    .OrderBy(city => distances[city])
            //    .ThenBy(city => city);

            //foreach (int city in result)
            //{
            //    Console.WriteLine($"{city} {distances[city]}");
            //}

            var parameters = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = parameters[0];
            int m = parameters[1];

            var graph = new Graph(n);

            for (int i = 0; i < m; i++)
            {
                var road = Console.ReadLine()!
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                graph.AddEdge(road[0], road[1], road[2]);
            }

            var result = GraphCenter.FindCenter(graph, onStep: GraphVisualizer.Draw);

            Console.WriteLine(result);
        }
    }
}
