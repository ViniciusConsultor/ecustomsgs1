using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ApplicationUtils.Utils.XMLProcessing;

namespace ApplicationUtils.GridHelper
{
	public class FieldsLoader
	{
		public static List<ColumnInfo>LoadColumns(string xmlFile)
		{
			List<ColumnInfo> columnInfos = new List<ColumnInfo>();

			XMLProcessing xml = new XMLProcessing(xmlFile);
			XmlNodeList nodes = xml.GetNodeList("Fields/Field");
			if(nodes.Count>0)
			{
				foreach (XmlNode node in nodes)
				{
					ColumnInfo columnInfo = new ColumnInfo();
					columnInfo.Name = node.Attributes["Name"].Value;
					columnInfo.DisplayText = node.Attributes["DisplayText"].Value;
					columnInfo.StringFormat = node.Attributes["StringFormat"].Value;
					if (node.OuterXml.Contains("Editable"))
					{
						columnInfo.Editable = node.Attributes["Editable"].Value.ToLower().Equals("true");
					}
					
					string formatType = node.Attributes["Format"].Value;
					if (formatType.Equals("Custom"))
					{
						columnInfo.Format = DevExpress.Utils.FormatType.Custom;	
					}
					else if (formatType.Equals("None"))
					{
						columnInfo.Format = DevExpress.Utils.FormatType.None;
					}
					else if (formatType.Equals("DateTime"))
					{
						columnInfo.Format = DevExpress.Utils.FormatType.DateTime;	
					}
					else if (formatType.Equals("Numeric"))
					{
						columnInfo.Format = DevExpress.Utils.FormatType.Numeric;
					}
					columnInfos.Add(columnInfo);
				}
			}
			return columnInfos;
		}
	}
}
