namespace Abstraction
{
    using System;

    internal abstract class Figure
    {
        internal double Radius;
        internal double Width;
        internal double Height;

        internal Figure()
        {
        }

        internal Figure(double radius)
        {
            this.Radius = radius;
        }

        internal Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
