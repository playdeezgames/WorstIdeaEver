using System;
using System.Collections.Generic;
using System.Linq;
using Wie.Data;
using Wie.Game;

namespace Wie.Engine
{
    internal class WorldMenuState
    {
        [StateShower(EngineState.WorldMenu)]
        internal static IEnumerable<string> ShowState(IDataContext context, IGame game)
        {
            List<string> lines = new List<string>
            {
                "",
                "World Menu:"
            };
            if (context.PlayerCharacters.All.Any())
            {
                lines.Add("1) Existing Character");
            }
            lines.Add("2) New Character");
            lines.Add("0) Leave World");
            return lines;
        }

        [InputHandler(EngineState.WorldMenu)]
        internal static Tuple<EngineState?, IEnumerable<string>> HandleInput(IDataContext context, IGame game, string line)
        {
            switch (line)
            {
                case "0":
                    context.CloseWorld();
                    return EngineState.ChooseWorld.Alone();
                case "1":
                    return EngineState.ChooseCharacter.Alone();
                case "2":
                    return EngineState.NewCharacterName.Alone();
                default:
                    return EngineState.WorldMenu.Alone();
            }
        }
    }
}
