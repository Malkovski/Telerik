namespace ShapesMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Square : Rectangle
    {
        public Square(int side)
            : base(side, side)
        {
        }
    }
}
