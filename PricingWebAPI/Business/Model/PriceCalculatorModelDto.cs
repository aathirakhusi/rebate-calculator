using Business.Rebate;
using System.Text.Json.Serialization;

namespace Business.Model
{

    public class PriceCalculatorModel
    {
        [JsonPropertyName("rebateTypes")]
        public RebateTypes RebateTypes { get; set; }
        [JsonPropertyName("products")]
        public List<ProductModelDto> Products { get; set; }
    }

}
