using Business.Model.Rebate;
using System.Text.Json.Serialization;

namespace Business.Rebate
{
    public class ProductRebate : RebateAbstract
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
