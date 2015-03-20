namespace OOPPrinciplesPartOne
{
    using System;

    public class Student : People, IComment
    {
        public Student(string name, int classNumber) : base()
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return this.ClassNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("The number cannot be zero or negative number!!!");
                }

                this.ClassNumber = value;
            }
        }

        public void Comment(string input)
        {
            Console.WriteLine(input);
        }
    }
}
