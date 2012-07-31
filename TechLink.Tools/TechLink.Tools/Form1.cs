using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraNavBar;
using TechLink.DatabaseViewer;
using TechLink.Views;


namespace TechLink.Tools
{
    public partial class Form1 : RibbonForm
    {
        private string sourceCnn = string.Empty;
        private string destCnn = string.Empty;

        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            InitGrid();

        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        BindingList<Person> gridDataList = new BindingList<Person>();
        void InitGrid()
        {
            gridDataList.Add(new Person("John", "Smith"));
            gridDataList.Add(new Person("Gabriel", "Smith"));
            gridDataList.Add(new Person("Ashley", "Smith", "some comment"));
            gridDataList.Add(new Person("Adrian", "Smith", "some comment"));
            gridDataList.Add(new Person("Gabriella", "Smith", "some comment"));
            //gridControl.DataSource = gridDataList;
        }

        void manageSerial_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        void createLicence_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            LicenceCreator licenceCreator = new LicenceCreator();
            licenceCreator.Dock = DockStyle.Fill;
            this.splitContainerControl.Panel2.Controls.Clear();
            this.splitContainerControl.Panel2.Controls.Add(licenceCreator);
        }

        void copyData_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            MigrateData migrateData = new MigrateData();
            migrateData.Dock= DockStyle.Fill;
            migrateData.GetSourceConnectionClick += new GetConnectionEventHandler(migrateData_GetSourceConnectionClick);
            migrateData.GetDestinationConnectionClick += new GetConnectionEventHandler(migrateData_GetDestinationConnectionClick);
            this.splitContainerControl.Panel2.Controls.Clear();
            this.splitContainerControl.Panel2.Controls.Add(migrateData);
        }

        void migrateData_GetDestinationConnectionClick(object sender, out string connection)
        {
            connection = string.Empty;
            destCnn = string.Empty;
            frmCreateConnection createConnection = new frmCreateConnection();
            createConnection.DatabaseSourceSelected += new DatabaseSeletedEventHandler(createConnection_DatabaseSourceSelected);
            createConnection.DatabaseDestSelected +=new DatabaseSeletedEventHandler(createConnection_DatabaseDestSelected);
            createConnection.ShowDialog(this);
            connection = destCnn;
        }


        void migrateData_GetSourceConnectionClick(object sender, out string connection)
        {
            connection = string.Empty;
            sourceCnn = string.Empty;
            frmCreateConnection createConnection = new frmCreateConnection();
            createConnection.DatabaseSourceSelected += new DatabaseSeletedEventHandler(createConnection_DatabaseSourceSelected);
            createConnection.DatabaseDestSelected += new DatabaseSeletedEventHandler(createConnection_DatabaseDestSelected);
            createConnection.ShowDialog(this);
            connection = sourceCnn;
        }

        void createConnection_DatabaseDestSelected(object sender, DatabaseViewer.DataTransferObjects.DatabaseInfo databaseInfo)
        {
            if (databaseInfo != null)
            {
                destCnn = databaseInfo.ToConnectionString();
            }
            else
            {
                destCnn = string.Empty;
            }
            
        }

        void createConnection_DatabaseSourceSelected(object sender, TechLink.DatabaseViewer.DataTransferObjects.DatabaseInfo databaseInfo)
        {
            if(databaseInfo!=null)
            {
                sourceCnn = databaseInfo.ToConnectionString();
            }
            else
            {
                sourceCnn = string.Empty;
            }
        }

        void trashItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        void iExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

    }
}