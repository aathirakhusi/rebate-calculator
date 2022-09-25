using Business.Model.Rebate;
using System.Text.Json.Serialization;

namespace Business.Rebate
{
    public class CustomerRebate : RebateAbstract
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
