namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;
       
        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        public Course(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name {
            get
            {
                return this.name;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty string!");
                }

                this.name = value;
            }
        }

        public string TeacherName {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Teacher name cannot be empty string!");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        public string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }
    }
}
