using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractServerConsole
{
    public interface ILogInLogOutNotifier
    {
        void NotifyLogIn(string userName);
        void NotifyLogOut(string userName);
    }
}
