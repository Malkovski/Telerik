using Computers.Interfaces;
using System;
using System.Linq;
using C = System.Console;

namespace Computers.Components
{
    internal class ColorfulVideoCard : IVideoCard
    {
        public void Draw(string message)
        {
            C.ForegroundColor = ConsoleColor.Green;
            C.WriteLine(message);
            C.ResetColor();
        }
    }
}