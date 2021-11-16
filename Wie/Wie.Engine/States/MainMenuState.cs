using System;
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
        internal static Tuple<EngineState?, IEnumerable<string>> HandleInput(IDataContext context, IGame game, string line)
        {
            switch(line)
            {
                case "1":
                    return EngineState.ChooseWorld.Alone();
                case "0":
                    return EngineState.ConfirmQuit.Alone();
                default:
                    return EngineState.MainMenu.Alone();
            }
        }
    }
}
