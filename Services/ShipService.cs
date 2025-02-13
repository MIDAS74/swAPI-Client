using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swAPI_Client.Models;
using swAPI_Client.Repos;
using Spectre.Console;

namespace swAPI_Client.Services
{
    internal class ShipService
    {
        private HttpClient httpClient = new HttpClient();
        private List<Ship> ships = new List<Ship>();

        public async Task PopulateList()
        {
            ShipRepo shipRepo = new ShipRepo();
            var shipsList = await shipRepo.GetShipsAsync(httpClient);
            ships.AddRange(shipsList);
        }

        public void PrintList()
        {
            foreach (var ship in ships)
            {
                AnsiConsole.MarkupLine($"[bold]Name:\t[/]{ship.name}\n" +
                    $"[bold]Model:\t[/]{ship.model}\n" +
                    $"[bold]Class:\t[/]{ship.starship_class}\n" +
                    $"[bold]Megalights:\t[/]{ship.MGLT}\n\n");
            }
        }
    }
}
