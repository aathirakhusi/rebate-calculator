using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class PurchaseWithSubTotal
    {
        public PurchaseModelDto PurchaseModelDto { get; set; }
        public decimal SubTotal { get; set; }

    }
}
