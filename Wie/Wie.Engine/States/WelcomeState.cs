using System;
using System.Collections.Generic;
using System.Text;
using Wie.Data;
using Wie.Game;

namespace Wie.Engine
{
    internal static class WelcomeState
    {
        [StateShower(EngineState.Welcome)]
        internal static IEnumerable<string> ShowState(IDataContext context, IGame game)
        {
            return new string[] 
            { 
                "Welcome to the Worst Idea Ever!",
                "Press RETURN"
            };
        }

        [InputHandler(EngineState.Welcome)]
        internal static Tuple<EngineState?, IEnumerable<string>> HandleInput(IDataContext context, IGame game, string line)
        {
            return EngineState.MainMenu.Alone();
        }
    }
}
