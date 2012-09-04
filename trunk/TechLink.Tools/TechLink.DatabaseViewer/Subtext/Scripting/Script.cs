namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using Microsoft.ApplicationBlocks.Data;
    using Subtext.Scripting.Exceptions;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Script : IScript, ITemplateScript
    {
        private TemplateParameterCollection _parameters;
        private readonly string _scriptText;
        private ScriptToken _scriptTokens;

        public Script(string scriptText)
        {
            this._scriptText = scriptText;
        }

        private string ApplyTemplateReplacements()
        {
            StringBuilder builder = new StringBuilder();
            if ((this._scriptTokens == null) && (this.TemplateParameters == null))
            {
                throw new InvalidOperationException("The Template parameters are null. This is impossible.");
            }
            this._scriptTokens.AggregateText(builder);
            return builder.ToString();
        }

        public int Execute(SqlTransaction transaction)
        {
            int num2;
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction", "Transaction was null.");
            }
            int returnValue = 0;
            try
            {
                returnValue = SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, this.ScriptText);
                num2 = returnValue;
            }
            catch (SqlException exception)
            {
                throw new SqlScriptExecutionException("Error in executing the script: " + this.ScriptText, this, returnValue, exception);
            }
            return num2;
        }

        public static ScriptCollection ParseScripts(string fullScriptText)
        {
            ScriptCollection scripts = new ScriptCollection(fullScriptText);
            ScriptSplitter splitter = new ScriptSplitter(fullScriptText);
            foreach (string str in splitter)
            {
                scripts.Add(new Script(str));
            }
            return scripts;
        }

        public override string ToString()
        {
            if (this._scriptTokens != null)
            {
                return this._scriptTokens.ToString();
            }
            return "Script has no tokens.";
        }

        public string OriginalScriptText
        {
            get
            {
                return this._scriptText;
            }
        }

        public string ScriptText
        {
            get
            {
                return this.ApplyTemplateReplacements();
            }
        }

        public TemplateParameterCollection TemplateParameters
        {
            get
            {
                if (this._parameters == null)
                {
                    this._parameters = new TemplateParameterCollection();
                    if (this._scriptText.Length == 0)
                    {
                        return this._parameters;
                    }
                    MatchCollection matchs = new Regex(@"<\s*(?<name>[^()\[\]>,]*)\s*,\s*(?<type>[^>,]*)\s*,\s*(?<default>[^>,]*)\s*>", RegexOptions.Compiled).Matches(this._scriptText);
                    this._scriptTokens = new ScriptToken();
                    int startIndex = 0;
                    foreach (Match match in matchs)
                    {
                        if (match.Index > 0)
                        {
                            string str = this._scriptText.Substring(startIndex, match.Index - startIndex);
                            this._scriptTokens.Append(str);
                        }
                        startIndex = match.Index + match.Length;
                        TemplateParameter parameter = this._parameters.Add(match);
                        this._scriptTokens.Append(parameter);
                    }
                    string text = this._scriptText.Substring(startIndex);
                    if (text.Length > 0)
                    {
                        this._scriptTokens.Append(text);
                    }
                }
                return this._parameters;
            }
        }

        private class ScriptToken
        {
            private Script.ScriptToken _next;
            private readonly string _text;

            internal ScriptToken()
            {
            }

            internal ScriptToken(string text)
            {
                this._text = text;
            }

            internal void AggregateText(StringBuilder builder)
            {
                builder.Append(this.Text);
                if (this.Next != null)
                {
                    this.Next.AggregateText(builder);
                }
            }

            internal void Append(TemplateParameter parameter)
            {
                this.Last.Next = new Script.TemplateParameterToken(parameter);
            }

            internal void Append(string text)
            {
                this.Last.Next = new Script.ScriptToken(text);
            }

            public override string ToString()
            {
                int length = 0;
                if (this.Text != null)
                {
                    length = this.Text.Length;
                }
                string str = string.Format("<ScriptToken length=\"{0}\">{1}", length, Environment.NewLine);
                if (this.Next != null)
                {
                    str = str + this.Next.ToString();
                }
                return str;
            }

            public Script.ScriptToken Last
            {
                get
                {
                    Script.ScriptToken token = this;
                    for (Script.ScriptToken token2 = this._next; token2 != null; token2 = token.Next)
                    {
                        token = token2;
                    }
                    return token;
                }
            }

            public Script.ScriptToken Next
            {
                get
                {
                    return this._next;
                }
                set
                {
                    this._next = value;
                }
            }

            public virtual string Text
            {
                get
                {
                    return this._text;
                }
            }
        }

        private class TemplateParameterToken : Script.ScriptToken
        {
            private readonly TemplateParameter _parameter;

            internal TemplateParameterToken(TemplateParameter parameter)
            {
                this._parameter = parameter;
            }

            public override string ToString()
            {
                string str = "<TemplateParameter";
                if (this._parameter != null)
                {
                    str = str + string.Format(" name=\"{0}\" value=\"{1}\" type=\"{2}\"", this._parameter.Name, this._parameter.Value, this._parameter.DataType);
                }
                str = str + " />" + Environment.NewLine;
                if (base.Next != null)
                {
                    str = str + base.Next.ToString();
                }
                return str;
            }

            public override string Text
            {
                get
                {
                    return this._parameter.Value;
                }
            }
        }
    }
}

