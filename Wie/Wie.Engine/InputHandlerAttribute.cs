using System;
using System.Collections.Generic;
using System.Text;

namespace Wie.Engine
{
    internal sealed class InputHandlerAttribute: Attribute
    {
        private EngineState _engineState;
        internal EngineState EngineState => _engineState;
        internal InputHandlerAttribute(EngineState engineState)
        {
            _engineState = engineState;
        }
    }
}
