namespace CarsSystem.ConsoleClient.XmlCarViewModels
{
    using System.Xml.Serialization;
    /// <remarks/>

    [XmlTypeAttribute(AnonymousType = true)]
    public partial class QueriesQuery
    {
        /// <remarks/>
        public string OrderBy { get; set; }

        /// <remarks/>
        [XmlArrayItemAttribute("WhereClause", IsNullable = false)]
        public QueriesQueryWhereClause[] WhereClauses { get; set; }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string OutputFileName { get; set; }
    }
}
