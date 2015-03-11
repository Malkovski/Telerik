namespace MobilePhones
{
    using System;
    using System.Text;

    public class Display
    {       
        private string displaySize;
        private long displayColors;

        public Display(string displaySize)
        {
            this.DisplaySize = displaySize;      
        }

        public Display(string displaySize, long displayColors) : this(displaySize)
        {
            this.DisplaySize = displaySize;
            this.DisplayColors = displayColors;
        }

        public string DisplaySize
        {
            get
            { 
                return this.displaySize;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Enter size!!!");
                }

                this.displaySize = value; 
            }
        }

        public long DisplayColors
        {
            get 
            {
                return this.displayColors;
            }

            set
            {
                int valueType = 0;

                if (int.TryParse(value.ToString(), out valueType) == false)
                {
                    throw new ArgumentException("Use only symbols from 0...9!");
                }
                else if (value.ToString().Length < 256 && value.ToString().Length > 19)
                {
                    throw new ArgumentException("Wrong color size range!");
                }

                this.displayColors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(string.Format("size: {0};", this.DisplaySize));
            info.Append(string.Format(" Dispaly colors: {0}", this.DisplayColors));

            return info.ToString();
        }           
    }
}
