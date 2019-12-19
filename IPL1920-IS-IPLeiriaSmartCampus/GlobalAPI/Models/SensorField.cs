using Newtonsoft.Json;

namespace GlobalAPI.Models
{
    public class SensorField
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "min_value")]
        public string MinValue { get; set; }

        [JsonProperty(PropertyName = "max_value")]
        public string MaxValue { get; set; }
    }
}