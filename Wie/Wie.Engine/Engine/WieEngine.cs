using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wie.Data;
using Wie.Game;

namespace Wie.Engine
{
    public class WieEngine : IEngine
    {
        private EngineState? _engineState = EngineState.Welcome;
        private readonly IDataContext _dataContext;
        private readonly IGame _game;
        private readonly Dictionary<EngineState, Func<IDataContext, IGame, IEnumerable<string>>> _outputters = new Dictionary<EngineState, Func<IDataContext, IGame, IEnumerable<string>>>();
        private readonly Dictionary<EngineState, Func<IDataContext, IGame, string, Tuple<EngineState?,IEnumerable<string>>>> _inputters = new Dictionary<EngineState, Func<IDataContext, IGame, string, Tuple<EngineState?,IEnumerable<string>>>>();
        private void InitializeOutputters()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach(var type in assembly.GetTypes())
            {
                foreach(var member in type.GetMembers(BindingFlags.Static | BindingFlags.NonPublic))
                {
                    var shower = member.GetCustomAttribute<StateShowerAttribute>();
                    if(shower!=null)
                    {
                        _outputters[shower.EngineState] = (dataContext, game) => 
                            (IEnumerable<string>)type.InvokeMember(member.Name, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, null, new object[] { dataContext, game });
                    }
                }
            }
        }
        private void InitializeInputters()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                foreach (var member in type.GetMembers(BindingFlags.Static | BindingFlags.NonPublic))
                {
                    var handler = member.GetCustomAttribute<InputHandlerAttribute>();
                    if (handler != null)
                    {
                        _inputters[handler.EngineState] = (dataContext, game, line) =>
                            (Tuple<EngineState?, IEnumerable<string>>)type.InvokeMember(member.Name, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, null, new object[] { dataContext, game, line });
                    }
                }
            }
        }
        public WieEngine(IDataContext dataContext, IGame game)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _game = game ?? throw new ArgumentNullException(nameof(game));
            InitializeOutputters();
            InitializeInputters();
        }

        public bool IsRunning()
        {
            return _engineState.HasValue;
        }

        public IEnumerable<string> ShowState()
        {
            return _outputters[_engineState.Value](_dataContext, _game);
        }

        public IEnumerable<string> HandleInput(string input)
        {
            var result = _inputters[_engineState.Value](_dataContext, _game, input);
            _engineState = result.Item1;
            return result.Item2;
        }
    }
}
