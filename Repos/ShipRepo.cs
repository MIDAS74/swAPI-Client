using Newtonsoft.Json;
using swAPI_Client.Models;

namespace swAPI_Client.Repos;

public class ShipRepo : IShipRepo
{
    private readonly HttpClient _httpClient;

    public ShipRepo(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Gets list of Ship objects as JSON from swapi.dev/api/starships
    /// </summary>
    /// <param name="httpClient"></param>
    /// <returns>Task{List{Ship}}</returns>
    public async Task<List<Ship>> GetShipsAsync()
    {
        var apiUrl = "https://swapi.dev/api/starships/";
        var ships = new List<Ship>();

        while (!string.IsNullOrEmpty(apiUrl))
        {
            var response = await _httpClient.GetAsync(apiUrl);
            var content = await response.Content.ReadAsStringAsync();
            var paginatedShips = JsonConvert.DeserializeObject<PaginatedStarshipResponse>(content);
            ships.AddRange(paginatedShips.Results);
            apiUrl = paginatedShips.Next;
        }

        return ships;
    }
}