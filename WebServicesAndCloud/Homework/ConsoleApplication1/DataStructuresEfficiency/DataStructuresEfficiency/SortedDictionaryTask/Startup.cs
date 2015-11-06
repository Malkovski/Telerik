namespace SortedDictionaryTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Startup
    {
        private static void Main()
        {
            SortedDictionary<string, OrderedBag<Student>> sortedData = ReadData();
            PrintSorted(sortedData);
        }

        private static SortedDictionary<string, OrderedBag<Student>> ReadData()
        {
            var sorted = new SortedDictionary<string, OrderedBag<Student>>();

            while (true)
            {
                string line = Console.ReadLine();
                var members = new OrderedBag<Student>();

                if (!string.IsNullOrEmpty(line))
                {
                    string[] parts = line.Split('|');

                    string key = parts[2].Trim();

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

        private static void PrintSorted(SortedDictionary<string, OrderedBag<Student>> sortedData)
        {
            foreach (KeyValuePair<string, OrderedBag<Student>> item in sortedData)
            {
                Console.Write(string.Format("{0}: ", item.Key));

                IOrderedEnumerable<Student> members = item.Value.OrderBy(x => x.FirstName);
                var builder = new StringBuilder();

                foreach (Student member in members)
                {
                    builder.AppendFormat("{0} {1}", member.FirstName, member.LastName);
                    builder.Append(", ");
                }

                builder.Remove(builder.Length - 2, 2);
                Console.WriteLine(builder);
            }
        }

        public class Student : IComparable
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int CompareTo(object obj)
            {
                var student = obj as Student;
                return this.LastName.CompareTo(student.LastName);
            }
        }
    }
}