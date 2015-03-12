namespace DefiningClassesPartTwo
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
       private List<Point3D> listOfPoints;

       public Path()
       {
           this.listOfPoints = new List<Point3D>();
       }

       public List<Point3D> ListOfPoints
       {
           get
           {
               return this.listOfPoints;
           }

           set
           {
               this.ListOfPoints = value;
           }
       }

       public void AddPoint(Point3D point)
       {
           this.ListOfPoints.Add(point);
       }

       public void DeletePoint(Point3D point)
       {
           this.ListOfPoints.Remove(point);
       }      
    }
}
