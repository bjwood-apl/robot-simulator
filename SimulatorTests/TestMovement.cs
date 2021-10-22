using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulatorLogic;

namespace SimulatorTests
{
    [TestClass]
    public class TestMovement
    {
        [TestMethod]
        public void ExampleInputA()
        {
            const string expected = "0,1,NORTH";

            Simulator simulator = new();
            simulator.ProcessInput("PLACE 0,0,NORTH");
            simulator.ProcessInput("MOVE");
            Assert.AreEqual(expected, simulator.ProcessInput("REPORT"));
        }

        [TestMethod]
        public void ExampleInputB()
        {
            const string expected = "0,0,WEST";

            Simulator simulator = new();
            simulator.ProcessInput("PLACE 0,0,NORTH");
            simulator.ProcessInput("LEFT");
            Assert.AreEqual(expected, simulator.ProcessInput("REPORT"));
        }

        [TestMethod]
        public void ExampleInputC()
        {
            const string expected = "3,3,NORTH";

            Simulator simulator = new();
            simulator.ProcessInput("PLACE 1,2,EAST");
            simulator.ProcessInput("MOVE");
            simulator.ProcessInput("MOVE");
            simulator.ProcessInput("LEFT");
            simulator.ProcessInput("MOVE");
            Assert.AreEqual(expected, simulator.ProcessInput("REPORT"));
        }

        [TestMethod]
        public void ExampleInputD()
        {
            const string expected = "3,2,NORTH";

            Simulator simulator = new();
            simulator.ProcessInput("PLACE 1,2,EAST");
            simulator.ProcessInput("MOVE");
            simulator.ProcessInput("LEFT");
            simulator.ProcessInput("MOVE");
            simulator.ProcessInput("PLACE 3,1");
            simulator.ProcessInput("MOVE");
            Assert.AreEqual(expected, simulator.ProcessInput("REPORT"));
        }
    }
}
