using System.Collections.Generic;
using Wie.Data;
using Wie.Game;

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
        internal static EngineState? HandleInput(IDataContext context, IGame game, string line)
        {
            switch (line)
            {
                case "1":
                    return null;
                case "0":
                    return EngineState.MainMenu;
                default:
                    return EngineState.ConfirmQuit;
            }
        }
    }
}
