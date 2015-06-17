namespace ShapesMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Shapes
    {
        private int width;
        private int height;

        public Shapes(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width 
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("The side must be positive integer bigger than zero!!!");
                }

                this.width = value;
            }
        
        }

        public int Height 
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("The side must be positive integer bigger than zero!!!");
                }

                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
