using System;
using System.Collections.Generic;
using Wie.Data;

namespace Wie.Engine
{
    public class WieEngine : IEngine
    {
        private EngineState? _engineState = EngineState.Welcome;
        private IDataContext _dataContext;
        private readonly Dictionary<EngineState, Func<IEnumerable<string>>> _outputters = new Dictionary<EngineState, Func<IEnumerable<string>>>()
        { 
            [EngineState.Welcome] = WelcomeState.ShowState,
            [EngineState.MainMenu] = MainMenuState.ShowState,
            [EngineState.ConfirmQuit] = ConfirmQuitState.ShowState
        };
        private readonly Dictionary<EngineState, Func<string, EngineState?>> _inputters = new Dictionary<EngineState, Func<string, EngineState?>>()
        {
            [EngineState.Welcome] = WelcomeState.HandleInput,
            [EngineState.MainMenu] = MainMenuState.HandleInput,
            [EngineState.ConfirmQuit] = ConfirmQuitState.HandleInput
        };
        public WieEngine(IDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public bool IsRunning()
        {
            return _engineState.HasValue;
        }

        public IEnumerable<string> ShowState()
        {
            return _outputters[_engineState.Value]();
        }

        public void HandleInput(string input)
        {
            _engineState = _inputters[_engineState.Value](input);
        }
    }
}
