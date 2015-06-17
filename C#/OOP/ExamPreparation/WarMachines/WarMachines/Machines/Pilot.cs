namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machineList = new List<IMachine>();

        public Pilot(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public List<IMachine> MachineList
        {
            get
            {
                return this.machineList;
            }          
        }

        public void AddMachine(IMachine machine)
        {
            this.machineList.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            if (this.machineList.Count == 0)
            {
                 report.Append(string.Format("{0} - no machines", this.Name));
            }
            else if (this.MachineList.Count == 1)
            {
                report.AppendLine(string.Format("{0} - 1 machine", this.Name)); 
            }
            else
            {
                report.AppendLine(string.Format("{0} - {1} machines", this.Name, this.MachineList.Count));
            }

            var sortedMachines = machineList.OrderBy(h => h.HealthPoints).ThenBy(n => n.Name);
          
            foreach (Machine m in sortedMachines)
            {
                report.Append(m.ToString());
            }

            return report.ToString();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
