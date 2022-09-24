using Business.Model;

namespace Business.Interface
{
    public interface IPriceCalculatorService
    {
        PurchaseWithSubTotal GenerateBill(PurchaseModelDto purchaseModelDto, string pricingRules);
    }
}