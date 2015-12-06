namespace PeshoCheat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static int n;
        private static string commands;
        private static int k;
        private static int begin;
        private static StringBuilder results = new StringBuilder();
        private static List<string> answer = new List<string>();

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            commands = Console.ReadLine();
            k = int.Parse(Console.ReadLine());
            begin = -1;
            
            if (commands[0] == '<')
            {
                begin = 0;
                //results.Add(0);
            }
            else if (commands[0] == '>')
            {
                begin = 1;
                //results.Add(1);
            }


            results.Append(begin);
            Solve(begin, 0);

            answer.Sort();
            Console.WriteLine(int.Parse(answer[0]) + k);
        }

        private static void Solve(int start, int index)
        {
            while (index >= 0 && index < commands.Length)
            {
                if (commands[index] == '>' && index < commands.Length)
                {
                    //Solve(start, index + 1);
                    if (results[index ] == '9')
                    {
                        results.Append(0);
                    }
                    else if (results[index] != '0')
                    {
                        results.Append(int.Parse((results[index]).ToString()) + 1);
                    }
                    else
                    {
                       
                        break;
                        //???

                    }

                   
                }

                if (commands[index] == '<' && index < commands.Length)
                {
                    //Solve(start, index + 1);

                    if (results[index] == '0')
                    {
                        results.Append(9);
                    }
                    else if (results[index] != '1')
                    {
                        results.Append(int.Parse((results[index]).ToString()) - 1);
                    }
                    else
                    {
                       
                        break;
                        //???
                    }

                   
                }


                if (commands[index] == '=' && index < commands.Length)
                {
                    results.Append(int.Parse((results[index]).ToString()));
                }

                index++;
            }
            

            answer.Add(results.ToString());
            results = new StringBuilder();
            results.Append(start);
        }
    }
}
