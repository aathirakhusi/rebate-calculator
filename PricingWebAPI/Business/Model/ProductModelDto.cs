using System.Text.Json.Serialization;

namespace Business.Model
{
    public class ProductModelDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("unitPrice")]
        public string UnitPrice { get; set; }
    }
}
