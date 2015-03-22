namespace AnimalsMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tomcat : Cat
    {
        private const Sex ConstSex = Sex.Male;

        public Tomcat(string name, int age) : base(name, age, ConstSex)
        {
        }
    }
}
