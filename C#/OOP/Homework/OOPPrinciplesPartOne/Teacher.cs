namespace OOPPrinciplesPartOne
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : People
    {
        private List<Discipline> setOfDisciplines;

        public Teacher(string name, string commentary) : base(name,  commentary)
        {
        }

        public Teacher(string name, string commentary, List<Discipline> list) : base(name, commentary)
        {
            this.SetOfDisciplines = list;
        }

        public List<Discipline> SetOfDisciplines
        {
            get
            {
                return this.setOfDisciplines;
            }

            set
            {
                this.setOfDisciplines = value;
            } 
        }

        public void AddDiscipline(Discipline uselessStudent)
        {
            this.SetOfDisciplines.Add(uselessStudent);
        }

        public void RemoveDiscipline(Discipline uselessDiscipline)
        {
            this.SetOfDisciplines.Remove(uselessDiscipline);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine(this.Name);
            info.AppendLine(this.Comment);
            info.AppendLine("Disciplines:");

            foreach (Discipline d in this.SetOfDisciplines)
            {
                info.AppendLine(d.ToString());
            }

            return info.ToString();
        }
    }
}   