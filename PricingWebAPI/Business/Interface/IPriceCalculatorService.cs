using Business.Model;

namespace Business.Interface
{
    public interface IPriceCalculatorService
    {
        ProductWithSubTotal GenerateBill(PurchaseModelDto purchaseModelDto, string pricingRules);
    }
}