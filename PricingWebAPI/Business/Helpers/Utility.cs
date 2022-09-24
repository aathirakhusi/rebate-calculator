using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class Utility
    {
        public decimal GetRebatePrice(int totalPrice, decimal rebate)
        {
            decimal rebatePrice = totalPrice - (totalPrice * rebate / 100);
            return rebatePrice;

        }
         
    }
}
