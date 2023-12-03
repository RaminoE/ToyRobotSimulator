using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Common.Enums;

namespace ToyRobotSimulator.Common.Helper
{
    public static class Helpers
    {
        public static int? GetNumberFromString(string text)
        {
            int result;
            return int.TryParse(text, out result) ? result : null;
        }


        public static Direction? GetDirectionFromString(string input)
        {
            Direction direction;
            Enum.TryParse(input, out direction);
            return direction;
        }

        public static bool IsValidPlacement(int? a)
        {
            var startIndex = 0;

            var endIndex = 4;

            return a >= startIndex && a <= endIndex;
        }

        public static string[]? GetArrayFromSplitInput(string input)
        {
            return input?.Split(new string[] { " ", "," }, StringSplitOptions.None);
        }

        public static void RunCommandIfTrue(Action action, bool condition)
        {
            if (condition && action != null)
            {
                action.Invoke();
            }

        }
    }
}
