using System;

namespace Wie.Engine
{
    internal sealed class StateShowerAttribute: Attribute
    {
        private EngineState _engineState;
        internal EngineState EngineState => _engineState;
        internal StateShowerAttribute(EngineState engineState)
        {
            _engineState = engineState;
        }
    }
}
