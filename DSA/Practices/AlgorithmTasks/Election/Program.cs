namespace Election
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var seats = new int[n];
            for (int i = 0; i < n; i++)
            {
                seats[i] = (int.Parse(Console.ReadLine()));
            }

            var a = GetCombination(seats, k);

            Console.WriteLine(a);
        }

        //---http://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values-in-c-sharp---//
        static int GetCombination(int[] list,  int k)
        {
            var sum = 0;
            var result = 0;

            double count = Math.Pow(2, list.Length);
            for (int i = 1; i <= count - 1; i++)
            {
                bool[] mask = Dec2Bin(i, list.Length);
                for (int j = 0; j < mask.Length; j++)
                {
                    if (mask[j] == true)
                    {
                        sum += list[j];
                        if (sum >= k)
                        {
                            
                            break;
                        }
                    }
                }

                if (sum >= k)
                {
                    result++;
                    sum = 0;
                }
                else
                {
                    sum = 0;
                }
            }

            return result;
        }

        static bool[] Dec2Bin(int value,  int len)
        {
            if (value == 0) return new[] { false };
            var n = (int)(Math.Log(value) / Math.Log(2));
            var a = new bool[len];
            for (var i = n; i >= 0; i--)
            {
                n = (int)Math.Pow(2, i);
                if (n > value) continue;
                a[i] = true;
                value -= n;
            }
            Array.Reverse(a);
            return a;
        }  
    }
}
