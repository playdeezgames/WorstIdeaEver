using System;
using System.Collections.Generic;
using System.Linq;
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
            var characterId = context.PlayerCharacterCreatures.FindCreatureId(playerCharacter.Id);
            var result = new List<string>();
            result.Add("");
            result.Add($"Name: {playerCharacter.Name}");
            if(characterId.HasValue)
            {
                result.Add("1) Continue");
                result.Add("2) Abandon");
            }
            else
            {
                result.Add("1) Start");
            }
            result.Add("0) Never mind");
            return result;
        }

        [InputHandler(EngineState.PlayerCharacterMenu)]
        internal static Tuple<EngineState?, IEnumerable<string>> HandleInput(IDataContext context, IGame game, string line)
        {
            switch (line)
            {
                case "0":
                    return EngineState.WorldMenu.Alone();
                default:
                    return EngineState.PlayerCharacterMenu.Alone();
            }
        }
    }
}
