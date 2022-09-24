using Business.Helpers;
using Business.Model;
using Business.Rebate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rebates
{
    public class ProductRebateService : IRebate
    {
        private decimal _percentage = 0.0m;
        private List<ProductRebate > _productRebates;
        public ProductRebateService(List<ProductRebate> productRebates)
        {
            _productRebates = productRebates;
        }
        private decimal CalculateDiscount(PurchaseWithSubTotal item) => Math.Round((item.SubTotal) * _percentage, 2);
        public IEnumerable<ApplicableRebate> DiscountsApplicable(PurchaseWithSubTotal purchaseWithSubTotal)
        {
            var rebatesApplied = new List<ApplicableRebate>();
            foreach (var productRebate in _productRebates)
            {
                if (purchaseWithSubTotal.PurchaseModelDto.ProductId == Convert.ToInt64(productRebate.Id))
                {
                    _percentage = decimal.Parse(productRebate.RebatePercent);
                    var discountedData = CalculateDiscount(purchaseWithSubTotal);
                    var appliedRebate = new ApplicableRebate
                    {
                        Type = Enums.RebateType.MonthRebate,
                        Text = $"Product ID {purchaseWithSubTotal.PurchaseModelDto.ProductId} = {_percentage:P0} OFF: - {discountedData.ToCurrencyString()}",
                        GrandTotal = discountedData,
                        PurchaseDetails = purchaseWithSubTotal

                    };

                    rebatesApplied.Add(appliedRebate);

                }
            }
            return rebatesApplied;
        }
    }
}
