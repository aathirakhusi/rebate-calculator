using Business.Rebate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
