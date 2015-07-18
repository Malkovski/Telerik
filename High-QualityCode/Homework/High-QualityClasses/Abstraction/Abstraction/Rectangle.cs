namespace Abstraction
{
    using System;

    internal class Rectangle : Figure
    {
        public Rectangle()
            : base(0, 0)
        {
        }

        internal Rectangle(double width, double height)
            : base(width, height)
        {
        }

        internal double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Width cannot be null!");
                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be negative value!");
                }

                this.width = value;
            }
        }

        internal double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Height cannot be null!");
                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be negative value!");
                }

                this.height = value;
            }
        }

        internal double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        internal double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}