using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities.Enums;
using ECustoms.Utilities;
using log4net;

namespace ECustoms
{
    public partial class frmAddGroup : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("Ecustoms.frmAddGroup");

        private Mode _mode;
        private tblGroup _group;
        private int _groupID;
        private UserInfo _userInfo;
        private UserFactory _userBOL;
        private TabPage _tabAddGroup;
        private TabPage _tabUser;
        private TabPage _tabRight;

        public frmAddGroup()
        {
            InitializeComponent();
        }

        public frmAddGroup(Mode mode, int groupID,  UserInfo userInfo)
        {
            InitializeComponent();
            _tabAddGroup = tabControlGroup.TabPages[0];
            _tabUser = tabControlGroup.TabPages[1];
            _tabRight = tabControlGroup.TabPages[2];
            _userInfo = userInfo;
            _group = GroupFactory.getGroupByID(groupID);
            _groupID = groupID;
            _mode = mode;
        }
        //private void addCheckAllHearderForlistGroup(){
        //// customize dataviewgrid, add checkbox column
        //  //DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
        //  //checkboxColumn.Width = 30;
        //  //checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //  // grvPermission.Columns.Insert(0, checkboxColumn);
        //  // add checkbox header
        //   Rectangle rect = grvPermission.GetCellDisplayRectangle(0, -1, true);
        //  // set checkbox header to center of header cell. +1 pixel to position correctly.
        //  rect.X = rect.Location.X + (rect.Width / 4);
        //  CheckBox checkboxHeader = new CheckBox();
        //  checkboxHeader.Name = "checkboxHeader";
        //  checkboxHeader.Size = new Size(18, 18);
        //  checkboxHeader.Location = rect.Location;
        //  checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
        //  grvPermission.Controls.Add(checkboxHeader);
          
        //}

        //private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        //{
        //  for (int i = 0; i < grvPermission.RowCount; i++)
        //  {
        //    grvPermission[0, i].Value = ((CheckBox)grvPermission.Controls.Find("checkboxHeader", true)[0]).Checked;
        //  }
        //  grvPermission.EndEdit();
        //}

        private void frmAddGroup_Load(object sender, EventArgs e)
        {
            this.Text = "Quan ly nhom" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            // Show form to the center
            this.Location = new Point((this.Owner.Width - this.Width) / 2, (this.Owner.Height - this.Height) / 2);
            InitData();
        }

        /// <summary>
        /// Bind Data to gridview
        /// </summary>
        /// <param name="uerInfos">UerInfo objcts</param>
        public void BindData()
        {          
          grvUser.AutoGenerateColumns = false;
          var users = UserInGroupFactory.GetByGroupID(_groupID);
          grvUser.DataSource = users;
        }



        public void LoadAllPermissionData()
        {
          grvPermission.AutoGenerateColumns = false;
          grvPermission.DataSource = PermissionFactory.GetAllPermission();
        }

        public void CheckAllPermissonOfGroup()
        {
          List<tblUserGroupPermission> listUserGroupPermission = UserGroupPermissionFactory.GetByGroupID(_groupID);
          foreach (tblUserGroupPermission obj in listUserGroupPermission)
          {
            foreach (DataGridViewRow dr in grvPermission.Rows)
            {
              if (dr.Cells[1].Value + "" == obj.PermissionID + "")
              {
                dr.Cells[0].Value = true;
                break;
              }
            }
          }
        }

        public void InitData()
        {
            
            if (_mode.Equals(Mode.Create)) // New mode
            {
              tabControlGroup.TabPages.Remove(_tabRight);
              tabControlGroup.TabPages.Remove(_tabUser);

            } else // Edit mode
            {
              // Bind data to the user grid
              this.BindData();
              txtName.Text = _group.GroupName;
              //EnableTab(tabControlGroup.TabPages[0], false);  
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (!Validate()) return;

                if (_mode.Equals(Mode.Create)) // New mode
                {
                    // Only insert the new group if the group name is not exsiting
                    if(!GroupFactory.IsExistingName(txtName.Text.Trim()))
                    {
                        var group = new tblGroup();
                        group.GroupName = txtName.Text.Trim();
                        group.CreatedBy = _userInfo.UserID;
                        group.ModifedBy = _userInfo.UserID;
                        var result = GroupFactory.Insert(group);
                        if(result < 1)
                        {
                            MessageBox.Show(ConstantInfo.MESSAGE_INSERT_FAIL);
                            return;
                        }

                        //getGroup after save
                        tblGroup groupResuilt = new tblGroup();
                        groupResuilt = GroupFactory.getGroupByName(txtName.Text.Trim());
                        _groupID = groupResuilt.GroupID;

                        // Bind the lastest to the parrent
                        Form[] listForm = this.Owner.OwnedForms;
                        foreach (Form form in listForm)
                        {
                          if (form.Name == "FrmListGroup")
                          {
                            ((FrmListGroup) form).InitData();
                          }
                        }
                        MessageBox.Show(ConstantInfo.MESSAGE_INSERT_SUCESSFULLY);
                        //this.Close();
                        btnSave.Enabled = false;
                        tabControlGroup.TabPages.Add(_tabUser);
                        tabControlGroup.TabPages.Add(_tabRight);
                        LoadAllPermissionData();
                        CheckAllPermissonOfGroup();
                        //EnableTab(tabControlGroup.TabPages[0],false);

                    } else
                    {
                        MessageBox.Show(ConstantInfo.MESSAGE_GROUP_NAME_EXISTING);
                    }
                }
                else // Edit mode
                {
                  // Update Group
                  tblGroup group = GroupFactory.getGroupByID(_groupID);
                  if (group == null)
                  {
                    MessageBox.Show(ConstantInfo.MESSAGE_GROUP_NOT_EXIST);
                    return;
                  }

                  tblGroup groupCheck = GroupFactory.getGroupByName(txtName.Text.Trim());
                  if (groupCheck != null && (groupCheck.GroupID != _groupID && groupCheck.GroupName == txtName.Text.Trim()))
                  {
                    MessageBox.Show(ConstantInfo.MESSAGE_GROUP_NAME_EXISTING);
                    return;
                  }

                  //update group
                  group.GroupName = txtName.Text.Trim();
                  GroupFactory.Update(group);
                  // Bind the lastest to the parrent
                  Form[] listForm = this.Owner.OwnedForms;
                  foreach (Form form in listForm)
                  {
                    if (form.Name == "FrmListGroup")
                    {
                      ((FrmListGroup)form).InitData();
                    }
                  }
                  MessageBox.Show(ConstantInfo.MESSAGE_UPDATE_SUCESSFULLY);

                }

            } catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        public void EnableTab(TabPage page, bool enable)
        {
          EnableControls(page.Controls, enable);
        }
        private static void EnableControls(Control.ControlCollection ctls, bool enable)
        {
          foreach (Control ctl in ctls)
          {
            ctl.Enabled = enable;
            EnableControls(ctl.Controls, enable);
          }
        }



        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show(ConstantInfo.MESSAGE_BLANK_NAME);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void grvUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        //cap nhat danh sach nguoi dung cua nhom
        private void btnAdd_Click(object sender, EventArgs e)
        {
          var addGroup = new frmListUserToAddInGroup(_mode, _groupID, _userInfo);
          addGroup.Show(this.Owner);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          try
          {
            if (grvUser.SelectedRows.Count > 0)
            {
              var dr = MessageBox.Show("Bạn có chắc là muốn xóa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (dr == DialogResult.Yes)
              {
                for (int i = 0; i < grvUser.SelectedRows.Count; i++)
                {
                  var userID = Int32.Parse(grvUser.SelectedRows[i].Cells["UserID"].Value.ToString());
                  UserInGroupFactory.DeleteUserInGroup(_groupID, userID) ;
                }
                MessageBox.Show("Xóa xong");
                BindData();
              }
            }
            else
            {
              MessageBox.Show("Bạn cần chọn tờ khai.");
            }
          }
          catch (Exception ex)
          {
            MessageBox.Show("Xóa bị lỗi");
            logger.Error(ex.ToString());
            if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
          }
        }

        private void btnUpdatePermission_Click(object sender, EventArgs e)
        {
          //check is group exist
          tblGroup group = GroupFactory.getGroupByID(_groupID);
          if (group == null)
          {
            MessageBox.Show("Nhóm người dùng này không còn tại tại trong hệ thống nữa, xin kiểm tra lại");
            return;
          }

          //delete all old permissions
          UserGroupPermissionFactory.DeleteUserGroupPermissionByGroupID(_groupID);
          
          //add new permissions
          try
          {
            List<tblUserGroupPermission> listUserGroupPermission = new List<tblUserGroupPermission>();
            foreach (DataGridViewRow dr in grvPermission.Rows)
            {
              if (dr.Cells[0].Value + "" == "True")
              {
                int permissionID = (int)dr.Cells[1].Value;
                tblUserGroupPermission userGroupPermission = new tblUserGroupPermission();
                userGroupPermission.GroupID = _groupID;
                userGroupPermission.PermissionID = permissionID;
                userGroupPermission.PermissionType = UserGroupPermissionFactory.PERMISSION_TYPE_GROUP;
                userGroupPermission.CreatedBy = _userInfo.UserID;
                userGroupPermission.ModifiedBy = _userInfo.UserID;
                userGroupPermission.CreatedDate = CommonFactory.GetCurrentDate();
                userGroupPermission.ModifiedDate = CommonFactory.GetCurrentDate();
                //add to listUserGroupPermission
                listUserGroupPermission.Add(userGroupPermission);
              }
            }

            //save listUserGroupPermission to database
            UserGroupPermissionFactory.Insert(listUserGroupPermission);
          }
          catch (Exception)
          {
            MessageBox.Show(ConstantInfo.MESSAGE_ADD_USER_IN_GROUP_FAIL);
            return;
          }

          MessageBox.Show(ConstantInfo.MESSAGE_ADD_USER_IN_GROUP_SUCESSFULLY);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
          LoadAllPermissionData();
          CheckAllPermissonOfGroup();
        }

        private void tabControlGroup_Click(object sender, EventArgs e)
        {
          if (tabControlGroup.SelectedIndex == 2)
          {
            LoadAllPermissionData();
            CheckAllPermissonOfGroup();
          }
        }

        private void chbCheckAllPermission_CheckedChanged(object sender, EventArgs e)
        {
          for (int i = 0; i < grvPermission.RowCount; i++)
          {
            grvPermission[0, i].Value = chbCheckAllPermission.Checked;
          }
          grvPermission.EndEdit();
        }

 

    }
}
