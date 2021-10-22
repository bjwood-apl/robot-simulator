using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic
{
    public class Simulator
    {
        Robot robot;
        internal enum RelativeDirection
        {
            LEFT,
            RIGHT
        }

        public Simulator()
        {
            robot = new();
        }

        public string ProcessInput(string input)
        {
            string[] splitInput = input.Split(' ');
            string command = splitInput[0];
            switch (command.ToUpper())
            {
                case "PLACE":
                    // Check that we actually have args before splitting
                    if (splitInput.Length < 2)
                        throw new ArgumentException("Invalid command, please use the format: PLACE X,Y,DIRECTION");

                    // We have already split on the space, so this takes the second half and splits on the commas
                    string[] args = splitInput[1].Split(',');
                    if (args.Length == 2 || args.Length == 3)
                        robot.Place(args);
                    else
                        throw new ArgumentException("Invalid command, please use the format: PLACE X,Y,DIRECTION");
                    break;

                case "MOVE":
                    robot.Move();
                    break;

                case "LEFT":
                    robot.Rotate(RelativeDirection.LEFT);
                    break;

                case "RIGHT":
                    robot.Rotate(RelativeDirection.RIGHT);
                    break;

                case "REPORT":
                    return robot.GetReport();

                default:
                    throw new ArgumentException($"Unrecognised command: {command}");
            }
            return null;
        }


    }
}
