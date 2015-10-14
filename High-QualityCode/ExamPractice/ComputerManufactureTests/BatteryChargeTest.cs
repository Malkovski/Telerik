namespace ComputerManufactureTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computers.Interfaces;
    using Computers.CoreModels;
    using Computers.Components;
    using Moq;

    [TestClass]
    public class BatteryChargeTest
    {
        //private IExtendedMotherboard board;
        //private ILaptop laptop;
        private IBattery battery;
        

        [TestInitialize]
        public void Initialization()
        {  
            battery = new Battery();
        }

        [TestMethod]
        public void ChargingNegativeValueLowerThanCurrentPercentageShouldExtractProperAmount()
        {
           
            var moqLaptop = new Mock<ILaptop>();
             moqLaptop.Object.Battery.Percentage = 100;
             Console.WriteLine(moqLaptop.Object.Battery.Percentage = 100);
            moqLaptop.Setup(l => l.Battery.Charge(-99));

            
            //laptop = new Laptop(board, battery);
           // battery.Charge(-99);
            var expected = 1;

            Assert.AreEqual(expected, moqLaptop.Setup(s => s.Battery.Percentage));
        }

        //[TestMethod]
        //public void ChargingNegativeValueBiggerThanCurrentPercentageShouldMakeItZero()
        //{
        //    battery.Percentage = 100;
        //    laptop = new Laptop(board, battery);
        //    battery.Charge(-101);
        //    var expected = 0;

        //    Assert.AreEqual(expected, battery.Percentage);
        //}

        //[TestMethod]
        //public void ChargingValueBiggerThanCurrentMaxPercentageShouldMakeIt100()
        //{
        //    battery.Percentage = 1;
        //    laptop = new Laptop(board, battery);
        //    battery.Charge(100);
        //    var expected = 100;

        //    Assert.AreEqual(expected, battery.Percentage);
        //}

        //[TestMethod]
        //public void ChargingValueToPercentageAndTheirSumNotExeedingMaxShouldAddItProperly()
        //{
        //    battery.Percentage = 1;
        //    laptop = new Laptop(board, battery);
        //    battery.Charge(1);
        //    var expected = 2;

        //    Assert.AreEqual(expected, battery.Percentage);
        //}
    }
}
