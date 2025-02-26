using Spectre.Console;

namespace swAPI_Client.Menus.SpectreConsole
{
    public class SpectreConsoleInput : IConsoleInput
    {
        /// <summary>
        /// Prompt the user to select from an array of choices
        /// </summary>
        /// <param name="title"></param>
        /// <param name="choices"></param>
        /// <returns></returns>
        public string PromptSelection(string title, string[] choices)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(4)
                    .AddChoices(choices));
        }

        /// <summary>
        /// Prompt the user for string input
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string PromptText(string message)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>(message));

        }

        /// <summary>
        /// Prompt the user for decimal input
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public decimal PromptDecimal(string message)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<decimal>(message));
        }
    }
}
