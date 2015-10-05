namespace ExtractSongNamesWithXmlReader
{
    using System;
    using System.Linq;
    using System.Xml;

    internal class ExtractNamesEntryPoint
    {
        private static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element && reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}