namespace Computers.Components
{
    using System;
    using System.Linq;
    using Computers.Interfaces;

    internal class MonochromeVideoCard : IVideoCard
    {
        public void Draw(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}