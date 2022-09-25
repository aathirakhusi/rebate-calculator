using System.Text.Json.Serialization;

namespace Business.Rebate
{
    public class RebateTypes
    {
        [JsonPropertyName("customerRebate")]
        public List<CustomerRebate> CustomerRebate { get; set; }

        [JsonPropertyName("productRebate")]
        public List<ProductRebate> ProductRebate { get; set; }

        [JsonPropertyName("volumeRebate")]
        public List<VolumeRebate> VolumeRebate { get; set; }

        [JsonPropertyName("monthRebate")]
        public List<MonthRebate> MonthRebate { get; set; }
    }
}
