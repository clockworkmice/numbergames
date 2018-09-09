using System.Collections.Generic;

namespace NumberGames.App
{
    public class Operation
    {
        public const char Add = '+';
        public const char Subtract = '-';
        public const char Combine = '\0';
    }

    public class OperationsGenerator
    {
        private readonly char[] _operatorSelection = new char[3] { Operation.Add, Operation.Subtract, Operation.Combine };

        public IEnumerable<IList<char>> GetOperationCombinations(int currentPosition, IList<char> currentCombination)
        {
            for (int i = 0; i < _operatorSelection.Length; i++)
            {
                currentCombination[currentPosition] = _operatorSelection[i];

                if (currentPosition < currentCombination.Count - 1)
                {
                    foreach (var item in GetOperationCombinations(currentPosition + 1, currentCombination))
                    {
                        yield return item;
                    }
                }
                else
                {
                    yield return new List<char>(currentCombination);
                }
            }
        }
    }
}
