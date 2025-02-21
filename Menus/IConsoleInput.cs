using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swAPI_Client.Menus
{
    public interface IConsoleInput
    {
        /// <summary>
        /// Prompt the user to select from an array of choices
        /// </summary>
        /// <param name="title"></param>
        /// <param name="choices"></param>
        /// <returns>string of selected choice</returns>
        string PromptSelection(string title, string[] choices);

        /// <summary>
        /// Prompt the user for string input
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        string PromptText(string message);

        /// <summary>
        /// Prompt the user for decimal input
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        decimal PromptDecimal(string message);
    }
}
