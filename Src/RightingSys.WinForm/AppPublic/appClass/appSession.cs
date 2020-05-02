using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightingSys.WinForm.AppPublic
{
    public static class appSession
    {

        public static string _AppConfigPath = Application.StartupPath + "\\AppConfig.ini";
        public static Guid _UserId;
        public static string _LoginName;
        public static string _FullName;
        public static Guid _DepartmentId;
        public static string _DepartmentName;
        public static List<Guid> _RoleIds;
        public static List<Guid> _RoleNames;
        public static Guid _SystemId=Guid.Parse("4c039630-cfeb-49c6-b9ca-e9b51b377724");
        public static string _SystemName= "资产管理系统";
        public static string _IPAddress = appPublic.getLocalIP();
        public static string _MACAddress = appPublic.getLocalMac();

        public static void SessionIntial()
        {
            _UserId = Guid.Empty;
            _LoginName = "";
            _FullName = "";
            _DepartmentId = Guid.Empty;
            _DepartmentName = "";
            _RoleIds=null;
            _RoleNames=null;
        }
    }
}
