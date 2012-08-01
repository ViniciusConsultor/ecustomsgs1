using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientServerExchange.Args
{
    public class LoginArgs:EventArgs
    {
        public object LoginInfo;

        private string _username;
        private string _password;
        public LoginArgs(string userName, string passWord)
        {
            _username = userName;
            _password = passWord;
        }

				public override string ToString()
				{
					return "Name: " + _username + " - Password: " + _password;
					//return base.ToString();
				}
    }
}
