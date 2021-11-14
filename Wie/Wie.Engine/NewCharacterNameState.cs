using System;
using System.Collections.Generic;
using System.Text;
using Wie.Data;

namespace Wie.Engine
{
    internal class NewCharacterNameState
    {
        [StateShower(EngineState.NewCharacterName)]
        internal static IEnumerable<string> ShowState(IDataContext context)
        {
            return new string[]
            {
                "",
                "New character name:",
            };
        }

        [InputHandler(EngineState.NewCharacterName)]
        internal static EngineState? HandleInput(IDataContext context, string line)
        {
            if(string.IsNullOrEmpty(line))
            {
                return EngineState.WorldMenu;
            }
            else
            {
                return EngineState.WorldMenu;
            }
        }
    }
}
