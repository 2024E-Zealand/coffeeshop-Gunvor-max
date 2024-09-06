using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class OrderSystem
    {
        public List<Order> Orders { get; set; }
        public Dictionary<string, int> TotalCoffeeItemsSold { get; set; }

        public OrderSystem()
        {
            Orders = new List<Order>();
            TotalCoffeeItemsSold = new Dictionary<string, int>();
        }

        public double TotalIncome()
        {
            double result = 0;
            foreach (Order order in Orders)
            {
                result += order.TotalPrice();
            }
            return result;
        }

        public double TotalMilkUsedLiter()
        {
            double result = 0;
            foreach (Order order in Orders)
            {
                foreach(Coffee coffee in order.CoffeeOrder)
                {
                    if (coffee is IMilk)
                    {
                        result += (coffee as IMilk).mlMilk();
                    }
                }

                
            }
            //Get the result back in liters
            return result/1000;
        }

        public Dictionary<string,int> TotalCoffeesSold()
        {
            foreach (Order order in Orders)
            {
                foreach (Coffee coffee in order.CoffeeOrder)
                {
                    if (TotalCoffeeItemsSold.ContainsKey(coffee.GetType().ToString())) 
                    {
                        TotalCoffeeItemsSold[coffee.GetType().ToString()]++;
                    }
                    else
                    {
                        TotalCoffeeItemsSold[coffee.GetType().ToString()] = 1;
                    }
                }


            }
            return TotalCoffeeItemsSold;
        }

       public void PrintTotalCoffeeSold()
        {
            foreach (KeyValuePair<string, int> kvp in TotalCoffeesSold())
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
