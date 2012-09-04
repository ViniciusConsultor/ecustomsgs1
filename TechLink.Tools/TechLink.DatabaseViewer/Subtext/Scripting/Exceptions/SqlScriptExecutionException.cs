namespace TechLink.DatabaseViewer.Subtext.Scripting.Exceptions
{
    using Subtext.Scripting;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class SqlScriptExecutionException : Exception, ISerializable
    {
        private readonly int _returnValue;
        private readonly Subtext.Scripting.Script _script;

        public SqlScriptExecutionException()
        {
        }

        public SqlScriptExecutionException(string message) : base(message)
        {
        }

        private SqlScriptExecutionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._script = info.GetValue("Script", typeof(string)) as Subtext.Scripting.Script;
        }

        public SqlScriptExecutionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public SqlScriptExecutionException(string message, Subtext.Scripting.Script script, int returnValue) : base(message)
        {
            this._script = script;
            this._returnValue = returnValue;
        }

        public SqlScriptExecutionException(string message, Subtext.Scripting.Script script, int returnValue, Exception innerException) : base(message, innerException)
        {
            this._script = script;
            this._returnValue = returnValue;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Script", this._script);
            this.GetObjectData(info, context);
        }

        public override string Message
        {
            get
            {
                string message = base.Message;
                if (this.Script != null)
                {
                    message = message + string.Format("{0}ScriptName: {1}", Environment.NewLine, this._script);
                }
                return (message + "Return Value: " + this.ReturnValue);
            }
        }

        public int ReturnValue
        {
            get
            {
                return this._returnValue;
            }
        }

        public Subtext.Scripting.Script Script
        {
            get
            {
                return this._script;
            }
        }
    }
}

