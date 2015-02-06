namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Printing
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int sheets = int.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());

            int allSheets = students * sheets;
            decimal realms = (decimal)allSheets / 500;

            decimal finalPrice = realms * price;
           

            Console.WriteLine(String.Format("{0:F2}", finalPrice));
        }
    }
}
