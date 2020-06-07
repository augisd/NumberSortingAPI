using System.IO;
using System.Linq;

namespace NumberSortingAPI.Storage
{
    public class FileStorage : IFileStorage
    {
        private static readonly string _fileName = "results.txt";
        private readonly string _filePath = Path.GetFullPath(Path.Combine(_fileName));

        public int[] GetSortedNumbers()
        {
            string integerString = File.ReadAllText(_filePath);
            int[] numbers = integerString.Split(" ").Select(int.Parse).ToArray();

            return numbers;
        }
        
        public void WriteSortedNumbers(int[] sortedArray)
        {
            string integersString = string.Join(" ", sortedArray);
            File.WriteAllText(_filePath, integersString);
        }
    }
}