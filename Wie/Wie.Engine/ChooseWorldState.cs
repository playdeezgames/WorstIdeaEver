﻿using System.Collections.Generic;
using Wie.Data;

namespace Wie.Engine
{
    internal static class ChooseWorldState
    {
        internal static IEnumerable<string> ShowState(IDataContext context)
        {
            return new string[]
            {
                "",
                "Choose World:",
                "1) World 1",
                "2) World 2",
                "3) World 3",
                "4) World 4",
                "5) World 5",
                "0) Never mind"
            };
        }

        internal static EngineState? HandleInput(IDataContext context, string line)
        {
            switch (line)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    context.OpenWorld($"World{line}");
                    return EngineState.WorldMenu;
                case "0":
                    return EngineState.MainMenu;
                default:
                    return EngineState.ChooseWorld;
            }
        }

    }
}
