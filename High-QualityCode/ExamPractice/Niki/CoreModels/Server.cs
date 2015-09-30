namespace Computers.CoreModels
{
    using System;
    using System.Linq;
    using Computers.Components;

    public class Server : Computer
    {
        private readonly Motherboard board;

        public Server(Motherboard board)
        {
            this.board = board;
        }

        public override void Process(int data)
        {
            this.board.Process(data);
        }
    }
}