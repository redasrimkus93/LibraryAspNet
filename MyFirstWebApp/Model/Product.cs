using System.Text.Json.Serialization;

namespace MyFirstWebApp.Model
{
    public class Product
    {
        public string Id { get; set; }
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
