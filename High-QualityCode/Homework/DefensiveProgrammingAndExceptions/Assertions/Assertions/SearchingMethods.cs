namespace Assertions
{
    using System;
    using System.Diagnostics;

    public class SearchingMethods
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null!");
            Debug.Assert(arr.Length != 0, "Array is empty!");
            Debug.Assert(value != null, "Searched value is null!");
            Debug.Assert(startIndex != null, "Start index value is null!");
            Debug.Assert(endIndex != null, "End index value is null!");
            Debug.Assert(startIndex >= 0, "Start index is negative number!");
            Debug.Assert(startIndex <= arr.Length - 1, "Start index is out of range!");
            Debug.Assert(endIndex >= 0, "End index is negative number!");
            Debug.Assert(endIndex <= arr.Length - 1, "End index is out of range!");
            Debug.Assert(startIndex < endIndex, "Start index is bigger than end index!");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            Debug.Assert(startIndex > endIndex, "Logic in the loop is incorrect!");

            // Searched value not found
            return -1;
        }
    }
}
