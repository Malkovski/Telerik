namespace DefiningClassesPartTwo
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePath(Path somePath)
        {
            StreamWriter writer = new StreamWriter("Paths.txt");

            using (writer)
            {
                for (int i = 0; i < somePath.ListOfPoints.Count; i++)
                {
                    writer.WriteLine(somePath.ListOfPoints[i]);
                }
            }
        }

        public static Path LoadPath(string someFilePath)
        {
            Path path = new Path();
            Point3D currentPoint = new Point3D();

            StreamReader reader = new StreamReader(someFilePath);

            using (reader)
            {
                while (reader.EndOfStream == false)
                {
                    string currentFileLine = reader.ReadLine();
                    currentPoint = Point3D.Parse(currentFileLine);
                    path.AddPoint(currentPoint);
                }
            }

            return path;
        }
    }
}
