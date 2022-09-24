using Business.Model;

namespace Business.Interface
{
    public interface IPriceCalculatorService
    {
        ApplicableRebate GenerateBill(PurchaseModelDto purchaseModelDto, string pricingRules);
    }
}