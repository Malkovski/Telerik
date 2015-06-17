namespace OOPPrinciplesPartOne.Humans
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
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Angel", "Markov", 200, 8));
            workers.Add(new Worker("Stefan", "Angelov", 100, 4));
            workers.Add(new Worker("Ivan", "Georgiev", 400, 7));
            workers.Add(new Worker("Angel", "Angelov", 335.6, 8));
            workers.Add(new Worker("Dimityr", "Angelov", 20, 1));
            workers.Add(new Worker("Petko", "Mihailov", 1, 1));
            workers.Add(new Worker("Zarko", "Gogov", 555, 10));
            workers.Add(new Worker("Stoyan", "Jelev", 210, 6));
            workers.Add(new Worker("Ivan", "Iliev", 170, 8));
            workers.Add(new Worker("Krasi", "Radkov", 260, 8));

            List<Student> students = new List<Student>();
            students.Add(new Student("Emo", "Hristov", 2));
            students.Add(new Student("Ivo", "Nikolov", 6));
            students.Add(new Student("Petko", "Iliev", 4));
            students.Add(new Student("Ogi", "Atanasov", 5));
            students.Add(new Student("Jivko", "Hristov", 2));
            students.Add(new Student("Marian", "Marianov", 3));
            students.Add(new Student("Asen", "Gogov", 3));
            students.Add(new Student("Georgi", "Hristov", 2));
            students.Add(new Student("Joro", "Avramov", 6));
            students.Add(new Student("Anton", "Dragnev", 5));

            List<Student> sortedStudents = new List<Student>(from st in students orderby st.Grade select st);

            foreach (var st in sortedStudents)
            {
                Console.WriteLine(st);
            }

            Console.WriteLine();
            List<Worker> sortedWorkers = new List<Worker>(workers.OrderByDescending(x => x.MoneyPerHour()));

            foreach (var wo in sortedWorkers)
            {
                Console.WriteLine(wo);
            }

            var merged = new List<Human>();
            merged.AddRange(sortedStudents);
            merged.AddRange(sortedWorkers);

            Console.WriteLine();
            var sortedMergedHumans = merged.OrderBy(x => x.FirstName).ThenBy(y => y.LastName);

            foreach (var item in sortedMergedHumans)
            {
                Console.WriteLine(item);
            }
        }
    }
}
