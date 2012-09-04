namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;

    internal class SqlScriptReader : ScriptReader
    {
        public SqlScriptReader(ScriptSplitter splitter) : base(splitter)
        {
        }

        protected override bool ReadNext()
        {
            if (base.EndOfLine)
            {
                base.splitter.Append(base.Current);
                base.splitter.SetParser(new SeparatorLineReader(base.splitter));
                return false;
            }
            base.splitter.Append(base.Current);
            return false;
        }
    }
}

