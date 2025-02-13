using Newtonsoft.Json;
using Spectre.Console;
using swAPI_Client.Models;

namespace swAPI_Client.Repos;

public class ShipRepo
{
    private Ship Ship { get; set; }

    // get list of all ships from API
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

    //public async Task<Ship> GetShipByIdAsync(HttpClient httpClient, int id)
    //{
    //    // get a ship by id
    //}
}