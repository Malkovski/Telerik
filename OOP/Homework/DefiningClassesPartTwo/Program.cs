namespace DefiningClassesPartTwo
{
    using System;
    public class Program
    {
        static void Main()
        {
            Point3D somePoint = new Point3D();

            Path myPath = new Path();

            myPath.AddPoint(somePoint);

            Console.WriteLine(somePoint);

            Point3D anotherPoint = new Point3D(2, 5, 2);

            myPath.AddPoint(anotherPoint);

            Console.WriteLine(anotherPoint);

            Console.WriteLine(string.Format("{0:0.000}", DistanceCalculatorClass.DistanceCalculator(somePoint, anotherPoint)));

            PathStorage.SavePath(myPath);

            Path testPath = PathStorage.LoadPath("Paths.txt");

            for (int i = 0; i < testPath.ListOfPoints.Count; i++)
            {
                Console.WriteLine(testPath.ListOfPoints[i]);
            }

            Console.WriteLine("End of test!");
        }
    }
}
