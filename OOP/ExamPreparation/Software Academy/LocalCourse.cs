namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name,  ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Data cannot be null or empty!!!");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            //; Lab={4}; Town=(town name – when applicable)"
            StringBuilder info = new StringBuilder();

            info.Append(string.Format("{0}; Lab={1}", base.ToString(), this.Lab));

            return info.ToString();
        }
    }
}
