namespace OOPPrinciplesPartOne
{
    using System;

    public  class People
    {
        private string name;

        public People()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                //if (value.Length <= 1)
                //{
                //    throw new ArgumentException("Name too short!!!");
                //}

                //foreach (char ch in value)
                //{
                //    if (!char.IsLetter(ch))
                //    {
                //        throw new ArgumentException("Name must contain ONLY letters!!!");
                //    }
                //}

                this.name = value;
            }
        }
    }
}
