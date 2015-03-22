namespace AnimalsMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Kitten : Cat
    {
        private const Sex ConstSex = Sex.Female;
        public Kitten(string name, int age) : base(name, age, ConstSex)
        {
        }
    }
}
