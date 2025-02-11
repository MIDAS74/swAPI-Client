using Spectre.Console;

namespace swAPI_Client;

public class Menu
{
    public void Show()
    {
        // basic spectre hello-world, into a prompt for decimal input of mega-lights
        AnsiConsole.Markup("[underline green]Welcome to Star Wars API Client![/]\n\n");

        var megalights = AnsiConsole.Prompt(
            new TextPrompt<decimal>("Enter a distance in Megalights"));

        AnsiConsole.Markup($"For a given distance of {megalights} Megalights, the following pitstops are needed:\n\n");
    }
}