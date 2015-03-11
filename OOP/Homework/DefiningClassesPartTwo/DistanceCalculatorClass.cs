namespace DefiningClassesPartTwo
{
    using System;

    public static class DistanceCalculatorClass
    {
        public static double DistanceCalculator(Point3D one, Point3D two)
        {
              double distance = Math.Sqrt(((one.X - two.X) * (one.X - two.X)) +
                                          ((one.Y - two.Y) * (one.Y - two.Y)) +
                                          ((one.Z - two.Z) * (one.Z - two.Z)));

              return distance;
        }
    }
}
