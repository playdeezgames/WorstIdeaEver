using System.Collections.Generic;

namespace Wie.Engine
{
    public interface IEngine
    {
        IEnumerable<string> ReceiveOutput();
        void SendInput(string input);
        bool IsRunning();
    }
}
