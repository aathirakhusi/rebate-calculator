using Business.Model.Rebate;
using System.Text.Json.Serialization;

namespace Business.Rebate
{
    public class VolumeRebate : RebateAbstract
    {
        [JsonPropertyName("quantityAbove")]
        public string QuantityAbove { get; set; }

    }
}
