namespace WarMachines.Engine
{
    using System.Collections.Generic;
    using WarMachines.Interfaces;
    using WarMachines.Machines;
    using WarMachines.Pilots;

    public class MachineFactory : IMachineFactory
    {
       // private IList<Machine> machineList;
       // private IList<Pilot> pilotList;

        public IPilot HirePilot(string name)
        {
            return new Pilot(name);
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            return new Tank(name, attackPoints, defensePoints);
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            return new Fighter(name, attackPoints, defensePoints, stealthMode);
        }
    }
}
