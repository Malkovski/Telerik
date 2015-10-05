namespace ListingAuthorsAndAlbumsCount
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
            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                string author = node["artist"].InnerText;

                if (!authorsList.ContainsKey(author))
                {
                    authorsList[author] = 1;
                }
                else
                {
                    authorsList[author]++;
                }
            }

            foreach (KeyValuePair<string, int> author in authorsList)
            {
                Console.WriteLine("The author {0} has {1} albums in the catalog!", author.Key, author.Value);
            }
        }
    }
}