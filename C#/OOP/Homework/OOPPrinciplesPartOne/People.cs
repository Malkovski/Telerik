namespace OOPPrinciplesPartOne
{
    using System;

    public abstract class People
    {
        private const string DefaultCommentary = "";

        private string name;
        private string comment;

        public People(string name, string commentary = DefaultCommentary)
        {
            this.Name = name;
            this.Comment = commentary;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length <= 1)
                {
                    throw new ArgumentException("Name too short!!!");
                }

                foreach (char ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("Name must contain ONLY letters!!!");
                    }
                }

                this.name = value;
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
    }
}
