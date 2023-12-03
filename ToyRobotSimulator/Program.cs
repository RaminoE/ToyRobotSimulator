using ToyRobotSimulator.Common.Helper;
using ToyRobotSimulator.Core;
using ToyRobotSimulator.Service;

namespace ToyRobotSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START THE ROBOT SIMULATOR ");
            bool run = true;

            var handler = new CommandHandler(new Robot());

            while (run)
            {
                try
                {
                    var data = (Helpers.GetArrayFromSplitInput(Console.ReadLine()));
                    if (data.Length > 4)
                        throw new Exception("Invalid Command");

                    handler.HandleCommand(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input: " + e.Message);
                }
            }
        }
    }
}
