namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    public class TemplateParameterCollection : ICollection<TemplateParameter>, IEnumerable<TemplateParameter>, IEnumerable
    {
        private List<TemplateParameter> list = new List<TemplateParameter>();

        public event EventHandler<ParameterValueChangedEventArgs> ValueChanged;

        public TemplateParameter Add(TemplateParameter value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Cannot add a null template parameter.");
            }
            if (this.Contains(value))
            {
                return this[value.Name];
            }
            this.List.Add(value);
            value.ValueChanged += new EventHandler<ParameterValueChangedEventArgs>(this.value_ValueChanged);
            return value;
        }

        public TemplateParameter Add(Match match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match", "Cannot create a template parameter from a null match.");
            }
            if (this[match.Groups["name"].Value] != null)
            {
                return this[match.Groups["name"].Value];
            }
            TemplateParameter parameter = new TemplateParameter(match.Groups["name"].Value, match.Groups["type"].Value, match.Groups["default"].Value);
            this.Add(parameter);
            return parameter;
        }

        public void AddRange(IEnumerable<TemplateParameter> value)
        {
            foreach (TemplateParameter parameter in value)
            {
                this.Add(parameter);
            }
        }

        public void Clear()
        {
            this.List.Clear();
        }

        public bool Contains(TemplateParameter value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Cannot test whether or not it contains null.");
            }
            return this.Contains(value.Name);
        }

        public bool Contains(string name)
        {
            return (this[name] != null);
        }

        public void CopyTo(TemplateParameter[] array, int arrayIndex)
        {
            this.List.CopyTo(array, arrayIndex);
        }

        public IEnumerator GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        public int IndexOf(TemplateParameter value)
        {
            return this.List.IndexOf(value);
        }

        protected void OnValueChanged(ParameterValueChangedEventArgs args)
        {
            EventHandler<ParameterValueChangedEventArgs> valueChanged = this.ValueChanged;
            if (valueChanged != null)
            {
                valueChanged(this, args);
            }
        }

        public bool Remove(TemplateParameter value)
        {
            return this.List.Remove(value);
        }

        public void SetValue(string name, string value)
        {
            if (this[name] != null)
            {
                this[name].Value = value;
            }
        }

        void ICollection<TemplateParameter>.Add(TemplateParameter item)
        {
            this.Add(item);
        }

        IEnumerator<TemplateParameter> IEnumerable<TemplateParameter>.GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        private void value_ValueChanged(object sender, ParameterValueChangedEventArgs args)
        {
            this.OnValueChanged(args);
        }

        public int Count
        {
            get
            {
                return this.List.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TemplateParameter this[string name]
        {
            get
            {
                foreach (TemplateParameter parameter in this.List)
                {
                    if (string.Compare(parameter.Name, name, true) == 0)
                    {
                        return parameter;
                    }
                }
                return null;
            }
        }

        public TemplateParameter this[int index]
        {
            get
            {
                return this.List[index];
            }
        }

        private List<TemplateParameter> List
        {
            get
            {
                return this.list;
            }
        }
    }
}

