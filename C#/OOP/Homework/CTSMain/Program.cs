namespace CTSMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            Student one = new Student("1213344556677", "Ivko");
            one.Specialty = Specialty.Engeneering;
            one.Course = new Course("OOP", 10);
            Student two = new Student("2344445565666", "Ivko");
            var three = one.Clone() as Student;

            Console.WriteLine(three.Specialty);
            
            var result = one.CompareTo(two);
            Console.WriteLine(result);
        }
    }
}
