using Business.Helpers;
using Business.Model;
using Business.Rebate;

namespace Business.Rebates
{
    public class VolumeRebateService : IRebate
    {
        private decimal _percentage = 0.0m;
        private List<VolumeRebate> _volumeRebates;
        public VolumeRebateService(List<VolumeRebate> volumeRebates)
        {
            _volumeRebates = volumeRebates;
        }
        private decimal CalculateDiscount(PurchaseWithSubTotal item) => Math.Round((item.SubTotal) * _percentage, 2);
        public IEnumerable<ApplicableRebate> DiscountsApplicable(PurchaseWithSubTotal purchaseWithSubTotal)
        {
            var rebatesApplied = new List<ApplicableRebate>();
            foreach (var volumeRebate in _volumeRebates)
            {
                if (purchaseWithSubTotal.PurchaseModelDto.Quantity > Convert.ToInt64(volumeRebate.QuantityAbove))
                {
                    _percentage = decimal.Parse(volumeRebate.RebatePercent);
                    var discountedData = CalculateDiscount(purchaseWithSubTotal);
                    var appliedRebate = new ApplicableRebate
                    {
                        Type = Enums.RebateType.VolumeRebate,
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
