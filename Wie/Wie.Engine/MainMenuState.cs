using System.Collections.Generic;
using Wie.Data;
using Wie.Game;

namespace Wie.Engine
{
    internal static class MainMenuState
    {
        [StateShower(EngineState.MainMenu)]
        internal static IEnumerable<string> ShowState(IDataContext context, IGame game)
        {
            return new string[] 
            { 
                "",
                "Main Menu:",
                "1) Start/Continue",
                "0) Quit"
            };
        }

        [InputHandler(EngineState.MainMenu)]
        internal static EngineState? HandleInput(IDataContext context, IGame game, string line)
        {
            switch(line)
            {
                case "1":
                    return EngineState.ChooseWorld;
                case "0":
                    return EngineState.ConfirmQuit;
                default:
                    return EngineState.MainMenu;
            }
        }
    }
}
