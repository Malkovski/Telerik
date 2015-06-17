namespace PersonMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person
    {
        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string  Name { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            if (this.Age != null)
            {
                return string.Format("Name: {0}, Age: {1}", this.Name, this.Age);
            }
            else
            {
                return string.Format("Name: {0}, Age - Unknown!", this.Name);
            }
        }
    }   
}
