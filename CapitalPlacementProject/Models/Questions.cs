using Newtonsoft.Json;
using static CapitalPlacementProject.Enums.Enum;

namespace CapitalPlacementProject.Models
{
    public class Questions
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public List<string>? Choices { get; set; }
    }
}
