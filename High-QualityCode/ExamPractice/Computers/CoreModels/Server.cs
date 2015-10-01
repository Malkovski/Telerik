namespace Computers.CoreModels
{
    using System;
    using System.Linq;
    using Computers.Interfaces;

    public class Server : Computer, IServer
    {
        private readonly IExtendedMotherboard board;

        public Server(IExtendedMotherboard board)
        {
            this.board = board;
        }

        public override void Process(int data)
        {
            var result = this.board.SquareNumber(data);
            this.board.DisplayMessage(result);
        }
    }
}