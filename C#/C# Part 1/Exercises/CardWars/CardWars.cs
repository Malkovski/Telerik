namespace CardWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class CardWars
    {
       public static void Main(string[] args)
        {
            BigInteger games = BigInteger.Parse(Console.ReadLine());
            BigInteger peshoScore = 0;
            BigInteger goshoScore = 0;
            BigInteger peshoHand = 0;
            BigInteger goshoHand = 0;
            bool cardXpesho = false;
            bool cardXgosho = false;
            BigInteger ctrPesho = 0;
            BigInteger ctrGosho = 0;
            for (int i = 0; i < games; i++)
            {
                for (int j = 0; j < 3; j++)
                {               
                    string card = Console.ReadLine();
                    switch (card)
                    {
                        case "2":
                            peshoHand += 10;
                            break;
                        case "3":
                            peshoHand += 9;
                            break;
                        case "4":
                            peshoHand += 8;
                            break;
                        case "5":
                            peshoHand += 7;
                            break;
                        case "6":
                            peshoHand += 6;
                            break;
                        case "7":
                            peshoHand += 5;
                            break;
                        case "8":
                            peshoHand += 4;
                            break;
                        case "9":
                            peshoHand += 3;
                            break;
                        case "10":
                            peshoHand += 2;
                            break;
                        case "J":
                            peshoHand += 11;
                            break;
                        case "Q":
                            peshoHand += 12;
                            break;
                        case "K":
                            peshoHand += 13;
                            break;
                        case "A":
                            peshoHand += 1;
                            break;
                        case "Z":
                            peshoScore *= 2;
                            break;
                        case "Y":
                            peshoScore -= 200;
                            break;
                        case "X":
                            cardXpesho = true;
                            break;
                        default:
                            break;
                    }
                }
                
                for (int k = 0; k < 3; k++)
                {
                    string card = Console.ReadLine();
                    switch (card)
                    {
                        case "2":
                            goshoHand += 10;
                            break;
                        case "3":
                            goshoHand += 9;
                            break;
                        case "4":
                            goshoHand += 8;
                            break;
                        case "5":
                            goshoHand += 7;
                            break;
                        case "6":
                            goshoHand += 6;
                            break;
                        case "7":
                            goshoHand += 5;
                            break;
                        case "8":
                            goshoHand += 4;
                            break;
                        case "9":
                            goshoHand += 3;
                            break;
                        case "10":
                            goshoHand += 2;
                            break;
                        case "J":
                            goshoHand += 11;
                            break;
                        case "Q":
                            goshoHand += 12;
                            break;
                        case "K":
                            goshoHand += 13;
                            break;
                        case "A":
                            goshoHand += 1;
                            break;
                        case "Z":
                            goshoScore *= 2;
                            break;
                        case "Y":
                            goshoScore -= 200;
                            break;
                        case "X":
                            cardXgosho = true;
                            break;
                        default:
                            break;
                    }
                }
                
                if (cardXpesho & cardXgosho)
                {
                    peshoScore += 50;
                    goshoScore += 50;
                    cardXgosho = false;
                    cardXpesho = false;
                    if ((peshoHand < 0) && (goshoHand < 0))
                    {
                        if (peshoHand > goshoHand)
                        {
                            ctrPesho++;
                            peshoScore += peshoHand;
                            goshoScore += goshoHand;
                            peshoHand = 0;
                            goshoHand = 0;
                        }
                        else if (goshoHand > peshoHand)
                        {
                            ctrGosho++;
                            goshoScore += goshoHand;
                            peshoScore += peshoHand;
                            goshoHand = 0;
                            peshoHand = 0;
                        }
                    }
                    else
                    {
                        if (peshoHand > goshoHand)
                        {
                            ctrPesho++;
                            peshoScore += peshoHand;
                            peshoHand = 0;
                            goshoHand = 0;
                        }
                        else if (goshoHand > peshoHand)
                        {
                            ctrGosho++;
                            goshoScore += goshoHand;
                            goshoHand = 0;
                            peshoHand = 0;
                        }
                    }

                    peshoHand = 0;
                    goshoHand = 0;
                }
                else if (cardXpesho)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    break;
                }
                else if (cardXgosho)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    break;
                }
                else
                {
                    if ((peshoHand < 0) && (goshoHand < 0))
                    {
                        if (peshoHand > goshoHand)
                        {
                            ctrPesho++;
                            peshoScore += peshoHand;
                            goshoScore += goshoHand;
                            peshoHand = 0;
                            goshoHand = 0;
                        }
                        else if (goshoHand > peshoHand)
                        {
                            ctrGosho++;
                            goshoScore += goshoHand;
                            peshoScore += peshoHand;
                            goshoHand = 0;
                            peshoHand = 0;
                        }
                    }
                    else
                    {
                        if (peshoHand > goshoHand)
                        {
                            ctrPesho++;
                            peshoScore += peshoHand;
                            peshoHand = 0;
                            goshoHand = 0;
                        }
                        else if (goshoHand > peshoHand)
                        {
                            ctrGosho++;
                            goshoScore += goshoHand;
                            goshoHand = 0;
                            peshoHand = 0;
                        }
                    }                  
                }
            }

            if ((!cardXpesho) & (!cardXgosho))
            {
                if (peshoScore > goshoScore)
                {
                    Console.WriteLine("First player wins!");
                    Console.WriteLine("Score: {0}", peshoScore);
                    Console.WriteLine("Games won: {0}", ctrPesho);
                }
                else if (goshoScore > peshoScore)
                {
                    Console.WriteLine("Second player wins!");
                    Console.WriteLine("Score: {0}", goshoScore);
                    Console.WriteLine("Games won: {0}", ctrGosho);
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                    Console.WriteLine("Score: {0}", peshoScore);
                }
            }           
        }
    }
}
