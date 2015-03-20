namespace OOPPrinciplesPartOne
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Class : IComment
    {
        public string Identifier { get; set; }
        public List<Teacher> SetOfTeachers { get; set; }
        public List<Student> SetOfStudents { get; set; }

        public void Comment(string input)
        {
            Console.WriteLine(input);
        }
    }
}
