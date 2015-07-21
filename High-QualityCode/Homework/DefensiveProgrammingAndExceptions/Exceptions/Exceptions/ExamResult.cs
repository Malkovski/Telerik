namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade {
            get
            {
                return this.grade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grade cannot be negative!");
                }

                this.grade = value;
            } 
        }
        public int MinGrade {
            get
            {
                return this.minGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MinGrade cannot be negative!");
                }

                this.grade = value;
            }
        }
        public int MaxGrade {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MaxGrade cannot be negative!");
                }

                this.maxGrade = value;
            } 
        }
        public string Comments
        {
            get { 
                return this.comments; 
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Comments cannto be empty string!");
                }

                this.comments = value;
            }
        }
    }
}
