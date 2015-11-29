namespace OnlineMarket
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

    public class Program
    {
        private static readonly MultiDictionary<string, Product> byName = new MultiDictionary<string, Product>(false);
        private static readonly MultiDictionary<string, Product> byCategory = new MultiDictionary<string, Product>(true);
        private static readonly OrderedMultiDictionary<double, Product> byPrice = new OrderedMultiDictionary<double, Product>(true);

        private static readonly StringBuilder result = new StringBuilder();
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

            Console.WriteLine(result);
        }

        public class Product : IComparable<Product>
        {
            public string Name { get; set; }

            public double Price { get; set; }

            public string Category { get; set; }

            public int CompareTo(Product other)
            {
                var compareValue = this.Price.CompareTo(other.Price);

                if (compareValue == 0)
                {
                    compareValue = this.Name.CompareTo(other.Name);
                }

                if (compareValue == 0)
                {
                    compareValue = this.Category.CompareTo(other.Category);
                }

                return compareValue;
            }

            public override string ToString()
            {
                var result = string.Format("{0}({1})", this.Name, this.Price);
                return result;
            }
        }

        public static string PrintProductsList(List<Product> list)
        {
            var len = list.Count > 10 ? 10 : list.Count;
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

        public static void CommandProcessor(string commandLine)
        {
            var parts = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = parts[0];

            switch (command)
            {
                case "add":
                    var name = parts[1];
                    var price = double.Parse(parts[2]);
                    var category = parts[3];

                    if (!byName.ContainsKey(name))
                    {
                        var newProduct = new Product
                        {
                            Name = name,
                            Price = price,
                            Category = category
                        };

                        byName.Add(name, newProduct);
                        byCategory.Add(category, newProduct);
                        byPrice.Add(price, newProduct);

                        result.AppendLine(string.Format("Ok: Product {0} added successfully", name));
                    }
                    else
                    {
                        result.AppendLine(string.Format("Error: Product {0} already exists", name));
                    }

                    break;
                case "filter":
                    var filterBy = parts[2];

                    if (filterBy == "type")
                    {
                        var type = parts[3];

                        if (byCategory.ContainsKey(type))
                        {
                            var filteredList = byCategory[type];
                            var productList = filteredList.ToList();

                            var products = PrintProductsList(productList);

                            result.AppendLine("Ok: " + products);
                            
                        }
                        else
                        {
                            result.AppendLine(string.Format("Error: Type {0} does not exists", type));
                        }
                    }
                    else if (filterBy == "price")
                    {
                        var range = parts[3];

                        if (range == "from")
                        {
                            double from = double.Parse(parts[4]);
                            
                            if (parts.Length == 7)
                            {
                                double to = double.Parse(parts[6]);

                                var priceRange = byPrice.Range(from, true, to, true);
                                var productList = priceRange.Values.ToList();

                                var products = PrintProductsList(productList);

                                result.AppendLine("Ok: " + products);
                            }
                            else
                            {
                                var priceRange = byPrice.RangeFrom(from, true);
                                var productList = priceRange.Values.ToList();

                                var products = PrintProductsList(productList);

                                result.AppendLine("Ok: " + products);
                            }
                        }
                        else
                        {
                            var to = double.Parse(parts[4]);

                            var priceRange = byPrice.RangeTo(to, true);
                            var productList = priceRange.Values.ToList();

                            var products = PrintProductsList(productList);

                            result.AppendLine("Ok: " + products);
                        }
                    }
                    

                    break;
                default:
                    break;
            }
        }
    }
}
