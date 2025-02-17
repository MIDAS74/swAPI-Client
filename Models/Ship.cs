using System.Text.Json.Serialization;

namespace swAPI_Client.Models;

//Example response:

//HTTP/1.0 200 OK
//Content-Type: application/json
//{
//    "MGLT": "10 MGLT",
//    "cargo_capacity": "1000000000000",
//    "consumables": "3 years",
//    "cost_in_credits": "1000000000000",
//    "created": "2014-12-10T16:36:50.509000Z",
//    "crew": "342953",
//    "edited": "2014-12-10T16:36:50.509000Z",
//    "hyperdrive_rating": "4.0",
//    "length": "120000",
//    "manufacturer": "Imperial Department of Military Research, Sienar Fleet Systems",
//    "max_atmosphering_speed": "n/a",
//    "model": "DS-1 Orbital Battle Station",
//    "name": "Death Star",
//    "passengers": "843342",
//    "films": [
//        "https://swapi.dev/api/films/1/"
//    ],
//    "pilots": [],
//    "starship_class": "Deep Space Mobile Battlestation",
//    "url": "https://swapi.dev/api/starships/9/"
//}

public class Ship
{
    // ugly snake_case naming convention, blame target API
    [JsonPropertyName("MGLT")]
    public string MGLT { get; set; }

    [JsonPropertyName("model")]
    public string model { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("starship_class")]
    public string starship_class { get; set; }

    [JsonPropertyName("cargo_capacity")]
    public string cargo_capacity { get; set; }

    [JsonPropertyName("consumables")]
    public string consumables { get; set; }

    [JsonPropertyName("cost_in_credits")]
    public string cost_in_credits { get; set; }

    [JsonPropertyName("created")]
    public string created { get; set; }

    [JsonPropertyName("crew")]
    public string crew { get; set; }

    [JsonPropertyName("edited")]
    public string edited { get; set; }

    [JsonPropertyName("hyperdrive_rating")]
    public string hyperdrive_rating { get; set; }

    [JsonPropertyName("length")]
    public string length { get; set; }

    [JsonPropertyName("manufacturer")]
    public string manufacturer { get; set; }

    [JsonPropertyName("max_atmosphering_speed")]
    public string max_atmosphering_speed { get; set; }

    [JsonPropertyName("passengers")]
    public string passengers { get; set; }

    [JsonPropertyName("films")]
    public List<string> films { get; set; }

    [JsonPropertyName("pilots")]
    public List<string> pilots { get; set; }

    [JsonPropertyName("url")]
    public string url { get; set; }
}