using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic
{
    internal class CardinalDirection
    {
        internal int Degrees;
        internal string Name;

        internal CardinalDirection(int degrees)
        {
            // Wrap around so we hit 0 instead of 360 when adding directions, and vice versa for subtracting
            if (degrees < 0)
                degrees = 270;
            if (degrees > 270)
                degrees = 0;

            this.Degrees = degrees;
            this.Name = GetNameFromOrientation(degrees);
        }

        internal CardinalDirection(string name)
        {
            this.Name = name;
            this.Degrees = GetOrientationFromName(name);
        }

        private static int GetOrientationFromName(string dirName)
        {
            return dirName.ToUpper() switch
            {
                "NORTH" => 0,
                "EAST" => 90,
                "SOUTH" => 180,
                "WEST" => 270,
                _ => throw new InvalidOperationException("Orientation is not NORTH, SOUTH, EAST or WEST"),
            };
        }

        private static string GetNameFromOrientation(int orientation)
        {
            return orientation switch
            {
                0 => "NORTH",
                90 => "EAST",
                180 => "SOUTH",
                270 => "WEST",
                _ => throw new InvalidOperationException("Orientation is not NORTH, SOUTH, EAST or WEST"),
            };
        }
    }
}
