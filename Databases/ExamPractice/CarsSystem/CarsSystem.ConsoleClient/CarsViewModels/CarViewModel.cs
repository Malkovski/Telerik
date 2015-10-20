namespace CarsSystem.ConsoleClient.CarsViewModels
{
    using System;
    using System.Linq;

    public class CarViewModel
    {
        public int Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerViewModel Dealer { get; set; }
    }
}