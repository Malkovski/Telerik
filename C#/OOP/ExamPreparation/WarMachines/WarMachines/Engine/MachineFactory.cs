namespace WarMachines.Engine
{
    using System;
    using System.Collections.Generic;
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        List<string> currentNames = new List<string>();

        public void CheckDuplicateNames(string name)
        {
            if (currentNames.Contains(name))
            {
                throw new ArgumentException("This name is already used!!!");
            }
        }

        public IPilot HirePilot(string name)
        {
            CheckDuplicateNames(name);
            currentNames.Add(name); 
            return new Pilot(name);
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            CheckDuplicateNames(name);
            currentNames.Add(name);
            return new Tank(name, attackPoints, defensePoints);
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            CheckDuplicateNames(name);
            currentNames.Add(name);
            return new Fighter(name, attackPoints, defensePoints, stealthMode);
        }
    }
}
