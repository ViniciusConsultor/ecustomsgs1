using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
}
