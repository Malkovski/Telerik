namespace Computers.Interfaces
{
    using System;
    using System.Linq;

    public interface IMotherboard
    {
        void SaveToRam(int newValue);

        int LoadFromRam();

        void DisplayMessage(string message);
    }
}