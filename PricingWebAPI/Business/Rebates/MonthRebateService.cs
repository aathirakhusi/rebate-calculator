using Business.Helpers;
using Business.Model;
using Business.Rebate;
using System.Globalization;

namespace Business.Rebates
{
    public class MonthRebateService : IRebate
    {
        private decimal _percentage = 0.0m;
        private List<MonthRebate> _monthRebates;
        public MonthRebateService(List<MonthRebate> monthRebates)
        {
            _monthRebates = monthRebates;
        }
        private decimal CalculateDiscount(PurchaseWithSubTotal item) => Math.Round((item.SubTotal) * _percentage, 2);
        public IEnumerable<ApplicableRebate> DiscountsApplicable(PurchaseWithSubTotal purchaseWithSubTotal)
        {
            var rebatesApplied = new List<ApplicableRebate>();
            foreach (var monthRebate in _monthRebates)
            {
                if (purchaseWithSubTotal.PurchaseModelDto.DateOfPurchase.Month == DateTime.ParseExact(monthRebate.Month, "MMMM", CultureInfo.CurrentCulture).Month)
                {
                    _percentage = decimal.Parse(monthRebate.RebatePercent);
                    var discountedData = CalculateDiscount(purchaseWithSubTotal);
                    var appliedRebate = new ApplicableRebate
                    {
                        Type = Enums.RebateType.MonthRebate,
                        Text = $"Product ID{purchaseWithSubTotal.PurchaseModelDto.ProductId} = {_percentage:P0} OFF: - {discountedData.ToCurrencyString()}",
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
