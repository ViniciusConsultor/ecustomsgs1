﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using TechLink.DatabaseViewer.DataAccess;

namespace TechLink.DatabaseViewer.Commands
{
    public class UpgradeVersion100:UpgradeCommandBase
    {
        public List<string> sqlQueries = new List<string>(); 

        public UpgradeVersion100(SqlCopier sqlCopier) : base(sqlCopier)
        {
            Version = "1.0.1";

            sqlQueries.Add("ALTER TABLE [dbo].[tblUser] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblUser] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblDeclaration] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblDeclaration] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblGoodsType] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblGoodsType] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblPermission] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblPermission] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblApplicationObject] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblApplicationObject] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblUserInGroup] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblUserInGroup] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblVehicleFeeSetting] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblVehicleFeeSetting] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblCheck] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblCheck] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblGroup] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblGroup] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblVehicle] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblVehicle] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tlbRole] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tlbRole] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblRoleInGroup] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblRoleInGroup] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblDeclarationVehicle] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblDeclarationVehicle] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblGate] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblGate] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblCustoms] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblCustoms] SET [IsSynced]=0");

            sqlQueries.Add("ALTER TABLE [dbo].[tblVehicle] ADD [IsSynced] bit NULL");
            sqlQueries.Add("UPDATE [dbo].[tblVehicle] SET [IsSynced]=0");


            sqlQueries.Add(
                string.Format(
                    "CREATE PROCEDURE [dbo].[BackupDiferentialDatabase] @fileSaved nvarchar(500) AS BACKUP DATABASE {0} TO DISK = @fileSaved WITH DIFFERENTIAL, MEDIANAME = 'Z_SQLServerBackups', NAME = 'Diferential Backup of {0}';",
                    sqlCopier.Database));
            sqlQueries.Add(
                string.Format(
                    "CREATE PROCEDURE [dbo].[BackupFullDatabase] @fileSaved nvarchar(500) AS BACKUP DATABASE {0} TO DISK = @fileSaved WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = 'Full Backup of {0}';",
                    sqlCopier.Database));

            if(FDHelper.RgGetSizeOfUnit()== ConstantInfo.Boss)
            {
                sqlQueries.Add(
                    "CREATE TABLE [dbo].[tblBranchDatabases]([Id] [uniqueidentifier] NOT NULL,[DatabaseName] [nvarchar](120) NOT NULL,[RegisterSerial] [nvarchar](128) NOT NULL,[BranchName] [nvarchar](300) NOT NULL,[LastSync] [datetime] NOT NULL, [IsRequestingSync] [bit] NOT NULL,CONSTRAINT [PK_tblBranchDatabases] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]");
            }

            sqlQueries.Add("CREATE TABLE [dbo].[tblSettings]([Version] [nvarchar](50) NOT NULL,[LastSync] [datetime] NOT NULL,[SyncInterval] [int] NULL,[SyncTime] [nvarchar](6) NULL, [IsStartingSync] [bit] NOT NULL) ON [PRIMARY]");
            sqlQueries.Add("INSERT INTO [dbo].[tblSettings]([Version],[LastSync], [IsStartingSync]) VALUES('1.0.1', '08/01/2012', 0)");

            
        }

        public override bool DoUpgrade(object parameters)
        {
            _params = parameters;
            //return base.DoUpgrade(parameters);
            if(parameters is ProgressBar)
            {
                try
                {
                    ProgressBar progress = parameters as ProgressBar;
                    progress.Minimum = 0;
                    progress.Maximum = sqlQueries.Count;

                    for (int i = 0; i < sqlQueries.Count; i++)
                    {
                        progress.Value = i;
                        var result = _SqlCopier.RunSqlQuery(sqlQueries[i]);
                        if(i==sqlQueries.Count-1 && !result.Equals(1))
                        {
                            return false;
                        }
                    }
                }
                catch (Exception exception)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < sqlQueries.Count; i++)
                    {
                        _SqlCopier.RunSqlQuery(sqlQueries[i]);
                    }
                }
                catch (Exception exception)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
