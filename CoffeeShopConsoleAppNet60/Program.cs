// See https://aka.ms/new-console-template for more information
using CoffeeShopConsoleAppNet60;

Console.WriteLine("Coffee menucard");

try
{
List<Coffee> menucard = new List<Coffee>
{
    new Latte(0,"Bekele - Early access"),
    new Cortado(0, "Bekele - Early access"),
    new BlackCoffee(0, "Bekele - Early access")
};
foreach (Coffee coffee in menucard)
{
    Console.WriteLine($"{coffee.GetType().Name} {coffee.Strength()} {coffee.Price()} kr. - Blend {coffee.Blend}");
}
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("\b");
Console.WriteLine("extra exercises");
Console.WriteLine("\b");
Console.WriteLine("Coffee menucard with milk");
List<Coffee> coffeesWithMilk = new List<Coffee>
{
    new Latte(0, "Bekele - Early access"),
    new Cortado(0, "Bekele - Early access"),
};
foreach(Coffee coffee in coffeesWithMilk)
{
    Console.WriteLine($"{coffee.GetType().Name} {coffee.Strength()} {coffee.Price()} kr. - Blend {coffee.Blend}");
}
Console.WriteLine("\b");
Order order1 = new Order(Guid.NewGuid(), "Jens", "Anders", true, 
    new List<Coffee> 
    {
        new Latte(0,"Bekele - Early access"),
        new Cortado(0, "Bekele - Early access")
    });

Console.WriteLine("Order");
Console.WriteLine(order1);