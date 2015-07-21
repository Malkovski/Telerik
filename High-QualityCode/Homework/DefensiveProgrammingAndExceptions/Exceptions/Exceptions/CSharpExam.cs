namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CSharpExam : Exam
    {
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Score must be in the interval 0 - 100!");
                }
            }
        }

        public override ExamResult Check()
        {
                return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}
