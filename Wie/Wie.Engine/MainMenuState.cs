using System.Collections.Generic;
using Wie.Data;

namespace Wie.Engine
{
    internal static class MainMenuState
    {
        internal static IEnumerable<string> ShowState(IDataContext context)
        {
            return new string[] 
            { 
                "",
                "Main Menu:",
                "1) Start/Continue",
                "0) Quit"
            };
        }

        internal static EngineState? HandleInput(IDataContext context, string line)
        {
            switch(line)
            {
                case "1":
                    return EngineState.MainMenu;
                case "0":
                    return EngineState.ConfirmQuit;
                default:
                    return EngineState.MainMenu;
            }
        }
    }
}
