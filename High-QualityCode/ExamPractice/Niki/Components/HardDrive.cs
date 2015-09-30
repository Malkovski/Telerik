namespace Computers.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Computers.Interfaces;

    internal class HardDrive : IHardDrive
    {
        private readonly bool isInRaid;

        private readonly int hardDrivesInRaid;

        private readonly List<HardDrive> hds;
        private readonly int capacity;
        private readonly Dictionary<int, string> data;

        internal HardDrive()
        {
        }

        internal HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;

            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);

            this.hds = new List<HardDrive>();
        }

        internal HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDrive> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);
            this.hds = hardDrives;
        }

        public int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hds.Any())
                    {
                        return 0;
                    }

                    return this.hds.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }
    }
}