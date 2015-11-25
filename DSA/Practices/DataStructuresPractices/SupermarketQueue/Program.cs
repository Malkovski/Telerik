namespace SupermarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        private static BigList<string> queue = new BigList<string>();
        private static Dictionary<string, int> memberCounts = new Dictionary<string, int>();
        private static StringBuilder result = new StringBuilder();

        static void Main()
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (line != "End")
                {
                    var commands = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (commands[0] == "Append")
                    {
                        var member = commands[1];
                        
                        queue.Add(member);

                        if (memberCounts.ContainsKey(member))
                        {
                            memberCounts[member]++;
                        }
                        else
                        {
                            memberCounts.Add(member, 1);
                        }

                        result.AppendLine("OK");
                    }
                    else if (commands[0] == "Find")
                    {
                        var name = commands[1];

                        var count = memberCounts.ContainsKey(name) == false ? 0 : memberCounts[name];

                        result.AppendLine(count.ToString());
                    }
                    else if (commands[0] == "Insert")
                    {
                        var pos = int.Parse(commands[1]);
                        var member = commands[2];

                        if (pos < 0 || pos > queue.Count)
                        {
                            result.AppendLine("Error");
                        }
                        else
                        {
                            queue.Insert(pos, member);

                            if (memberCounts.ContainsKey(member))
                            {
                                memberCounts[member]++;
                            }
                            else
                            {
                                memberCounts.Add(member, 1);
                            }

                            result.AppendLine("OK");
                        }
                    }
                    else 
                    {
                        var count = int.Parse(commands[1]);

                        if (count < 0 || count > queue.Count)
                        {
                            result.AppendLine("Error");
                        }
                        else
                        {
                            var piece = queue.Range(0, count);

                            foreach (var item in piece)
                            {
                                if (memberCounts.ContainsKey(item))
                                {
                                    memberCounts[item]--;
                                }
                            }

                            result.AppendLine(string.Join(" ", piece));

                            queue.RemoveRange(0, count);
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
