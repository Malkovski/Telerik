namespace OOPPrinciplesPartOne
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Class 
    {
        private const string DefaultCommentary = "";

        private string identifier;
        private List<Teacher> setOfTeachers;
        private List<Student> setOfStudents;
        private string comment;

        public Class(string identifier, string commentary = DefaultCommentary)
        {
            this.Identifier = identifier;
            this.Comment = commentary;
        }

        public Class(string identifier, List<Teacher> teachers, List<Student> students, string commentary = DefaultCommentary)
            : this(identifier, commentary)
        {          
            this.SetOfTeachers = teachers;
            this.SetOfStudents = students;
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Name cannot be null or empty!!!");
                }

                if (value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("Identifier too long, use up to 20 chars!!!");
                }

                this.identifier = value;
            } 
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentOutOfRangeException("The comment must be up to 200 characters!!!");
                }

                this.comment = value;
            }
        }

        public List<Teacher> SetOfTeachers
        {
            get
            {
                return this.setOfTeachers;
            }

            set
            {
                this.setOfTeachers = value;
            }
        }

        public List<Student> SetOfStudents
        {
            get
            {
                return this.setOfStudents;
            }

            set
            {
                this.setOfStudents = value;
            }
        }

        public void AddTeacher(Teacher newTeacher)
        {
            this.SetOfTeachers.Add(newTeacher);
        }

        public void RemoveTeacher(Teacher uselessTeacher)
        {
            this.SetOfTeachers.Remove(uselessTeacher);
        }

        public void AddStudent(Student newStudent)
        {
            this.SetOfStudents.Add(newStudent);
        }

        public void RemoveStudent(Student uselessStudent)
        {
            this.SetOfStudents.Remove(uselessStudent);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine("ID: " + this.Identifier);
            info.AppendLine("Comment: " + this.Comment);
            info.AppendLine("List of teachers:");

            foreach (Teacher t in this.SetOfTeachers)
            {
                info.AppendLine(t.ToString());
            }

            info.AppendLine("List of students:");

            foreach (Student s in this.SetOfStudents)
            {
                info.AppendLine(s.ToString());
            }

            return info.ToString();
        }
    }
}
