namespace CarsSystem.ConsoleClient.XmlCarViewModels
{
        using System;
        using System.Xml.Serialization;

        [Serializable]
        public class XmlCar
        {
            [XmlIgnore]
            public int Id { get; set; }

            [XmlAttribute]
            public string Manufacturer { get; set; }

            [XmlAttribute]
            public string Model { get; set; }

            [XmlAttribute]
            public int Year { get; set; }

            [XmlAttribute]
            public decimal Price { get; set; }

            [XmlAttribute]
            public string TransmissionType { get; set; }

            public XmlDealer Dealer { get; set; }
        }
    
}
