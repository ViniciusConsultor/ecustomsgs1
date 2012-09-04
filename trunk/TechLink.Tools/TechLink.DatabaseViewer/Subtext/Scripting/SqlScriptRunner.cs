namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using Subtext.Scripting.Exceptions;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SqlScriptRunner : IScript, ITemplateScript
    {
        private Subtext.Scripting.ScriptCollection scripts;

        public SqlScriptRunner(Subtext.Scripting.ScriptCollection scripts)
        {
            this.scripts = scripts;
        }

        public SqlScriptRunner(string scriptText) : this(Script.ParseScripts(scriptText))
        {
        }

        public SqlScriptRunner(Stream scriptStream, Encoding encoding) : this(ReadStream(scriptStream, encoding))
        {
        }

        public SqlScriptRunner(Assembly assemblyWithEmbeddedScript, string fullScriptName, Encoding encoding) : this(UnpackEmbeddedScript(assemblyWithEmbeddedScript, fullScriptName), encoding)
        {
        }

        public SqlScriptRunner(Type scopingType, string scriptName, Encoding encoding) : this(UnpackEmbeddedScript(scopingType, scriptName), encoding)
        {
        }

        public SqlScriptRunner(Assembly assemblyWithEmbeddedScript, Type scopingType, string scriptName, Encoding encoding) : this(UnpackEmbeddedScript(assemblyWithEmbeddedScript, scopingType, scriptName), encoding)
        {
        }

        public int Execute(SqlTransaction transaction)
        {
            int num = 0;
            SetNoCountOff(transaction);
            string pattern = @"(INSERT\sINTO\s[\s\w\d\)\(\,\.\]\[\>\<]+)|(UPDATE\s[\s\w\d\)\(\,\.\]\[\>\<]+SET\s)|(DELETE\s[\s\w\d\)\(\,\.\]\[\>\<]+FROM\s[\s\w\d\)\(\,\.\]\[\>\<]+WHERE\s)";
            Regex regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            this.scripts.ApplyTemplatesToScripts();
            foreach (Script script in this.scripts)
            {
                int returnValue = script.Execute(transaction);
                if (regex.Match(script.ScriptText).Success && IsCrudScript(script))
                {
                    if (returnValue <= -1)
                    {
                        throw new SqlScriptExecutionException("An error occurred while executing the script.", script, returnValue);
                    }
                    num += returnValue;
                }
            }
            return num;
        }

        private static bool IsCrudScript(Script script)
        {
            return ((script.ScriptText.IndexOf("TRIGGER") == -1) && (script.ScriptText.IndexOf("PROC") == -1));
        }

        private static string ReadStream(Stream stream, Encoding encoding)
        {
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                return reader.ReadToEnd();
            }
        }

        private static void SetNoCountOff(SqlTransaction transaction)
        {
            new Script("SET NOCOUNT OFF").Execute(transaction);
        }

        private static Stream UnpackEmbeddedScript(Assembly assembly, string fullScriptName)
        {
            return assembly.GetManifestResourceStream(fullScriptName);
        }

        private static Stream UnpackEmbeddedScript(Type scopingType, string scriptName)
        {
            return scopingType.Assembly.GetManifestResourceStream(scopingType, scriptName);
        }

        private static Stream UnpackEmbeddedScript(Assembly assembly, Type scopingType, string scriptName)
        {
            return assembly.GetManifestResourceStream(scopingType, scriptName);
        }

        public Subtext.Scripting.ScriptCollection ScriptCollection
        {
            get
            {
                return this.scripts;
            }
        }

        public TemplateParameterCollection TemplateParameters
        {
            get
            {
                return this.scripts.TemplateParameters;
            }
        }
    }
}

