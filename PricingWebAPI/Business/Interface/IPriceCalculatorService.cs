using Business.Model;

namespace Business.Interface
{
    public interface IPriceCalculatorService
    {
        PriceModel GenerateBill(PurchaseModelDto purchaseModelDto, string pricingRules);
    }
}