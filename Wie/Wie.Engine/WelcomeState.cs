using System;
using System.Collections.Generic;
using System.Text;
using Wie.Data;

namespace Wie.Engine
{
    internal static class WelcomeState
    {
        internal static IEnumerable<string> ShowState(IDataContext context)
        {
            return new string[] 
            { 
                "Welcome to the Worst Idea Ever!",
                "Press RETURN"
            };
        }

        internal static EngineState? HandleInput(IDataContext context, string line)
        {
            return EngineState.MainMenu;
        }
    }
}
