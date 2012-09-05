using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using TechLink.DatabaseViewer.DataAccess;

namespace TechLink.DatabaseViewer.Commands
{
    public class UpgradeVersion100 : UpgradeCommandBase
    {
        public List<string> sqlQueries = new List<string>();
        private string[] tables = new string[] { "tblUser", "tblDeclaration", "tblGoodsType", "tblPermission", "tblApplicationObject", 
            "tblUserInGroup", "tblVehicleFeeSetting", "tblCheck", "tblGroup", "tblVehicle", "tlbRole", "tblRoleInGroup", 
            "tblDeclarationVehicle", "tblGate", "tblCustoms", "tblCompany", "tblDeclarationLoan", "tblPermissionType",
            "tblProfileConfig", "tblType", "tblUserGroupPermission", "tblVehicleCheck", "tblVehicleType"};
        public UpgradeVersion100(SqlCopier sqlCopier)
            : base(sqlCopier)
        {
            Version = "1.0.1";
            
            sqlQueries.Add(
                string.Format(
                    "CREATE PROCEDURE [dbo].[BackupDiferentialDatabase] @fileSaved nvarchar(500) AS BACKUP DATABASE {0} TO DISK = @fileSaved WITH DIFFERENTIAL, MEDIANAME = 'Z_SQLServerBackups', NAME = 'Diferential Backup of {0}';",
                    sqlCopier.Database));
            sqlQueries.Add(
                string.Format(
                    "CREATE PROCEDURE [dbo].[BackupFullDatabase] @fileSaved nvarchar(500) AS BACKUP DATABASE {0} TO DISK = @fileSaved WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = 'Full Backup of {0}';",
                    sqlCopier.Database));

            if (FDHelper.RgGetSizeOfUnit() == ConstantInfo.Boss)
            {
                sqlQueries.Add(
                    "CREATE TABLE [dbo].[tblBranchDatabases]([Id] [nvarchar] (15) NOT NULL,[DatabaseName] [nvarchar](120) NOT NULL,[RegisterSerial] [nvarchar](128) NOT NULL,[BranchName] [nvarchar](300) NOT NULL,[LastSync] [datetime] NOT NULL, [IsRequestingSync] [bit] NOT NULL,CONSTRAINT [PK_tblBranchDatabases] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]");
            }

            sqlQueries.Add("CREATE TABLE [dbo].[tblSettings]([Version] [nvarchar](50) NOT NULL,[LastSync] [datetime] NOT NULL,[SyncInterval] [int] NULL,[SyncTime] [nvarchar](6) NULL,[IsStartingSync] [bit] NOT NULL,CONSTRAINT [PK_tblSettings] PRIMARY KEY CLUSTERED ([Version] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]");
            sqlQueries.Add("INSERT INTO [dbo].[tblSettings]([Version],[LastSync], [IsStartingSync]) VALUES('1.0.1', '09/02/2012', 0)");

            sqlQueries.Add("ALTER TABLE dbo.tblDeclaration DROP CONSTRAINT FK_tblDeclaration_tblUser");
            //sqlQueries.Add("ALTER TABLE dbo.tblUser DROP CONSTRAINT PK_tblUsers");
            sqlQueries.Add("ALTER TABLE dbo.tblUser ADD CONSTRAINT	PK_tblUsers PRIMARY KEY CLUSTERED(UserID,BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblApplicationObject DROP CONSTRAINT PK_ApplicationObject");
            sqlQueries.Add("ALTER TABLE dbo.tblApplicationObject ADD CONSTRAINT	PK_ApplicationObject PRIMARY KEY CLUSTERED (	ApplicationObjectID,BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblCheck DROP CONSTRAINT PK_tblCheck");
            sqlQueries.Add("ALTER TABLE dbo.tblCheck ADD CONSTRAINT	PK_tblCheck PRIMARY KEY CLUSTERED (CheckID,BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblCompany DROP CONSTRAINT PK_tblCompany");
            sqlQueries.Add("ALTER TABLE dbo.tblCompany ADD CONSTRAINT PK_tblCompany PRIMARY KEY CLUSTERED (CompanyCode,BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblCustoms DROP CONSTRAINT PK_tblCustoms");
            sqlQueries.Add("ALTER TABLE dbo.tblCustoms ADD CONSTRAINT PK_tblCustoms PRIMARY KEY CLUSTERED (CustomsCode,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblDeclaration DROP CONSTRAINT PK_tblDeclaration");
            sqlQueries.Add("ALTER TABLE dbo.tblDeclaration ADD CONSTRAINT PK_tblDeclaration PRIMARY KEY CLUSTERED (DeclarationID, BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblGoodsType DROP CONSTRAINT PK_tblGoodsType");
            sqlQueries.Add("ALTER TABLE dbo.tblGoodsType ADD CONSTRAINT PK_tblGoodsType PRIMARY KEY CLUSTERED (TypeId,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblGate DROP CONSTRAINT PK_tblGate");
            sqlQueries.Add("ALTER TABLE dbo.tblGate ADD CONSTRAINT	PK_tblGate PRIMARY KEY CLUSTERED (GateCode,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblDeclarationVehicle DROP CONSTRAINT PK_tblDeclarationVehicle");
            sqlQueries.Add("ALTER TABLE dbo.tblDeclarationVehicle ADD CONSTRAINT PK_tblDeclarationVehicle PRIMARY KEY CLUSTERED (DeclarationID,	VehicleID,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblDeclarationLoan DROP CONSTRAINT PK_tblDeclarationLoan");
            sqlQueries.Add("ALTER TABLE dbo.tblDeclarationLoan ADD CONSTRAINT PK_tblDeclarationLoan PRIMARY KEY CLUSTERED (ID,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblGroup DROP CONSTRAINT PK_tblGroup");
            sqlQueries.Add("ALTER TABLE dbo.tblGroup ADD CONSTRAINT PK_tblGroup PRIMARY KEY CLUSTERED (GroupID,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblPermission DROP CONSTRAINT PK__tblPermi__EFA6FB0F29E1370A");
            sqlQueries.Add("ALTER TABLE dbo.tblPermission ADD CONSTRAINT PK_tblPermission PRIMARY KEY CLUSTERED (PermissionID, BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblPermissionType DROP CONSTRAINT PK_tblPermissionType");
            sqlQueries.Add("ALTER TABLE dbo.tblPermissionType ADD CONSTRAINT PK_tblPermissionType PRIMARY KEY CLUSTERED (TypeCode,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblProfileConfig DROP CONSTRAINT PK_tblProfileConfig");
            sqlQueries.Add("ALTER TABLE dbo.tblProfileConfig ADD CONSTRAINT PK_tblProfileConfig PRIMARY KEY CLUSTERED (ID,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblUserInGroup DROP CONSTRAINT PK_tblUserInGroup");
            sqlQueries.Add("ALTER TABLE dbo.tblUserInGroup ADD CONSTRAINT PK_tblUserInGroup PRIMARY KEY CLUSTERED (UserID,	GroupID, BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblUserGroupPermission DROP CONSTRAINT PK__tblUserG__3214EC277D439ABD");
            sqlQueries.Add("ALTER TABLE dbo.tblUserGroupPermission ADD CONSTRAINT PK_tblUserGroupPms PRIMARY KEY CLUSTERED (ID,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblType DROP CONSTRAINT PK_tblType");
            sqlQueries.Add("ALTER TABLE dbo.tblType ADD CONSTRAINT	PK_tblType PRIMARY KEY CLUSTERED (TypeCode,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblRoleInGroup DROP CONSTRAINT PK_tblRoleInGroup");
            sqlQueries.Add("ALTER TABLE dbo.tblRoleInGroup ADD CONSTRAINT PK_tblRoleGroups PRIMARY KEY CLUSTERED (GroupID,	RoleID,	BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblVehicle DROP CONSTRAINT PK_tblVehicle");
            sqlQueries.Add("ALTER TABLE dbo.tblVehicle ADD CONSTRAINT PK_tblVehicle PRIMARY KEY CLUSTERED (VehicleID, BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblVehicleCheck DROP CONSTRAINT PK_tblVehicleCheck");
            sqlQueries.Add("ALTER TABLE dbo.tblVehicleCheck ADD CONSTRAINT PK_tblVehicleCheck PRIMARY KEY CLUSTERED (VehicleCheckID, BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblVehicleFeeSetting DROP CONSTRAINT PK_tblVehicleFeeSetting");
            sqlQueries.Add("ALTER TABLE dbo.tblVehicleFeeSetting ADD CONSTRAINT	PK_tblVehicleFeeSetting PRIMARY KEY CLUSTERED (VehicleTypeId,	GoodsTypeId, BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblVehicleType DROP CONSTRAINT PK_tblVehicleType");
            sqlQueries.Add("ALTER TABLE dbo.tblVehicleType ADD CONSTRAINT PK_tblVehicleType PRIMARY KEY CLUSTERED (VehicleTypeID, BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            //sqlQueries.Add("ALTER TABLE dbo.tblRoleInGroup DROP CONSTRAINT PK_tblRoleInGroup");
            sqlQueries.Add("ALTER TABLE dbo.tblRoleInGroup DROP CONSTRAINT FK_tblRoleInGroup_tlbRole");

            //sqlQueries.Add("ALTER TABLE dbo.tlbRole DROP CONSTRAINT PK_tlbRole");
            sqlQueries.Add("ALTER TABLE dbo.tlbRole ADD CONSTRAINT PK_tlbRole PRIMARY KEY CLUSTERED (RoleID, BranchId) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
        }

        public override bool DoUpgrade(object parameters)
        {
            var parms = parameters as List<object>;

            if(parms==null || parms.Count<2) return false;

            _params = parms[0];
            string _defaultBrancheId = parms[1].ToString();
            //return base.DoUpgrade(parameters);
            if (_params is ProgressBar)
            {
                try
                {
                    int maxProg = sqlQueries.Count + tables.Count() + 1;
                    ProgressBar progress = _params as ProgressBar;
                    progress.Minimum = 0;
                    progress.Maximum = maxProg;

                    foreach (string table in tables)
                    {
                       
                        if(!_SqlCopier.ExistingFieldInTable(table, "IsSynced"))
                        {
                            var str = string.Format("ALTER TABLE [dbo].[{0}] ADD [IsSynced] bit NULL;", table);
                            var result = _SqlCopier.RunSqlQuery(str);

                            if (result.Equals(-1))
                            {
                                str = string.Format("UPDATE [dbo].[{0}] SET [IsSynced]=0;", table);
                                result = _SqlCopier.RunSqlQuery(str);
                            }
                        }

                        if (!_SqlCopier.ExistingFieldInTable(table, "BranchId"))
                        {
                            var str = string.Format("ALTER TABLE [dbo].[{0}] ADD [BranchId] [nvarchar](15) NULL;", table);
                            var result = _SqlCopier.RunSqlQuery(str);

                            if (result.Equals(-1))
                            {
                                str = string.Format("UPDATE [dbo].[{0}] SET [BranchId]='{1}';", table, _defaultBrancheId);
                                result = _SqlCopier.RunSqlQuery(str);

                                str = string.Format("ALTER TABLE [dbo].[{0}] ALTER COLUMN [BranchId] [nvarchar](15) NOT NULL;", table);
                                result = _SqlCopier.RunSqlQuery(str);
                            }
                        }

                        string sqlGetConstraint =
                            string.Format(
                                "SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME ='{0}' AND TABLE_CATALOG='{1}'",
                                table, _SqlCopier.Database);
                        DataTable dataTable = _SqlCopier.RunSqlReader(sqlGetConstraint) as DataTable;
                        if(dataTable.Rows.Count>0)
                        {
                            string constraintName = dataTable.Rows[0][0].ToString();

                            constraintName = string.Format("ALTER TABLE dbo.{0} DROP CONSTRAINT {1}", table, constraintName);
                            _SqlCopier.RunSqlQuery(constraintName);    
                        }

                        progress.Value++;
                    }

                    for (int i = 0; i < sqlQueries.Count; i++)
                    {
                        progress.Value++;
                        var result = _SqlCopier.RunSqlQuery(sqlQueries[i]);
                        if (i == sqlQueries.Count - 1 && !result.Equals(1))
                        {
                            return false;
                        }
                    }

                    progress.Value = maxProg;
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
                    foreach (string table in tables)
                    {
                        if (!_SqlCopier.ExistingFieldInTable(table, "IsSynced"))
                        {
                            var str = string.Format("ALTER TABLE [dbo].[{0}] ADD [IsSynced] bit NULL;", table);
                            var result = _SqlCopier.RunSqlQuery(str);

                            if (result.Equals(-1))
                            {
                                str = string.Format("UPDATE [dbo].[{0}] SET [IsSynced]=0;", table);
                                result = _SqlCopier.RunSqlQuery(str);
                            }
                        }

                        if (!_SqlCopier.ExistingFieldInTable(table, "BranchId"))
                        {
                            var str = string.Format("ALTER TABLE [dbo].[{0}] ADD [BranchId] [nvarchar](15) NULL;", table);
                            var result = _SqlCopier.RunSqlQuery(str);

                            if (result.Equals(-1))
                            {
                                str = string.Format("UPDATE [dbo].[{0}] SET [BranchId]='{1}';", table, _defaultBrancheId);
                                result = _SqlCopier.RunSqlQuery(str);
                            }
                        }

                    }

                    for (int i = 0; i < sqlQueries.Count; i++)
                    {
                        var result = _SqlCopier.RunSqlQuery(sqlQueries[i]);
                        if (i == sqlQueries.Count - 1 && !result.Equals(1))
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

            return true;
        }
    }
}
