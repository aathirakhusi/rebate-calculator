using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Rebate
{
    public class VolumeRebate
    {
        [JsonPropertyName("quantityAbove")]
        public string QuantityAbove { get; set; }

        [JsonPropertyName("rebatePercent")]
        public string RebatePercent { get; set; }
    }
}
