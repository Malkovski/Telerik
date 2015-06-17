namespace AnimalsMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cat : Animal, ISound
    {
        public Cat(string name, int age, Sex sex) : base(name, age, sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Meaw");
        }
    }
}
