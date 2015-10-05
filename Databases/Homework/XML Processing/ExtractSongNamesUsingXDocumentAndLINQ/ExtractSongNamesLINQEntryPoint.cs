namespace ExtractSongNamesUsingXDocumentAndLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal class ExtractSongNamesLINQEntryPoint
    {
        private static void Main()
        {
            XDocument xDoc = XDocument.Load("../../catalog.xml");

            IEnumerable<XElement> songNames = xDoc.Descendants("title");

            foreach (XElement name in songNames)
            {
                Console.WriteLine(name.Value);
            }
        }
    }
}