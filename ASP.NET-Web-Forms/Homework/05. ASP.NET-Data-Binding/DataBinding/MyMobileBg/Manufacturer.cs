namespace MyMobileBg
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Models = new HashSet<Model>();
        }

        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}