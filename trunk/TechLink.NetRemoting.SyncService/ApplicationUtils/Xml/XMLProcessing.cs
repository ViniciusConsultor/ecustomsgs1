using System.Xml;
//using System.Xml.XPath;

namespace ApplicationUtils.Utils.XMLProcessing
{
    public class XMLProcessing
    {
        private string _fileName = string.Empty;
        private XmlTextReader textReader = null;
        private XmlDocument xmlDocument = null;

        #region Constructors
        public XMLProcessing(string xmlFilePath)
        {
            _fileName = xmlFilePath;
            textReader = new XmlTextReader(_fileName);
            xmlDocument = new XmlDocument();
            xmlDocument.Load(textReader);
            textReader.Close();
        }

        public XMLProcessing(XmlTextReader pTextReader)
        {
            textReader = pTextReader;
            xmlDocument = new XmlDocument();
            xmlDocument.Load(textReader);
            textReader.Close();
        }
        #endregion

        #region Static Members
        public static string XmlNodeListToString(XmlNodeList xmlNodeList)
        {
            string retValue = string.Empty;
            foreach (var list in xmlNodeList)
            {
                retValue += (retValue.Length>0?"\r\n":"") + ((System.Xml.XmlElement)list).OuterXml;
            }
            return retValue;
        }

        public static XmlNodeList GetNodeList(string fileName, string nodePath)
        {
            XmlTextReader _textReader = new XmlTextReader(fileName);
            XmlDocument _xmlDocument = new XmlDocument();

            _xmlDocument.Load(_textReader);
            _textReader.Close();

            XmlNodeList nodeList = _xmlDocument.SelectNodes(nodePath);
            return nodeList;
        }

        public static XmlNode GetNode(string fileName, string nodePath)
        {
            XmlTextReader _textReader = new XmlTextReader(fileName);
            XmlDocument _xmlDocument = new XmlDocument();

            _xmlDocument.Load(_textReader);
            _textReader.Close();
            if (nodePath == null) return null;
            XmlNode node = _xmlDocument.SelectSingleNode(nodePath);
            return node;
        }
        
        public static string[] GetAttributeList(string fileName, string nodePath, string attributeName)
        {
            XmlNodeList nodeList =
                XMLProcessing.GetNodeList(fileName, nodePath);
            string[] attributeValues = new string[0];

            if (nodeList.Count > 0)
            {
                attributeValues = new string[nodeList.Count];
                for (int i = 0; i < nodeList.Count; i++)
                {
                    attributeValues[i] = nodeList[i].Attributes[attributeName].Value;
                }

            }

            return attributeValues;
        }
        #endregion

        #region Dynamic Members
        public XmlNode GetNodeByKey(string nodePath, string keyRef)
        {
            if (!nodePath.EndsWith("/")) nodePath += "/";
            string xPathWithExpression = nodePath + keyRef;
            return xmlDocument.SelectSingleNode(xPathWithExpression);
        }

        public XmlNodeList GetNodeList(string nodePath)
        {
            XmlNodeList nodeList = xmlDocument.SelectNodes(nodePath);
            return nodeList;
        }

        public XmlNodeList GetNodeListByKey(string nodePath, string keyRef)
        {
            if (!nodePath.EndsWith("/")) nodePath += "/";
            string xPathWithExpression = nodePath + keyRef;

            XmlNodeList nodeList = xmlDocument.SelectNodes(xPathWithExpression);
            return nodeList;
        }

        public XmlNode GetNode(string nodePath)
        {
            if (nodePath == null) return null;
            XmlNode node = xmlDocument.SelectSingleNode(nodePath);
            return node;
        }

        public string[] GetAttributeList(string nodePath, string attributeName)
        {
            XmlNodeList nodeList =
                GetNodeList(nodePath);
            string[] attributeValues = new string[0];

            if (nodeList.Count > 0)
            {
                attributeValues = new string[nodeList.Count];
                for (int i = 0; i < nodeList.Count; i++)
                {
                    attributeValues[i] = nodeList[i].Attributes[attributeName].Value;
                }

            }

            return attributeValues;
        }
        #endregion
    }
}
