using swAPI_Client.Services;
using swAPI_Client.Menus.SpectreConsole;
using swAPI_Client.Repos;
using Spectre.Console;

namespace swAPI_Client.Menus;

public class Menu
{
    private readonly IShipService _shipService;
    private readonly IConsoleOutput _consoleOutput;
    private readonly IConsoleInput _consoleInput;

    public Menu(IShipService shipService, IConsoleOutput consoleOutput, IConsoleInput consoleInput)
    {
        _shipService = shipService;
        _consoleOutput = consoleOutput;
        _consoleInput = consoleInput;
    }

    /// <summary>
    /// generic console menu loop
    /// </summary>
    /// <param name="shipService"></param>
    public void Show()
    {
        _consoleOutput.Write("[underline green]Welcome to Star Wars API Client![/] \n(navigate with up and down arrow keys, enter to confirm. You may be prompted for other input, just type and enter again)\n\n");

        while (true)
        {
            var choice = _consoleInput.PromptSelection("Choose an option",
                new[] {
                    "List all ships", "Full Ship Data", "Calculate pitstops", "Exit"
                });
            switch (choice)
            {
                case "List all ships":
                    _consoleOutput.WriteCollection(_shipService.ListShips());
                    break;
                case "Full Ship Data":
                    GetShipData();
                    break;
                case "Calculate pitstops":
                    ShowPitstops();
                    break;
                case "Exit":
                    _consoleOutput.Write("[bold red]Goodbye![/]");
                    return;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// calls CalculatePitstops and outputs results
    /// </summary>
    /// <param name="shipService"></param>
    public void ShowPitstops()
    {
        var megalights = _consoleInput.PromptDecimal("Enter a distance in Megalights");
        _consoleOutput.Write($"For a given distance of {megalights} Megalights, the following pitstops are needed:\n\n");
        _consoleOutput.WriteCollection(_shipService.CalculatePitstops(megalights));
    }

    /// <summary>
    /// calls GetShipData and outputs results
    /// </summary>
    /// <param name="shipService"></param>
    public void GetShipData()
    {
        var name = _consoleInput.PromptText("Enter ship name");
        // call ShipService for full data on single ship
        _consoleOutput.Write(_shipService.GetShipByName(name));
    }
}