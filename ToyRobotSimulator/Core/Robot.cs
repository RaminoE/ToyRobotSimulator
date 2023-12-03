using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Common.Enums;
using ToyRobotSimulator.Common.Helper;
using ToyRobotSimulator.CoreShared;
using ToyRobotSimulator.Model;

namespace ToyRobotSimulator.Core
{
    public class Robot : IRobot
    {
        private int? _x;
        private int? _y;
        private Direction? _f;

        //Sets _x, _y and _f values if request contains valid data and returns a bool to indicate success or failure 
        public bool Place(PlacementRequestModel req)
        {
            var placed = false;

            if (req != null && Helpers.IsValidPlacement(req.X) && Helpers.IsValidPlacement(req.Y) && req.F != null)
            {
                _x = req.X;

                _y = req.Y;

                _f = req.F;

                placed = true;
            }

            return placed;
        }

        //Moves robot one unit in direction faced
        public void Move()
        {
            switch (_f)
            {
                case Direction.NORTH:
                    Helpers.RunCommandIfTrue(() => _y++, Helpers.IsValidPlacement(_y + 1));
                    break;
                case Direction.SOUTH:
                    Helpers.RunCommandIfTrue(() => _y--, Helpers.IsValidPlacement(_y - 1));
                    break;
                case Direction.EAST:
                    Helpers.RunCommandIfTrue(() => _x++, Helpers.IsValidPlacement(_x + 1));
                    break;
                case Direction.WEST:
                    Helpers.RunCommandIfTrue(() => _x--, Helpers.IsValidPlacement(_x - 1));
                    break;
                default:
                    break;
            }
        }

        //Calls turn with direction as increment of _f
        public void Left()
        {
            Turn(() => (int)_f + 1);
        }

        //Calls turn with direction as decrement of _f
        public void Right()
        {
            Turn(() => (int)_f - 1);
        }

        //If value less than zero default, otherwise calculate direction based on modulo
        private void Turn(Func<int> newDirection)
        {
            _f = newDirection() < 0 ? Direction.EAST : (Direction)(newDirection() % 4);
        }

        //Outputs comma-separated string with _x,_y and _f values
        public void Report()
        {
            Console.WriteLine($"Output: {_x},{_y},{_f}");
        }
    }
}
