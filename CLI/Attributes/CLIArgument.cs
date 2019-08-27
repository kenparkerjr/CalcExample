using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CalcCLI
{
    [AttributeUsage(System.AttributeTargets.Property)]
    public class CLIArgument : Attribute
    {
        private readonly string command;
        private readonly string help;

        public string Command
        {
            get
            {
                return command;
            }
        }
        public string Help
        {
            get
            {
                return help;
            }
        }

        public string PropertyName
        {
            get; set;
        }
        public Type PropertyType
        {
            get; set;
        }

        public CLIArgument(string command, string help)
        {
            this.command = command;
            this.help = help;
        }

    }
}
