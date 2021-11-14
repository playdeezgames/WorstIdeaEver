using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wie.Data;

namespace Wie.Engine
{
    public class WieEngine : IEngine
    {
        private EngineState? _engineState = EngineState.Welcome;
        private readonly IDataContext _dataContext;
        private readonly Dictionary<EngineState, Func<IDataContext, IEnumerable<string>>> _outputters = new Dictionary<EngineState, Func<IDataContext, IEnumerable<string>>>();
        private readonly Dictionary<EngineState, Func<IDataContext, string, EngineState?>> _inputters = new Dictionary<EngineState, Func<IDataContext, string, EngineState?>>();
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
                        _outputters[shower.EngineState] = (dataContext) => 
                            (IEnumerable<string>)type.InvokeMember(member.Name, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, null, new object[] { dataContext });
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
                    var shower = member.GetCustomAttribute<InputHandlerAttribute>();
                    if (shower != null)
                    {
                        _inputters[shower.EngineState] = (dataContext, line) =>
                            (EngineState?)type.InvokeMember(member.Name, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, null, new object[] { dataContext, line });
                    }
                }
            }
        }
        public WieEngine(IDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            InitializeOutputters();
            InitializeInputters();
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
