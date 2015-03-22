namespace OOPPrinciplesPartOne
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
            Discipline d1 = new Discipline("Math", 3, 3);
            Discipline d2 = new Discipline("History", 5, 5);
            Discipline d3 = new Discipline("Biology", 4, 4, "My comment here!");
            List<Discipline> disciplineList = new List<Discipline>();
            disciplineList.Add(d1);
            disciplineList.Add(d2);
            disciplineList.Add(d3);

            Teacher t1 = new Teacher("Penka", "Oldest teacher", disciplineList);
            Teacher t2 = new Teacher("Stanka", "Best teacher here!!!", disciplineList);
            Teacher t3 = new Teacher("Minka", "Always ill?!?!", disciplineList);
            List<Teacher> teacherList = new List<Teacher>();
            teacherList.Add(t1);
            teacherList.Add(t2);
            teacherList.Add(t3);

            Student s1 = new Student("Albena", "Failer", 1);
            Student s2 = new Student("Borqna", "Failer", 2);
            Student s3 = new Student("Katq", "Exelent student", 18);
            List<Student> studentList = new List<Student>();
            studentList.Add(s1);
            studentList.Add(s2);
            studentList.Add(s3);

            Class c1 = new Class("1A");
            Class c2 = new Class("1B", "This class is full of failers!");
            Class c3 = new Class("5A", teacherList, studentList, "This class is full of girls!");

            Console.WriteLine(c3);
        }
    }
}
