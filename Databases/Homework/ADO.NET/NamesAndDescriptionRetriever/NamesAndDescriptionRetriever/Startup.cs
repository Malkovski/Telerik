namespace NamesAndDescriptionRetriever
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class Startup
    {
        private const string CONNECTION_STRING = "Server=.\\SQL; " + "Database=NorthWind; Integrated Security=true";

        private static void Main()
        {
            var dbCon = new SqlConnection(CONNECTION_STRING);
            dbCon.Open();

            using (dbCon)
            {
                var command = new SqlCommand("select CategoryName, Description from Catgories", dbCon);

                SqlDataReader categoryInformation = command.ExecuteReader();

                using (categoryInformation)
                {
                    while (categoryInformation.Read())
                    {
                        var name = (string)categoryInformation["CategoryName"];
                        var info = (string)categoryInformation["Description"];

                        Console.WriteLine("{0} - {1}", name, info);
                    }
                }
            }
        }
    }
}