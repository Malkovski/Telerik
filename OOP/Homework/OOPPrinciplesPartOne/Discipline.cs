namespace OOPPrinciplesPartOne
{
    using System;

    public class Discipline : IComment
    {
       private string disciplineName;
       private int numberOFLectures;
       private int numberOfExercises;
       
        public Discipline(string name, int lectNum, int exerNum)
        {
            this.DisciplineName = disciplineName;
            this.NumberOfLectures = numberOFLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public string DisciplineName
        {
            get
            {
                return this.disciplineName;
            }

            set
            {
                this.disciplineName = value;
            }
        }

        public int NumberOfLectures 
        {
            get 
            {
                return this.NumberOfLectures;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("The number cannot be negative number!!!");
                }

                this.NumberOfLectures = value;
            }
        }
        public int NumberOfExercises
        {
            get
            {
                return this.NumberOfExercises;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("The number cannot be negative number!!!");
                }

                this.NumberOfExercises = value;
            }
        }

        public void Comment(string input)
        {
            Console.WriteLine(input);
        }
    }
}
