namespace TechLink.DatabaseViewer.Subtext.Scripting
{
    using System;
    using System.Data.SqlClient;

    public interface IScript
    {
        int Execute(SqlTransaction transaction);
    }
}

