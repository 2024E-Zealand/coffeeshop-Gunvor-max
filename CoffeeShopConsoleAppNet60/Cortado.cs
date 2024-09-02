using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class Cortado : Coffee, IMilk
    {
        public int mlMilk()
        {
            return 40;
        }

        public override double Price()
        {
            return base.Price() + 5;
        }

        public override CoffeeStrength Strength()
        {
            return CoffeeStrength.Medium;
        }
    }
}
