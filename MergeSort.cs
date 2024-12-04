using System;
using System.Collections.Generic;

namespace bobFinal
{
    public class MergeSort
    {
        // Public method to sort a list and return the sorted list
        public List<Property> Sort(List<Property> list, string sortByWhat)
        {
            if (list.Count <= 1)
                return list;

            Property[] array = list.ToArray();
            Property[] temp = new Property[array.Length];
            MergeSortRecursive(array, temp, 0, array.Length - 1, sortByWhat);

            return new List<Property>(array);
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
                        propertyOneValue = array[left].TotalGoldGain;
                        propertyTwoValue = array[right].TotalGoldGain;
                        break;
                    case "Lumber":
                        propertyOneValue = array[left].TotalLumberGain;
                        propertyTwoValue = array[right].TotalLumberGain;
                        break;
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