﻿namespace Computers.Components
{
    using System;
    using Computers.Interfaces;

    public class Cpu32 : ICpu
    {
        private readonly Random random = new Random();

        public Cpu32(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; set; }
     
        public string SquareNumber(int data)
        {
            if (data < 0)
            {
                return "Number too low.";
            }
            else if (data > 500)
            {
                return "Number too high.";
            }
            else
            {
                double value = Math.Pow(data, 2);
                
                return string.Format("Square of {0} is {1}.", data, value);
            }
        }

        public int GetRandomValue(int a, int b)
        {
            return this.random.Next(a, b);
        }
    }
}
