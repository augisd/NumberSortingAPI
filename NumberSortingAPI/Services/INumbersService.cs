namespace NumberSortingAPI.Services
{
    public interface INumbersService
    {
        public void SortNumbers(int[] unsortedNumbers);
        public int[] GetNumbers();
        public void WriteNumbers(int[] sortedNumbers);
    }
}