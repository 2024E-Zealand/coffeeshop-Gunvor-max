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
    public class OrderSystemTests
    {
        Order Order1;
        Order Order2;
        OrderSystem OrderOverview;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Order1 = new Order(new Guid(), "Barista", "Customer", false, new List<Coffee>
            { new Cortado(0,"TestBlend", IMilk.MilkVariants.Minimælk),
              new Latte(0,"TestBlend", IMilk.MilkVariants.SoyaDrik),
              new Expresso(0,"TestBlend")
            });

            Order2 = new Order(new Guid(), "Barista", "Customer", false, new List<Coffee>
            { new Cortado(0,"TestBlend", IMilk.MilkVariants.Minimælk),
              new Latte(0,"TestBlend", IMilk.MilkVariants.SoyaDrik),
              new Expresso(0,"TestBlend")
            });

            OrderOverview = new OrderSystem();
            OrderOverview.Orders.Add(Order1);
            OrderOverview.Orders.Add(Order2);
        }


        [TestMethod()]
        [DataRow(160)]
        public void TotalIncomeTest(double totalIncome)
        {
            //Act
            double expectedValue = totalIncome;
            double actuelValue = OrderOverview.TotalIncome();
            Assert.AreEqual(expectedValue, actuelValue);
        }

        [TestMethod()]
        [DataRow(480)]
        public void TotalMilkUsedLiterTest(double totalMl)
        {
            double expectedValue = totalMl / 1000;
            double actualValue = OrderOverview.TotalMilkUsedLiter();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod()]
        [DataRow(6)]
        public void TotalCoffeesSoldTest(int items)
        {
            var expectedValue = items;
            var actualValue = OrderOverview.TotalCoffeesSold().Values.Sum();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}