using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class BlackCoffee : Coffee
    {
        public override CoffeeStrength Strength()
        {
            return CoffeeStrength.Strong;
        }
    }
}
