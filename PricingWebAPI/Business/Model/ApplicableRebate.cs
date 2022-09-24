using Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class ApplicableRebate
    {
        public RebateType Type { get; set; }
        public string Text { get; set; }
        public decimal GrandTotal { get; set; }
        ProductWithSubTotal PurchaseDetails { get; set; }
    }
}
