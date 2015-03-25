namespace RangeException
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T value, T minValue, T maxValue)
            : base(message)
        {
            this.Value = value;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public T Value { get; private set; }
        public T MinValue { get; private set; }
        public T MaxValue { get; private set; }

    }
}
