namespace Computers.CoreModels
{
    using System;
    using System.Linq;
    using Computers.Components;

    public class PC : Computer
    {
        private readonly Motherboard board;

        public PC(Motherboard board) 
        {
            this.board = board;
        }

        public override void Play(int guessNumber)
        {
            this.board.Play(guessNumber);
        }
    }
}