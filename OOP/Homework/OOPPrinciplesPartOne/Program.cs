namespace OOPPrinciplesPartOne
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            Student pepi = new Student("tttt", 66);
           // pepi.Name = "Pepe";
            Console.WriteLine(pepi.Name);
            //Console.WriteLine(pepi.ClassNumber);
            //Discipline dis = new Discipline("Math", 5, 5);
           
           //Console.WriteLine(dis.DisciplineName);
        }
    }
}
