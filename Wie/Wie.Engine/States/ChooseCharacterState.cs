using System;
using System.Collections.Generic;
using Wie.Data;
using Wie.Game;

namespace Wie.Engine
{
    internal class ChooseCharacterState
    {
        [StateShower(EngineState.ChooseCharacter)]
        internal static IEnumerable<string> ShowState(IDataContext context, IGame game)
        {
            List<string> output = new List<string>
            { 
                "",
                "Choose Character:"
            };
            int index = 1;
            foreach(var playerCharacter in context.PlayerCharacters.All)
            {
                output.Add($"{index}) {playerCharacter.Name}");
                index++;
            }
            output.Add("0) Never mind");
            return output;
        }

        [InputHandler(EngineState.ChooseCharacter)]
        internal static Tuple<EngineState?, IEnumerable<string>> HandleInput(IDataContext context, IGame game, string line)
        {
            switch(line)
            {
                case "0":
                    return EngineState.WorldMenu.Alone();
                default:
                    if(int.TryParse(line, out var index))
                    {
                        index--;//menu is 1 based... list is 0 based
                        if(index>=0 && index<context.PlayerCharacters.All.Count)
                        {
                            var playerCharacter = context.PlayerCharacters.All[index];
                            game.PlayerCharacterId = playerCharacter.Id;
                            return EngineState.PlayerCharacterMenu.Alone();
                        }
                    }
                    return EngineState.ChooseCharacter.WithMessages("","Please make a valid selection.");
            }
        }
    }
}
