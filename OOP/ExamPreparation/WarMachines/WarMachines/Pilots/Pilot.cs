namespace WarMachines.Pilots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machineList;

        public Pilot(string name)
        {
            this.Name = name;
            this.MachineList = new List<IMachine>();
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

        public List<IMachine> MachineList { get; set; }

        public void AddMachine(IMachine machine)
        {
            this.MachineList.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            if (this.MachineList.Count == 0)
            {
                 report.AppendLine(string.Format("{0} - no machines", this.Name));
                 return report.ToString();
            }
            else if (this.MachineList.Count == 1)
            {
                report.AppendLine(string.Format("{0} - 1 machine", this.Name)); 
            }
            else
            {
                report.AppendLine(string.Format("{0} - {1} machines", this.Name, this.MachineList.Count));
            }

            var sortedMachines = machineList.OrderByDescending(h => h.HealthPoints).ThenBy(n => n.Name);

            foreach (Machine m in sortedMachines)
            {
                this.ToString();
            }

            return report.ToString();
        }
    }
}
