
namespace CohesionAndCoupling
{
    using System;

    private static class Utils
    {
        internal static double Width { get; set; }

        internal static double Height { get; set; }

        internal static double Depth { get; set; }

        internal static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        internal static double CalcDiagonalXYZ()
        {
            double distance = Distance.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        internal static double CalcDiagonalXY()
        {
            double distance = Distance.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        internal static double CalcDiagonalXZ()
        {
            double distance = Distance.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        internal static double CalcDiagonalYZ()
        {
            double distance = Distance.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}