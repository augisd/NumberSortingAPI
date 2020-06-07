namespace NumberSortingAPI.Storage
{
    public interface IFileStorage
    {
        public int[] GetSortedNumbers();
        public void WriteSortedNumbers(int[] sortedArray);
    }
}