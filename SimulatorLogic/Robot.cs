using System;
using static SimulatorLogic.Simulator;

namespace SimulatorLogic
{
    internal class Robot
    {
        private int x;
        private int y;
        private CardinalDirection orientation;

        public Robot()
        {
            x = -1;
            y = -1;
            orientation = null;
        }

        internal void Place(string[] args)
        {
            if (args.Length == 2 && orientation == null)
            {
                // No orientation provided, this is only ok if we have already been placed
                throw new ArgumentException("Please provide an orientation.");
            }
                
            int desiredX = int.Parse(args[0]);
            int desiredY = int.Parse(args[1]);
            if (Board.IsValidCoordinate(desiredX, desiredY))
            {
                x = desiredX;
                y = desiredY;
                if (args.Length > 2)
                    orientation = new CardinalDirection(args[2]);
            }
            else
            {
                throw new ArgumentException("Invalid location.");
            }
        }

        internal void Move()
        {
            if (!IsReady())
                return;

            (int newX, int newY) = GetNextCoordinate();
            if (Board.IsValidCoordinate(newX, newY))
            {
                x = newX;
                y = newY;
            }
            else
            {
                throw new ArgumentException("Invalid move.");
            }
        }

        internal void Rotate(Simulator.RelativeDirection direction)
        {
            if (!IsReady())
                return;

            // The CardinalDirection constructor takes care of bounds checks (0 to 270)
            if (direction == RelativeDirection.LEFT)
                orientation = new CardinalDirection(orientation.Degrees - 90);
            else if (direction == RelativeDirection.RIGHT)
                orientation = new CardinalDirection(orientation.Degrees + 90);

        }

        internal string GetReport()
        {
            return $"{x},{y},{orientation.Name}";
        }

        private bool IsReady()
        {
            return (x != -1 && y != -1 && orientation != null);
        }

        private Tuple<int, int> GetNextCoordinate()
        {
            return orientation.Name switch
            {
                "NORTH" => Tuple.Create(x, y + 1),
                "EAST" => Tuple.Create(x + 1, y),
                "SOUTH" => Tuple.Create(x, y - 1),
                "WEST" => Tuple.Create(x - 1, y),
                _ => throw new InvalidOperationException("Orientation is not NORTH, SOUTH, EAST or WEST"),
            };
        }
    }
}
