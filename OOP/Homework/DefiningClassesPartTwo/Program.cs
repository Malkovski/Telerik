namespace DefiningClassesPartTwo
{
    using System;
    public class Program
    {
        static void Main()
        {
            Point3D somePoint = new Point3D();

            Console.WriteLine(somePoint);

            Point3D anotherPoint = new Point3D(2, 5, 2);

            Console.WriteLine(anotherPoint);

            Console.WriteLine(string.Format("{0:0.000}", DistanceCalculatorClass.DistanceCalculator(somePoint, anotherPoint)));
        }
    }
}
