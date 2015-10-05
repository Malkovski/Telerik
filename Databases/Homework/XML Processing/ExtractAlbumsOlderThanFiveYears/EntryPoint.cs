namespace ExtractAlbumsOlderThanFiveYears
{
    using System;
    using System.Linq;
    using System.Xml;

    internal class EntryPoint
    {
        private static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            string xPathQuery = "catalog/album";

            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            int currentYear = DateTime.Now.Year;

            foreach (XmlNode album in albums)
            {
                string year = album.SelectSingleNode("year").InnerText;
                string price = album.SelectSingleNode("price").InnerText;

                if ((currentYear - int.Parse(year)) < 5)
                {
                    Console.WriteLine(price);
                }
            }
        }
    }
}