using System;
using System.Xml;

namespace ApplicationUtils.Utils.XMLProcessing
{
    public class SummaryFieldsDirection
    {
        public SummaryFieldsDirection() { }
        public SummaryFieldsDirection(SummaryFieldsDirection fieldsDirection)
        {
            this.DefaultValue = fieldsDirection.DefaultValue;
            //this.KeyCompare = fieldsDirection.KeyCompare;
            this.KeyRef = fieldsDirection.KeyRef;
            this.Name = fieldsDirection.Name;
            this.Type = fieldsDirection.Type;
            this.XmlXPath = fieldsDirection.XmlXPath;
            
        }
        private string _name = string.Empty;
        public string Name
        {
            get{ return _name;}
            set { _name = value;}
        }

        private string _xmlXPath = string.Empty;
        public string XmlXPath
        {
            get{ return _xmlXPath;}
            set { _xmlXPath = value;}
        }

        private string _keyRef = string.Empty;
        public string KeyRef
        {
            get{ return _keyRef;}
            set { _keyRef = value;}
        }

        //private string _keyCompare = string.Empty;
        //public string KeyCompare
        //{
        //    get{ return _keyCompare;}
        //    set { _keyCompare = value;}
        //}

        private string _defaultValue = string.Empty;
        public string DefaultValue
        {
            get{ return _defaultValue;}
            set{ _defaultValue = value;}
        }

        private string _type = string.Empty;
        public string Type
        {
            get{ return _type;}
            set{ _type = value;}
        }
    }

    public class SummaryField:SummaryFieldsDirection
    {
        public SummaryField() { }
        public SummaryField(SummaryFieldsDirection fieldsDirection)
            : base(fieldsDirection) 
        { }

        private object _value = null;
        public object Value
        {
            get{ return _value;}
            set{ _value = value;}
        }
    }

    public class XmlMetaProcessing
    {
        #region Private Members
        private const string ServerAdditionalInfoXPath = "/ServerErrorReport/AditionalInfo/InfoItem";
        private const string SummaryFieldsXPath = "/Fields/Field";
        private const string TagNameField = "Name";
        private const string TagXmlXPathField = "XmlXPath";
        private const string TagKeyRefField = "KeyRef";
        //private const string TagKeyCompareField = "KeyCompare";
        private const string TagDefaultValueField = "DefaultValue";
        private const string TagTypeField = "Type";
        private XMLProcessing xmlMetaProcessing = null;
        private XMLProcessing xmlSummaryProcessing = null;
        #endregion

        #region Constructors
        public  XmlMetaProcessing(string summaryXMLDefineFilePath, string xmlMetaFilePath)
        {
            _summaryFilePath = summaryXMLDefineFilePath;
            _metaFilePath = xmlMetaFilePath;
            xmlMetaProcessing = new XMLProcessing(MetaFilePath);
            xmlSummaryProcessing = new XMLProcessing(SummaryFilePath);
        }
        #endregion
        
        #region Private Properties
        private SummaryFieldsDirection[] _fieldsDirection = null;
        private SummaryFieldsDirection[] FieldsDirection
        {
            get
            {
                XmlNodeList nodeList = xmlSummaryProcessing.GetNodeList(SummaryFieldsXPath);
                if(nodeList.Count>0)
                {
                    _fieldsDirection = new SummaryFieldsDirection[nodeList.Count];
                    for(int i=0;i<nodeList.Count;i++)
                    {
                        _fieldsDirection[i] = new SummaryFieldsDirection();

                        _fieldsDirection[i].Name = nodeList[i].Attributes[TagNameField].Value;
                        _fieldsDirection[i].DefaultValue = (nodeList[i].Attributes[TagDefaultValueField] != null
                                                              ? nodeList[i].Attributes[TagDefaultValueField].Value
                                                              : null);
                        //_fieldsDirection[i].KeyCompare = (nodeList[i].Attributes[TagKeyCompareField] != null
                        //                                      ? nodeList[i].Attributes[TagKeyCompareField].Value
                        //                                      : null);
                        _fieldsDirection[i].KeyRef = (nodeList[i].Attributes[TagKeyRefField] != null
                                                              ? nodeList[i].Attributes[TagKeyRefField].Value
                                                              : null);
                        _fieldsDirection[i].XmlXPath = (nodeList[i].Attributes[TagXmlXPathField] != null
                                                              ? nodeList[i].Attributes[TagXmlXPathField].Value
                                                              : null);
                        _fieldsDirection[i].Type = (nodeList[i].Attributes[TagTypeField] != null
                                                              ? nodeList[i].Attributes[TagTypeField].Value
                                                              : null);
                    }
                }

                return _fieldsDirection;
            }
        }
        #endregion

        #region Private Methods
        private TypeCode GetTypeCode(string stringTypeCode)
        {
            switch (stringTypeCode)
            {
                case "string":
                    return TypeCode.String;
                case "int":
                    return TypeCode.Int32;
                case "bool":
                    return TypeCode.Boolean;
            }

            return TypeCode.String;
        }
        #endregion

        #region Public Properties

        #region File Path Properties
        private string _summaryFilePath = string.Empty;
        /// <summary>
        /// Gets the summary file path. eg: c:\files\summary_info.xml
        /// </summary>
        public string SummaryFilePath
        {
            get { return _summaryFilePath; }
        }

        private string _metaFilePath = string.Empty;
        /// <summary>
        /// Gets the meta file path. eg: c:\files\report_details_info.xml
        /// </summary>
        public string MetaFilePath
        {
            get { return _metaFilePath; }
        }
        #endregion

        private SummaryField[] _summaryFields = new SummaryField[0];
        
        ///// <summary>
        ///// Gets SummaryField[] list from Meta file
        ///// </summary>
        //private SummaryField[] SummaryFields
        //{
        //    get
        //    {
        //        SummaryFieldsDirection[] summaryFieldsDirections = FieldsDirection;
        //        if (summaryFieldsDirections.Length > 0)
        //        {
        //            _summaryFields = new SummaryField[summaryFieldsDirections.Length];
        //            int i = 0;
        //            foreach (SummaryFieldsDirection direction in summaryFieldsDirections)
        //            {
        //                _summaryFields[i] = new SummaryField(direction);
        //                if(direction.KeyRef != null)
        //                {
        //                    XmlNodeList nodeList = xmlMetaProcessing.GetNodeList(direction.XmlXPath);
        //                    if(nodeList.Count>0)
        //                    {
        //                        for (int j = 0; j < nodeList.Count; j++)
        //                        {
        //                            if (nodeList[j].Attributes[direction.KeyRef].Value != null)
        //                            {
        //                                if (
        //                                    nodeList[j].Attributes[direction.KeyRef].Value.ToLower().Equals(
        //                                        direction.KeyCompare.ToLower()))
        //                                {
        //                                    _summaryFields[i].Value = Convert.ChangeType(nodeList[j].InnerText,
        //                                                                                 GetTypeCode(
        //                                                                                     _summaryFields[i].Type));
        //                                    break;
        //                                }
        //                            }
        //                            //If not found any Key or value of key is null
        //                            _summaryFields[i].Value = Convert.ChangeType(_summaryFields[i].DefaultValue,
        //                                                                             GetTypeCode(
        //                                                                                 _summaryFields[i].Type));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        _summaryFields[i].Value = Convert.ChangeType(_summaryFields[i].DefaultValue,
        //                                                                     GetTypeCode(_summaryFields[i].Type));
        //                    }
        //                }
        //                else
        //                {
        //                    XmlNode node = xmlMetaProcessing.GetNode(direction.XmlXPath);
        //                    if(node!=null)
        //                    {
        //                        _summaryFields[i].Value = Convert.ChangeType(node.InnerText,
        //                                                                     GetTypeCode(_summaryFields[i].Type));
        //                    }
        //                    else
        //                    {
        //                        _summaryFields[i].Value = Convert.ChangeType(_summaryFields[i].DefaultValue,
        //                                                                     GetTypeCode(_summaryFields[i].Type));
        //                    }
        //                }
        //                i++;
        //            }
        //        }

        //        return _summaryFields;
        //    }
        //}


        /// <summary>
        /// Gets SummaryField[] list from Meta file
        /// </summary>
        public SummaryField[] SummaryFields
        {
            get
            {
                SummaryFieldsDirection[] summaryFieldsDirections = FieldsDirection;
                if (summaryFieldsDirections.Length > 0)
                {
                    _summaryFields = new SummaryField[summaryFieldsDirections.Length];
                    for (int i = 0; i < summaryFieldsDirections.Length; i++)
                    {
                        _summaryFields[i] = new SummaryField(summaryFieldsDirections[i]);

                        if (summaryFieldsDirections[i].KeyRef != null)
                        {
                            XmlNode node =
                                xmlMetaProcessing.GetNodeByKey(summaryFieldsDirections[i].XmlXPath,
                                summaryFieldsDirections[i].KeyRef);
                            if(node!=null)
                            {
                                _summaryFields[i].Value = Convert.ChangeType(node.InnerText,
                                                                             GetTypeCode(_summaryFields[i].Type));
                            }
                            else
                            {
                                _summaryFields[i].Value = Convert.ChangeType(_summaryFields[i].DefaultValue,
                                                                             GetTypeCode(_summaryFields[i].Type));
                            }
                        }
                        else
                        {
                            XmlNode node = xmlMetaProcessing.GetNode(summaryFieldsDirections[i].XmlXPath);
                            if (node != null)
                            {
                                _summaryFields[i].Value = Convert.ChangeType(node.InnerText,
                                                                             GetTypeCode(_summaryFields[i].Type));
                            }
                            else
                            {
                                _summaryFields[i].Value = Convert.ChangeType(_summaryFields[i].DefaultValue,
                                                                             GetTypeCode(_summaryFields[i].Type));
                            }
                        }

                    }
                }

                return _summaryFields;
            }
        }
        #endregion
    }
}
