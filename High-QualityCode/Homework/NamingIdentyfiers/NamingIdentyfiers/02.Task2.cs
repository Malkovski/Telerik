// Task 2. Make_Чуек in C#
   
// Refactor the following examples to produce code with well-named C# identifiers.
   
// class Hauptklasse
// {
//   enum Пол { ултра_Батка, Яка_Мацка };
//   class чуек
//   {
//     public Пол пол { get; set; }
//     public string име_на_Чуека { get; set; }
//     public int Възраст { get; set; }
//   }       
//   public void Make_Чуек(int магическия_НомерНаЕДИНЧОВЕК)
//   {
//     чуек new_Чуек = new чуек();
//     new_Чуек.Възраст = магическия_НомерНаЕДИНЧОВЕК;
//     if (магическия_НомерНаЕДИНЧОВЕК%2 == 0)
//     {
//       new_Чуек.име_на_Чуека = "Батката";
//       new_Чуек.пол = Пол.ултра_Батка;
//     }
//     else
//     {
//       new_Чуек.име_на_Чуека = "Мацето";
//       new_Чуек.пол = Пол.Яка_Мацка;
//     }
//   }
// }

namespace NamingIdentyfiers
{
    public class PersonCreator
    {
        public enum Gender 
        { 
            ултра_Батка,
            Яка_Мацка 
        }

        public void CreatePerson(int age)
        {
            Person currentPerson = new Person();
            currentPerson.Age = age;

            if (age % 2 == 0)
            {
                currentPerson.Name = "Батката";
                currentPerson.Gender = Gender.ултра_Батка;
            }
            else
            {
                currentPerson.Name = "Мацето";
                currentPerson.Gender = Gender.Яка_Мацка;
            }
        }

        public class Person
        {
            public Gender Gender { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
