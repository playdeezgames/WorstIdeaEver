using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wie.Data;
using Wie.Game;

namespace Wie.Engine.States
{
    internal class PlayerCharacterMenuState
    {
        [StateShower(EngineState.PlayerCharacterMenu)]
        internal static IEnumerable<string> ShowState(IDataContext context, IGame game)
        {
            var playerCharacter = context.PlayerCharacters.All.Single(x => x.Id == game.PlayerCharacterId.Value);
            return new string[] 
            { 
                "",
                $"Name: {playerCharacter.Name}",
                //"1) Embark",
                //"2) Delete",
                "0) Never mind"
            };
        }

        [InputHandler(EngineState.PlayerCharacterMenu)]
        internal static Tuple<EngineState?, IEnumerable<string>> HandleInput(IDataContext context, IGame game, string line)
        {
            switch(line)
            {
                case "0":
                    return EngineState.WorldMenu.Alone();
                default:
                    return EngineState.PlayerCharacterMenu.Alone();
            }
        }
    }
}
