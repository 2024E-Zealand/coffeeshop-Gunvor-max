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
    public class ExpressoTests
    {
        private Coffee TestObject;
        private Coffee TestObjectDiscount;
        [TestInitialize]
        public void BeforeEachTest()
        {
            TestObject = new Expresso(0, "TestBlend");
        }

        [TestMethod()]
        [DataRow(15)]
        public void PriceTestNoDiscountOK(double price)
        {
            //Act
            double expectedPrice = price;
            double actualPrice = TestObject.Price();

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod()]
        [DataRow(15, 5)]
        [DataRow(15, 3)]
        [DataRow(15, 1)]
        public void PriceTestDiscountOK(double price, int discount)
        {
            //Arrange
            TestObjectDiscount = new Expresso(discount, "TestBlend");

            //Act
            double expectedPrice = price - discount;
            double actualPrice = TestObjectDiscount.Price();

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod()]
        [DataRow(6)]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDiscountNOTOK(int discount)
        {
            //Arrange + Act
            TestObjectDiscount = new Expresso(discount, "TestBlend");

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

            Assert.AreEqual(expectedValue, actualValue);
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