namespace NorthwindDbContext.Twin
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using NorthwindDbContext;

    public class Startup
    {
        

        private static void Main()
        {
            IObjectContextAdapter context = new NorthEntities();

            string cloneNorth = context.ObjectContext.CreateDatabaseScript();

            var db = new NorthEntities();

            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] commandText = CreateDbCommandsStringHolder.CreateDb.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

            foreach (string commandLine in commandText)
            {
                db.Database.ExecuteSqlCommand(commandLine);
            }

            var dbConForCreatingDB = new SqlConnection("Server=.\\SQL;Database=NorthwindTwin;Integrated Security=true");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                var cloneDB = new SqlCommand(cloneNorth, dbConForCreatingDB);
                cloneDB.ExecuteNonQuery();
            }
        }
    }
}