namespace RangeException
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RangeApplicationSystem
    {
        public static void Main()
        {
            int num = 0;
            int minNum = 1000;
            int maxNum = 2000;

            try
            {
                num = int.Parse(Console.ReadLine());

                if (num < minNum || num > maxNum)
                {
                    throw new InvalidRangeException<int>("Not in range!!!", num, minNum, maxNum);
                }
            }
            catch (InvalidRangeException<int> ex)
            {

                Console.WriteLine("InvalidRangeException: Number {0} must be in the range {1} - {2}", ex.Value, ex.MinValue, ex.MaxValue);
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Operation failed!!!");
            }
        }
    }
}
