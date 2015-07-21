namespace Assertions
{
    using System;
    using System.Diagnostics;

    public class Utils
    {
        public static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null!");
            Debug.Assert(arr.Length != 0, "Array is empty!");
            Debug.Assert(startIndex >= 0, "Start index is negative number!");
            Debug.Assert(startIndex <= arr.Length - 1, "Start index is out of range!");
            Debug.Assert(endIndex >= 0, "End index is negative number!");
            Debug.Assert(endIndex <= arr.Length - 1, "End index is out of range!");
            Debug.Assert(startIndex < endIndex, "Start index is bigger than end index!");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(minElementIndex >= 0 && minElementIndex <= arr.Length - 1, "Result index out of range!");
            return minElementIndex;
        }

        public static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "First value is null!");
            Debug.Assert(y != null, "Second value is null!");

            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
