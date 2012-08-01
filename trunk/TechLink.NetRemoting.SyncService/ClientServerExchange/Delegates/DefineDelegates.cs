using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientServerExchange.Args;

namespace ClientServerExchange.Delegates
{
    public delegate void OnLoginHandler(object sender, LoginArgs e);
		public delegate void OnLogoutHandler(object sender, LoginArgs e);

    public delegate void OnDeleteUserHandler(object sender, object e);
}
