namespace OOPPrinciplesPartOne.Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Names cannot be empty!!!");
                }

                foreach (char ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("Names must contain only letters!!!");
                    }
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Names cannot be empty!!!");
                }

                foreach (char ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("Names must contain only letters!!!");
                    }
                }

                this.lastName = value;
            }
        }   
    }
}
