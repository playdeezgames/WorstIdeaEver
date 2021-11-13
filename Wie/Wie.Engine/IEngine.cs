using System.Collections.Generic;

namespace Wie.Engine
{
    public interface IEngine
    {
        IEnumerable<string> ShowState();
        void HandleInput(string input);
        bool IsRunning();
    }
}
