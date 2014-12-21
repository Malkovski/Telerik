namespace MissCat2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int winner = 0;
           
            int[] vote = new int[n];

            for (int i = 0; i < n; i++)
            {
                vote[i] = int.Parse(Console.ReadLine());
            }
            int first = 0;
            int cat = 0;
            int missCat = vote[first];

            for (int i = 0; i < vote.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < i; j++)
                {
                    if (vote[i] == vote[j])
                    {
                        found = true;
                        counter++;
                        if (counter >= winner)
                        {
                            winner = counter;
                            cat = vote[i];
                            if (cat <= missCat)
                            {
                                missCat = cat;
                            }
                        }                     
                        break;
                    }
                }
                if (found = false)
                {
                    vote[first] = vote[i];
                    first++;
                }
            }
            Console.WriteLine(missCat);
        }
    }
}
