using System.Collections.Generic;
using Wie.Data;

namespace Wie.Engine
{
    internal class WorldMenuState
    {
        internal static IEnumerable<string> ShowState(IDataContext context)
        {
            return new string[]
            {
                "",
                "World Menu:",
                "1) Existing Character",
                "2) New Character",
                "0) Leave World"
            };
        }

        internal static EngineState? HandleInput(IDataContext context, string line)
        {
            switch (line)
            {
                case "0"://TODO: make a confirm step
                    context.CloseWorld();
                    return EngineState.ChooseWorld;
                default:
                    return EngineState.WorldMenu;
            }
        }
    }
}
