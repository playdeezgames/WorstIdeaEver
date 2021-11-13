using System;
using System.Collections.Generic;
using System.Text;

namespace Wie.Engine
{
    public class WieEngine : IEngine
    {
        public bool IsRunning()
        {
            return true;
        }

        public IEnumerable<string> ReceiveOutput()
        {
            return new string[] 
            { 
                "Welcome to the Worst Idea Ever!"
            };
        }

        public void SendInput(string input)
        {
            throw new NotImplementedException();
        }
    }
}
