using System;
using System.Data;
using System.Windows.Forms;
using RightingSys.WinForm.AppPublic;


namespace RightingSys.WinForm.SubForm.pageSystem
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private RightingSys.BLL.RightingSysManager _appRight;
        public LoginForm(RightingSys.BLL.RightingSysManager appRight)
        {
            InitializeComponent();
            _appRight = appRight;
        }

        public void SetFocus()
        {
            if (this.txtLoginName.Text == "")
            {
                this.txtLoginName.Focus();
                return;
            }
            this.txtLoginPwd.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (doLogin())
            {
                SaveLoginConfig();
               // appLogs.Add_LoginLog("用户登录");
                base.DialogResult = DialogResult.OK;
            }
        }
        
        private bool doLogin()
        {
            string text = this.txtLoginName.Text.Trim();
            string text2 = this.txtLoginPwd.Text.Trim();
            try
            {
                DataTable dataTable = _appRight.GetUserInfo(text, text2);
                if (dataTable == null || dataTable.Rows.Count < 1)
                {
                    appPublic.ShowMessage("用户和密码错误", this.Text);
                    return false;
                }
                DataRow dataRow = dataTable.Rows[0];

                appSession._UserId = appPublic.GetObjGUID(dataRow["Id"]);
                appSession._LoginName = appPublic.GetObjectString(dataRow["LoginName"]);
                appSession._FullName = appPublic.GetObjectString(dataRow["FullName"]);
                //appSession._RoleID = appPublic.GetObjGUID(dataRow["RoleID"]);
                //appSession._RoleName= appPublic.GetObjectString(dataRow["RoleName"]);
                appSession._DepartmentId = appPublic.GetObjGUID(dataRow["DepartmentId"]);
                appSession._DepartmentName= appPublic.GetObjectString(dataRow["DepartmentName"]);

                return true;
                //if (_appRight.BlackIPIsLogin(appSession._UserID))
                //{
                //    appLogs.LogOpInfo("用户登录", DateTime.Now);
                //    .UpdateLastLoginInf();
                //    return true;
                //}
                //else {
                //    appPublic.ShowMessage("规则拒绝该用户[" + appSession._LoginName + "]登录！", this.Text);
                //    appLogs.LogOpInfo("规则拒绝该用户登录", DateTime.Now);
                //    return false ;
                //}
            }
            catch(Exception ex)
            {
                //appLogs.LogError("登录出错", ex);
                appPublic.ShowMessage("系统出错", this.Text);
                return false;
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            //DBhelper.Global.Db = new DBhelper.clsConn(GetConnection());
            ReadLoginConfig();
        }

        private string GetConnection()
        {
            string DbServer, DbName, DbLoginName, DbLoginPwd, conn;
            conn = DbServer = DbName = DbLoginName = DbLoginPwd = string.Empty;
            try
            {
                conn = string.Format("data source={0};database={1};user id={2};password={3}", DbServer, DbName, DbLoginName, DbLoginPwd);
            }
            catch (Exception GetConnEx)
            {
               // DBhelper.OpSysLog.WriteErrorLog(this.Text, GetConnEx.Message);
            }
            return conn;
        }

        //public bool IsNeedUpdate()
        //{
        //    bool result;
        //    try
        //    {
        //        string xmlFile = Application.StartupPath + "\\UpdateList.xml";
        //        DBhelper.XmlFiles xmlFiles = new DBhelper.XmlFiles(xmlFile);
        //        string nodeValue = xmlFiles.GetNodeValue("AutoUpdate/Application/Version");
        //        string nodeValue2 = xmlFiles.GetNodeValue("AutoUpdate/Updater/LastUpdateTime");
        //        string sQLString = "select * from ys_AppVersion";
        //        DataTable dataTable = DBhelper.sSQLDB.Query(sQLString).Tables[0];
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            if (nodeValue.CompareTo(dataTable.Rows[0]["AppVersion"].ToString()) < 0)
        //            {
        //                result = true;
        //            }
        //            else if (nodeValue2.CompareTo(dataTable.Rows[0]["AppDate"].ToString()) < 0)
        //            {
        //                result = true;
        //            }
        //            else
        //            {
        //                result = false;
        //            }
        //        }
        //        else
        //        {
        //            result = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        result = false;
        //    }
        //    return result;
        //}


        #region 用户登录信息配置
        public  void SaveLoginConfig()
        {

            if (CheckRemPwd.Checked)
            {
                appIniConfig.IniWriteValue("UserConfig", "RemPwd", "1");
                appIniConfig.IniWriteValue("UserConfig", "LoginName", txtLoginName.Text.Trim());
                appIniConfig.IniWriteValueEncrypt("UserConfig", "LoginPwd", txtLoginPwd.Text.Trim());
            }
            else
            {
                appIniConfig.IniWriteValue("UserConfig", "RemPwd", "0");
                appIniConfig.IniWriteValue("UserConfig", "LoginName", txtLoginName.Text.Trim());
            }
        }

        public  void ReadLoginConfig()
        {
            try
            {
                string IsRemPwd = appIniConfig.IniReadValue("UserConfig", "RemPwd", "");
                txtLoginName.Text = appIniConfig.IniReadValue("UserConfig", "LoginName", "");
                if (IsRemPwd == "1")
                {
                    txtLoginPwd.Text = appIniConfig.IniReadValueDecrypt("UserConfig", "LoginPwd", "");
                    CheckRemPwd.Checked = true;
                }
                else
                {
                    CheckRemPwd.Checked = false;
                }
            }
            catch {

            }
           
        }
        #endregion

    }
}


