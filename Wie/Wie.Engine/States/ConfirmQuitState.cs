using System.Collections.Generic;
using Wie.Data;
using Wie.Game;
using System;
using System.Linq;

namespace Wie.Engine
{
    internal class ConfirmQuitState
    {
        [StateShower(EngineState.ConfirmQuit)]
        internal static IEnumerable<string> ShowState(IDataContext context, IGame game)
        {
            return new string[]
            {
                "",
                "Are you sure you want to quit?",
                "1) Yes",
                "0) No"
            };
        }

        [InputHandler(EngineState.ConfirmQuit)]
        internal static Tuple<EngineState?, IEnumerable<string>> HandleInput(IDataContext context, IGame game, string line)
        {
            switch (line)
            {
                case "1":
                    return new Tuple<EngineState?, IEnumerable<string>>(null, Array.Empty<string>());
                case "0":
                    return EngineState.MainMenu.Alone();
                default:
                    return EngineState.ConfirmQuit.Alone();
            }
        }
    }
}
