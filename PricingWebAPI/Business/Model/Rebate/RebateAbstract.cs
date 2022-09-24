using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Model.Rebate
{
    public abstract class RebateAbstract
    {
        [JsonPropertyName("rebatePercent")]
        public string RebatePercent { get; set; }
    }
}
