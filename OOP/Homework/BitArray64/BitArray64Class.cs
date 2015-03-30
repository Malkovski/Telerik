namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64Class : IEnumerable<int>
    {
        public BitArray64Class(ulong number = 0)
        {
            this.Number = number;
        }

        public ulong Number { get; set; }

        public override bool Equals(object obj)
        {
            var temp = obj as BitArray64Class;

            if (temp == null)
            {
                return false;
            }

            if (this.Number != temp.Number)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        public static bool operator ==(BitArray64Class first, BitArray64Class second)
        {
            return BitArray64Class.Equals(first, second);
        }

        public static bool operator !=(BitArray64Class first, BitArray64Class second)
        {
            return !BitArray64Class.Equals(first, second);
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("Index out of the possible range!!!");
                }

                int mask = 1 << index;
                int result = (int)(this.Number & (ulong)mask);
                return result >> index;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
