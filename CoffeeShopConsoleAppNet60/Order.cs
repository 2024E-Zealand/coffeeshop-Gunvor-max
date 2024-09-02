using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class Order
    {

        public Guid OrderId { get; set; }
        public string BaristaName { get; set; }
        public string CustomerName { get; set; }
        public bool TakeAway { get; set; }
        public int TableId { get; set; }
        List<Coffee> CoffeeOrder {  get; set; } = new List<Coffee>();

        public Order(Guid orderId, string baristaName, string customerName, int tableId, List<Coffee> coffeeOrder)
        {
            OrderId = orderId;
            BaristaName = baristaName;
            CustomerName = customerName;
            TakeAway = false;
            TableId = tableId;
            CoffeeOrder = coffeeOrder;
        }

        public Order(Guid orderId, string baristaName, string customerName, bool takeAway, List<Coffee> coffeeOrder)
        {
            OrderId = orderId;
            BaristaName = baristaName;
            CustomerName = customerName;
            TakeAway = takeAway;
            CoffeeOrder = coffeeOrder;
        }

        public double TotalPrice() 
        {
            double totalPrice = 0;
            foreach (var coffee in CoffeeOrder)
            {
                totalPrice =+ coffee.Price();
            }
            return totalPrice;
        }

        public int TotalOrderItems()
        {
        return CoffeeOrder.Count; 
        }

        public double TotalDiscount() 
        {
            double totalDiscount = 0;
            foreach (var coffee in CoffeeOrder)
            {
                totalDiscount =+ coffee.Discount;
            }
            return totalDiscount;
        }

        public string PrintCoffeeInfo()
        {
            string print = string.Empty;
            foreach (var coffee in CoffeeOrder)
            {
                print += ($"{coffee.GetType().Name} {coffee.Strength()} {coffee.Price()} kr. - Blend {coffee.Blend}\b");
            }
            return print;
        }

        public override string ToString()
        {
            return $"{{{nameof(OrderId)}={OrderId.ToString()}, {nameof(BaristaName)}={BaristaName}, {nameof(CustomerName)}={CustomerName}, {nameof(TakeAway)}={TakeAway.ToString()}, {nameof(TableId)}={TableId.ToString()}, {PrintCoffeeInfo()} }}";
        }
    }
}
