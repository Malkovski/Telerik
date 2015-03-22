namespace AnimalsMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Sex sex) : base(name, age, sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Bau-Bau");
        }
    }
}
