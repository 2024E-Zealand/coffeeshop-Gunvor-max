// See https://aka.ms/new-console-template for more information
using CoffeeShopConsoleAppNet60;

Console.WriteLine("Coffee menucard");


List<Coffee> menucard = new List<Coffee>
{
    new Latte(0,"Bekele - Early access", IMilk.MilkVariants.Havredrik),
    new Cortado(0, "Bekele - Early access", IMilk.MilkVariants.Havredrik),
    new BlackCoffee(0, "Bekele - Early access")
};
foreach (Coffee coffee in menucard)
{
    Console.WriteLine($"{coffee.GetType().Name} {coffee.Strength()} {coffee.Price()} kr. - Blend {coffee.Blend}");
}
Console.WriteLine("\b");
Console.WriteLine("extra exercises");
Console.WriteLine("\b");
Console.WriteLine("Coffee menucard with milk");
List<IMilk> coffeesWithMilk = new List<IMilk>();
foreach (var coffee in menucard)
{
    if(coffee is IMilk)
    {
        coffeesWithMilk.Add(coffee as IMilk);
    }
}

foreach(Coffee coffee in coffeesWithMilk)
{
    Console.WriteLine($"{coffee.GetType().Name} {coffee.Strength()} {coffee.Price()} kr. - Blend {coffee.Blend}");
    //if(coffee is Cortado)
    //{
    //    (coffee as Cortado)
    //}
}
Console.WriteLine("\b");
Order order1 = new Order(Guid.NewGuid(), "Jens", "Anders", true, 
    new List<Coffee> 
    {
        new Latte(4,"Bekele - Early access", IMilk.MilkVariants.Havredrik),
        new Cortado(4, "Bekele - Early access", IMilk.MilkVariants.Minimælk)
    });

Order order2 = new Order(Guid.NewGuid(), "Jens", "Tine", true,
    new List<Coffee>
    {
        new Latte(0,"Bekele - Early access", IMilk.MilkVariants.Sødmælk),
        new Cortado(0, "Bekele - Early access",IMilk.MilkVariants.Havredrik),
        new Expresso(0, "Bekele - Early access"),
        new FlatWhite(0, "Bekele - Early access",IMilk.MilkVariants.Minimælk)
    }); ;

Console.WriteLine("Order");
Console.WriteLine(order1);
Console.WriteLine(order1.TotalPrice());
Console.WriteLine(order1.TotalDiscount());

Console.WriteLine("--------- Ordersystem");
OrderSystem orderlist = new OrderSystem();
orderlist.Orders.Add(order1);
orderlist.Orders.Add(order2);
Console.WriteLine(string.Join("\r\n", orderlist.Orders));
Console.WriteLine($"TotalIncome for all orders: {orderlist.TotalIncome()} kr.");
Console.WriteLine($"Total Milk used: {orderlist.TotalMilkUsedLiter()} L");
Console.WriteLine($"Total Coffee's sold: \n");
orderlist.PrintTotalCoffeeSold();