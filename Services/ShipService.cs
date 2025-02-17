using Spectre.Console;
using swAPI_Client.Models;
using swAPI_Client.Repos;

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
                AnsiConsole.MarkupLine($"[bold yellow]Name:\t[/]{ship.name}\n" +
                    $"[bold yellow]Model:\t[/]{ship.model}\n" +
                    $"[bold yellow]Class:\t[/]{ship.starship_class}\n" +
                    $"[bold yellow]Megalights:\t[/]{ship.MGLT}\n\n" +
                    $"[bold yellow]Consumables:\t[/]{ship.consumables}\n\n");
            }
        }

        public void CalculatePitstops(decimal megalights)
        {
            // for each ship in list, check that MGLT is not unknown
            foreach (var ship in ships)
            {
                if (!(ship.MGLT == "unknown"))
                {
                    // parse out number and period from consumables
                    // from format "3 {period} e.g. days, weeks, months years"
                    // get hours from period
                    var consumables = ship.consumables.Split(' ');
                    var period = consumables[1];
                    decimal hours;

                    switch (period)
                    {
                        case "day":
                        case "days":
                            hours = 24;
                            break;
                        case "week":
                        case "weeks":
                            hours = 168;
                            break;
                        case "month":
                        case "months":
                            hours = 24 * 30;
                            break;
                        case "year":
                        case "years":
                            hours = 8766;
                            break;
                        default:
                            hours = 0;
                            break;
                    }
                    hours *= Convert.ToDecimal(consumables[0]);

                    var stops = Math.Floor(megalights / (Convert.ToDecimal(ship.MGLT) * hours));
                    // output
                    AnsiConsole.MarkupLine($"[bold]Name:\t[/]{ship.name}\n" +
                        $"[bold]Model:\t[/]{ship.model}\n" +
                        $"[bold]Class:\t[/]{ship.starship_class}\n" +
                        $"[bold]Megalights:\t[/]{ship.MGLT}\n" +
                        $"[bold]Consumables:\t[/]{ship.consumables}\n" +
                        $"[bold cyan]Pitstops:\t[/]{Math.Ceiling(stops)}\n\n");
                }
            }
        }

        public void GetShipData(string name)
        {
            var ship = ships.FirstOrDefault(s => s.name == name);
            if (ship == null)
            {
                AnsiConsole.MarkupLine("[bold red]Ship not found![/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[bold]Name:\t[/]{ship.name}\n" +
                    $"[bold]Model:\t[/]{ship.model}\n" +
                    $"[bold]Class:\t[/]{ship.starship_class}\n" +
                    $"[bold]Megalights:\t[/]{ship.MGLT}\n" +
                    $"[bold]Cargo Capacity:\t[/]{ship.cargo_capacity}\n" +
                    $"[bold]Consumables:\t[/]{ship.consumables}\n" +
                    $"[bold]Cost in Credits:\t[/]{ship.cost_in_credits}\n" +
                    $"[bold]Created:\t[/]{ship.created}\n" +
                    $"[bold]Crew:\t[/]{ship.crew}\n" +
                    $"[bold]Edited:\t[/]{ship.edited}\n" +
                    $"[bold]Hyperdrive Rating:\t[/]{ship.hyperdrive_rating}\n" +
                    $"[bold]Length:\t[/]{ship.length}\n" +
                    $"[bold]Manufacturer:\t[/]{ship.manufacturer}\n" +
                    $"[bold]Max Atmosphering Speed:\t[/]{ship.max_atmosphering_speed}\n" +
                    $"[bold]Passengers:\t[/]{ship.passengers}\n" +
                    $"[bold]Films:\t[/]{string.Join(", ", ship.films)}\n" +
                    $"[bold]Pilots:\t[/]{string.Join(", ", ship.pilots)}\n" +
                    $"[bold]URL:\t[/]{ship.url}\n\n");
            }
        }

    }

}
