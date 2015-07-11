//Refactor the following class using best practices for organizing straight-line code:

//public class Chef
//{
//    private Bowl GetBowl()
//    {   
//        //... 
//    }
//    private Carrot GetCarrot()
//    {
//        //...
//    }
//    private void Cut(Vegetable potato)
//    {
//        //...
//    }  
//    public void Cook()
//    {
//        Potato potato = GetPotato();
//        Carrot carrot = GetCarrot();
//        Bowl bowl;
//        Peel(potato);

//        Peel(carrot);
//        bowl = GetBowl();
//        Cut(potato);
//        Cut(carrot);
//        bowl.Add(carrot);

//        bowl.Add(potato);
//    }
//    private Potato GetPotato()
//    {
//        //...
//    }
//}

namespace RefactorCalssStatementsLoops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            Bowl bowl = this.GetBowl();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Potato GetPotato()
        {
            //...
        }

        private Carrot GetCarrot()
        {
            //...
        }

        private Bowl GetBowl()
        {
            return new Bowl(); 
        }

        private void Cut(Vegetable vegetable)
        {
            //...
        }

        private void Peel(Vegetable vegetable)
        {
            // ...
        }
    }

    public class Vegetable
    {

    }

    public class Potato : Vegetable
    {

    }

    public class Carrot : Vegetable
    {

    }

    public class Bowl 
    {
       
    }
}
