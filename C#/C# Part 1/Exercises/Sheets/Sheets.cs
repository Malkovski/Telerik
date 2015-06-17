namespace Sheets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Sheets
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int needed = n - 1;
            int[] sheets = {1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048};
            string[] names = {"A10", "A9", "A8", "A7", "A6", "A5", "A4", "A3", "A2", "A1", "A0"};

            do
            {
                for (int i = 0; i < sheets.Length - 1; i++)
                {
                    if ((n >= sheets[i]) & (n < sheets[i + 1]))
                    {
                        names[i] = null;
                        n = n - sheets[i];
                    }

                }
            }
            while (n != 0);
            names = names.Where(ele => ele != null).Select(ele => ele).ToArray();
                                                    
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]); 
            }
        }
    }
}
