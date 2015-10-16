namespace RetrieveAndStoreImages
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing.Imaging;
    using System.IO;

    public class Startup
    {
        private const string ConnectionString = "Server=.\\SQLEXPRESS; " + "Database=NorthWind; Integrated Security=true";

        public static void Main(string[] args)
        {
            var dbCon = new SqlConnection(ConnectionString);

            ExtractImagesFromDB(dbCon);
        }

        private static void ExtractImagesFromDB(SqlConnection dbConn)
        {
            dbConn.Open();
            using (dbConn)
            {
                var cmd = new SqlCommand("SELECT * FROM Categories ", dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var rawData = (byte[])reader["Picture"];
                    string fileName = string.Format("{0}.jpg", reader["CategoryName"].ToString().Replace('/', '_'));
                    int len = rawData.Length;
                    int header = 78;
                    byte[] imgData = new byte[len - header];
                    Array.Copy(rawData, 78, imgData, 0, len - header);

                    var memoryStream = new MemoryStream(imgData);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                    image.Save(new FileStream(fileName, FileMode.Create), ImageFormat.Jpeg);

                    // Check RetrieveAndStoreImages\bin\Debug
                }
            }
        }
    }
}