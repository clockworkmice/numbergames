using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberGames.App
{
    public class Calculator
    {
        public IEnumerable<string> FindCorrectEquations(IList<int> numbers, IList<char> operations, int expected)
        {
            // do combine operartions first and reduce lists of numbers and operations accordingly
            int combineIndex;
            while ((combineIndex = operations.IndexOf(Operation.Combine)) > -1)
            {
                numbers[combineIndex] = DoOperation(numbers[combineIndex], Operation.Combine, numbers[combineIndex + 1]);
                numbers.RemoveAt(combineIndex + 1);
                operations.RemoveAt(combineIndex);
            }

            // evaluate result
            var index = 0;
            var result = numbers.Aggregate((a, b) => DoOperation(a, operations[index++], b));

            if (result != expected)
                yield break;

            // if correct generate forumla string
            var sb = new StringBuilder(numbers[0].ToString());
            for (int i = 0; i < operations.Count; i++)
            {
                sb.Append(operations[i]);
                sb.Append(numbers[i + 1]);
            }
            
            yield return $"{sb} = {result}";
        }

        private static int DoOperation(int left, char operation, int right)
        {
            switch (operation)
            {
                case Operation.Add:
                    return left + right;
                case Operation.Subtract:
                    return left - right;
                case Operation.Combine:
                    return int.Parse(string.Concat(left, right));
                default:
                    throw new ArgumentException("Unknown operation", nameof(operation));
            }
        }
    }
}
