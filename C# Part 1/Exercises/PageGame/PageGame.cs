namespace PageGame
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

   public class PageGame
    {
       public static void Main(string[] args)
        {
            int[,] cookieBox = new int[16, 16];

            for (int row = 0; row < cookieBox.GetLength(0); row++)
            {
                for (int col = 0; col < cookieBox.GetLength(1); col++)
                {
                    cookieBox[row, col] = int.Parse(Console.ReadLine());
                }
            }

            string question = Console.ReadLine();
            int rowLoc = int.Parse(Console.ReadLine());
            int colLoc = int.Parse(Console.ReadLine());
            bool center = false;
            bool cookie = false;
            bool crumb = false;
            bool brokenCookie = false;
            decimal tax = 0;

            if ((rowLoc == 1) | (rowLoc == 4) | (rowLoc == 7) | (rowLoc == 10) |  (rowLoc == 13))
            {
                if ((colLoc == 1) | (colLoc == 4) | (colLoc == 7) | (colLoc == 10) | (colLoc == 13))
                {
                    center = true;
                }
            }

            if (cookieBox[rowLoc, colLoc] == 1)
            {
                if ((cookieBox[rowLoc - 1, colLoc - 1] == 1) & (cookieBox[rowLoc - 1, colLoc] == 1) &
                 (cookieBox[rowLoc - 1, colLoc + 1] == 1) & (cookieBox[rowLoc, colLoc - 1] == 1) &
                 (cookieBox[rowLoc, colLoc + 1] == 1) & (cookieBox[rowLoc + 1, colLoc - 1] == 1) &
                 (cookieBox[rowLoc + 1, colLoc] == 1) & (cookieBox[rowLoc + 1, colLoc + 1] == 1))
                {
                    cookie = true;
                }
                else if (((cookieBox[rowLoc - 1, colLoc - 1] == 0) & (cookieBox[rowLoc - 1, colLoc] == 0) &
                 (cookieBox[rowLoc - 1, colLoc + 1] == 0) & (cookieBox[rowLoc, colLoc - 1] == 0) &
                 (cookieBox[rowLoc, colLoc + 1] == 0) & (cookieBox[rowLoc + 1, colLoc - 1] == 0) &
                 (cookieBox[rowLoc + 1, colLoc] ==01) & (cookieBox[rowLoc + 1, colLoc + 1] == 0)))
                {
                    crumb = true;
                }
                else
                {
                    brokenCookie = true;
                }
            }
            else
            {
                if (((cookieBox[rowLoc - 1, colLoc - 1] == 1) | (cookieBox[rowLoc - 1, colLoc] == 1) |
                 (cookieBox[rowLoc - 1, colLoc + 1] == 1) | (cookieBox[rowLoc, colLoc - 1] == 1) |
                 (cookieBox[rowLoc, colLoc + 1] == 1) | (cookieBox[rowLoc + 1, colLoc - 1] == 1) |
                 (cookieBox[rowLoc + 1, colLoc] == 1) | (cookieBox[rowLoc + 1, colLoc + 1] == 1)))
	            {
                    brokenCookie = true;
	            }                 
            }
           // Page questions here...
            switch (question)
            {
                case "what is":
                    if (cookie == true)
                    {
                        Console.WriteLine("cookie");  
                    }
                    else if (brokenCookie == true)
                    {
                        Console.WriteLine("broken cookie"); 
                    }
                    else if (crumb == true)
                    {
                        Console.WriteLine("cookie crumb");  
                    }
                    break;
                case "buy":
                    if (cookie == true)
                    {
                       tax += 1.79M;
                       cookieBox[rowLoc - 1, colLoc - 1] = 0;
                       cookieBox[rowLoc - 1, colLoc] = 0;
                       cookieBox[rowLoc - 1, colLoc + 1] = 0;
                       cookieBox[rowLoc, colLoc - 1] = 0;
                       cookieBox[rowLoc, colLoc + 1] = 0;
                       cookieBox[rowLoc + 1, colLoc - 1] = 0;
                       cookieBox[rowLoc + 1, colLoc] = 0;
                       cookieBox[rowLoc + 1, colLoc + 1] = 0;  
                    }
                    else if ((brokenCookie == true) | (crumb == true))
                    {
                        Console.WriteLine("page"); 
                    }
                    else  
                    {
                        Console.WriteLine("smile");  
                    }
                    break;

                default:
                    break;
            }
           
        }
    }
}
