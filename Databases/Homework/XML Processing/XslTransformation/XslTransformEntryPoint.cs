namespace XslTransformation
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;

    internal class XslTransformEntryPoint
    {
        public class EntryPoint
        {
            private const string XmlFilename = "../../catalogue.xml";
            private const string XslFilename = "../../catalogue.xsl";
            private const string HtmlFilename = "../../catalogue.html";

            public static void Main()
            {
                var xslt = new XslCompiledTransform();
                xslt.Load(XslFilename);
                xslt.Transform(XmlFilename, HtmlFilename);
            }
        }
    }
}