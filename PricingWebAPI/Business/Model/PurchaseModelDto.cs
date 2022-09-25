namespace Business.Model
{
    public class PurchaseModelDto
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
