using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swAPI_Client.Menus
{
    public interface IConsoleOutput
    {
        /// <summary>
        /// write a message to the output stream
        /// </summary>
        /// <param name="message"></param>
        void Write(string message);

        /// <summary>
        /// write a collection of strings to the output stream
        /// </summary>
        /// <param name="lines"></param>
        void WriteCollection(IEnumerable<string> lines);
    }
}
