using System;
using System.Collections.Generic;
using Wie.Data;

namespace Wie.Engine
{
    public class WieEngine : IEngine
    {
        private EngineState? _engineState = EngineState.Welcome;
        private readonly IDataContext _dataContext;
        private readonly Dictionary<EngineState, Func<IDataContext, IEnumerable<string>>> _outputters = new Dictionary<EngineState, Func<IDataContext, IEnumerable<string>>>()
        { 
            [EngineState.ChooseWorld] = ChooseWorldState.ShowState,
            [EngineState.ConfirmQuit] = ConfirmQuitState.ShowState,
            [EngineState.MainMenu] = MainMenuState.ShowState,
            [EngineState.Welcome] = WelcomeState.ShowState,
            [EngineState.WorldMenu] = WorldMenuState.ShowState,
        };
        private readonly Dictionary<EngineState, Func<IDataContext, string, EngineState?>> _inputters = new Dictionary<EngineState, Func<IDataContext, string, EngineState?>>()
        {
            [EngineState.ChooseWorld] = ChooseWorldState.HandleInput,
            [EngineState.ConfirmQuit] = ConfirmQuitState.HandleInput,
            [EngineState.MainMenu] = MainMenuState.HandleInput,
            [EngineState.Welcome] = WelcomeState.HandleInput,
            [EngineState.WorldMenu] = WorldMenuState.HandleInput,
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
            return _outputters[_engineState.Value](_dataContext);
        }

        public void HandleInput(string input)
        {
            _engineState = _inputters[_engineState.Value](_dataContext, input);
        }
    }
}
