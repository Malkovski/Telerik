namespace ListingAuthorsAndAlbumsCountXpath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    internal class AuthorListingEntryPoint
    {
        private static void Main()
        {
            var authorsList = new Dictionary<string, int>();

            var doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            string xPathQuery = "catalog/album";

            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                string artist = album.SelectSingleNode("artist").InnerText;

                if (!authorsList.ContainsKey(artist))
                {
                    authorsList[artist] = 1;
                }
                else
                {
                    authorsList[artist]++;
                }
            }

            foreach (KeyValuePair<string, int> author in authorsList)
            {
                Console.WriteLine("The author {0} has {1} albums in the catalog!", author.Key, author.Value);
            }
        }
    }
}