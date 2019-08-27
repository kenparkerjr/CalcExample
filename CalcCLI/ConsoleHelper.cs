using System;
using System.Collections.Generic;
using System.Text;

namespace CalcCLI
{
    public class ConsoleHelper
    {
        public string ReadUntilCtrlC()
        {
            string result = String.Empty;
            Console.TreatControlCAsInput = true;
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                bool controlPressed = (keyInfo.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control;
                if (controlPressed & keyInfo.Key == ConsoleKey.C)
                    break;
                if (keyInfo.Key == ConsoleKey.Enter)
                    Console.Write("\n");
                else
                    Console.Write(keyInfo.KeyChar);
                result += keyInfo.KeyChar == '\r' ? '\n' : keyInfo.KeyChar;
            }
            Console.TreatControlCAsInput = false;
            return result;
        }
    }
}
