namespace AnimalsMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Animal 
    {
        private string name;
        private int age;

        public Animal(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
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
                    throw new ArgumentNullException("Name cannot be null or empty!!! Enter some name!!!");
                }

                foreach (char ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("Use only letters please!!!");
                    }
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be 0 or negative!!!!");
                }

                this.age = value;
            }
        }

        public Sex Sex { get; set; }
    }
}
