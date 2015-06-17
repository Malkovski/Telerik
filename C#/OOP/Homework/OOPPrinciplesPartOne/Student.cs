namespace OOPPrinciplesPartOne
{
    using System;
    using System.Text;

    public class Student : People
    {
        private int classNumber;
     
        public Student(string name, string commentary, int classNumber) : base(name, commentary)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("The number cannot be zero or negative number!!!");
                }

                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine("Student name: " + this.Name);
            info.AppendLine("Comment: " + this.Comment);
            info.AppendLine("Class number: " + this.ClassNumber);

            return info.ToString();
        }
    }
}
