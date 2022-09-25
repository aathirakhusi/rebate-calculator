using Business.Helpers;
using Business.Model;
using Business.Rebate;

namespace Business.Rebates
{
    public class CustomerRebateService : IRebate
    {
        private decimal _percentage = 0.0m;
        private List<CustomerRebate> _customerRebates;
        public CustomerRebateService(List<CustomerRebate> customerRebate)
        {
            _customerRebates = customerRebate;
        }
        private decimal CalculateDiscount(PurchaseWithSubTotal item) => Math.Round((item.SubTotal) * _percentage, 2);


        public IEnumerable<ApplicableRebate> DiscountsApplicable(PurchaseWithSubTotal purchaseWithSubTotal)
        {
            var rebatesApplied = new List<ApplicableRebate>();
            foreach (var customerRebate in _customerRebates)
            {
                if (purchaseWithSubTotal.PurchaseModelDto.CustomerId == Convert.ToInt16(customerRebate.Id))
                {
                    _percentage = decimal.Parse(customerRebate.RebatePercent);
                    var discountedData = CalculateDiscount(purchaseWithSubTotal);
                    var appliedRebate = new ApplicableRebate
                    {
                        Type =Enums.RebateType.CustomerRebate,
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
