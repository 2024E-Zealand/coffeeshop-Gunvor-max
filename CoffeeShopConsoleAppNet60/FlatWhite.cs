using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class FlatWhite : Coffee, IMilk
    {
        public FlatWhite(int discount, string blend) : base(discount, blend)
        {
        }

        public override CoffeeStrength Strength()
        {
            return CoffeeStrength.Weak;
        }

        public override double Price()
        {
            return base.Price() + 5;
        }

        public int mlMilk()
        {
            return 100;
        }
    }
}
