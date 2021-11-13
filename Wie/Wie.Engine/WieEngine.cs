using System;
using System.Collections.Generic;

namespace Wie.Engine
{
    public class WieEngine : IEngine
    {
        private EngineState? _engineState = EngineState.Welcome;
        private readonly Dictionary<EngineState, Func<IEnumerable<string>>> _outputters = new Dictionary<EngineState, Func<IEnumerable<string>>>()
        { 
            [EngineState.Welcome] = WelcomeState.Write,
            [EngineState.MainMenu] = MainMenuState.Write
        };
        private readonly Dictionary<EngineState, Func<string, EngineState?>> _inputters = new Dictionary<EngineState, Func<string, EngineState?>>()
        {
            [EngineState.Welcome] = WelcomeState.Read,
            [EngineState.MainMenu] = MainMenuState.Read
        };

        public bool IsRunning()
        {
            return _engineState.HasValue;
        }

        public IEnumerable<string> ReceiveOutput()
        {
            return _outputters[_engineState.Value]();
        }

        public void SendInput(string input)
        {
            _inputters[_engineState.Value](input);
        }
    }
}
