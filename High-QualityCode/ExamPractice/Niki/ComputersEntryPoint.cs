﻿namespace Computers
{
    using System;
    using CoreModels;
    using Factory;

    public class ComputersEntryPoint
    {
        private static ComputerFactory factory;

        private static Computer pc, laptop, server;

        public static void Main()
        {
            string manufacturer = Console.ReadLine();
            
            if (manufacturer == "HP")
            {
                factory = new HpComputers();
            }
            else if (manufacturer == "Dell")
            {
                factory = new DellComputers();
            }
            else if (manufacturer == "Lenovo")
            {
                factory = new LenovoComputers();
            }
            else
            {
                Console.WriteLine("Invalid manufacturer!");
            }

            laptop = factory.ManufactureLaptop();
            server = factory.ManufactureServer();
            pc = factory.ManufacturePC();

            while (true)
            {
                string command = Console.ReadLine();
                string[] commandParts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (command == null)
                {
                    return;
                }

                if (command.StartsWith("Exit"))
                {
                    return;
                }

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
            }
        }
    }
}