namespace OOPPrinciplesPartOne
{
    using System;
    using System.Collections.Generic;

    public class Teacher : People, IComment
    {
        private List<Discipline> setOfDisciplines;

        public List<Discipline>  SetOfDisciplines { get; set; }

        public void Comment(string input)
        {
            Console.WriteLine(input);
        }
    }
}
        