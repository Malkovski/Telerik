namespace CarsSystem.ConsoleClient.XmlCarViewModels
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    class XmlDealer
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArrayItem(ElementName = "City")]
        public List<string> Cities { get; set; }
    }
}
