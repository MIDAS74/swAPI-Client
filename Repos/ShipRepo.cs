using Newtonsoft.Json;
using Spectre.Console;
using swAPI_Client.Models;

namespace swAPI_Client.Repos;

public class ShipRepo : IShipRepo
{
    private Ship Ship { get; set; }

    /// <summary>
    /// Gets list of Ship objects as JSON from swapi.dev/api/starships
    /// </summary>
    /// <param name="httpClient"></param>
    /// <returns>Task{List{Ship}}</returns>
    public async Task<List<Ship>> GetShipsAsync(HttpClient httpClient)
    {
        var apiUrl = "https://swapi.dev/api/starships/";

        var ships = new List<Ship>();

        while (!string.IsNullOrEmpty(apiUrl))
        {
            var response = await httpClient.GetAsync(apiUrl);
            var content = await response.Content.ReadAsStringAsync();
            var paginatedShips = JsonConvert.DeserializeObject<PaginatedStarshipResponse>(content);
            ships.AddRange(paginatedShips.Results);
            apiUrl = paginatedShips.Next;
        }

        return ships;
    }
}