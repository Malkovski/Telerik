namespace Continents.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;


    public class Continent
    {
        private ICollection<Country> countries;

        public Continent()
        {
            this.countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Country> Countries
        {
            get
            {
                return this.countries;
            }

            set
            {
                this.countries = value;
            }
        }
    }
}