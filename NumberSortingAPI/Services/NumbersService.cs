using NumberSortingAPI.Services.Utilities;
using NumberSortingAPI.Storage;

namespace NumberSortingAPI.Services
{
    public class NumbersService : INumbersService
    {
        private readonly IFileStorage _fileStorage;

        public NumbersService(IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }
        
        public void SortNumbers(int[] unsortedNumbers)
        {
            QuickSort.Sort(unsortedNumbers);
        }

        public int[] GetNumbers()
        {
            return _fileStorage.GetSortedNumbers();
        }

        public void WriteNumbers(int[] sortedNumbers)
        {
            _fileStorage.WriteSortedNumbers(sortedNumbers);
        }
    }
}