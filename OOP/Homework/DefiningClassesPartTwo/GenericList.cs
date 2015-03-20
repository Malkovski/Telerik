namespace DefiningClassesPartTwo
{
    using System;
    using System.Text;

    public class GenericList<T> 
        where T : IComparable, new()
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int count;
        private int capacity;

        public GenericList() : this(DefaultCapacity)
        {           
        }

        public GenericList(int capacity)
        {
            this.items = new T[capacity];
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                int temp = 0;

                if (!int.TryParse(value.ToString(), out temp) || int.Parse(value.ToString()) < 0)
                {
                    throw new ArgumentException("Capacity must be positive number");
                }

                this.capacity = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T elementToAdd)
        {
            if (this.Count == this.Capacity)
            {
                AutoGrow();
            }

            this.items[count] = elementToAdd;
            count++;
        }

        public void AutoGrow()
        {
            T[] increased = new T[this.Capacity * 2];
            this.items.CopyTo(increased, 0);
            this.items = increased;
            this.Capacity = increased.Length;
           
        }

        public void Clear()
        {
            this.items = new T[DefaultCapacity];
            this.count = 0;
            this.Capacity = DefaultCapacity;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Index out of range!");
                }

                T result = items[index];
                return result;
            }         
        }

        public void RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }

            T[] result = new T[Capacity];

            if (index == 0)
            {
                for (int i = 1; i < Count; i++)
                {
                    result[i - 1] = this.items[i];
                }
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    result[i] = this.items[i];
                }

                for (int i = index + 1; i < Count; i++)
                {
                    result[i - 1] = this.items[i];
                }
            }
            
            count--;
            this.items = result;
        }

        public void Insert(T element, int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }

            if (Count + 1 > Capacity)
            {
                AutoGrow();
            }

            T[] result = new T[Capacity];

            if (index == 0)
            {
                result[index] = element;

                for (int i = 0; i < Count; i++)
                {
                    result[i + 1] = this.items[i];
                }
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    result[i] = this.items[i];
                }

                result[index] = element;

                for (int i = index; i < Count; i++)
                {
                    result[i + 1] = this.items[i];
                }
            }

            count++;
            this.items = result;
        }

        public int IndexOf(T searched)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (searched.CompareTo(this.items[i]) == 0)
                {
                    searched = this.items[i];
                    return i;         
                }
            }

            return -1;
        }

        public T Max()
        {
            T maxT = this.items[0];

            for (int i = 0; i < Count; i++)
            {
                if (this.items[i].CompareTo(maxT) > 0)
                {
                    maxT = this.items[i];
                }
            }

            return maxT;
        }

        public T Min()
        {
            T minT = this.items[0];

            for (int i = 0; i < Count; i++)
            {
                if (this.items[i].CompareTo(minT) < 0)
                {
                    minT = this.items[i];
                }
            }

            return minT;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                info.Append(this.items[i]);

                if (i < Count - 1)
                {
                    info.Append(", ");
                }
            }
            
            return info.ToString();
        }
    }
}
