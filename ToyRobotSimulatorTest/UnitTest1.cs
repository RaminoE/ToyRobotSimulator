using Microsoft.VisualStudio.TestPlatform.Utilities;
using NuGet.Frameworks;
using ToyRobotSimulator.Common.Enums;
using ToyRobotSimulator.Core;
using ToyRobotSimulator.CoreShared;
using ToyRobotSimulator.Model;
using ToyRobotSimulator.Service;

namespace ToyRobotSimulatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidPlacementTest()
        {
            IRobot robot = new Robot();

            CommandHandler c = new CommandHandler(robot);
            var data = c.HandleCommand(new string[] { "PLACE", "0", "0", "NORTH" });
            Assert.AreEqual(true, data);
        }

        [Test]
        public void InvalidPlacementTest()
        {
            IRobot robot = new Robot();

            CommandHandler c = new CommandHandler(robot);
            var exception = Assert.Throws<Exception>(() => c.HandleCommand(new string[] { "PLACE", "0", "9", "NORTH" }));
            Assert.AreEqual("Invalid placement", exception.Message);
        }

        [Test]
        public void SuccessfullReport()
        {
            IRobot robot = new Robot();

            CommandHandler c = new CommandHandler(robot);
            var output = c.HandleCommand(new string[] { "PLACE", "0", "0", "NORTH" });
            Assert.AreEqual(true, output);
            output = c.HandleCommand(new string[] { "Move" });
            Assert.AreEqual(true, output);
            output = c.HandleCommand(new string[] { "Report" });
            Assert.AreEqual(true, output);

            output = c.HandleCommand(new string[] { "PLACE", "0", "0", "NORTH" });
            Assert.AreEqual(true, output);
            output = c.HandleCommand(new string[] { "Left" });
            Assert.AreEqual(true, output);
            output = c.HandleCommand(new string[] { "Move" });
            Assert.AreEqual(true, output);
            output = c.HandleCommand(new string[] { "Report" });
            Assert.AreEqual(true, output);

        }

        [Test]
        public void RobotTest()
        {
            Robot robot = new Robot();

            robot.Place(new PlacementRequestModel()
            {
                X = 0,
                Y = 0,
                F = Direction.NORTH
            });
            robot.Left();


            var expectedoutput = new PlacementRequestModel()
            {
                X = 0,
                Y = 0,
                F = Direction.WEST
            };
            var output = robot.Report();
            Assert.AreEqual(expectedoutput.X,output.X );
            Assert.AreEqual(expectedoutput.Y,output.Y );
            Assert.AreEqual(expectedoutput.F,output.F );
        }

        [Test]
        public void RobotTest1()
        {
            Robot robot = new Robot();

            robot.Place(new PlacementRequestModel()
            {
                X = 0,
                Y = 0,
                F = Direction.NORTH
            });

            var expectedoutput = new PlacementRequestModel()
            {
                X = 0,
                Y = 0,
                F = Direction.NORTH
            };
            var output = robot.Report();
            Assert.AreEqual(expectedoutput.X, output.X);
            Assert.AreEqual(expectedoutput.Y, output.Y);
            Assert.AreEqual(expectedoutput.F, output.F);
        }

        [Test]
        public void RobotTest2()
        {
            Robot robot = new Robot();

            robot.Place(new PlacementRequestModel()
            {
                X = 1,
                Y = 2,
                F = Direction.EAST
            });
            robot.Move();
            robot.Move();
            robot.Left();
            robot.Move();


            var expectedoutput = new PlacementRequestModel()
            {
                X = 3,
                Y = 3,
                F = Direction.NORTH
            };
            var output = robot.Report();
            Assert.AreEqual(expectedoutput.X, output.X);
            Assert.AreEqual(expectedoutput.Y, output.Y);
            Assert.AreEqual(expectedoutput.F, output.F);
        }
    }
}