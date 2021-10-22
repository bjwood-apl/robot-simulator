using System;
using SimulatorLogic;

namespace RobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator simulator = new();
            while (true)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();
                if (command.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                    break;
                try
                {
                    string output = simulator.ProcessInput(command);
                    if (!string.IsNullOrEmpty(output))
                        Console.WriteLine(output);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " +  ex.Message);
                }
            }
        }
    }
}
