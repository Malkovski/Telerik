namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Data cannot be null or empty!!!");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(string.Format("{0}; Town={1}", base.ToString(), this.Town));

            return info.ToString();
        }
    }
}
