using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class Latte : Coffee, IMilk
    {
        public int mlMilk()
        {
            return 200;
        }

        public override double Price()
        {
            return base.Price() + 20;
        }

        public override CoffeeStrength Strength()
        {
            return CoffeeStrength.Weak;
        }
    }
}
