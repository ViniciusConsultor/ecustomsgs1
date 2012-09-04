namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;

    internal abstract class ScriptReader
    {
        protected readonly ScriptSplitter splitter;

        public ScriptReader(ScriptSplitter splitter)
        {
            this.splitter = splitter;
        }

        protected bool CharEquals(char compare)
        {
            return CharEquals(this.Current, compare);
        }

        protected static bool CharEquals(char expected, char actual)
        {
            return (char.ToLowerInvariant(expected) == char.ToLowerInvariant(actual));
        }

        protected char Peek()
        {
            if (!this.HasNext)
            {
                return '\0';
            }
            return (char) this.splitter.Peek();
        }

        protected virtual bool ReadDashDashComment()
        {
            this.splitter.Append(this.Current);
            while (this.splitter.Next())
            {
                this.splitter.Append(this.Current);
                if (this.EndOfLine)
                {
                    break;
                }
            }
            this.splitter.SetParser(new SeparatorLineReader(this.splitter));
            return false;
        }

        protected abstract bool ReadNext();
        public bool ReadNextSection()
        {
            if (this.IsQuote)
            {
                this.ReadQuotedString();
                return false;
            }
            if (this.BeginDashDashComment)
            {
                return this.ReadDashDashComment();
            }
            if (this.BeginSlashStarComment)
            {
                this.ReadSlashStarComment();
                return false;
            }
            return this.ReadNext();
        }

        protected virtual void ReadQuotedString()
        {
            this.splitter.Append(this.Current);
            while (this.splitter.Next())
            {
                this.splitter.Append(this.Current);
                if (this.IsQuote)
                {
                    return;
                }
            }
        }

        protected virtual void ReadSlashStarComment()
        {
            if (this.ReadSlashStarCommentWithResult())
            {
                this.splitter.SetParser(new SeparatorLineReader(this.splitter));
            }
        }

        private bool ReadSlashStarCommentWithResult()
        {
            this.splitter.Append(this.Current);
            while (this.splitter.Next())
            {
                if (this.BeginSlashStarComment)
                {
                    this.ReadSlashStarCommentWithResult();
                }
                else
                {
                    this.splitter.Append(this.Current);
                    if (this.EndSlashStarComment)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool BeginDashDashComment
        {
            get
            {
                return ((this.Current == '-') && (this.Peek() == '-'));
            }
        }

        private bool BeginSlashStarComment
        {
            get
            {
                return ((this.Current == '/') && (this.Peek() == '*'));
            }
        }

        protected char Current
        {
            get
            {
                return this.splitter.Current;
            }
        }

        protected bool EndOfLine
        {
            get
            {
                return ('\n' == this.splitter.Current);
            }
        }

        private bool EndSlashStarComment
        {
            get
            {
                return ((this.LastChar == '*') && (this.Current == '/'));
            }
        }

        protected bool HasNext
        {
            get
            {
                return this.splitter.HasNext;
            }
        }

        protected bool IsQuote
        {
            get
            {
                return ('\'' == this.splitter.Current);
            }
        }

        protected char LastChar
        {
            get
            {
                return this.splitter.LastChar;
            }
        }

        protected bool WhiteSpace
        {
            get
            {
                return char.IsWhiteSpace(this.splitter.Current);
            }
        }
    }
}

