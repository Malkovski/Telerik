namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets = new List<string>();

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.Pilot = pilot;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
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

            set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            set
            {
                this.defensePoints = value;
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
            info.AppendLine(" *Type: " + this.GetType().Name);
            info.AppendLine(" *Health: " + this.HealthPoints);
            info.AppendLine(" *Attack: " + this.AttackPoints);
            info.AppendLine(" *Defense: " + this.DefensePoints);

            if (this.Targets.Count == 0)
            {
                info.Append(" *Targets: None");
            }
            else
            {      
                string givenTragets = string.Empty;

                for (int i = 0; i < targets.Count; i++)
                {
                    givenTragets += targets[i];

                    if (i < targets.Count - 1)
                    {
                        givenTragets += ", ";
                    }
                }

                info.AppendLine(" *Targets: " + givenTragets);
            }
            
            return info.ToString();
        }
    }
}
