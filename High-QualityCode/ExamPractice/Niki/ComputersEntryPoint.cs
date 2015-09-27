using System;
using System.Collections.Generic;
using Computers.Factory;

namespace Computers
{
    internal class ComputersEntryPoint
    {
        private static Factory.Computer pc, laptop, server;

        public static void Main()
        {
            string manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                //var ram = new Rammstein(Eight / 4);
                //var videoCard = new HardDriver() { IsMonochrome = false };
                //pc = new Computer(Computers.Type.PC, new Cpu(Eight / 4, 32, ram, videoCard), ram, new[] { new HardDriver(500, false, 0) }, videoCard, null);

                //var serverRam = new Rammstein(Eight * 4);
                //var serverVideo = new HardDriver();
                //server = new Computer(
                //    Computers.Type.SERVER,
                //    new Cpu(Eight / 2,
                //        32, serverRam, serverVideo),
                //    serverRam,
                //    new List<HardDriver>
                //    {
                //        new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(1000, false, 0), new HardDriver(1000, false, 0) })
                //    },
                //    serverVideo, null);
                //{
                //    var card = new HardDriver()
                //    {
                //        IsMonochrome = false
                //    };
                //    var ram1 = new Rammstein(Eight / 2);
                //    laptop = new Computer(
                //        Computers.Type.LAPTOP,
                //        new Cpu(Eight / 4, 64, ram1, card),
                //        ram1,
                //        new[]
                //        {
                //            new HardDriver(500,
                //                false, 0)
                //        },
                //        card,
                //        new LaptopBattery());
                //}
            }
            else if (manufacturer == "Dell")
            {
                pc = new DellPC();
                laptop = new DellLaptop();
                server = new DellServer();

                //var ram = new Rammstein(Eight);
                //var videoCard = new HardDriver() { IsMonochrome = false };
                //pc = new Computer(Computers.Type.PC, new Cpu(Eight / 2, 64, ram, videoCard), ram, new[] { new HardDriver(1000, false, 0) }, videoCard, null);
                //var ram1 = new Rammstein(Eight * Eight);
                //var card = new HardDriver();
                //server = new Computer(Computers.Type.SERVER,
                //    new Cpu(Eight, 64, ram1, card),
                //    ram1,
                //    new List<HardDriver>
                //    {
                //        new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(2000, false, 0), new HardDriver(2000, false, 0) })
                //    }, card, null);
                //var ram2 = new Rammstein(Eight);
                //var videoCard1 = new HardDriver() { IsMonochrome = false };
                //laptop = new Computer(Computers.Type.LAPTOP,
                //    new Cpu(Eight / 2, ((32)), ram2, videoCard1),
                //    ram2,
                //    new[] { new HardDriver(1000, false, 0) },
                //    videoCard1,
                //    new LaptopBattery());
            }
            else
            {
                Console.WriteLine("Invalid manufacturer!");
            }


            while (true)
            {
                string command = Console.ReadLine();
                string[] commandParts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandParts.Length != 2)
                {
                    {
                        Console.WriteLine("Invalid command!");
                    }
                }

                string commandName = commandParts[0];
                int commandAttribute = int.Parse(commandParts[1]);

                if (commandName == "Charge")
                {
                    laptop.Charge(commandAttribute);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandAttribute);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandAttribute);
                }
               

                if (command == null)
                {
                    return;
                }
                if (command.StartsWith("Exit"))
                {
                    return;
                }
            }
        }

        //public class InvalidArgumentException : ArgumentException
        //{
        //    public InvalidArgumentException(string message) : base(message)
        //    {
        //    }
        //}
    }
}