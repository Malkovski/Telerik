namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Table : Element, ITable
    {
        private readonly string name = "table";


        private int rows;
        private int cols;
        private IElement[,] elements;


        public Table(int rows, int cols)
            :base("table")
        {
            this.Rows = rows;
            this.Cols = cols;
            this.elements = new IElement[rows, cols];
        }

        public int Rows
        {
            get { return this.rows; }

            protected set
            {
                this.rows = value;
            }
        }

        public int Cols
        {
            get { return this.cols; }

            protected set
            {
                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.elements[row, col];
            }

            set
            {

                this.elements[row, col] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append("<table>");
            for (int i = 0; i < rows; i++)
            {
                info.Append("<tr>");

                for (int j = 0; j < cols; j++)
                {
                    info.Append("<td>");
                    info.Append(this.elements[i, j].ToString());
                }
            }
            info.Append("</table>");

            return info.ToString();
        }
    }
}
