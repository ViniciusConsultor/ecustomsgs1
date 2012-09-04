namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;
    using System.Text.RegularExpressions;

    [Serializable]
    public class ConnectionString
    {
        private readonly string _connectionFormatString;
        private string _database;
        private string _databaseFieldName;
        private static readonly ConnectionString _emptyConnectionString = new ConnectionString();
        private string _password;
        private string _rawOriginal;
        private string _securityType;
        private string _securityTypeText;
        private string _server;
        private string _serverFieldName;
        private readonly string _trustedConnectionFormatString;
        private string _userId;

        private ConnectionString()
        {
            this._connectionFormatString = "{0}={1};{2}={3};User ID={4};Password={5};{6}";
            this._trustedConnectionFormatString = "{0}={1};{2}={3};{4}";
            this._databaseFieldName = "Database";
            this._serverFieldName = "Server";
        }

        private ConnectionString(string connectionString)
        {
            this._connectionFormatString = "{0}={1};{2}={3};User ID={4};Password={5};{6}";
            this._trustedConnectionFormatString = "{0}={1};{2}={3};{4}";
            this._databaseFieldName = "Database";
            this._serverFieldName = "Server";
            this._rawOriginal = connectionString;
            this.ParseServer(connectionString);
            this.ParseDatabase(connectionString);
            this.ParseUserId(connectionString);
            this.ParsePassword(connectionString);
            this.ParseSecurityType(connectionString);
        }

        public static implicit operator string(ConnectionString connectionString)
        {
            return connectionString.ToString();
        }

        public static implicit operator ConnectionString(string connectionString)
        {
            return new ConnectionString(connectionString);
        }

        public static ConnectionString Parse(string connectionString)
        {
            return new ConnectionString(connectionString);
        }

        private bool ParseDatabase(string connectionString)
        {
            Regex regex = new Regex(@"(?<databaseField>Database|Initial Catalog)\s*=\s*(?<database>.*?)(;|$|\s)", RegexOptions.IgnoreCase);
            Match match = regex.Match(connectionString);
            if (match.Success)
            {
                this._database = match.Groups["database"].Value;
                this._databaseFieldName = match.Groups["databaseField"].Value;
                if (!string.IsNullOrEmpty(this._database))
                {
                    return true;
                }
            }
            if (string.IsNullOrEmpty(this._database))
            {
                match = new Regex(@"AttachDbFilename\s*=\s*\|DataDirectory\|\\(?<database>.*?)(;|$|\s)", RegexOptions.IgnoreCase).Match(connectionString);
                if (match.Success)
                {
                    this._database = match.Groups["database"].Value;
                    if (!string.IsNullOrEmpty(this._database))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ParsePassword(string connectionString)
        {
            Match match = new Regex(@"Password\s*=\s*(?<password>.*?)(;|$|\s)", RegexOptions.IgnoreCase).Match(connectionString);
            if (match.Success)
            {
                this._password = match.Groups["password"].Value;
                return true;
            }
            return false;
        }

        private bool ParseSecurityType(string connectionString)
        {
            Match match = new Regex(@"(?<securityTypeField>Integrated\s+Security|Trusted_Connection)\s*=\s*(?<securityType>.*?)(;|$|\s)", RegexOptions.IgnoreCase).Match(connectionString);
            if (match.Success)
            {
                this._securityType = match.Groups["securityType"].Value;
                this._securityTypeText = match.Groups["securityTypeField"].Value + "=" + this._securityType + ";";
                return true;
            }
            return false;
        }

        private bool ParseServer(string connectionString)
        {
            Match match = new Regex(@"(?<serverField>Data\s+Source|Server)\s*=\s*(?<server>.*?)(;|$|\s)", RegexOptions.IgnoreCase).Match(connectionString);
            if (match.Success)
            {
                this._server = match.Groups["server"].Value;
                this._serverFieldName = match.Groups["serverField"].Value;
                return true;
            }
            return false;
        }

        private bool ParseUserId(string connectionString)
        {
            Match match = new Regex(@"User\s+Id\s*=\s*(?<userId>.*?)(;|$|\s)", RegexOptions.IgnoreCase).Match(connectionString);
            if (match.Success)
            {
                this._userId = match.Groups["userId"].Value;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            if (this.TrustedConnection)
            {
                return string.Format(this._trustedConnectionFormatString, new object[] { this._serverFieldName, this._server, this._databaseFieldName, this._database, this._securityTypeText });
            }
            return string.Format(this._connectionFormatString, new object[] { this._serverFieldName, this._server, this._databaseFieldName, this._database, this._userId, this._password, this._securityTypeText });
        }

        public string Database
        {
            get
            {
                return this._database;
            }
            set
            {
                this._database = value;
            }
        }

        public static ConnectionString Empty
        {
            get
            {
                return _emptyConnectionString;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string RawOriginal
        {
            get
            {
                return this._rawOriginal;
            }
        }

        public string Server
        {
            get
            {
                return this._server;
            }
            set
            {
                this._server = value;
            }
        }

        public bool TrustedConnection
        {
            get
            {
                if (string.Compare(this._securityType, "sspi", true) != 0)
                {
                    return (string.Compare(this._securityType, "true", true) == 0);
                }
                return true;
            }
            set
            {
                if (value)
                {
                    this._securityType = "true";
                    this._securityTypeText = "Trusted_Connection=true";
                }
                else
                {
                    this._securityType = this._securityTypeText = string.Empty;
                }
            }
        }

        public string UserId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }
    }
}

