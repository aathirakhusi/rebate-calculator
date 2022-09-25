using Business.Model.Rebate;
using System.Text.Json.Serialization;

namespace Business.Rebate
{
    public class MonthRebate : RebateAbstract
    {
        [JsonPropertyName("month")]
        public string Month { get; set; }

    }
}
