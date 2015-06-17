namespace DefiningClassesPartTwo
{
    using System;

    [Version("1.00")]
    [Version("1.02")]
    public class Program
    {        
        static void Main()
        {
            // Some testing  the Point3D class!!

            //Point3D somePoint = new Point3D();
            //Path myPath = new Path();
            //myPath.AddPoint(somePoint);
            //Console.WriteLine(somePoint);
            //Point3D anotherPoint = new Point3D(2, 5, 2);
            //myPath.AddPoint(anotherPoint);
            //Console.WriteLine(anotherPoint);
            //Console.WriteLine(string.Format("{0:0.000}", DistanceCalculatorClass.DistanceCalculator(somePoint, anotherPoint)));
            //PathStorage.SavePath(myPath);
            //Path testPath = PathStorage.LoadPath("Paths.txt");

            //for (int i = 0; i < testPath.ListOfPoints.Count; i++)
            //{
            //    Console.WriteLine(testPath.ListOfPoints[i]);
            //}

            //Console.WriteLine("End of test 1!");


            // Some testing the GenericList!!           
 
            //GenericList<int> listInt = new GenericList<int>();
            //int count = listInt.Capacity;
            //Console.WriteLine(listInt);

            //for (int i = 0; i < 4; i++)
            //{
            //    listInt.Add(i);
            //}

            //Console.WriteLine("Count is {0} Capacity is {1}", listInt.Count, listInt.Capacity);
            //listInt.Add(9);
            //Console.WriteLine("Count is {0} Capacity is {1}",listInt.Count, listInt.Capacity);
            //listInt.Insert(100, 0);
            //Console.WriteLine("Count is {0} Capacity is {1}", listInt.Count, listInt.Capacity);
            //listInt.Insert(88, 2);
            //Console.WriteLine("Count is {0} Capacity is {1}", listInt.Count, listInt.Capacity);
            //listInt.Add(111);
            //Console.WriteLine(listInt.IndexOf(88));
            //Console.WriteLine(listInt.IndexOf(8));
            //Console.WriteLine(listInt);
            //listInt.RemoveAt(4);
            //Console.WriteLine(listInt);
            //listInt.RemoveAt(0);
            //Console.WriteLine(listInt);
            //listInt.RemoveAt(listInt.Count - 1);
            //Console.WriteLine(listInt);           
            //Console.WriteLine(listInt);
            //count = listInt[3];
            //Console.WriteLine(count);
            //Console.WriteLine("{0}", listInt.Max());
            //count = listInt.Min();
            //Console.WriteLine(count);
            //Console.WriteLine("End of test 2!");


            // Some testing the Matrix<>!!

            int myRow = 4;
            int myCol = 4;
            Matrix<int> myMatrix = new Matrix<int>(myRow, myCol);
            int counter = 1;

            for (int i = 0; i < myRow; i++)
            {
                for (int j = 0; j < myCol; j++)
                {
                    myMatrix[i, j] = counter;
                    counter++;
                }
            }

            int myNumber = myMatrix[2, 3];
            Console.WriteLine(myNumber);

            Matrix<int> addingMatrix = myMatrix + myMatrix;
            Matrix<int> subMatrix = myMatrix - myMatrix;
            Matrix<int> multiplMatrix = myMatrix * myMatrix;

            Console.WriteLine("{0}", addingMatrix);
            Console.WriteLine(subMatrix);
            Console.WriteLine(multiplMatrix);     
        
            // Testing the attribute!!

            Type type = typeof(Program);
            object[] versionType = type.GetCustomAttributes(false);

            foreach (VersionAttribute attribute in versionType)
            {
                Console.WriteLine("Version: {0}", attribute.Version);
            }
            
        }
    }
}
