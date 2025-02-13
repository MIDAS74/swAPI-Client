using System.Text.Json.Serialization;

namespace swAPI_Client.Models;

public class Ship
{
    // ugly snake_case naming convention, blame target API
    [JsonPropertyName("MGLT")]
    public String MGLT { get; set; }
    [JsonPropertyName("model")]
    public String model { get; set; }
    [JsonPropertyName("name")]
    public String name { get; set; }
    [JsonPropertyName("starship_class")]
    public String starship_class { get; set; }
}