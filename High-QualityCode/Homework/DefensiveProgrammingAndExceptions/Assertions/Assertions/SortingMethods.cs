namespace Assertions
{
    using System;
    using System.Diagnostics;

    public class SortingMethods
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null!");
            Debug.Assert(arr.Length != 0, "Array is empty!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = Utils.FindMinElementIndex(arr, index, arr.Length - 1);
                Utils.Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }
    }
}
