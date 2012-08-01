using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractServerConsole
{
    public interface IServerConsole
    {
        void Start(string[] args);
        bool Started { get; }
        void Stop();
        string ServerPort { get; }
        void CleanUpBeforeClosed();
    }
}
