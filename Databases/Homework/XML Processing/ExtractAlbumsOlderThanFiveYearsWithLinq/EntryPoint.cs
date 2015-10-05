namespace ExtractAlbumsOlderThanFiveYearsWithLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    internal class EntryPoint
    {
        private static void Main()
        {
            XDocument doc = XDocument.Load("../../catalog.xml");

            var albums = from album in doc.Descendants("album")
                                       where (int.Parse(album.Element("year").Value) <= (DateTime.Now.Year - 5))
                                       select new
                                       {
                                           AlbumName = album.Element("name").Value,
                                           AlbumPrice = album.Element("price").Value
                                       };

            foreach (var album in albums)
            {
                Console.WriteLine("The album {0} is older than five years. Costs ${1}", album.AlbumName, album.AlbumPrice);
            }
        }
    }
}