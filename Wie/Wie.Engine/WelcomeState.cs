using System;
using System.Collections.Generic;
using System.Text;

namespace Wie.Engine
{
    internal static class WelcomeState
    {
        internal static IEnumerable<string> Write()
        {
            return new string[] 
            { 
                "Welcome to the Worst Idea Ever!",
                "Press RETURN"
            };
        }

        internal static EngineState? Read(string line)
        {
            return EngineState.MainMenu;
        }
    }
}
