namespace CarsSystem.ConsoleClient.XmlCarViewModels
{
    using System.Xml.Serialization;


    [XmlTypeAttribute(AnonymousType = true)]
    public partial class WhereClause
    {

        [XmlAttributeAttribute()]
        public string PropertyName { get; set; }


        [XmlAttributeAttribute()]
        public string Type { get; set; }

        [XmlIgnore]
        public WhereTypes WhereType
        {
            get
            {
                switch (this.Type)
                {
                    case "Contains": return WhereTypes.Contains;
                    case "Equals": return WhereTypes.Equals;
                    case "GreatherThan": return WhereTypes.GreaterThan;
                     default:  return WhereTypes.LessThan;
                };
            }
        }

        [XmlTextAttribute()]
        public string Value { get; set; }
    }
}

