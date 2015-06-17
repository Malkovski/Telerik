namespace TheyAreGreen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class TheyAreGreen
    {
       public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] letters = new string[num];
            int counter = 0;

            for (int i = 0; i < num; i++)
            {
                letters[i] = Console.ReadLine();
            }

            StringBuilder word = new StringBuilder(num);
            StringBuilder prevWord = new StringBuilder(num);

            for (int i = 0; i < num; i++)
            {
                word.Append(letters[i]);
                if (num == 1)
                {
                    counter = 1;
                    break;
                }        
                    for (int j = 0; j < num; j++)
                    {
                        if ((letters[j] != letters[i]) && j != i)
                        {
                            word.Append(letters[j]);

                            if (num > 2)
                            {
                                for (int k = 0; k < num; k++)
                                {
                                    if ((letters[k] != letters[j]) && k != j && k != i)
                                    {
                                        word.Append(letters[k]);

                                        if (num > 3)
                                        {
                                            for (int p = 0; p < num; p++)
                                            {
                                                if ((letters[p] != letters[k]) && p != k && p != j && p != i)
                                                {
                                                    word.Append(letters[p]);

                                                    if (num > 4)
                                                    {
                                                        for (int m = 0; m < num; m++)
                                                        {
                                                            if ((letters[m] != letters[p]) && m != p && m != k && m != j && m != i)
                                                            {
                                                                word.Append(letters[m]);

                                                                if (num > 5)
                                                                {
                                                                    for (int n = 0; n < num; n++)
                                                                    {
                                                                        if ((letters[n] != letters[m]) && n != m && n != p && n != k && n != j && n != i)
                                                                        {
                                                                            word.Append(letters[n]);

                                                                            if (num > 6)
                                                                            {
                                                                                for (int v = 0; v < num; v++)
                                                                                {
                                                                                    if ((letters[v] != letters[n]) && v != n && v != m && v != p && v != k && v != j && v != i)
                                                                                    {
                                                                                        word.Append(letters[v]);

                                                                                        if (num > 7)
                                                                                        {                                                                                         
                                                                                            for (int g = 0; g < num; g++)
                                                                                            {
                                                                                                if ((letters[g] != letters[v]) && g != v && g != n && g != m && g != p && g != k && g != j && g != i)
                                                                                                {
                                                                                                    word.Append(letters[g]);

                                                                                                    if (num > 8)
                                                                                                    {                                                                                                      
                                                                                                        for (int h = 0; h < num; h++)
                                                                                                        {
                                                                                                            if ((letters[h] != letters[g]) && h != g && h != v && h != n && h != m && h != p && h != k && h != j && h != i)
                                                                                                            {
                                                                                                                word.Append(letters[h]);

                                                                                                                if (num > 9)
                                                                                                                {                                                                                                                  
                                                                                                                    for (int y = 0; y < num; y++)
                                                                                                                    {
                                                                                                                        if ((letters[y] != letters[h]) && y != h && y != g && y != v && y != n && y != m && y != p && y != k && y != j && y != i)
                                                                                                                        {
                                                                                                                            word.Append(letters[y]);

                                                                                                                            if (word != prevWord)
                                                                                                                            {
                                                                                                                                counter++;
                                                                                                                                prevWord = word;
                                                                                                                                word.Clear();
                                                                                                                            }
                                                                                                                            word.Clear();
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (word != prevWord)
                                                                                                                    {
                                                                                                                        counter++;
                                                                                                                        prevWord = word;
                                                                                                                        word.Clear();
                                                                                                                    }
                                                                                                                    word.Clear();
                                                                                                                } 
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (word != prevWord)
                                                                                                        {
                                                                                                            counter++;
                                                                                                            prevWord = word;
                                                                                                            word.Clear();
                                                                                                        }
                                                                                                        word.Clear();
                                                                                                    } 
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (word != prevWord)
                                                                                            {
                                                                                                counter++;
                                                                                                prevWord = word;
                                                                                                word.Clear();
                                                                                            }
                                                                                            word.Clear();
                                                                                        } 
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (word != prevWord)
                                                                                {
                                                                                    counter++;
                                                                                    prevWord = word;
                                                                                    word.Clear();
                                                                                }
                                                                                word.Clear();
                                                                            } 
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (word != prevWord)
                                                                    {
                                                                        counter++;
                                                                        prevWord = word;
                                                                        word.Clear();
                                                                    }
                                                                    word.Clear();
                                                                } 
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (word != prevWord)
                                                        {
                                                            counter++;
                                                            prevWord = word;
                                                            word.Clear();
                                                        }
                                                        word.Clear();
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (word != prevWord)
                                            {
                                                counter++;
                                                prevWord = word;
                                                word.Clear();
                                            }
                                            word.Clear();
                                        }
                                    }
                                } 
                            }
                            else
                            {
                                if (word != prevWord)
                                {
                                    counter++;
                                    prevWord = word;
                                    word.Clear();
                                }
                                word.Clear();
                            }
                            
                        }                                      
                    }           
            }
            Console.WriteLine(counter);
        }
    }
}
