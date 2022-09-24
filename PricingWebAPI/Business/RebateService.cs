using Business.Rebate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;
using Business.Rebates;

namespace Business
{
    public class RebateService
    {
        private readonly IEnumerable<IRebate> _rebates;
        private readonly ProductWithSubTotal _productWithSubTotal;
        
        public RebateService(IEnumerable<IRebate> rebates, ProductWithSubTotal productWithSubTotal)
        {
            _rebates = rebates ?? throw new ArgumentNullException(nameof(rebates));
            _productWithSubTotal = productWithSubTotal;
        }
        public decimal CalculateRebate (PurchaseModelDto purchaseModelDto)
        {
            var rebates = new List<ApplicableRebate>();
            foreach (var rebate in _rebates)
            {
                rebates.AddRange(rebate.DiscountsApplicable(_productWithSubTotal));
            }
            return 0;

        }
    }
}
