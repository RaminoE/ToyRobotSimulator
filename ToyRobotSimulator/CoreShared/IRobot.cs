using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Model;

namespace ToyRobotSimulator.CoreShared
{
    public interface IRobot
    {
        public bool Place(PlacementRequestModel req);
        public void Left();
        public void Right();
        public PlacementRequestModel Report();
        public void Move();
    }
}
