namespace DeleteAlbumsWithPriceOverTwenty
{
    using System;
    using System.Linq;
    using System.Xml;

    internal class DeleteAlbumsEntryPoint
    {
        private static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            XmlNode rootNode = doc.DocumentElement;

            Console.WriteLine("Albums count is {0}", rootNode.ChildNodes.Count);

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                int price = int.Parse(node["price"].InnerText);

                if (price > 20)
                {
                    rootNode.RemoveChild(node);
                }
            }

            Console.WriteLine("Albums cheaper than 20 are {0}", rootNode.ChildNodes.Count);
        }
    }
}