using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class Expresso : Coffee
    {
        public Expresso(int discount, string blend) : base(discount, blend)
        {
        }

        public override CoffeeStrength Strength()
        {
            return CoffeeStrength.Strong;
        }

        public override double Price()
        {
            return base.Price() - 5;
        }
    }
}
