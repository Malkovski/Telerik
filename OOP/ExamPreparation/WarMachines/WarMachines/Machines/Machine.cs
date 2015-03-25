namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;
    using WarMachines.Pilots;

    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.Pilot = pilot;
            this.HealthPoints = healthPoints;
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

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine("- " + this.Name);
            info.AppendLine("*Type: " + this.GetType().Name);
            info.AppendLine("*Health: " + this.HealthPoints);
            info.AppendLine("*Attack: " + this.AttackPoints);
            info.AppendLine("*Defense: " + this.DefensePoints);

            if (this.Targets.Count == 0)
            {
                info.AppendLine("*Targets: None");
            }
            else
            {
                info.AppendLine("*Targets: ");

                for (int i = 0; i < targets.Count; i++)
                {
                    info.Append(targets[i]);

                    if (i < targets.Count - 1)
                    {
                        info.Append(", ");
                    }
                }
            }
            
            return info.ToString();
        }
    }
}
