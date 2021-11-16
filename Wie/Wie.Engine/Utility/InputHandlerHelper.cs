using System;
using System.Collections.Generic;
using System.Text;

namespace Wie.Engine
{
    internal static class InputHandlerHelper
    {
        private static Tuple<EngineState?, IEnumerable<string>> FromState(EngineState? engineState)
        {
            return new Tuple<EngineState?, IEnumerable<string>>(engineState, Array.Empty<string>());
        }
        internal static Tuple<EngineState?, IEnumerable<string>> Alone(this EngineState engineState)
        {
            return FromState(engineState);
        }
    }
}
