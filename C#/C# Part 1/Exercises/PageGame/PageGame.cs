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
            bool cookie = false;
            bool crumb = false;
            bool brokenCookie = false;
            decimal tax = 0.00M;           
            int[,] cookieBox = new int[16, 16];

            for (int row = 0; row < 16; row++)
            {
                string cookieLine = Console.ReadLine();
                        
                    for (int col = 0; col < cookieLine.Length; col++)
                    {
                        cookieBox[row, col] = int.Parse(cookieLine[col].ToString());
                    }           
            }

            for (;;)
            {
                string question = Console.ReadLine();
                if (question == "paypal")
                {
                    Console.WriteLine("{0}", tax);
                    break;
                }
                else
                {
                    int rowLoc = int.Parse(Console.ReadLine());
                    int colLoc = int.Parse(Console.ReadLine());

                    if ((rowLoc != 0) & (colLoc != 0) & (rowLoc != 15) & (colLoc != 15))
                    {
                        if (cookieBox[rowLoc, colLoc] == 1)
                        {
                            if ((cookieBox[rowLoc - 1, colLoc - 1] == 1) & (cookieBox[rowLoc - 1, colLoc] == 1) &
                             (cookieBox[rowLoc - 1, colLoc + 1] == 1) & (cookieBox[rowLoc, colLoc - 1] == 1) &
                             (cookieBox[rowLoc, colLoc + 1] == 1) & (cookieBox[rowLoc + 1, colLoc - 1] == 1) &
                             (cookieBox[rowLoc + 1, colLoc] == 1) & (cookieBox[rowLoc + 1, colLoc + 1] == 1))
                            {
                                cookie = true;
                            }
                            else if ((cookieBox[rowLoc - 1, colLoc - 1] == 0) & (cookieBox[rowLoc - 1, colLoc] == 0) &
                             (cookieBox[rowLoc - 1, colLoc + 1] == 0) & (cookieBox[rowLoc, colLoc - 1] == 0) &
                             (cookieBox[rowLoc, colLoc + 1] == 0) & (cookieBox[rowLoc + 1, colLoc - 1] == 0) &
                             (cookieBox[rowLoc + 1, colLoc] == 0) & (cookieBox[rowLoc + 1, colLoc + 1] == 0))
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
                            cookie = false;
                            crumb = false;
                            brokenCookie = false;                          
                        }
                    }
                    else
                    {
                        if (cookieBox[rowLoc, colLoc] == 1)
                        {
                            if (rowLoc == 0)
                            {
                                if ((colLoc > 0) & (colLoc < 15))
                                {
                                    if ((cookieBox[rowLoc, colLoc - 1] == 1) | (cookieBox[rowLoc, colLoc + 1] == 1))
                                    {
                                        brokenCookie = true;
                                    }
                                    else
                                    {
                                        crumb = true;
                                    }
                                }
                                else
                                {
                                    if (colLoc == 0)
                                    {
                                        if ((cookieBox[rowLoc, colLoc + 1] == 1) | (cookieBox[rowLoc + 1, colLoc] == 1))
                                        {
                                            brokenCookie = true;
                                        }
                                        else
                                        {
                                            crumb = true;
                                        }
                                    }

                                    if (colLoc == 15)
                                    {
                                        if ((cookieBox[rowLoc, colLoc - 1] == 1) | (cookieBox[rowLoc + 1, colLoc] == 1))
                                        {
                                            brokenCookie = true;
                                        }
                                        else
                                        {
                                            crumb = true;
                                        }
                                    }
                                }
                            }
                            else if (rowLoc == 15)
                            {
                                if ((colLoc > 0) & (colLoc < 15))
                                {
                                    if ((cookieBox[rowLoc, colLoc - 1] == 1) | (cookieBox[rowLoc, colLoc + 1] == 1))
                                    {
                                        brokenCookie = true;
                                    }
                                    else
                                    {
                                        crumb = true;
                                    }
                                }
                                else
                                {
                                    if (colLoc == 0)
                                    {
                                        if ((cookieBox[rowLoc, colLoc + 1] == 1) | (cookieBox[rowLoc - 1, colLoc] == 1))
                                        {
                                            brokenCookie = true;
                                        }
                                        else
                                        {
                                            crumb = true;
                                        }
                                    }

                                    if (colLoc == 15)
                                    {
                                        if ((cookieBox[rowLoc, colLoc - 1] == 1) | (cookieBox[rowLoc - 1, colLoc] == 1))
                                        {
                                            brokenCookie = true;
                                        }
                                        else
                                        {
                                            crumb = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (colLoc == 0)
                                {
                                    if (cookieBox[rowLoc, colLoc + 1] == 1)
                                    {
                                        brokenCookie = true;
                                    }
                                    else
                                    {
                                        crumb = true;
                                    }
                                }
                                else
                                {
                                    if (colLoc == 15)
                                    {
                                        if (cookieBox[rowLoc, colLoc - 1] == 1)
                                        {
                                            brokenCookie = true;
                                        }
                                        else
                                        {
                                            crumb = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            cookie = false;
                            crumb = false;
                            brokenCookie = false;
                        }
                    }

                   //// Page questions here...
                    switch (question)
                    {
                        case "what is":
                            if (cookie == true)
                            {
                                Console.WriteLine("cookie");
                                cookie = false;
                                crumb = false;
                                brokenCookie = false;
                            }
                            else if (brokenCookie == true)
                            {
                                Console.WriteLine("broken cookie");
                                cookie = false;
                                crumb = false;
                                brokenCookie = false;
                            }
                            else if (crumb == true)
                            {
                                Console.WriteLine("cookie crumb");
                                cookie = false;
                                crumb = false;
                                brokenCookie = false;
                            }
                            else
                            {
                                Console.WriteLine("smile");
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
                                cookieBox[rowLoc, colLoc] = 0;
                                cookieBox[rowLoc, colLoc + 1] = 0;
                                cookieBox[rowLoc + 1, colLoc - 1] = 0;
                                cookieBox[rowLoc + 1, colLoc] = 0;
                                cookieBox[rowLoc + 1, colLoc + 1] = 0;
                                cookie = false;
                            }
                            else if ((brokenCookie == true) | (crumb == true))
                            {
                                Console.WriteLine("page");
                                brokenCookie = false;
                                crumb = false;
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
    }
}
