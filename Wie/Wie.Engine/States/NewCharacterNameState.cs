using System;
using System.Collections.Generic;
using Wie.Data;
using Wie.Game;

namespace Wie.Engine
{
    internal class NewCharacterNameState
    {
        [StateShower(EngineState.NewCharacterName)]
        internal static IEnumerable<string> ShowState(IDataContext context, IGame game)
        {
            return new string[]
            {
                "",
                "New character name:",
            };
        }

        [InputHandler(EngineState.NewCharacterName)]
        internal static Tuple<EngineState?, IEnumerable<string>> HandleInput(IDataContext context, IGame game, string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return EngineState.WorldMenu.Alone();
            }
            else
            {
                var playerCharacter = context.PlayerCharacters.Create(line);
                if (playerCharacter != null)
                {
                    game.PlayerCharacterId = playerCharacter.Id;
                    return EngineState.PlayerCharacterMenu.Alone();
                }
                return EngineState.WorldMenu.WithMessages("", "There is already a player character with that name.");
            }
        }
    }
}
