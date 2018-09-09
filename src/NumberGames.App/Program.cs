using System;
using System.Diagnostics;
using System.Linq;

namespace NumberGames.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var equationGenerator = new OperationsGenerator();
            var calculator = new Calculator();
            Console.Write("Enter an integer and press [Enter]: ");

            while (int.TryParse(Console.ReadLine(), out var expectedResult))
            {
                var sw = Stopwatch.StartNew();
                foreach (var operationsCombo in equationGenerator.GetOperationCombinations(0, Enumerable.Repeat(Operation.Add, 8).ToList()))
                {
                    var numbers = Enumerable.Range(1, 9).ToList();
                    foreach (var result in calculator.FindCorrectEquations(numbers, operationsCombo, expectedResult))
                    {
                        Console.WriteLine(result);
                    }
                }
            
                Console.Write($"Completed in {sw.ElapsedMilliseconds}ms{Environment.NewLine}{Environment.NewLine}"
                    + "Try another integer or anything else to quit: ");
            }
        }
    }
}
