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

        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, InitialHealth, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
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
            this.defenseMode = !defenseMode;

            if (this.defenseMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }        
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(base.ToString());

            if (this.defenseMode)
            {
                info.AppendLine(" *Defence: ON");
            }
            else
            {
                info.AppendLine(" *Defence: OFF");
            }

            
            return info.ToString();
        }
    }
}
