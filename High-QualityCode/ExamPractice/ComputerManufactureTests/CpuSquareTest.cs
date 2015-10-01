namespace ComputerManufactureTests
{
    using System;
    using Computers.Components;
    using Computers.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CpuSquareTest
    {
        private ICpu cpu32, cpu64, cpu128;

        [TestInitialize]
        public void Initialization()
        {
            this.cpu128 = new Cpu128(4);
            this.cpu32 = new Cpu32(4);
            this.cpu64 = new Cpu64(4);
        }

        [TestMethod]
        public void Cpu32ShouldReturnCorerctMessageWhenValueLowerThanMin()
        {
            string expected = "Number too low.";
            string result = this.cpu32.SquareNumber(-1);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Cpu64ShouldReturnCorerctMessageWhenValueLowerThanMin()
        {
            string expected = "Number too low.";
            string result = this.cpu32.SquareNumber(-1);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Cpu128ShouldReturnCorerctMessageWhenValueLowerThanMin()
        {
            string expected = "Number too low.";
            string result = this.cpu32.SquareNumber(-1);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Cpu32ShouldReturnCorerctMessageWhenValueBiggerThanMax()
        {
            string expected = "Number too high.";
            string result = this.cpu32.SquareNumber(501);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Cpu64ShouldReturnCorerctMessageWhenValueBiggerThanMax()
        {
            string expected = "Number too high.";
            string result = this.cpu32.SquareNumber(1001);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Cpu128ShouldReturnCorerctMessageWhenValueBiggerThanMax()
        {
            string expected = "Number too high.";
            string result = this.cpu32.SquareNumber(2001);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Cpu32ShouldReturnCorerctMessageWhenValueIsInRange()
        {
            string expected = "Square of 500 is 250000.";
            string result = this.cpu32.SquareNumber(500);

            Assert.AreEqual(expected, result);
        }

        public void Cpu64ShouldReturnCorerctMessageWhenValueIsInRange()
        {
            string expected = "Square of 1000 is 1000000.";
            string result = this.cpu32.SquareNumber(1000);

            Assert.AreEqual(expected, result);
        }

        public void Cpu128ShouldReturnCorerctMessageWhenValueIsInRange()
        {
            string expected = "Square of 2000 is 4000000.";
            string result = this.cpu32.SquareNumber(2000);

            Assert.AreEqual(expected, result);
        }
    }
}