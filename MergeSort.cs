using System;
using System.Collections.Generic;
using bobFinal.PropertiesClasses;

namespace bobFinal
{
    public class MergeSort
    {
        // Public method to sort a list and return the sorted list
        public List<Property> Sort(List<Property> list, string sortByWhat, string sortOrder)
        {
            if (list.Count <= 1)
                return list;

            Property[] array = list.ToArray();
            Property[] temp = new Property[array.Length];
            MergeSortRecursive(array, temp, 0, array.Length - 1, sortByWhat, sortOrder);

            return new List<Property>(array);
        }

        // Recursive merge sort logic
        private void MergeSortRecursive(Property[] array, Property[] temp, int leftStart, int rightEnd, string sortByWhat, string sortOrder)
        {
            if (leftStart >= rightEnd)
                return;

            int middle = (leftStart + rightEnd) / 2;

            // Sort the left half
            MergeSortRecursive(array, temp, leftStart, middle, sortByWhat, sortOrder);

            // Sort the right half
            MergeSortRecursive(array, temp, middle + 1, rightEnd, sortByWhat, sortOrder);

            // Merge the sorted halves
            Merge(array, temp, leftStart, middle, rightEnd, sortByWhat, sortOrder);
        }

        // Merge two sorted halves
        private void Merge(Property[] array, Property[] temp, int leftStart, int middle, int rightEnd, string sortByWhat, string sortOrder)
        {
            int left = leftStart;
            int right = middle + 1;
            int index = leftStart;

            // Copy both halves into a temporary array
            while (left <= middle && right <= rightEnd)
            {
                int propertyOneValue = 0;
                int propertyTwoValue = 0;

                switch (sortByWhat)
                {
                    case "Gold":
                        propertyOneValue = array[left].getTotalGoldGain();
                        propertyTwoValue = array[right].getTotalGoldGain();
                        break;
                    case "Lumber":
                        propertyOneValue = array[left].getTotalLumberGain();
                        propertyTwoValue = array[right].getTotalLumberGain();
                        break;
                    case "ID":
                        propertyOneValue = array[left].getPropertyID();
                        propertyTwoValue = array[right].getPropertyID();
                        break;
                }

                // ascending order
                if (sortOrder == "ascending")
                {
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
                }

                // descending order
                else if (sortOrder == "descending")
                {
                    if (propertyOneValue >= propertyTwoValue)
                    {
                        temp[index] = array[left];
                        left++;
                    }
                    else
                    {
                        temp[index] = array[right];
                        right++;
                    }
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