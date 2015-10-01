namespace Computers.Components
{
    using System;
    using System.Linq;
    using Computers.Interfaces;

    internal class ColorfulVideoCard : IVideoCard
    {
        public void Draw(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}