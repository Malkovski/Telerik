namespace OOPPrinciplesPartOne
{
    using System;

    public class Discipline 
    {
        private const string DefaultCommentary = "";

        private string disciplineName;
        private int numberOfLectures;
        private int numberOfExercises;
        private string comment;
       
        public Discipline(string name, string commentary = DefaultCommentary)
        {
            this.DisciplineName = name;
            this.Comment = commentary;
        }

        public Discipline(string name, int numberOfLectures, int numberOfExercises, string commentary = DefaultCommentary)
            : this(name, commentary)
        {
            this.NumberOfLectures = numberOfLectures;
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

        public string Comment
        { 
            get
            {
                return this.comment;
            }

            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentOutOfRangeException("The comment must be up to 200 characters!!!");
                }

                this.comment = value;
            }
        }

        public int NumberOfLectures 
        {
            get 
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("The number cannot be negative number!!!");
                }

                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("The number cannot be negative number!!!");
                }

                this.numberOfExercises = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Discipline name: {0}, Number of lectures: {1}, Number of exercises: {2}, Comment: {3}", this.DisciplineName, this.NumberOfLectures, this.NumberOfExercises, this.Comment);
        }
    }
}
