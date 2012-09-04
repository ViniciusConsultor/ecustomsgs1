namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;

    public class ParameterValueChangedEventArgs : EventArgs
    {
        private string _newValue;
        private string _oldValue;
        private string _parameterName;

        public ParameterValueChangedEventArgs(string parameterName, string oldValue, string newValue)
        {
            this._oldValue = oldValue;
            this._newValue = newValue;
            this._parameterName = parameterName;
        }

        public string NewValue
        {
            get
            {
                return this._newValue;
            }
        }

        public string OldValue
        {
            get
            {
                return this._oldValue;
            }
        }

        public string ParameterName
        {
            get
            {
                return this._parameterName;
            }
        }
    }
}

