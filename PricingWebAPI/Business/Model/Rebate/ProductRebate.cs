﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Rebate
{
    public class ProductRebate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rebatePercent")]
        public string RebatePercent { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
