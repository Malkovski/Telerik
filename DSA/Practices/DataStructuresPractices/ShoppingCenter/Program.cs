namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        private static readonly MultiDictionary<string, Product> byNameAndProduct = new MultiDictionary<string, Product>(true);
        private static readonly MultiDictionary<string, Product> byName = new MultiDictionary<string, Product>(true);
        private static readonly MultiDictionary<string, Product> byProducer = new MultiDictionary<string, Product>(true);
        private static readonly OrderedMultiDictionary<decimal, Product> byPrice = new OrderedMultiDictionary<decimal, Product>(true);
        
     
        private static readonly StringBuilder result = new StringBuilder();

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var inputParts = input.Split(new char[] { ' ' }, 2);

                var command = inputParts[0];
                var details = inputParts[1].Split(';');

                if (command == "AddProduct")
                {
                    var name = details[0];
                    var producer = details[2];
                    var mixed = name + ";" + producer;
                    var price = decimal.Parse(details[1]);

                    var newProduct = new Product
                    {
                        Name = name,
                        Producer = producer,
                        Price = price
                    };

                    byName.Add(name, newProduct);
                    byProducer.Add(producer, newProduct);
                    byNameAndProduct.Add(mixed, newProduct);
                    byPrice.Add(price, newProduct);

                    result.AppendLine("Product added");
                }
                else if (command == "FindProductsByName")
                {
                    var nameToFind = details[0];

                    if (byName.ContainsKey(nameToFind))
                    {
                        var builder = new StringBuilder();
                        var list = new List<Product>(byName[nameToFind]);
                        list.Sort();

                        foreach (var item in list)
                        {
                            builder.AppendLine(item.ToString());
                        }
                        var text = builder.ToString().TrimEnd();
                        result.AppendLine(text);
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
                        var builder = new StringBuilder();
                        var list = new List<Product>(byProducer[producerToFind]);
                        list.Sort();
                        foreach (var item in list)
                        {
                            builder.AppendLine(item.ToString());
                        }

                        var text = builder.ToString().TrimEnd();
                        result.AppendLine(text);
                    }
                    else
                    {
                        result.AppendLine("No products found");
                    }
                }
                else if (command == "FindProductsByPriceRange")
                {
                    var from = decimal.Parse(details[0]);
                    var to = decimal.Parse(details[1]);

                    var range = byPrice.Range(from, true, to, true).Values;

                    if (range.Count == 0)
                    {
                        result.AppendLine("No products found");
                    }
                    else
                    {
                        var builder = new StringBuilder();
                        var members = new List<Product>(range);
                        members.Sort();

                        foreach (var item in members)
                        {
                            builder.AppendLine(item.ToString());
                        }

                        var text = builder.ToString().TrimEnd();
                        result.AppendLine(text);
                    }
                }
                else
                {
                    //Deletes
                    if (details.Count() > 1)
                    {
                        var keyToDelete = details[0] + ";" + details[1];

                        if (!byNameAndProduct.ContainsKey(keyToDelete))
                        {
                            result.AppendLine("No products found");
                        }
                        else
                        {
                            var list = byNameAndProduct[keyToDelete];

                            foreach (var item in list)
                            {
                                byName.Remove(details[0]);
                                byProducer.Remove(details[1]);
                                byPrice.Remove(item.Price, item);
                            }

                            var count = list.Count;
                            byNameAndProduct.Remove(keyToDelete);

                            result.AppendLine(string.Format("{0} products deleted", count));
                        }

                    }
                    else
                    {
                        var producerTODelete = details[0];

                        if (!byProducer.ContainsKey(producerTODelete))
                        {
                            result.AppendLine("No products found");
                        }
                        else
                        {
                            var list = byProducer[producerTODelete];

                            foreach (var item in list)
                            {
                                byName.Remove(item.Name, item);
                                byPrice.Remove(item.Price, item);
                                byNameAndProduct.Remove(inputParts[1], item);
                            }

                            var count = list.Count;
                            byProducer.Remove(producerTODelete);

                            result.AppendLine(string.Format("{0} products deleted", count));
                        }
                    }
                }
            }
            
            Console.Write(result);
        }

        public class Product : IComparable<Product>
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Producer { get; set; }

            public override string ToString()
            {
                string toString = "{" + this.Name + ";" + this.Producer + ";" + this.Price.ToString("0.00") + "}";
                return toString;
            }

            public int CompareTo(Product current)
            {
                var compareResult = this.Name.CompareTo(current.Name);

                if (compareResult == 0)
                {
                    compareResult = this.Producer.CompareTo(current.Producer);
                }
                if (compareResult == 0)
                {
                    compareResult = this.Price.CompareTo(current.Price);
                }

                return compareResult;
            }
        }
    }
}
