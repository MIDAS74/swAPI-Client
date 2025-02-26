using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swAPI_Client.Menus
{
    public class MockConsoleOutput : IConsoleOutput
    {
        public List<string> Output { get; } = new List<string>();
        public IConsoleOutput Object { get; internal set; }

        public void Write(string message)
        {
            Output.Add(message);
        }

        public void WriteCollection(IEnumerable<string> lines)
        {
            Output.AddRange(lines);
        }
    }

    public class MockConsoleInput : IConsoleInput
    {
        public List<string> prompts { get; } = new List<string>();
        public Queue<string> _inputs { get; } = new Queue<string>();
        public IConsoleInput Object { get; internal set; }

        public MockConsoleInput(List<string> inputQueue)
        {
            foreach (var input in inputQueue)
            {
                _inputs.Enqueue(input);
            }
        }

        public decimal PromptDecimal(string message)
        {
            prompts.Add(message);
            return decimal.Parse(_inputs.Dequeue());
        }

        public string PromptSelection(string title, string[] choices)
        {
            prompts.AddRange(choices);
            return _inputs.Dequeue();
        }

        public string PromptText(string message)
        {
            prompts.Add(message);
            return _inputs.Dequeue();
        }
    }
}
