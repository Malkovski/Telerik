namespace Computers.CoreModels
{
    using System;
    using System.Linq;
    using Computers.Components;

    public class Laptop : Computer
    {
        private readonly Motherboard board;
        
        public Laptop(Motherboard board)         
        {
            this.board = board;
        }

        public override void Charge(int percent)
        {
            this.board.Charge(percent);
        }
    }
}