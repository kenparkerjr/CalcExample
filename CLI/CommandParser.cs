using System;
using System.Collections.Generic;
using System.Text;

namespace CLI
{
    public class CommandParser : ICommandParser
    {
        public CommandParser()
        {
            CommandPrefix = '/';
        }
        public char CommandPrefix { get; private set; }
        public IDictionary<string, string> Parse(string[] args)
        {
            var commandDictionary = new Dictionary<string, string>();
            string command = String.Empty;
            string parameter = String.Empty;
            foreach (string argument in args)
            {
                if (argument.StartsWith(CommandPrefix))
                    command = argument.TrimStart(CommandPrefix).ToLower();
                else if(String.IsNullOrWhiteSpace(command) == false)
                {
                    parameter = argument;
                    if (commandDictionary.ContainsKey(command) == false)
                        commandDictionary.Add(command, parameter);
                    command = String.Empty;
                    parameter = String.Empty;
                }
            }
            return commandDictionary;
        }
    }
}
