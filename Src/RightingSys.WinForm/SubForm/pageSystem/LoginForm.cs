using System;
using System.Data;
using System.Windows.Forms;
using RightingSys.WinForm.Utils.cls;


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
                    clsPublic.ShowMessage("用户和密码错误", this.Text);
                    return false;
                }
                DataRow dataRow = dataTable.Rows[0];

                clsSession._UserId = clsPublic.GetObjGUID(dataRow["Id"]);
                clsSession._LoginName = clsPublic.GetObjectString(dataRow["LoginName"]);
                clsSession._FullName = clsPublic.GetObjectString(dataRow["FullName"]);
                //clsSession._RoleID = appPublic.GetObjGUID(dataRow["RoleID"]);
                //clsSession._RoleName= appPublic.GetObjectString(dataRow["RoleName"]);
                clsSession._DepartmentId = clsPublic.GetObjGUID(dataRow["DepartmentId"]);
                clsSession._DepartmentName= clsPublic.GetObjectString(dataRow["DepartmentName"]);

                return true;
                //if (_appRight.BlackIPIsLogin(clsSession._UserID))
                //{
                //    appLogs.LogOpInfo("用户登录", DateTime.Now);
                //    .UpdateLastLoginInf();
                //    return true;
                //}
                //else {
                //    appPublic.ShowMessage("规则拒绝该用户[" + clsSession._LoginName + "]登录！", this.Text);
                //    appLogs.LogOpInfo("规则拒绝该用户登录", DateTime.Now);
                //    return false ;
                //}
            }
            catch(Exception ex)
            {
                //appLogs.LogError("登录出错", ex);
                clsPublic.ShowMessage("系统出错", this.Text);
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
                clsIniConfig.IniWriteValue("UserConfig", "RemPwd", "1");
                clsIniConfig.IniWriteValue("UserConfig", "LoginName", txtLoginName.Text.Trim());
                clsIniConfig.IniWriteValueEncrypt("UserConfig", "LoginPwd", txtLoginPwd.Text.Trim());
            }
            else
            {
                clsIniConfig.IniWriteValue("UserConfig", "RemPwd", "0");
                clsIniConfig.IniWriteValue("UserConfig", "LoginName", txtLoginName.Text.Trim());
            }
        }

        public  void ReadLoginConfig()
        {
            try
            {
                string IsRemPwd = clsIniConfig.IniReadValue("UserConfig", "RemPwd", "");
                txtLoginName.Text = clsIniConfig.IniReadValue("UserConfig", "LoginName", "");
                if (IsRemPwd == "1")
                {
                    txtLoginPwd.Text = clsIniConfig.IniReadValueDecrypt("UserConfig", "LoginPwd", "");
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


