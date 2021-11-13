using System;
using System.Collections.Generic;
using System.Text;
using Wie.Data;

namespace Wie.Engine
{
    internal class ConfirmQuitState
    {
        internal static IEnumerable<string> ShowState(IDataContext context)
        {
            return new string[]
            {
                "",
                "Are you sure you want to quit?",
                "1) Yes",
                "0) No"
            };
        }

        internal static EngineState? HandleInput(IDataContext context, string line)
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
