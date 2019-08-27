using System;
using System.Collections.Generic;
using System.Text;

namespace CalcCLI
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class CLIProgram : System.Attribute
    {
        private readonly string usage;
        private readonly string version;

        public string Usage
        {
            get
            {
                return usage;
            }
        }
        public string Version
        {
            get
            {
                return version;
            }
        }
        public CLIProgram(string usage, string version = "")
        {
            this.usage = usage;
            this.version = version;
        }
    }
 
}
