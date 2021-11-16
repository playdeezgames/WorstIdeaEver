using System.Collections.Generic;

namespace Wie.Engine
{
    public interface IEngine
    {
        IEnumerable<string> ShowState();
        IEnumerable<string> HandleInput(string input);
        bool IsRunning();
    }
}
