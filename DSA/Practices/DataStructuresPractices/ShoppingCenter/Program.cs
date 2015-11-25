namespace ShoppingCenter
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
       // private static readonly OrderedDictionary<int, Product> main = new OrderedDictionary<int, Product>();
        private static readonly OrderedMultiDictionary<string, Product> byName = new OrderedMultiDictionary<string, Product>(true);
        private static readonly OrderedMultiDictionary<string, string> byProducer = new OrderedMultiDictionary<string, string>(false);
        private static readonly OrderedMultiDictionary<double, string> byPrice = new OrderedMultiDictionary<double, string>(false);
             
        private static readonly StringBuilder result = new StringBuilder();

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var index = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var inputParts = input.Split(new char[] { ' ' }, 2);

                var command = inputParts[0];
                var details = inputParts[1].Split(';');

                if (command == "AddProduct")
                {
                    var name = details[0];
                    var price = double.Parse(details[1]);
                    var producer = details[2];

                    var product = new Product
                    {
                        Name = name,
                        Prducer = producer,
                        Price = price
                    };

                    //main.Add(index, product);

                    byName.Add(name, product);
                    byPrice.Add(price, name);
                    byProducer.Add(producer, name);

                    index++;

                    result.AppendLine("Product added");
                }
                else if (command == "FindProductsByName")
                {
                    var searchedName = details[0];

                    if (byName.ContainsKey(searchedName))
                    {
                        foreach (var item in byName[searchedName])
                        {
                            if (!item.IsDeleted)
                            {
                                result.AppendLine("{" + item.Name + ";" + item.Prducer + ";" + item.Price.ToString("0.00") + "}");   
                            }
                        }
                    }
                    else
                    {
                        result.AppendLine("No products found");
                    }
                }
                else if (command == "FindProductsByProducer")
                {
                    var searchedProducer = details[0];

                    if (byProducer.ContainsKey(searchedProducer))
                    {
                        foreach (var item in byProducer[searchedProducer])
                        {
                            foreach (var name in byName[item])
                            {
                                if (!name.IsDeleted)
                                {
                                    result.AppendLine("{" + name.Name + ";" + name.Prducer + ";" + name.Price.ToString("0.00") + "}");   
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
                    var cnt = 0;

                    foreach (var price in byPrice)
                    {
                        
                        if (price.Key >= from && price.Key <= to)
                        {
                            cnt++;
                            foreach (var name in price.Value)
                            {
                                foreach (var item in byName[name])
                                {
                                    if (!item.IsDeleted)
                                    {
                                        result.AppendLine("{" + item.Name + ";" + item.Prducer + ";" + item.Price.ToString("0.00") + "}");    
                                    }  
                                }
                            }
                        }
                    }

                    if (cnt == 0)
                    {
                        result.AppendLine("No products found");
                    }
                }
                else if (command == "DeleteProducts")
                {
                    if (details.Count() > 1)
                    {
                        var name = details[0];
                        var producer = details[1];
                        var count = 0;

                        if (byName.ContainsKey(name))
                        {
                            foreach (var product in byName[name])
                            {
                                if (product.Prducer == producer)
                                {
                                    product.IsDeleted = true;
                                    count++;
                                }
                            }

                            if (byName[name].Count() == 0)
                            {
                                byName.Remove(name);
                            }

                            if (count > 0)
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
                        var producerName = details[0];
                        var count = 0;

                        if (byProducer.ContainsKey(producerName))
                        {
                            foreach (var item in byProducer[producerName])
                            {

                                foreach (var element in byName[item])
                                {
                                    if (element.Prducer == producerName)
                                    {
                                        element.IsDeleted = true;
                                        count++;
                                    }
                                }
                            }

                            byProducer.Remove(producerName);

                            if (count > 0)
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
                }
            }

            Console.WriteLine(result.ToString());
        }

        public class Product : IComparable
        {
            public string Name { get; set; }

            public double Price { get; set; }

            public string Prducer { get; set; }

            public bool IsDeleted { get; set; }

            public int CompareTo(object obj)
            {
                var current = obj as Product;
                return this.Name.CompareTo(current.Name);
            }
        }
    }
}
