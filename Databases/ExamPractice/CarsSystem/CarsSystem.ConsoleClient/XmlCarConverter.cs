namespace CarsSystem.ConsoleClient
{
    using CarsSystem.ConsoleClient.XmlCarViewModels;
    using System;
    using System.Linq;
    using System.Xml.Serialization;

    public class XmlCarConverter
    {
        public void Convert()
        {
            var serializer = new XmlSerializer(typeof(Queries), new XmlRootAttribute("Queries"));
        }
    }
}