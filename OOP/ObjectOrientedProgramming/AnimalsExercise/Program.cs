namespace AnimalsMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main()
        {
            Cat cat = new Cat("Maca", 3, Sex.Female);
            cat.MakeSound();
            Kitten kitten = new Kitten("Pissy", 1);
            kitten.MakeSound();
            Console.WriteLine(kitten.Sex);
            Tomcat tom = new Tomcat("Tom", 1);
            tom.MakeSound();
            Console.WriteLine(tom.Sex);
            Frog frog = new Frog("Kikirica", 5, Sex.Female);
            frog.MakeSound();
            Dog doggy = new Dog("Bobi", 7, Sex.Male);
            doggy.MakeSound();

            List<Animal> myAnimals = new List<Animal>();
            myAnimals.Add(cat);
            myAnimals.Add(kitten);
            myAnimals.Add(tom);
            myAnimals.Add(doggy);
            myAnimals.Add(frog);

            AverageAge(myAnimals);
        }

        public static void AverageAge(List<Animal> list)
        {
            var ages =
                from a in list
                select a.Age;

            double sum = 0;

            foreach (int item in ages)
            {
                sum += item;

            }

            Console.WriteLine(sum / ages.Count());
        }
    }
}
