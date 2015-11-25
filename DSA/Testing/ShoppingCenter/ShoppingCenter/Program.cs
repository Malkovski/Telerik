namespace ShoppingCenter
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        private static OrderedMultiDictionary<string, Product> byName =
            new OrderedMultiDictionary<string, Product>(true);
        private static OrderedMultiDictionary<double, string> byPrice = new OrderedMultiDictionary<double, string>(false);
        private static OrderedMultiDictionary<string, string> byProducer = new OrderedMultiDictionary<string, string>(false);


        private static StringBuilder result = new StringBuilder();
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var parts = input.Split(new char[] { ' ' }, 2);
                var command = parts[0];
                var details = parts[1].Split(';');

                if (command == "AddProduct")
                {
                    var name = details[0];
                    var price = double.Parse(details[1]);
                    var producer = details[2];

                    var newProduct = new Product
                    {
                        Name = name,
                        Producer = producer,
                        Price = price
                    };

                    byName.Add(name, newProduct);
                    byPrice.Add(price, name);
                    byProducer.Add(producer, name);
                    result.AppendLine("Product added");
                }
                else if (command == "FindProductsByName")
                {
                    var nameToFind = details[0];

                    if (byName.ContainsKey(nameToFind))
                    {
                        foreach (var item in byName[nameToFind])
                        {
                            result.AppendLine("{" + item.Name + ";" + item.Producer + ";" + item.Price.ToString("0.00") + "}");
                        }
                    }
                    else
                    {
                        result.AppendLine("No products found");
                    }
                }
                else if (command == "FindProductsByProducer")
                {
                    var producerToFind = details[0];

                    if (byProducer.ContainsKey(producerToFind))
                    {
                        foreach (var element in byProducer[producerToFind])
                        {
                            foreach (var item in byName[element])
                            {
                                if (item.Producer == producerToFind)
                                {
                                    result.AppendLine("{" + item.Name + ";" + item.Producer + ";" + item.Price.ToString("0.00") + "}");
                                }
                            }
                        }
                    }
                    else
                    {
                        result.AppendLine("No products found");
                    }
                }
                else if (command == "FindProductsByPriceRange")
                {
                    var from = double.Parse(details[0]);
                    var to = double.Parse(details[1]);
                    var count = 0;

                    foreach (var price in byPrice)
                    {
                        if (price.Key >= from && price.Key <= to)
                        {
                            foreach (var element in byPrice[price.Key])
                            {
                                if (byName.ContainsKey(element))
                                {
                                    count++;
                                    foreach (var item in byName[element])
                                    {
                                        if (item.Price == price.Key)
                                        {
                                            result.AppendLine("{" + item.Name + ";" + item.Producer + ";" + item.Price.ToString("0.00") + "}");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (count == 0)
                    {
                        result.AppendLine("No products found");
                    }
                }
                else 
                {
                    if (details.Count() > 1)
                    {
                        var nameToDelete = details[0];
                        var producerToDelete = details[1];
                        var count = 0;

                        if (byName.ContainsKey(nameToDelete))
                        {
                            foreach (var product in byName[nameToDelete])
                            {
                                if (product.Producer == producerToDelete)
                                {
                                    byName[nameToDelete].Remove(product);
                                    count++;
                                }
                            }

                            if (count != 0)
                            {
                                result.AppendLine(string.Format("{0} products deleted", count));
                            }
                            else
                            {
                                result.AppendLine("No products found");
                            }
                        }
                        else
                        {
                            result.AppendLine("No products found");
                        }
                    }
                    else
                    {
                        var producerToDelete = details[0];
                        var count = 0;

                        if (byProducer.ContainsKey(producerToDelete))
                        {
                            foreach (var item in byProducer[producerToDelete])
                            {
                                var a = byName[item].Count;

                                while (a > 0)
                                {
                                    foreach (var product in byName[item])
                                    {
                                        if (product.Producer == producerToDelete)
                                        {

                                            byName[item].Remove(product);
                                            count++;
                                            a--;
                                            break;
                                        }
                                    }
                                }
                            }

                            byProducer.Remove(producerToDelete);
                            result.AppendLine(string.Format("{0} products deleted", count));
                        }
                        else
                        {
                            result.AppendLine("No products found");
                        }
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }

        public class Product : IComparable
        {
            public string Name { get; set; }

            public double Price { get; set; }

            public string Producer { get; set; }

            public int CompareTo(object obj)
            {
                var current = obj as Product;

                return this.Name.CompareTo(current.Name);
            }
        }
    }
}
