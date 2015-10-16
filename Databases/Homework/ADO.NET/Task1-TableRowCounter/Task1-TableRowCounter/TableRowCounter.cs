namespace Task1TableRowCounter
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class TableRowCounter
    {
        private const string DB_CONNECTION_STRING = "Server=:.\\SQL;" + "Database=NORTHWND; Integrated Security=true";

        private static void Main()
        {
            var dbCon = new SqlConnection(DB_CONNECTION_STRING);
            dbCon.Open();

            using (dbCon)
            {
                var command = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);

                var count = (int)command.ExecuteScalar();

                Console.WriteLine("The number of rows in table Categories is {0}", count);
            }
        }
    }
}