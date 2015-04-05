namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Data cannot be null or empty!!!");
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            var info = string.Format("Teacher: Name={0}", this.Name);

            if (this.courses.Count > 0)
            {
                info += string.Format("; Courses=[{0}]", this.CoursesPrint());
            }

            return info;
        }

        public string CoursesPrint()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < this.courses.Count; i++)
            {
                if (i != this.courses.Count - 1)
                {
                    output.Append(courses[i].Name + ", ");
                }
                else
                {
                    output.Append(courses[i].Name);
                }
            }
           
            return output.ToString();
        }
    }
}
