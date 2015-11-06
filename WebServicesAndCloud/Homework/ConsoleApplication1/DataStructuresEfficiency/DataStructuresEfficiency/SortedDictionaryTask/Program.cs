namespace SortedDictionaryTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }

        static void Main(string[] args)
        {
            var sortedData = ReadData();
            PrintSorted(sortedData);
        }

        private static void PrintSorted(SortedDictionary<string, List<Student>> sortedData)
        {
            foreach (var item in sortedData)
            {
                Console.Write(item.Key);

                var members = item.Value;

                members.Select(x => x.LastName).OrderBy(x => x)
                    
                   
                    

                foreach (var member in sortedData[item.Key])
                {
                    Console.Write(" " + member);
                }

                Console.WriteLine();
            }
            
        }

        public static SortedDictionary<string, List<Student>> ReadData()
        {
            var sorted = new SortedDictionary<string, List<Student>>();

            while (true)
            {
                var line = Console.ReadLine();
                var members = new List<Student>();

                if (!string.IsNullOrEmpty(line))
                {
                    var parts = line.Split('|');

                    var key = parts[2].Trim();

                    var student = new Student
                    {
                        FirstName = parts[0].Trim(),
                        LastName = parts[1].Trim()
                    };

                    if (!sorted.Keys.Contains(key))
                    {
                        sorted.Add(key, members);

                        sorted[key].Add(student);
                    }
                    else
                    {
                        sorted[key].Add(student);
                    }
                }
                else
                {
                    break;
                }
            }

            return sorted;
        }
    }
}
