namespace ShapesMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShapesMainSystem
    {
        static void Main()
        {
            var randomShapeCollection = new List<Shapes>()
            {
               new Triangle(2, 2),
               new Rectangle(3, 4),
               new Square(5),
               new Rectangle(1, 6),
               new Triangle(3, 7),
               new Square(100),
               new Triangle(12, 4)
            };

            // Here, I test the behaviour of the method, for surface calculations.
            ShapeSurfaceTester(randomShapeCollection);
        }

        public static void ShapeSurfaceTester(IEnumerable<Shapes> randomShapes)
        {
            foreach (var item in randomShapes)
            {
                Console.WriteLine(string.Format("{0}", item.CalculateSurface()));
            }
        }
    }
}
