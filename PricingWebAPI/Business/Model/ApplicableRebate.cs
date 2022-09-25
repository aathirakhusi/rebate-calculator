using Business.Enums;

namespace Business.Model
{
    public class ApplicableRebate
    {
        public RebateType Type { get; set; }
        public string Text { get; set; }
        public decimal GrandTotal { get; set; }
        public PurchaseWithSubTotal PurchaseDetails { get; set; }
    }
}
