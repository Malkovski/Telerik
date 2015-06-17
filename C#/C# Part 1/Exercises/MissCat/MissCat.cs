

namespace MissCat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MissCat
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            int winner = 0;
            int cat = 0;
            int missCat = 0;
            int[] vote = new int[n];


            for (int i = 0; i < n; i++)
            {
                vote[i] = int.Parse(Console.ReadLine());
            }
            int first = vote[0];

            if (n == 1)
            {
                missCat = vote[0];  
            }
            else
            {
                for (int i = 0; i < (vote.Length/2)+1; i++)
                {
                    int[] matchedVotes = Array.FindAll(vote, x => x == vote[i]);
                    counter = matchedVotes.Length;

                    if (counter > winner) 
                    {
                        winner = counter;
                        missCat = vote[i];
                      
                        if (counter == winner)
                        {
                            cat = vote[i];
                        }

                    }
                    if (cat <= missCat)
                    {
                        missCat = cat;
                    }
                   
                }

            }

           
            Console.WriteLine(missCat); 
          
        }
    }
}
