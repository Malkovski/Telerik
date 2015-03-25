namespace ShapesMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Triangle : Shapes
    {
        public Triangle(int width, int height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (double)this.Height * this.Width / 2;

            
        }
    }
}
