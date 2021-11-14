using System.Collections.Generic;
using System.Linq;
using Wie.Data;

namespace Wie.Engine
{
    internal class WorldMenuState
    {
        [StateShower(EngineState.WorldMenu)]
        internal static IEnumerable<string> ShowState(IDataContext context)
        {
            List<string> lines = new List<string>
            {
                "",
                "World Menu:"
            };
            if (context.GetPlayerCharacters().Any())
            {
                lines.Add("1) Existing Character");
            }
            lines.Add("2) New Character");
            lines.Add("0) Leave World");
            return lines;
        }

        [InputHandler(EngineState.WorldMenu)]
        internal static EngineState? HandleInput(IDataContext context, string line)
        {
            switch (line)
            {
                case "0"://TODO: make a confirm step
                    context.CloseWorld();
                    return EngineState.ChooseWorld;
                case "2":
                    return EngineState.NewCharacterName;
                default:
                    return EngineState.WorldMenu;
            }
        }
    }
}
