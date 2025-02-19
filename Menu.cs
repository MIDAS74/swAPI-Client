using Spectre.Console;
using swAPI_Client.Services;

namespace swAPI_Client;

public class Menu
{

    /// <summary>
    /// Spectre.Console menu loop, options currently include: 
    /// partial data on all ships in list, full data on singular ships
    /// calculating pitstops
    /// </summary>
    /// <param name="shipService"></param>
    public void Show(ShipService shipService)
    {
        AnsiConsole.Markup("[underline green]Welcome to Star Wars API Client![/] \n(navigate with up and down arrow keys, enter to confirm. You may be prompted for other input, just type and enter again)\n\n");

        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Choose an option[/]")
                    .PageSize(4)
                    .AddChoices(new[] {
                    "List all ships", "Full Ship Data", "Calculate pitstops", "Exit"
                    }));

            switch (choice)
            {
                case "List all ships":
                    shipService.PrintList();
                    break;
                case "Full Ship Data":
                    GetShipData(shipService);
                    break;
                case "Calculate pitstops":
                    ShowPitstops(shipService);
                    break;
                case "Exit":
                    AnsiConsole.Markup("[bold red]Goodbye![/]");
                    return;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// calls CalculatePitstops for Show()
    /// </summary>
    /// <param name="shipService"></param>
    public void ShowPitstops(ShipService shipService)
    {
        var megalights = AnsiConsole.Prompt(
            new TextPrompt<decimal>("Enter a distance in Megalights"));
        AnsiConsole.Markup($"For a given distance of {megalights} Megalights, the following pitstops are needed:\n\n");

        // call ShipService for amount of pitstops from internal list
        shipService.CalculatePitstops(megalights);
    }

    /// <summary>
    /// calls GetShipData for Show()
    /// </summary>
    /// <param name="shipService"></param>
    public void GetShipData(ShipService shipService)
    {
        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter ship name"));

        // call ShipService for full data on single ship
        shipService.GetShipData(name);
    }
}