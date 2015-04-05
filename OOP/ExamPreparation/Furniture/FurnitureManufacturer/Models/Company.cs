namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures = new List<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty!!!");  
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Name must be at least 5 symbols!!!");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Registration number cannot be empty!!!");
                }

                if (value.Length != 10)
                {
                    throw new ArgumentException("Registration number must be exactly 10 digits!!!");
                }

                foreach (char ch in value)
                {
                    if (!char.IsDigit(ch))
                    {
                        throw new ArgumentException("Registration number must contain only digis!!!");
                    }
                }  
 
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }

            protected set
            {
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            var foundModel = furnitures.Where(x => x.Model.ToLower().Contains(model.ToLower())).ToList();

            if (foundModel.Count != 0)
            {
                return foundModel[0];
            }
            return null;
        }

        public string Catalog()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine(this.ToString());

            foreach (var item in this.furnitures.OrderBy(x => x.Price).ThenBy(i => i.Model))
            {
                info.AppendLine(item.ToString());
            }

            return info.ToString();
        }

        public override string ToString()
        {
            string  result = string.Format("{0} - {1} - {2} {3}",
            this.Name,
            this.RegistrationNumber,
            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
            this.Furnitures.Count != 1 ? "furnitures" : "furniture"
            );

            return result;
        }
    }
}
