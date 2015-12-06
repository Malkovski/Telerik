namespace UnitsOfWorkExam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class UnitsOfWorkEntry
    {
        private static readonly MultiDictionary<string, Unit> byName = new MultiDictionary<string, Unit>(false);
        private static readonly MultiDictionary<string, Unit> byType = new MultiDictionary<string, Unit>(true);
        private static readonly OrderedMultiDictionary<int, Unit> byAttack = new OrderedMultiDictionary<int, Unit>(true, new MyIntComparer());

        private static StringBuilder result = new StringBuilder();
        static void Main()
        {
            while (true)
            {
                var commandLine = Console.ReadLine();

                if (commandLine == "end")
                {
                    break;
                }

                CommandProcessor(commandLine);
            }

            Console.Write(result);
        }

        public class MyIntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }

        public class Unit : IComparable<Unit>
        {
            public string Name { get; set; }

            public int Attack { get; set; }

            public string Type { get; set; }

            public int CompareTo(Unit other)
            {
                var compareValue = other.Attack.CompareTo(this.Attack);

                if (compareValue == 0)
                {
                    compareValue = this.Name.CompareTo(other.Name);
                }

                return compareValue;
            }
            public override string ToString()
            {
                var result = string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
                return result;
            }
        }

        public static string PrintProductsList(List<Unit> list, int count)
        {
            var len = count > list.Count ? list.Count : count;
            var builder = new StringBuilder();
            list.Sort();

            for (int i = 0; i < len; i++)
            {
                builder.Append(list[i].ToString());

                if (i < len - 1)
                {
                    builder.Append(", ");
                }
            }

            return builder.ToString();
        }

        private static void CommandProcessor(string commandLine)
        {
            var parts = commandLine.Split(' ');
            var command = parts[0];

            switch (command)
            {
                case "add":
                    var name = parts[1];
                    var attack = int.Parse(parts[3]);

                    if (attack < 100)
                    {
                        attack = 100;
                    }
                    if (attack > 1000)
                    {
                        attack = 1000;
                    }

                    var category = parts[2];

                    if (!byName.ContainsKey(name))
                    {
                        var newProduct = new Unit
                        {
                            Name = name,
                            Attack = attack,
                            Type = category
                        };

                        byName.Add(name, newProduct);
                        byType.Add(category, newProduct);
                        byAttack.Add(attack, newProduct);

                        result.AppendLine(string.Format("SUCCESS: {0} added!", name));
                    }
                    else
                    {
                        result.AppendLine(string.Format("FAIL: {0} already exists!", name));
                    }

                    break;
                case "find":
                    var searchedType = parts[1];

                    if (byType.ContainsKey(searchedType))
                    {
                        var filteredList = byType[searchedType];
                        var productList = filteredList.ToList();

                        var products = PrintProductsList(productList , 10);

                        result.AppendLine("RESULT: " + products);

                    }
                    else
                    {
                        result.AppendLine("RESULT: ");
                    }

                    break;
                case "power":
                    var number = int.Parse(parts[1]);

                    var topUnits = byAttack.Values.Take(number).ToList();
                    var tops = PrintProductsList(topUnits, number);

                    result.AppendLine("RESULT: " + tops);
                    break;
                case "remove":
                    var nameToRemove = parts[1];

                    if (byName.ContainsKey(nameToRemove))
                    {
                        var typeOfTheRemoved = byName[nameToRemove].FirstOrDefault().Type;
                        var attackOfTheRemoved = byName[nameToRemove].FirstOrDefault().Attack;

                        byName.Remove(nameToRemove);

                        var typesToSearch = byType[typeOfTheRemoved].ToList();
                        foreach (var item in typesToSearch)
                        {
                            if (item.Name == nameToRemove)
                            {
                                byType.Remove(typeOfTheRemoved, item);
                            }
                        }

                        if (byType[typeOfTheRemoved].Count == 0)
                        {
                            byType.Remove(typeOfTheRemoved);
                        }

                        var attackToSearch = byAttack[attackOfTheRemoved].ToList();
                        foreach (var item in attackToSearch)
                        {
                            if (item.Name == nameToRemove)
                            {
                                byAttack.Remove(attackOfTheRemoved, item);
                            }
                        }

                        if (byAttack[attackOfTheRemoved].Count == 0)
                        {
                            byAttack.Remove(attackOfTheRemoved);
                        }


                        result.AppendLine(string.Format("SUCCESS: {0} removed!", nameToRemove));
                    }
                    else
                    {
                        result.AppendLine(string.Format("FAIL: {0} could not be found!", nameToRemove));
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
