using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;

namespace TechLink.DatabaseViewer.DataTransferObjects
{
    public class TableInfo
    {
        public string Schema { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// "BASE TABLE" or others
        /// </summary>
        public string Type { get; set; }
    }

    public class FieldInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsNullable { get; set; }
        public int MaxLength { get; set; }
    }
}
