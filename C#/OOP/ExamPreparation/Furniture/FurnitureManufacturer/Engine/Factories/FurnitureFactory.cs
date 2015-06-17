namespace FurnitureManufacturer.Engine.Factories
{
    using System;
    using Interfaces;
    using Interfaces.Engine;
    using Models;
    using System.Collections.Generic;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        private readonly IList<string> tables = new List<string>();
        private readonly IList<string> chairs = new List<string>();
        private readonly IList<string> adjustibleChairs = new List<string>();
        private readonly IList<string> convertibleChairs = new List<string>();


        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            if (!tables.Contains(model))
            {
                var table = new Table(model, materialType, price, height, length, width);
                tables.Add(model);
                return table;
            }
            else
            {
                throw new ArgumentException("Model already exists!!!");
            }
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            if (!chairs.Contains(model))
            {
                var chair =  new Chair(model, materialType, price, height, numberOfLegs);
                chairs.Add(model);
                return chair;
            }
            else
            {
                throw new ArgumentException("Model already exists!!!");
            }
            
        }

        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            if (!adjustibleChairs.Contains(model))
            {
               var adjChair = new AdjustableChair(model, materialType, price, height, numberOfLegs);
               adjustibleChairs.Add(model);
               return adjChair;
            }
            else
            {
                throw new ArgumentException("Model already exists!!!");
            }
        }
            

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            if (!convertibleChairs.Contains(model))
            {
                var converChair =  new ConvertibleChair(model, materialType, price, height, numberOfLegs);
                convertibleChairs.Add(model);
                return converChair;
            }
            else
            {
                throw new ArgumentException("Model already exists!!!");
            }         
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }
    }
}
