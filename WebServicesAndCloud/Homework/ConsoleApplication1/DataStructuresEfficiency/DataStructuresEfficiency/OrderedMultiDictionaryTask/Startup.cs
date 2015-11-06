namespace OrderedMultiDictionaryTask
{
    using System;
    using System.Linq;

    public  class Startup
    {
        public static FastRangeSearchDataStructure myFatsData = new FastRangeSearchDataStructure();

        public static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                var article = new Article
                {
                    Title = i + "test",
                    Price = i * 0.12M + 0.11M
                };

                myFatsData.Add(article.Price, article);
            }

            

            var range = myFatsData.FindRange(1, 2);

            foreach (var item in range)
            {
                Console.WriteLine(item.Value);
            }
        }
 
        private static void FillData()
        {
            
        }
    }
}

