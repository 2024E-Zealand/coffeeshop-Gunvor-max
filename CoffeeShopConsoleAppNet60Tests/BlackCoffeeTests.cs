using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeShopConsoleAppNet60;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoffeeShopConsoleAppNet60.Coffee;

namespace CoffeeShopConsoleAppNet60.Tests
{
    [TestClass()]
    public class BlackCoffeeTests
    {
        private Coffee TestObject;
        private Coffee TestObjectDiscount;
        [TestInitialize]
        public void BeforeEachTest()
        {
            TestObject = new BlackCoffee(0,"TestBlend");
        }

        [TestMethod()]
        [DataRow(20)]
        public void PriceTestNoDiscountOK(double price)
        {
            //Act
            double expectedPrice = price;
            double actualPrice = TestObject.Price();

            //Assert
            Assert.AreEqual(expectedPrice,actualPrice);
        }

        [TestMethod()]
        [DataRow(20,5)]
        [DataRow(20, 3)]
        [DataRow(20, 1)]
        public void PriceTestDiscountOK(double price,int discount)
        {
            //Arrange
            TestObjectDiscount = new BlackCoffee(discount, "TestBlend");

            //Act
            double expectedPrice = price - discount;
            double actualPrice = TestObjectDiscount.Price();

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod()]
        [DataRow(20, 6)]
        [DataRow(20, -1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PriceTestDiscountNOTOK(double price, int discount)
        {
            //Arrange + Act
            TestObjectDiscount = new BlackCoffee(discount, "TestBlend");

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow(CoffeeStrength.Strong)]
        public void CoffeeStrengthTestOK(CoffeeStrength coffeeStrength)
        {
            //Act
            CoffeeStrength expectedValue = coffeeStrength;
            CoffeeStrength actualValue = TestObject.Strength();

            Assert.AreEqual(expectedValue,actualValue);
        }

        [TestMethod()]
        [DataRow(CoffeeStrength.Weak)]
        public void CoffeeStrengthTestNOTOK(CoffeeStrength coffeeStrength)
        {
            //Act
            CoffeeStrength expectedValue = coffeeStrength;
            CoffeeStrength actualValue = TestObject.Strength();

            Assert.AreNotEqual(expectedValue, actualValue);
        }
    }
}