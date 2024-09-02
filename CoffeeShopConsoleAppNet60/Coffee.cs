using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopConsoleAppNet60
{
    public abstract class Coffee
    {
        private int _discount;
        public int Discount 
        {
            get { return _discount; }
            set 
            {
                if (value >= 0 && value <= 5) 
                {
                    _discount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Discount was {value}. It has to be in the range 0-5 kr.");
                }
            } 
        }

        public string Blend { get; set; }

        protected Coffee(int discount, string blend)
        {
            Discount = discount;
            Blend = blend;
        }

        public virtual double Price() 
        {
            return 20 - Discount;
        }

        public abstract CoffeeStrength Strength();

        public enum CoffeeStrength
        {
            Weak,
            Medium,
            Strong
        }
    }

}