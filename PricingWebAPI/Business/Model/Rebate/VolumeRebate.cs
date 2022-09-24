using Business.Model.Rebate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Rebate
{
    public class VolumeRebate : RebateAbstract
    {
        [JsonPropertyName("quantityAbove")]
        public string QuantityAbove { get; set; }

    }
}
