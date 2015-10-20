namespace CarsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
