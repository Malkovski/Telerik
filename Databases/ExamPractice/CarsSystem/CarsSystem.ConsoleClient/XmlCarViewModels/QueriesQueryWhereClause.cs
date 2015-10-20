namespace CarsSystem.ConsoleClient.XmlCarViewModels
{
    using System.Xml.Serialization;
    /// <remarks/>

    [XmlTypeAttribute(AnonymousType = true)]
    public partial class QueriesQueryWhereClause
    {
        /// <remarks/>
        [XmlAttributeAttribute()]
        public string PropertyName { get; set; }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Type { get; set; }

        /// <remarks/>
        [XmlTextAttribute()]
        public string Value { get; set; }
    }
}

