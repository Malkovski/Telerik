namespace ComputerManufactureTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computers.Interfaces;
    using Computers.CoreModels;
    using Telerik.JustMock;
    using Computers.Components;

    [TestClass]
    public class BatteryChargeTest
    {
        private IExtendedMotherboard board;
        private ILaptop laptop;
        private IBattery battery;

        [TestInitialize]
        public void Initialization()
        {
            board = Mock.Create<IExtendedMotherboard>();
            battery = new Battery();
        }

        [TestMethod]
        public void ChargingNegativeValueLowerThanCurrentPercentageShouldExtractProperAmount()
        {
            battery.Percentage = 100;
            laptop = new Laptop(board, battery);
            battery.Charge(-99);
            var expected = 1;

            Assert.AreEqual(expected, battery.Percentage);
        }

        [TestMethod]
        public void ChargingNegativeValueBiggerThanCurrentPercentageShouldMakeItZero()
        {
            battery.Percentage = 100;
            laptop = new Laptop(board, battery);
            battery.Charge(-101);
            var expected = 0;

            Assert.AreEqual(expected, battery.Percentage);
        }

        [TestMethod]
        public void ChargingValueBiggerThanCurrentMaxPercentageShouldMakeIt100()
        {
            battery.Percentage = 1;
            laptop = new Laptop(board, battery);
            battery.Charge(100);
            var expected = 100;

            Assert.AreEqual(expected, battery.Percentage);
        }

        [TestMethod]
        public void ChargingValueToPercentageAndTheirSumNotExeedingMaxShouldAddItProperly()
        {
            battery.Percentage = 1;
            laptop = new Laptop(board, battery);
            battery.Charge(1);
            var expected = 2;

            Assert.AreEqual(expected, battery.Percentage);
        }
    }
}
