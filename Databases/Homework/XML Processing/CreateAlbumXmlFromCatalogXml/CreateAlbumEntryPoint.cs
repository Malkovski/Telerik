namespace CreateAlbumXmlFromCatalogXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    internal class CreateAlbumEntryPoint
    {
        private const string Filename = "../../catalog.xml";

        public static void Main()
        {
            XDocument xmlDoc = XDocument.Load(Filename);
            var xmlAlbums = new XElement("albums");
            var albums = from album in xmlDoc.Descendants("album")
                                       select new
                                       {
                                           Album = album.Element("name").Value,
                                           Author = album.Element("artist").Value
                                       };

            foreach (var album in albums)
            {
                var xmlAlbum = new XElement("album",
                    new XElement("Name", album.Album),
                    new XElement("Author", album.Author));

                xmlAlbums.Add(xmlAlbum);
            }

            Console.WriteLine(xmlAlbums);

            xmlAlbums.Save("../../albums.xml");
        }
    }
}