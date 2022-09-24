using System.Text.Json.Serialization;

namespace PricingWebAPI.Model
{
    public class RebatePriceResponseModel
    {
        [JsonPropertyName("appliedDiscountType")]
        public string AppliedDiscountType { get; set; }

        [JsonPropertyName("discountText")]
        public string DiscountText { get; set; }

        [JsonPropertyName("grandTotal")]
        public decimal GrandTotal { get; set; }

        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }

        [JsonPropertyName("totalUnits")]
        public int TotalUnits { get; set; }

        [JsonPropertyName("dateOfPurchase")]
        public DateTime DateOfPurchase { get; set; }

        [JsonPropertyName("actualCost")]
        public decimal ActualCost { get; set; }
    }
}
