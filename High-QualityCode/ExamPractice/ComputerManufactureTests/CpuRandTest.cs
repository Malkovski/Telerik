namespace ComputerManufactureTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computers.Interfaces;
    using Computers.Components;

    [TestClass]
    public class CpuRandTest
    {
        private ICpu cpu;

        [TestInitialize]
        public void Initialization()
        {
            cpu = new Cpu32(2);
        }

        [TestMethod]
        public void RandMethodShouldReturnProprerValueInRange()
        {
            //Random rand = new Random();
            int randomNumber = cpu.GetRandomValue(2, 3);
            var expected = 2;

            Assert.AreEqual(expected, randomNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RandMethodShouldThrowExeptionWhenWrongRange()
        {
            Random rand = new Random();
            int randomNumeber = cpu.GetRandomValue(10, 1);
        }
    }
}
