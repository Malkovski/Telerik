namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const double InitialHealth = 100;
        private double defencePoints;
        private double attackPoints;
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, InitialHealth, attackPoints, defensePoints)
        {
            this.defenseMode = true;
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.defencePoints += 30;
                this.attackPoints -= 40;
            }
            else
            {
                this.defencePoints -= 30;
                this.attackPoints += 40;
            }        
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(base.ToString());
            info.AppendLine("*Defence: ");

            if (this.defenseMode)
            {
                info.Append("ON");
            }
            else
            {
                info.Append("OFF");
            }


            return info.ToString();
        }
    }
}
