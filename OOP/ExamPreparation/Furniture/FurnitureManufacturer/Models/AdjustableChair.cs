namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;

    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal heigth, int numberOfLegs)
            : base(model, material, price, heigth, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (height < this.Height/2 || height > this.Height + 15)
            {
                throw new ArgumentOutOfRangeException("Heigth cannnot be adjusted to this level!");
            }

            this.Height = height;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
