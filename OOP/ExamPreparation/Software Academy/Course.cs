namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private IList<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.teacher = teacher;
            this.topics = new List<string>();
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

        public ITeacher Teacher
        {
            get
            {
               return this.teacher;
            }

            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            var info = string.Format("{0}: Name={1}; ",this.GetType().Name, this.Name);

            if (this.Teacher != null)
            {
                info += string.Format("Teacher={0}; ", this.Teacher.Name);
            }

            if (this.topics.Count > 0)
            {
                info += string.Format("Topics=[{0}]", this.PrintTopics());
            }

            return info;
        }

        public string PrintTopics()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < this.topics.Count; i++)
            {
                if (i != this.topics.Count - 1)
                {
                    output.Append(topics[i] + ", ");
                }
                else
                {
                    output.Append(topics[i]);
                }
            }
           
            return output.ToString();
        }
    }
}
