

namespace NumberGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class NumberGame
    {
        static void Main(string[] args)
        {
            int counter = 10;
            bool kill = false;
           // bool over = false;           
                for (counter = 10; counter > 0; counter--)
                if (counter == 0)
                {
                    Console.WriteLine("GAME OVER");
                }
                else
                {
                    {
                        if (counter == 1)
                        {
                            kill = true;
                            Console.WriteLine("Последен опит!");
                        }
                        else
                        {
                            Console.WriteLine("Имате {0} опита:", counter);
                        }
                        int number = 0;
                        var input = Console.ReadLine();



                        if (int.TryParse(input, out number))
                        {
                            switch (number)
                            {
                                case 0: Console.WriteLine("Нула"); break;
                                case 1: Console.WriteLine("Едно"); break;
                                case 2: Console.WriteLine("Две"); break;
                                case 3: Console.WriteLine("Три"); break;
                                case 4: Console.WriteLine("Четири"); break;
                                case 5: Console.WriteLine("Пет"); break;
                                case 6: Console.WriteLine("Шест"); break;
                                case 7: Console.WriteLine("Седем"); break;
                                case 8: Console.WriteLine("Осем"); break;
                                case 9: Console.WriteLine("Девет"); break;
                                default: Console.WriteLine("Не се ебавай!!! Спазвай диапазона от 0 до 9!!!"); break;
                            }
                        }
                        else
                        {
                            if (kill)
                            {
                                Console.WriteLine("GAME OVER");
                                counter = 0;
                            }
                            else
                            {
                                Console.WriteLine("Не си въвел числена стойност идиот!Губиш ред!МУХАХАХАХАХ");
                                counter = 2;
                                // kill = true;

                            }
                        }
                    }
                }
        }
    }
}
