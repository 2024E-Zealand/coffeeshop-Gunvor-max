using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeShopConsoleAppNet60;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoffeeShopConsoleAppNet60.Coffee;
using System.Diagnostics;

namespace CoffeeShopConsoleAppNet60.Tests
{
    [TestClass()]
    public class CortadoTests
    {

        private Coffee TestObject;
        private Coffee TestObjectDiscount;
        [TestInitialize]
        public void BeforeEachTest()
        {
            TestObject = new Cortado(0, "TestBlend", IMilk.MilkVariants.Skummetmælk);
        }

        [TestMethod()]
        [DataRow(25)]
        public void PriceTestNoDiscountOK(double price)
        {
            //Act
            double expectedPrice = price;
            double actualPrice = TestObject.Price();

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod()]
        [DataRow(25, 5)]
        [DataRow(25, 3)]
        [DataRow(25, 1)]
        public void PriceTestDiscountOK(double price, int discount)
        {
            //Arrange
            TestObjectDiscount = new Cortado(discount, "TestBlend", IMilk.MilkVariants.Skummetmælk);

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
            TestObjectDiscount = new Cortado(discount, "TestBlend", IMilk.MilkVariants.Skummetmælk);

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow(CoffeeStrength.Medium)]
        public void CoffeeStrengthTestOK(CoffeeStrength coffeeStrength)
        {
            //Act
            CoffeeStrength expectedValue = coffeeStrength;
            CoffeeStrength actualValue = TestObject.Strength();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod()]
        [DataRow(CoffeeStrength.Strong)]
        [DataRow(CoffeeStrength.Weak)]
        public void CoffeeStrengthTestNOTOK(CoffeeStrength coffeeStrength)
        {
            //Act
            CoffeeStrength expectedValue = coffeeStrength;
            CoffeeStrength actualValue = TestObject.Strength();

            Assert.AreNotEqual(expectedValue, actualValue);
        }

        [TestMethod()]
        [DataRow(40)]
        public void mlMilkTestOK(int ml)
        {

            //Act
            int expectedValue = ml;
            int actualValue = (TestObject as Cortado).mlMilk();

            //Assert
            Assert.AreEqual(expectedValue, actualValue);



        }
        [TestMethod()]
        [DataRow(10)]
        public void mlMilkTestNOTOK(int ml)
        {

            //Act
            int expectedValue = ml;
            int actualValue = (TestObject as Cortado).mlMilk();

            //Assert
            Assert.AreNotEqual(expectedValue, actualValue);
        }
    }
}