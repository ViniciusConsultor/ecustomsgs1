
namespace ApplicationUtils.GridHelper
{
    public class ColumnInfo
    {
        public ColumnInfo(){}
        
        private string _name;
        public string Name
        {
            get{ return _name;}
            set{ _name = value;}
        }

        private string _displayText;
        public string DisplayText
        {
            get{ return _displayText;}
            set{ _displayText = value;}
        }

    	public string StringFormat { get; set; }
			public DevExpress.Utils.FormatType Format { get; set; }

			public bool Editable { get; set; }
    }
}
