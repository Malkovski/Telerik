namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        private const double InitialHealth = 200;
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defencePoints, bool stealthMode)
            : base(name, InitialHealth, attackPoints, defencePoints)
        {
            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
        }

        public void ToggleStealthMode()
        {
            if (this.stealthMode)
            {
                this.stealthMode = false;
            }
            else
            {
                this.stealthMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(base.ToString());

            if (this.stealthMode)
            {
                info.Append(" *Stealth: ON");
            }
            else
            {
                info.Append(" *Stealth: OFF");
            }


            return info.ToString();
        }
    }
}
