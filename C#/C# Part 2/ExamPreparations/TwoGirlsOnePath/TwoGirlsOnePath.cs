namespace TwoGirlsOnePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

   public class TwoGirlsOnePath
    {
       public static void Main(string[] args)
       {
           string text = Console.ReadLine();
           string[] pathText = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
           BigInteger[] path = new BigInteger[pathText.Length];

           for (int i = 0; i < pathText.Length; i++)
           {
               path[i] = BigInteger.Parse(pathText[i]);
           }

           BigInteger mStep = path[0];
           BigInteger dStep = path[path.Length - 1];
           int mPos = 0;
           int dPos = path.Length - 1;
           BigInteger mFlowers = 0;
           BigInteger dFlowers = 0;
           bool mEnd = false;
           bool dEnd = false;

           while (true)
           {
               if (path[mPos] != 0)
               {              
                   mStep = path[mPos];

                   if (dPos == mPos)
                   {
                       mFlowers += path[mPos] / 2;                    
                   }
                   else
                   {
                       mFlowers += path[mPos];
                       path[mPos] = 0;
                   }
               }
               else
               {
                   mEnd = true;
               }

               if (path[dPos] != 0)
               {               
                   dStep = path[dPos];

                   if (dPos == mPos)
                   {
                       dFlowers += path[dPos] / 2;
                   }
                   else
                   {
                       dFlowers += path[dPos];
                       path[dPos] = 0;
                   }
               }
               else
               {
                  dEnd = true;
               }

               if (dPos == mPos)
               {
                   path[dPos] = path[dPos] % 2;
               }

               if (dEnd || mEnd)
               {
                   break;
               }

               mPos = MollyJump(path, mStep, mPos);
               dPos = DollyJump(path, dStep, dPos);
           }

           if (!dEnd && mEnd)
           {
               Console.WriteLine("Dolly");
           }
           else if (dEnd && !mEnd)
           {
               Console.WriteLine("Molly"); 
           }
           else
           {
               Console.WriteLine("Draw");
           }     

           Console.WriteLine("{0} {1}", mFlowers, dFlowers);         
       }

       public static int DollyJump(BigInteger[] path, BigInteger steps, int pos)
       {
           if (steps > path.Length)
           {
               int tempPos = pos;
               pos = pos - (int)(steps % path.Length);

               if (pos < 0)
               {
                  pos = pos * -1;
                  pos = path.Length - pos;
               }
           }
           else if (steps >= path.Length - (path.Length - pos))
           {
               pos = pos - (int)steps;

               if (pos < 0)
               {
                   pos = pos * -1;
                   pos = path.Length - pos;
               }
           }
           else
           {
               pos = pos - (int)steps;
           }
          
           return pos;
       }

       public static int MollyJump(BigInteger[] path, BigInteger steps, int pos)
       {
           if (steps > path.Length)
           {             
               pos = (int)(steps % path.Length) + pos;
           }
           else if (steps >= path.Length - pos)
           {
               pos = (int)steps - (path.Length - pos); 
           }
           else
           {
               pos = pos + (int)steps;
           }
          
           return pos;
       }
    }
}
