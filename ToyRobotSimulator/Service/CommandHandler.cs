using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Common;
using ToyRobotSimulator.Common.Helper;
using ToyRobotSimulator.CoreShared;
using ToyRobotSimulator.Model;
using ToyRobotSimulator.ServiceShared;

namespace ToyRobotSimulator.Service
{
    public class CommandHandler : ICommandHandler
    {
        private IRobot _rob;
        private bool _placeHasBeenExecuted = false;

        public CommandHandler(IRobot rob)
        {
            _rob = rob;
        }

        //Handles command. Requires valid placement to occur before executing any other command 
        public bool HandleCommand(string[] command)
        {
            if (command == null) { throw new ArgumentNullException("command is null"); }

            switch (command[0])
            {
                case DataConstants.PlaceName:
                    var placed = command.Length == 4 && _rob.Place(new PlacementRequestModel
                    {
                        X = Helpers.GetNumberFromString("" + command[1]),
                        Y = Helpers.GetNumberFromString(command[2]),
                        F = Helpers.GetDirectionFromString(command[3])
                    });

                    Helpers.RunCommandIfTrue(() => _placeHasBeenExecuted = placed, _placeHasBeenExecuted == false);
                    break;
                case DataConstants.MoveName:
                    Helpers.RunCommandIfTrue(() => _rob.Move(), _placeHasBeenExecuted);
                    break;
                case DataConstants.LeftName:
                    Helpers.RunCommandIfTrue(() => _rob.Left(), _placeHasBeenExecuted);
                    break;
                case DataConstants.RightName:
                    Helpers.RunCommandIfTrue(() => _rob.Right(), _placeHasBeenExecuted);
                    break;
                case DataConstants.ReportName:
                    Helpers.RunCommandIfTrue(() => _rob.Report(), _placeHasBeenExecuted);
                    break;
                default:
                    break;
            }

            return _placeHasBeenExecuted;
        }
    }
}
