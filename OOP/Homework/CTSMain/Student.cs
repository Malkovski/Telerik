namespace CTSMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public  class Student : ICloneable, IComparable<Student>
    {
        public Student(string ssn, string firstName)
        {
            this.FirstName = firstName;
            this.SSN = ssn;
        }

        public Student(string ssn, string firstName, string middleName, string lastName)
            : this(ssn, firstName)
        {

        }



        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string  MobilePhone { get; set; }
        public string Email { get; set; }
        public Course Course { get; set; }
        public University University { get; set; }
        public Specialty Specialty { get; set; }
        public Faculty Faculty { get; set; }

        public override bool Equals(object obj)
        {
            var student = obj as Student;

            if (student == null)
            {
                throw new ArgumentNullException("NULL!!!");
            }

            if (this.SSN == student.SSN)
            {
                return true;	 
            }

            return false;
        }

        public override int GetHashCode()
        {
            return int.Parse(this.MobilePhone) ^ int.Parse(this.SSN);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(string.Format("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            info.Append(Environment.NewLine);
            info.Append(string.Format("SSN: {0}", this.SSN));
            info.Append(Environment.NewLine);
            info.Append(string.Format("Address: {0}, Mobile Phone: {1}, Email: {2}", this.Address, this.MobilePhone, this.Email));
            info.Append(Environment.NewLine);
            info.Append(string.Format("Course name: {0}, Course length {1}", this.Course.Name, this.Course.Lenght));
            info.Append(Environment.NewLine);
            info.Append(string.Format("University: {0}, Faculty {1}, Specialty: {2}", this.University, this.Faculty, this.Specialty));

            return info.ToString();
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return object.Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !object.Equals(firstStudent, secondStudent); 
        }

        public object Clone()
        {
            var temp = this.MemberwiseClone() as Student;
            temp.Course = new Course(this.Course.Name, this.Course.Lenght);
            return temp;
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) == 0)
            {
                if (this.SSN.CompareTo(other.SSN) > 0)
                {
                    return 1;
                }
                else if (this.SSN.CompareTo(other.SSN) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else if (this.FirstName.CompareTo(other.FirstName) > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
