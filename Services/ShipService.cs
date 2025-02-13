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
    public class ShipService
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

        public void CalculatePitstops(decimal megalights)
        {
            foreach (var ship in ships)
            {
                if (ship.MGLT == "unknown")
                {
                    //AnsiConsole.MarkupLine($"[bold]Name:\t[/]{ship.name}\n" +
                    //    $"[bold]Model:\t[/]{ship.model}\n" +
                    //    $"[bold]Class:\t[/]{ship.starship_class}\n" +
                    //    $"[bold]Megalights:\t[/]{ship.MGLT}\n" +
                    //    $"[bold cyan]Pitstops:\t[/]Unknown\n\n");
                }
                else
                {
                    var stops = megalights / decimal.Parse(ship.MGLT);
                    AnsiConsole.MarkupLine($"[bold]Name:\t[/]{ship.name}\n" +
                        $"[bold]Model:\t[/]{ship.model}\n" +
                        $"[bold]Class:\t[/]{ship.starship_class}\n" +
                        $"[bold]Megalights:\t[/]{ship.MGLT}\n" +
                        $"[bold cyan]Pitstops:\t[/]{Math.Ceiling(stops)}\n\n");
                }
            }
        }
    }
}
