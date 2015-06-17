namespace DefiningClassesPartTwo
{
    using System;

    public struct Point3D
    {
        private static readonly Point3D O;
        private double x;
        private double y;
        private double z;

        static Point3D()
        {
            O = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                double parser = 0d;

                if (!double.TryParse(value.ToString(), out parser))
                {
                    throw new ArgumentException("The coordinate must be number!");
                }

                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                double parser = 0d;

                if (!double.TryParse(value.ToString(), out parser))
                {
                    throw new ArgumentException("The coordinate must be number!");
                }

                this.y = value;
            }
        }

        public double Z
        {
            get
            {
                return this.z;
            }

            set
            {
                double parser = 0d;

                if (!double.TryParse(value.ToString(), out parser))
                {
                    throw new ArgumentException("The coordinate must be number!");
                }

                this.z = value;
            }
        }

        public override string ToString()
        {

            return string.Format("X coordinate is:{0}, Y coordinate is:{1}, Z coordinate is:{2}", this.X, this.Y, this.Z);
        }

        public static Point3D Parse(string fileData)
        {
            string[] coordinateParts = fileData.Split(',');
            double[] coords = new double[3];

            for (int i = 0; i < coordinateParts.Length; i++)
            {
                coords[i] = double.Parse(coordinateParts[i].Substring(coordinateParts[i].LastIndexOf(':') + 1));
            }

            return new Point3D(coords[0], coords[1], coords[2]);
        }
    }
}
