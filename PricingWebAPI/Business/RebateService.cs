using Business.Model;
using Business.Rebates;

namespace Business
{
    public class RebateService 
    {
        private readonly IEnumerable<IRebate> _rebates;
        private readonly PurchaseWithSubTotal _productWithSubTotal;

        public RebateService(IEnumerable<IRebate> rebates, PurchaseWithSubTotal productWithSubTotal)
        {
            _rebates = rebates ?? throw new ArgumentNullException(nameof(rebates));
            _productWithSubTotal = productWithSubTotal;
        }
        public List<ApplicableRebate> GetApplicableRebates(PurchaseModelDto purchaseModelDto)
        {
            var rebates = new List<ApplicableRebate>();
            foreach (var rebate in _rebates)
            {
                rebates.AddRange(rebate.DiscountsApplicable(_productWithSubTotal));
            }
            if (!rebates.Any())
                rebates.Add(new ApplicableRebate
                {
                    Type = Enums.RebateType.None,
                    Text = "(No offers available)",
                    GrandTotal = _productWithSubTotal.SubTotal,
                    PurchaseDetails = _productWithSubTotal
                });
            return rebates;

        }
    }
}
