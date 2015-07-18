namespace Abstraction
{
    using System;

    internal class Circle : Figure
    {
        internal Circle()
            : base(0)
        {
        }

        internal Circle(double radius)
            : base(radius)
        {
        }

        internal double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Radius cannot be null!");
                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Radius cannot be negative value!");
                }

                this.radius = value;
            }
        }

        internal double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        internal double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}