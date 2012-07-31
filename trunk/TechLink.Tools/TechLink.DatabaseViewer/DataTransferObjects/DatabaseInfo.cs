using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechLink.DatabaseViewer.DataTransferObjects
{
    public class DatabaseInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsIntergratedSecurityMode { get; set; }

    }
}
