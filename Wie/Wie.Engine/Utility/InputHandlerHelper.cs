using System;
using System.Collections.Generic;

namespace Wie.Engine
{
    internal static class InputHandlerHelper
    {
        private static Tuple<EngineState?, IEnumerable<string>> Build(EngineState? engineState, IEnumerable<string> messages)
        {
            return new Tuple<EngineState?, IEnumerable<string>>(engineState, messages);
        }
        internal static Tuple<EngineState?, IEnumerable<string>> Alone(this EngineState engineState)
        {
            return Build(engineState, Array.Empty<string>());
        }
        internal static Tuple<EngineState?, IEnumerable<string>> WithMessages(this EngineState engineState, params string[] messages)
        {
            return Build(engineState, messages);
        }
    }
}
