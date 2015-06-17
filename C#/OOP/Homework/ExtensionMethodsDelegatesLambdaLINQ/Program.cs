namespace ExtensionMethodsDelegatesLambdaLINQ
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

   public class Program
    {      
        public static void Main()
        {
            // Testing the StringBuilder extension method Substring
            Console.WriteLine("---SB test extension---");
            StringBuilder testSb = new StringBuilder("TestSomeStringBuilderExtensions");
            StringBuilder substringTest = testSb.Substring(4, 10);
            Console.WriteLine(substringTest.ToString());

            //Testing IEnumerable extension methods
            Console.WriteLine("---IEnumerable test extension---");
            int[] someTestArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(someTestArr.Max());
            Console.WriteLine(someTestArr.Min());
            Console.WriteLine(someTestArr.Average());
            Console.WriteLine(someTestArr.Sum());
            Console.WriteLine(someTestArr.Product());

            string[] someTestStr = new string[] { "1", "2", "3" };

            Console.WriteLine(someTestStr.Max());
            Console.WriteLine(someTestStr.Min());
            Console.WriteLine(someTestStr.Sum());
            //Console.WriteLine(someTestStr.Average());
            //Console.WriteLine(someTestStr.Product());

            // Testing the Studens LINQs
            List<Students> list = new List<Students>();
            list.Add(new Students("Pesho", "Angelov", 30, "1100105", "02443355", "pepi@abv.bg", new List<int> { 2, 2, 2, 2, 2 }, 1));
            list.Add(new Students("Pencho", "Dimitrov", 18, "120006", "0888445865", "pencho@abv.bg", new List<int> { 4, 6, 3, 5, 2 }, 1));
            list.Add(new Students("Ivo", "Stoyanov", 20, "120001", "088977335", "ivo@mail.bg", new List<int> { 2, 4, 2, 4, 3 }, 2));
            list.Add(new Students("Ivan", "Kirilov", 21, "120003", "0888433422", "ivan@yahoo.bg", new List<int> { 2, 3, 2, 3, 3 }, 2));
            list.Add(new Students("Ivo", "Nikolov", 25, "120004", "02905355", "ivo@abv.bg", new List<int> { 2, 6, 6, 2, 5 }, 1));

            Console.WriteLine("---First name before last test---");
            FirstNameBeforeLastAlphabetically(list);
            Console.WriteLine("---Age between 18 and 24 test---");
            AgeRangeBetween18And24(list);
            Console.WriteLine("---Order by descending with Lambda names test---");
            OrderByLambda(list);
            Console.WriteLine("---Order by descending with LINQ names test---");
            OrderByLinq(list);
            Console.WriteLine("---Print the divisible by 3 and 7 test---");
            int[] someArrInt = new int[] { 3, 6, 8, 123, 14, 21, 52, 42 };
            DivisibleBy3And7Lambda(someArrInt);
            DivisibleBy3And7LINQ(someArrInt);
            Console.WriteLine("---Timer class with delegates test---");
            MyDelegate timer = new MyDelegate(Timer.MessageRepeat);
            timer("WORKING!", 5);

            Console.WriteLine("---Student queries testing---");

            OnlyGroupTwoAndOrderedLINQ(list);
            Console.WriteLine();
            OnlyGroupTwoAndOrderedLambda(list);
            Console.WriteLine();
            ExtractByEmailABV(list);
            Console.WriteLine();
            ExtractByPhoneInSofia(list);
            Console.WriteLine();
            ByExcellentMarkExtractor(list);
            Console.WriteLine();
            ExtractWithExactTwoMarksTwo(list);
            Console.WriteLine();
            ExtractMarksForFN06(list);
            Console.WriteLine();
            GroupedByGroupBy(list);
            Console.WriteLine();
            GroupedByLinq(list);
            Console.WriteLine();
            PrintLongestString("This is some test, about finding the longest word or sequence in given string. I really hope that it works properly!");
           
        }

        public static void PrintLongestString(string input)
        {
            string[] parts = input.Split(new char[] {' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var longest = from s in parts where s.Length == parts.Max(x => x.Length) select s;

            foreach (var item in longest)
            {
                Console.WriteLine(string.Format("{0} - {1} letters", item, item.Length));
            }
        }

        public static void GroupedByLinq(List<Students> list)
        {
            var myList = from st in list group st by st.GroupNumber into newGroup orderby newGroup.Key select newGroup;

            foreach (var student in myList)
            {
                Console.WriteLine(student.Key);

                foreach (var item in student)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                }
            }
        }

        public static void GroupedByGroupBy(List<Students> list)
        {
            var myList = list.GroupBy(st => st.GroupNumber).OrderBy(x => x.Key);

            foreach (var current in myList)
            {
                Console.WriteLine(current.Key);

                foreach (var item in current)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                }
            }
        }

        public static void ExtractMarksForFN06(List<Students> list)
        {
            var myList = from st in list where st.FN[4] == '0' && st.FN[5] == '6' select st;

            foreach (var item in myList)
            {
                string marks = string.Empty;

                foreach (var mark in item.Marks)
                {
                    marks += mark + ","; 
                }

                marks.TrimEnd(',');

                Console.WriteLine(marks);
            }
        }

        public static void ExtractWithExactTwoMarksTwo(List<Students> list)
        {
            var myList = list
                .Where(st => st.Marks.Count(x => x == 2) == 2)
                .Select( st => new {  FullName = st.FirstName + " " + st.LastName, Marks = st.Marks });

            foreach (var item in myList)
            {
                Console.WriteLine(item.FullName);

                string marks = string.Empty;

                foreach (var mark in item.Marks)
                {
                    marks += mark + ",";
                }

                marks.TrimEnd(',');

                Console.WriteLine(marks);
            }
        }

        public static void ByExcellentMarkExtractor(List<Students> list)
        {
            var myList = from st in list where st.Marks.Contains(6) select new { FullName = st.FirstName + " " + st.LastName, Marks = st.Marks };       

            foreach (var item in myList)
            {
                Console.WriteLine(item.FullName);

                string marks = string.Empty;

                foreach (var mark in item.Marks)
                {
                    marks += mark + ",";
                }

                marks.TrimEnd(',');

                Console.WriteLine(marks);
            }
        }

        public static void ExtractByPhoneInSofia(List<Students> list)
        {
            var myList = from st in list where st.Phone.StartsWith("02") select st;

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public static void ExtractByEmailABV(List<Students> list)
        {
            var myList = from st in list where st.Email.EndsWith("abv.bg") select st;

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public static void OnlyGroupTwoAndOrderedLambda(List<Students> list)
        {
            var myList = list
                .Where(st => st.GroupNumber == 2)
                .OrderBy(st => st.FirstName);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        
        public static void OnlyGroupTwoAndOrderedLINQ(List<Students> list)
        {
            var myListOfStudents = from st in list where st.GroupNumber == 2 orderby st.FirstName select st;

            foreach (var item in myListOfStudents)
            {
                Console.WriteLine(item);
            }
        }

        public static void FirstNameBeforeLastAlphabetically(List<Students> listOfStudents)
        {
            var nameBeforeLastName =
                from st in listOfStudents
                where st.FirstName.CompareTo(st.LastName) < 0
                select st;

            foreach (Students st in nameBeforeLastName)
            {
                Console.WriteLine(st);
            }
        }

        public static void AgeRangeBetween18And24(List<Students> list)
        {
            var ageRange =
                from st in list
                where st.Age < 25 && st.Age > 17
                select st;

            foreach (Students st in ageRange)
            {
                Console.WriteLine(st);
            }
        }

        public static void OrderByLambda(List<Students> list)
        {
            var ordered =
                list.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);

            foreach (Students st in ordered)
            {
                Console.WriteLine(st);
            }
        }

        public static void OrderByLinq(List<Students> list)
        {
            var ordered =
                (from st in list
                orderby st.FirstName, st.LastName
                select st).Reverse();
            

            foreach (Students st in ordered)
            {
                Console.WriteLine(st);
            }
        }

        public static void DivisibleBy3And7Lambda(int[] arr)
        {
            var divisible = arr.Where(x => x % 3 == 0 && x % 7 == 0).ToArray();

            foreach (var item in divisible)
            {
                Console.WriteLine(item);
            }
        }

        public static void DivisibleBy3And7LINQ(int[] arr)
        {
            var divisible =
                from number in arr
                where number % 3 == 0 && number % 7 == 0
                select number;

            foreach (var number in divisible)
            {
                Console.WriteLine(number);
            }
        }
    }
}
