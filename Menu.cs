using Spectre.Console;
using swAPI_Client.Services;

namespace swAPI_Client;

public class Menu
{
    public void Show(ShipService shipService)
    {
        // basic spectre hello-world, into a prompt for decimal input of mega-lights
        AnsiConsole.Markup("[underline green]Welcome to Star Wars API Client![/]\n\n");

        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Choose an option[/]")
                    .PageSize(3)
                    .AddChoices(new[] {
                    "List all ships", "Calculate pitstops", "Exit"
                    }));

            switch (choice)
            {
                case "List all ships":
                    shipService.PrintList();
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

    public void ShowPitstops(ShipService shipService)
    {
        var megalights = AnsiConsole.Prompt(
            new TextPrompt<decimal>("Enter a distance in Megalights"));
        AnsiConsole.Markup($"For a given distance of {megalights} Megalights, the following pitstops are needed:\n\n");

        // call ShipService for amount of pitstops from internal list
        shipService.CalculatePitstops(megalights);
    }
}