namespace CarsSystem.ConsoleClient.XmlCarViewModels
{
    using System.Xml.Serialization;

    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Queries
    {
        /// <remarks/>
        [XmlElementAttribute("Query")]
        public Query[] Query { get; set; }
    }
}