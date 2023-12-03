using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.ServiceShared
{
    public interface ICommandHandler
    {
        public bool HandleCommand(string[] command);
    }
}
