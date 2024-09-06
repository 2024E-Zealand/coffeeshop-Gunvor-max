using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class Latte : Coffee, IMilk
    {
        public IMilk.MilkVariants MilkVariants { get; set; }

        public Latte(int discount, string blend, IMilk.MilkVariants milkVariants) : base(discount, blend)
        {
            MilkVariants = milkVariants;
        }

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
