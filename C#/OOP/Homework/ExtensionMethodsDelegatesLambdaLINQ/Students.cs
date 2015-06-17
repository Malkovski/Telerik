namespace ExtensionMethodsDelegatesLambdaLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Students
    {
        public Students()
        {
        }
        public Students(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Students(string firstName, string lastName, int age, string fn, string phone, string email, List<int> marks, int group) : this(firstName, lastName, age)
        {
            this.FN = fn;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = group;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FN { get; set; }
        public string Phone { get; set; }
        public string  Email { get; set; }
        public List<int>  Marks { get; set; }
        public int GroupNumber { get; set; }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(string.Format("{0} {1}", this.FirstName, this.LastName));
            info.Append(" ");
            info.Append(this.Age);
            info.Append(" ");
            info.Append(this.FN);
            info.Append(" ");
            info.Append(this.Phone);
            info.Append(" ");
            info.Append(this.Email);
            info.Append(" ");
            info.Append(this.GroupNumber);
            info.Append(" ");
            string grades = string.Empty;
            foreach (var item in this.Marks)
            {
                grades += item + ",";
            }

            grades.TrimEnd(',');
            info.Append(grades);

            return info.ToString();
        }
    }

    
}
