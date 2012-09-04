namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using Subtext.Scripting.Exceptions;
    using System;
    using System.Text;

    internal class SeparatorLineReader : ScriptReader
    {
        private StringBuilder builder;
        private bool foundGo;
        private bool gFound;

        public SeparatorLineReader(ScriptSplitter splitter) : base(splitter)
        {
            this.builder = new StringBuilder();
        }

        private void FoundNonEmptyCharacter(char c)
        {
            this.builder.Append(c);
            base.splitter.Append(this.builder.ToString());
            base.splitter.SetParser(new SqlScriptReader(base.splitter));
        }

        protected override bool ReadDashDashComment()
        {
            if (!this.foundGo)
            {
                base.ReadDashDashComment();
                return false;
            }
            base.ReadDashDashComment();
            return true;
        }

        protected override bool ReadNext()
        {
            if (base.EndOfLine)
            {
                if (!this.foundGo)
                {
                    this.builder.Append(base.Current);
                    base.splitter.Append(this.builder.ToString());
                    base.splitter.SetParser(new SeparatorLineReader(base.splitter));
                    return false;
                }
                this.Reset();
                return true;
            }
            if (base.WhiteSpace)
            {
                this.builder.Append(base.Current);
                return false;
            }
            if (!base.CharEquals('g') && !base.CharEquals('o'))
            {
                this.FoundNonEmptyCharacter(base.Current);
                return false;
            }
            if (base.CharEquals('o'))
            {
                if (ScriptReader.CharEquals('g', base.LastChar) && !this.foundGo)
                {
                    this.foundGo = true;
                }
                else
                {
                    this.FoundNonEmptyCharacter(base.Current);
                }
            }
            if (ScriptReader.CharEquals('g', base.Current))
            {
                if (this.gFound || (!char.IsWhiteSpace(base.LastChar) && (base.LastChar != '\0')))
                {
                    this.FoundNonEmptyCharacter(base.Current);
                    return false;
                }
                this.gFound = true;
            }
            if (!base.HasNext && this.foundGo)
            {
                this.Reset();
                return true;
            }
            this.builder.Append(base.Current);
            return false;
        }

        protected override void ReadSlashStarComment()
        {
            if (this.foundGo)
            {
                throw new SqlParseException("Incorrect syntax was encountered while parsing GO. Cannot have a slash star /* comment */ after a GO statement.");
            }
            base.ReadSlashStarComment();
        }

        private void Reset()
        {
            this.foundGo = false;
            this.gFound = false;
            this.builder = new StringBuilder();
        }
    }
}

