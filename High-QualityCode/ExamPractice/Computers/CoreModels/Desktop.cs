namespace Computers.CoreModels
{
    using System;
    using System.Linq;
    using Computers.Interfaces;

    public class Desktop : Computer, IDesktop
    {
        private const int MinPlayRange = 1;
        private const int MaxPlayRange = 10;
        private const string LoseMessage = "You didn't guess the number {0}.";
        private const string WinMessage = "You win!";

        private readonly IExtendedMotherboard board;

        public Desktop(IExtendedMotherboard board) 
        {
            this.board = board;
        }

        public override void Play(int guessNumber)
        {
            int randomNumber = this.board.GetRandomValue(MinPlayRange, MaxPlayRange);

            this.board.SaveToRam(randomNumber);

            int number = this.board.LoadFromRam();

            if (number != guessNumber)
            {
                this.board.DisplayMessage(string.Format(LoseMessage, number));
            }
            else
            {
                this.board.DisplayMessage(WinMessage);
            }
        }
    }
}