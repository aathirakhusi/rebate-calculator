using Business.Model;

namespace Business.Rebates
{
    public interface IRebate
    {
        IEnumerable<ApplicableRebate> DiscountsApplicable(PurchaseWithSubTotal product);
    }
}
