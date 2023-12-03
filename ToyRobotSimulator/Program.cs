using ToyRobotSimulator.Common.Helper;
using ToyRobotSimulator.Core;
using ToyRobotSimulator.Service;

namespace ToyRobotSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;

            var handler = new CommandHandler(new Robot());

            while (run)
            {
                try
                {
                    handler.HandleCommand(Helpers.GetArrayFromSplitInput(Console.ReadLine()));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input: " + e.Message);
                }
            }
        }
    }
}
