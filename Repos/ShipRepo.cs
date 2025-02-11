using System.Text.Json;
using Spectre.Console;
using swAPI_Client.Models;

namespace swAPI_Client.Repos;

public class ShipRepo
{
    static string baseUrl = "https://swapi.dev/api/";

    public static async Task<List<Ship>> GetShipsAsync(HttpClient httpClient)
    {
        var url = baseUrl + "starships/";
        HttpResponseMessage response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var ships = JsonSerializer.Deserialize<List<Ship>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return ships;
        }
        else
        {
            // Handle error response
            return new List<Ship>();
        }
    }

    public static async Task<Ship> GetShipByIdAsync(HttpClient httpClient, int id)
    {
        var url = baseUrl + $"starships/{id}/";
        HttpResponseMessage response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var ship = JsonSerializer.Deserialize<Ship>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return ship;
        }
        else
        {
            // Handle error response
            return new Ship();
        }
    }
}