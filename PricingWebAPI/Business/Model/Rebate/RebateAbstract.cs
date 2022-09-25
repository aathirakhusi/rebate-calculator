using System.Text.Json.Serialization;

namespace Business.Model.Rebate
{
    public abstract class RebateAbstract
    {
        [JsonPropertyName("rebatePercent")]
        public string RebatePercent { get; set; }
    }
}
