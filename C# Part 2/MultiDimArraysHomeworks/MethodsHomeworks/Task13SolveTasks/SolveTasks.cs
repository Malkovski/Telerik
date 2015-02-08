namespace Task13SolveTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class SolveTasks
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("CHOOSE OPTION!");
            Console.WriteLine("For reversing decimals, press \"D\"");
            Console.WriteLine("For average calculation of integers, press \"C\"");
            Console.WriteLine("For linear equasion solving, press \"E\"");
            string option = Console.ReadLine();

            if (option == "D" || option == "d")
            {
                Console.WriteLine("POWER REVERSING ACTIVATED!!!");
                Console.WriteLine("Enter decimal number now!");
                string number = Console.ReadLine();
                decimal deca = 0M;
                bool isDecimal = decimal.TryParse(number, out deca);
                bool isPositiveDec = false;

                if (isDecimal)
                {
                    if (decimal.Parse(number) >= 0)
                    {
                        isPositiveDec = true;
                    }  
                }

                if (isPositiveDec)
                {
                    string reversed = ReversingDecimals(number);
                    decimal revDec = decimal.Parse(reversed);
                    Console.WriteLine("Reversed result is: {0}", revDec);
                    Console.WriteLine("Thank you for using our services!");
                }
                else
                {
                    Console.WriteLine("Wrong input data!");
                }
            }
            else if (option == "C" || option == "c")
            {
                 Console.WriteLine("POWER AVERAGE CALCULATIONS ACTIVATED!!!");
                 Console.WriteLine("Enter sequence of integers now!");
                 Console.WriteLine("Use ONLY \",\" (comma) to seperate them!!!");
                 string seqInt = Console.ReadLine();
                 string[] splittedSeq = seqInt.Split(',');
                 int num = 0;
                 bool dataOk = true;

                 for (int i = 0; i < splittedSeq.Length; i++)
                 {
                     if (!int.TryParse(splittedSeq[i], out num))
                     {
                         Console.WriteLine("Wrong input data!");
                         dataOk = false;
                         break;
                     }
                 }

                 if (dataOk)
                 {                  
                     int average = AverageCalc(splittedSeq);
                     Console.WriteLine("The average result is: {0}", average);
                     Console.WriteLine("Thank you for using our services!");
                 }
            }
            else if (option == "E" || option == "e")
            {
                Console.WriteLine("POWER LINEAR EQUASION SOLVER ACTIVATED!!!");
                Console.WriteLine("Enter your equasion of type \" a * x + b = 0 \" and \"= 0\" can be skipped!");
                Console.WriteLine("Value \"a\" MUST be bigger than \"0\"");
                string equasion = Console.ReadLine();
                char[] dividers = { '*', '+', '-', '=' };
                string[] eqElem = equasion.Split(dividers);

                if (eqElem[0] == "0")
                {
                    Console.WriteLine("Wrong input data!"); 
                }
                else
                {
                    decimal result = LinearEquasionSolver(equasion, eqElem);
                    Console.WriteLine("Result is: {0}", result);
                    Console.WriteLine("Thank you for using our services!");
                }
            }
        }

       private static decimal LinearEquasionSolver(string equasion, string[] eqElem)
       {
           decimal result = 0;

           if (decimal.TryParse(eqElem[0], out result))
           {
               result = (decimal.Parse(eqElem[2]) * -1) / decimal.Parse(eqElem[0]);
           }
           else
           {
               result = decimal.Parse(eqElem[1]) * -1;
           }

           return result;
       }

       private static int AverageCalc(string[] splittedSeq)
       {
           int average = 0;

           for (int i = 0; i < splittedSeq.Length; i++)
           {
               average += int.Parse(splittedSeq[i]); 
           }

           average = average / splittedSeq.Length;
           return average;
       }

       private static string ReversingDecimals(string number)
       {
           string numberStr = number.ToString();
           string reversed = string.Empty;

           for (int i = numberStr.Length - 1; i >= 0; i--)
           {
               reversed = reversed + numberStr[i];
           }

           return reversed;
       }
    }
}
