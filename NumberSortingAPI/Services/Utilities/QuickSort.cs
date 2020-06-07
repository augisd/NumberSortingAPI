namespace NumberSortingAPI.Services.Utilities
{
    public static class QuickSort
    {
        public static void Sort(int[] array) => Sort(array, 0, array.Length - 1);

        private static void Sort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int partitionIndex = Partition(array, lowIndex, highIndex);
                Sort(array, lowIndex, partitionIndex - 1);
                Sort(array, partitionIndex + 1, highIndex);
            }
        }

        private static int Partition(int[] array, int lowIndex, int highIndex)
        {
            int pivotValue = array[highIndex];
            int i = lowIndex;

            for (int j = lowIndex; j < highIndex; j++)
            {
                if (array[j] <= pivotValue)
                {
                    array.Swap(j, i);
                    i += 1;
                }
            }
            
            array.Swap(i, highIndex);
            
            return i;
        }
        
        private static void Swap(this int[] array, int indexOne, int indexTwo)
        {
            int temp = array[indexOne];
            array[indexOne] = array[indexTwo];
            array[indexTwo] = temp;
        }
    }
}