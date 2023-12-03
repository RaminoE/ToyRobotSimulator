using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Common.Enums;

namespace ToyRobotSimulator.Model
{
    public class PlacementRequestModel
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public Direction? F { get; set; }
    }
}
