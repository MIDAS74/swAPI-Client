using System.Text.Json.Serialization;

namespace swAPI_Client.Models
{
    /// <summary>
    /// Contain the List format JSON return from swapi.dev/api/starships/
    /// </summary>
    public class PaginatedStarshipResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Ship> Results { get; set; }
    }
}
