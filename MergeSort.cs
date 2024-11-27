using System;

namespace bobFinal
{
    public class MergeSort
    {
        /*
        example usage:

        int[] array = { 38, 27, 43, 3, 9, 82, 10 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(", ", array));

        MergeSort mergeSort = new MergeSort();
        mergeSort.Sort(array);

        Console.WriteLine("Sorted Array:");
        Console.WriteLine(string.Join(", ", array));
        */

        // public method to sort an array
        public void Sort(Property[] array, string sortByWhat)
        {
            if (array.Length <= 1)
                return;

            Property[] temp = new Property[array.Length];
            MergeSortRecursive(array, temp, 0, array.Length - 1, sortByWhat);
        }

        // Recursive merge sort logic
        private void MergeSortRecursive(Property[] array, Property[] temp, int leftStart, int rightEnd, string sortByWhat)
        {
            if (leftStart >= rightEnd)
                return;

            int middle = (leftStart + rightEnd) / 2;

            // Sort the left half
            MergeSortRecursive(array, temp, leftStart, middle, sortByWhat);

            // Sort the right half
            MergeSortRecursive(array, temp, middle + 1, rightEnd, sortByWhat);

            // Merge the sorted halves
            Merge(array, temp, leftStart, middle, rightEnd, sortByWhat);
        }

        // Merge two sorted halves
        private void Merge(Property[] array, Property[] temp, int leftStart, int middle, int rightEnd, string sortByWhat)
        {
            int left = leftStart;
            int right = middle + 1;
            int index = leftStart;

            // Copy both halves into a temporary array in sorted order
            while (left <= middle && right <= rightEnd)
            {

                int propertyOneValue = 0;
                int propertyTwoValue = 0;

                switch (sortByWhat)
                {
                    case "Gold":
                    {
                        propertyOneValue = array[left].DailyGoldGain;
                        propertyTwoValue = array[right].DailyGoldGain;
                        break;
                    }

                    case "Lumber":
                    {
                        propertyOneValue = array[left].DailyLumberGain;
                        propertyTwoValue = array[right].DailyLumberGain;
                        break;
                    }

                    /*
                    case "ID":
                    {
                        propertyOneValue = array[left].ID;
                        propertyTwoValue = array[right].ID;
                        break;
                    }
                    */

                }


                if (propertyOneValue <= propertyTwoValue)
                {
                    temp[index] = array[left];
                    left++;
                }
                else
                {
                    temp[index] = array[right];
                    right++;
                }
                index++;
            }

            // Copy the remaining elements of the left half
            while (left <= middle)
            {
                temp[index] = array[left];
                left++;
                index++;
            }

            // Copy the remaining elements of the right half
            while (right <= rightEnd)
            {
                temp[index] = array[right];
                right++;
                index++;
            }

            // Copy the sorted elements back into the original array
            for (int i = leftStart; i <= rightEnd; i++)
            {
                array[i] = temp[i];
            }
        }
    }
}