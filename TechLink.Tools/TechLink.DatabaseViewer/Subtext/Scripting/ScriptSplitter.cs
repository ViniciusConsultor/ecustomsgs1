namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    
    public class ScriptSplitter : IEnumerable<string>
	{
		private ScriptReader scriptReader = null;
		private StringBuilder builder = new StringBuilder();
		private readonly TextReader reader;
		private char current = char.MinValue;
		private char lastChar = char.MinValue;

		public ScriptSplitter(string script)
		{
			this.reader = new StringReader(script);
			this.scriptReader = new SeparatorLineReader(this);
		}

		internal bool Next()
		{
			if (!HasNext)
			{
				return false;
			}

			this.lastChar = this.current;
			this.current = (char)reader.Read();
			return true;
		}

		internal bool HasNext
		{
			get { return reader.Peek() != -1; }
		}

		internal int Peek()
		{
			return reader.Peek();
		}

		internal char Current
		{
			get { return this.current; }
		}

		internal char LastChar
		{
			get { return this.lastChar; }
		}

		private bool Split()
		{
			return this.scriptReader.ReadNextSection();
		}

		internal void SetParser(ScriptReader newReader)
		{
			this.scriptReader = newReader;
		}

		internal void Append(string text)
		{
			builder.Append(text);
		}

		internal void Append(char c)
		{
			builder.Append(c);
		}

		void Reset()
		{
			current = lastChar = char.MinValue;
			builder = new StringBuilder();
		}

		public IEnumerator<string> GetEnumerator()
		{
			while (Next())
			{
				if (Split())
				{
					string script = builder.ToString().Trim();
					if (script.Length > 0)
						yield return (script);
					Reset();
				}
			}
			if (builder.Length > 0)
			{
				string scriptRemains = builder.ToString().Trim();
				if (scriptRemains.Length > 0)
					yield return (scriptRemains);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

