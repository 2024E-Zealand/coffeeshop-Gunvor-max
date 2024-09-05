using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public class FlatWhite : Coffee, IMilk
    {
        public IMilk.MilkVariants MilkVariants { get; set; }
        public FlatWhite(int discount, string blend, IMilk.MilkVariants milkVariants) : base(discount, blend)
        {
            MilkVariants = milkVariants;
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
