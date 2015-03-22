namespace MobilePhones
{
    using System;
    using System.Text;

    public class Battery
    {
        private string batteryModel;
        private int idleHours;
        private int talkHours;

        public Battery()
        {
            this.BatteryModel = "Unknown";
            this.IdleHours = 10;
            this.TalkHours = 5;
            this.Type = BatteryType.NiMH;
        }

        public Battery(string batteryModel)
        {
            this.BatteryModel = batteryModel;         
        }

        public Battery(string batteryModel, int idleHours, int talkHours) : this(batteryModel)
        {
            this.IdleHours = idleHours;
            this.TalkHours = talkHours;
        }

        public Battery(string batteryModel, int idleHours, int talkHours, BatteryType type)
            : this(batteryModel, idleHours, talkHours)
        {
            this.Type = type;
        }

        public string BatteryModel
        {
            get
            { 
                return this.batteryModel; 
            }   
   
            set 
            {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Enter battery model!!!");
                    }

                this.batteryModel = value; 
            }
        }

        public int IdleHours
        { 
            get
            { 
                return this.idleHours; 
            }

            set
            {
                int valueType = 0;

                if (!int.TryParse(value.ToString(), out valueType))
                {
                    throw new ArgumentException("Use only symbols from 0...9!");
                }
                else if (int.Parse(value.ToString()) < 0)
                {
                    throw new ArgumentException("Data must be positive number!!!");
                }

                this.idleHours = value; 
            }
        }

        public int TalkHours
        {
            get
            { 
                return this.talkHours;
            }

            set
            {
                int valueType = 0;

                if (!int.TryParse(value.ToString(), out valueType))
                {
                    throw new ArgumentException("Use only symbols from 0...9!");
                }
                else if (int.Parse(value.ToString()) < 0)
                {
                    throw new ArgumentException("Data must be positive number!!!");
                }

                this.talkHours = value; 
            }
        }

        public BatteryType Type
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(string.Format("model: {0};", this.BatteryModel));
            info.Append(string.Format(" Idle hours: {0};", this.IdleHours));
            info.Append(string.Format(" Talk hours: {0};", this.TalkHours));
            info.Append(string.Format(" Type: {0}", this.Type));

            return info.ToString();
        }
    }
}
