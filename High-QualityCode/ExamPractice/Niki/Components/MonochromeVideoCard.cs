using Computers.Interfaces;
using System;
using System.Linq;
using C = System.Console;

namespace Computers.Components
{
    internal class MonochromeVideoCard : IVideoCard
    {
        public void Draw(string message)
        {
            C.ForegroundColor = ConsoleColor.Gray;
            C.WriteLine(message);
            C.ResetColor();
        }
    }
}