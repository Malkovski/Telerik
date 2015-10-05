namespace ExtractAlbumsOlderThanFiveYearsWithLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    class EntryPoint
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("../../catalog.xml");

            var albums = doc.Descendants("album");

            foreach (var album in albums)
            {
                var year = album.Descendants("year").Take(1);
                var price = album.Descendants("price");

                Console.WriteLine(year);
            }
            
        }
    }
}
