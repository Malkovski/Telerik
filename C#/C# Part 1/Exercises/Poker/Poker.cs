

namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Poker
    {
        static void Main(string[] args)
        {
            string[] cards = { "2","3","4","5","6","7","8","9","10","J","Q","K","A"};
            int counter = 0;
            int ctr = 1;
            int count = 0;
            int pair = 0;
            int three = 0;
            int four = 0;
            int five = 0;
            int[] nums = new int[5];
            string[] hand = new string[5];
            for (int i = 0; i < 5; i++)
            {
                hand[i] = Console.ReadLine();             
            }                     
            for (int i = 0; i < hand.Length; i++)
            {
                int index = Array.IndexOf(cards, hand[i]);
                nums[i] = index;                                     
            }
            Array.Sort(nums);
            for (int j = 0; j < nums.Length - 1; j++)
            {
                if (nums[j] == 12)
                {
                    
                }
                if ((nums[j] + 1 == nums[j + 1]) | (nums[j] + 1 == (nums[j+ 1] - 8)))
                {
                    counter++;
                }
            }
            if (counter == 4)
            {
                Console.WriteLine("Straight");
               
            }
            else
            {
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] == nums[i - 1])
                    {
                        ctr++;
                        if (i == nums.Length - 1)
                        {
                            // ctr++;
                            switch (ctr)
                            {
                                case 2: pair++; break;
                                case 3: three++; break;
                                case 4: four++; break;
                                case 5: five++; break;

                                default: break;
                            }
                        }
                    }
                    else
                    {
                        switch (ctr)
                        {
                            case 2: pair++; break;
                            case 3: three++; break;
                            case 4: four++; break;
                            case 5: five++; break;

                            default: break;
                        }
                        ctr = 1;
                    }
                }
            
           
               
            }

            if (five == 1)
            {
                Console.WriteLine("Impossible");
            }
            else if (four == 1)
            {
                Console.WriteLine("Four of a Kind");
            }
            else if ((three == 1) & (pair == 1))
            {
                Console.WriteLine("Full House");
            }
            else if (three == 1)
            {
                Console.WriteLine("Three of a Kind");
            }
            else if (pair == 2)
            {
                Console.WriteLine("Two Pairs");
            }
            else if (pair == 1)
            {
                Console.WriteLine("One Pair");
            }
            else if (counter != 4)
            {
                Console.WriteLine("Nothing");
            }
            
        }
    }
}
