namespace Continents.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }
    }
}