namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class TemplateParameter
    {
        private string _name;
        private string _type;
        private string _value;

        public event EventHandler<ParameterValueChangedEventArgs> ValueChanged;

        public TemplateParameter(string name, string type, string defaultValue)
        {
            this._name = name;
            this._type = type;
            this._value = defaultValue;
        }

        protected void OnValueChanged(string oldValue, string newValue)
        {
            EventHandler<ParameterValueChangedEventArgs> valueChanged = this.ValueChanged;
            if (valueChanged != null)
            {
                valueChanged(this, new ParameterValueChangedEventArgs(this.Name, oldValue, newValue));
            }
        }

        public string DataType
        {
            get
            {
                return this._type;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (value != this._value)
                {
                    this.OnValueChanged(this._value, value);
                }
                this._value = value;
            }
        }
    }
}

