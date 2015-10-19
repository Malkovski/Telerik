namespace CarsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Dealer
    {
        private ICollection<Car> cars;
        private ICollection<City> cities;

        public Dealer()
        {
            this.cars = new HashSet<Car>();
            this.cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities 
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}