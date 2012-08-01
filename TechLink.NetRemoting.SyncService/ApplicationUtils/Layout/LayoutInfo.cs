using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtils.Utils.XMLProcessing;
using ExceptionHandler;

namespace ApplicationUtils.Layout
{
    [Serializable]
    public class LayoutInfo
    {
        public LayoutInfo()
        {
            
        }

        public LayoutInfo(string controlName, object value)
        {
            ControlName = controlName;
            Value = value;
        }

        public string ControlName { get; set; }
        public object Value { get; set; }
    }

    [Serializable]
    public class LayoutList
    {
        public LayoutList()
        {
            this.LayoutControls = new List<LayoutInfo>();
        }

        public List<LayoutInfo> LayoutControls { get; set; }

        public bool Save(string fileName)
        {
            try
            {
                ObjectXMLSerializer<LayoutList>.Save(this, fileName);
                return true;
            }
            catch (Exception exception)
            {
                ProcessException.WriteErrorLog(exception.Message + "\r\n" + exception.StackTrace, "LayoutList.Save()");
                throw exception;
            }
            return false;
        }
        public LayoutList Load(string fileName)
        {
            try
            {
                LayoutList layoutList = ObjectXMLSerializer<LayoutList>.Load(fileName);
                this.LayoutControls = layoutList.LayoutControls;
                return this;
            }
            catch (Exception exception)
            {

                ProcessException.WriteErrorLog(exception.Message + "\r\n" + exception.StackTrace, "LayoutList.Load()");
                throw exception;
            }
            return new LayoutList();
        }
    }
}
