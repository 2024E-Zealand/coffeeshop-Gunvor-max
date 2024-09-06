using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeShopConsoleAppNet60;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60.Tests
{
    [TestClass()]
    public class OrderTests
    {
        public Order Order1;
        public Order OrderDiscount;

        public static List<Coffee> testList { get; set; } = new List<Coffee>
            { new Cortado(0,"TestBlend", IMilk.MilkVariants.Minimælk),
              new Latte(0,"TestBlend", IMilk.MilkVariants.SoyaDrik),
              new Expresso(0,"TestBlend")
            };

        [TestInitialize]
        public void BeforeEachTest()
        {
            Order1 = new Order(new Guid(), "Barista", "Customer", false, new List<Coffee> 
            { new Cortado(0,"TestBlend", IMilk.MilkVariants.Minimælk),
              new Latte(0,"TestBlend", IMilk.MilkVariants.SoyaDrik),
              new Expresso(0,"TestBlend")
            });

            OrderDiscount = new Order(new Guid(), "Barista", "Customer", false, new List<Coffee>
            { new Cortado(3,"TestBlend", IMilk.MilkVariants.Minimælk),
              new Latte(4,"TestBlend", IMilk.MilkVariants.SoyaDrik),
              new Expresso(5,"TestBlend")
            });

        }

        [TestMethod()]
        [DataRow(80)]
        public void TotalPriceTestOK(double totalPrice)
        {
            //Act 
            double expectedValue = totalPrice;
            double actualValue = Order1.TotalPrice();

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod()]
        [DataRow(100)]
        public void TotalPriceTestNOTOK(double totalPrice)
        {
            //Act 
            double expectedValue = totalPrice;
            double actualValue = Order1.TotalPrice();

            //Assert
            Assert.AreNotEqual(expectedValue, actualValue);
        }

        [TestMethod()]
        [DataRow(80, 12)]
        public void TotalPriceTestDiscountOK(double totalPrice, int totalDiscount)
        {
            //Act 
            double expectedValue = totalPrice - totalDiscount;
            double actualValue = OrderDiscount.TotalPrice();

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod()]
        [DataRow(3)]
        public void TotalOrderItemsTest(int totalItems)
        {

            //Act
            int expectedValue = totalItems;
            int actualValue = Order1.TotalOrderItems();
            Assert.AreEqual(expectedValue,actualValue);
        }

        [TestMethod()]
        [DataRow(12)]
        public void TotalDiscountTest(int totaldiscount)
        {
            double expectedValue = OrderDiscount.TotalPrice() - totaldiscount;
            double actualValue = OrderDiscount.TotalPrice() - OrderDiscount.TotalDiscount();
            Assert.AreEqual(expectedValue,actualValue);
        }

        [TestMethod()]
        [DataRow("Cortado")]
        [DataRow("Latte")]
        [DataRow("Expresso")]
        public void PrintCoffeeInfoTestOK(string coffee)
        {
            // Act 
            string expectedValue = coffee;
            bool actualValue = Order1.PrintCoffeeInfo().Contains(expectedValue);

            Assert.IsTrue(actualValue);
        }
    }
}