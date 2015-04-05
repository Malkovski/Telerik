namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Element : IElement
    {
        private string name;
        private string textContent;
        private ICollection<IElement> childElements;

        public Element(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public Element(string name, string textContent)
            : this(name)
        {
            this.TextContent = textContent;
        }

        public string Name
        {
            get { return this.name;}

            protected set
            {
                this.name = value;
            }
        }

        public string TextContent
        {
            get
            {
                return this.textContent;
            }

            set
            {
                this.textContent = value;
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return this.childElements; }
        }

        public void AddElement(IElement element)
        {
            childElements.Add(element);
        }

        public void Render(StringBuilder output)
        {

        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            if (this.Name != null)
            {
                info.Append(string.Format("<{0}>", this.Name));
            }

            if (this.TextContent != null)
            {
                var newText = this.TextContent.Replace("<", "&lt").Replace(">", "&gt").Replace("&", "&amp");

                info.Append(string.Format("{0}", newText));
            }

            foreach (var element in childElements)
            {
                if (element.Name != null)
                {
                    if (element.Name == "table")
                    {
                        info.Append("<table>");
                        for (int i = 0; i < (element as Table).Rows; i++)
                        {
                            info.Append("<tr>");

                            for (int j = 0; j < (element as Table).Cols; j++)
                            {
                                info.Append("<td>");
                                info.Append((element as Table)[i, j].ToString());
                            }
                        }
                        info.Append("</table>");
                    }
                    else
                    {
                        info.Append(string.Format("<{0}>", element.Name));

                        if (element.TextContent != null)
                        {
                            var newText = element.TextContent.Replace("<", "&lt").Replace(">", "&gt").Replace("&", "&amp");

                            info.Append(string.Format("{0}", newText));
                        }

                        info.Append(string.Format("</{0}>", element.Name));
                    }
                }
            }

            if (this.Name != null)
            {
                info.Append(string.Format("</{0}>", this.Name));
            }

            return info.ToString();

        }
    }
}
