namespace AnimalsMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Sex sex) : base(name, age, sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Kwakk");
        }
    }
}
