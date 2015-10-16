namespace ProductNamesAndCategoriesRetriever
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    internal class Startup
    {
        private const string ConnectionString = "Server=.\\SQL; " + "Database=NorthWind; Integrated Security=true";

        public static void Main(string[] args)
        { 
            var dbCon = new SqlConnection(ConnectionString);

            dbCon.Open();
            using (dbCon)
            {
                var cmdCount = new SqlCommand("Select * from Categories inner join Products on Categories.CategoryID = Products.CategoryIDorder by Categories.CategoryName, Products.ProductName", dbCon);

                SqlDataReader allCategories = cmdCount.ExecuteReader();

                using (allCategories)
                {
                    while (allCategories.Read())
                    {
                        var categoryName = (string)allCategories["CategoryName"];
                        var productName = (string)allCategories["ProductName"];
                        Console.WriteLine("{0} - {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}