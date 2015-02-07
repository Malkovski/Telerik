namespace Task11BinarySearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class BinarySearch
    {
       public static void Main(string[] args)
        {
            string[] givenArr = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string searchedElement = Console.ReadLine();
            int result = -1;
            int start = 0;
            int end = givenArr.Length - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (searchedElement == givenArr[middle])
                {
                    result = middle;
                    break;
                }
                else if (int.Parse(searchedElement) < int.Parse(givenArr[middle]))
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }

            if (result == -1)
            {
               Console.WriteLine("The element does not exsist in the array"); 
            }
            else
            {
                Console.WriteLine("The position of the wanted element is {0}", result);
            }          
        }
    }
}
