namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public class ScriptCollection : Collection<Script>, ITemplateScript
    {
        private string _fullScriptText;
        private TemplateParameterCollection _templateParameters;

        internal ScriptCollection(string fullScriptText)
        {
            this._fullScriptText = fullScriptText;
        }

        private void _templateParameters_ValueChanged(object sender, ParameterValueChangedEventArgs args)
        {
            this.ApplyTemplatesToScripts();
        }

        public void AddRange(IEnumerable<Script> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Cannot add a range from null.");
            }
            foreach (Script script in value)
            {
                base.Add(script);
            }
        }

        internal void ApplyTemplatesToScripts()
        {
            foreach (TemplateParameter parameter in this.TemplateParameters)
            {
                foreach (Script script in this)
                {
                    if (script.TemplateParameters.Contains(parameter.Name))
                    {
                        script.TemplateParameters[parameter.Name].Value = parameter.Value;
                    }
                }
            }
        }

        public string ExpandedScriptText
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                this.ApplyTemplatesToScripts();
                foreach (Script script in this)
                {
                    builder.Append(script.ScriptText);
                    builder.Append(Environment.NewLine);
                    builder.Append("GO");
                    builder.Append(Environment.NewLine);
                    builder.Append(Environment.NewLine);
                }
                return builder.ToString();
            }
        }

        public string FullScriptText
        {
            get
            {
                return this._fullScriptText;
            }
        }

        public TemplateParameterCollection TemplateParameters
        {
            get
            {
                if (this._templateParameters == null)
                {
                    this._templateParameters = new TemplateParameterCollection();
                    foreach (Script script in this)
                    {
                        this._templateParameters.AddRange(script.TemplateParameters);
                    }
                    this._templateParameters.ValueChanged += new EventHandler<ParameterValueChangedEventArgs>(this._templateParameters_ValueChanged);
                }
                return this._templateParameters;
            }
        }
    }
}

