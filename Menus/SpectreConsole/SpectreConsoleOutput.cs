using Spectre.Console;

namespace swAPI_Client.Menus
{
    public class SpectreConsoleOutput : IConsoleOutput
    {
        /// <summary>
        /// write a message to the AnsiConsole
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            AnsiConsole.MarkupLine(message);
        }

        /// <summary>
        /// write a collection of strings to the AnsiConsole
        /// </summary>
        /// <param name="lines"></param>
        public void WriteCollection(IEnumerable<string> lines)
        {
            if (lines == null || !lines.Any())
            {
                AnsiConsole.MarkupLine("[red]No lines to display.[/]");
                return;
            }

            foreach (var line in lines)
            {
                AnsiConsole.MarkupLine(line);
            }
        }
    }
}
