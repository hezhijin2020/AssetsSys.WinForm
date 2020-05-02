using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.WinForm.AppPublic
{
    public static class AppRigthing
    {
        /// <summary>
        /// 根据用户ID获取用户权限列表
        /// </summary>
        /// <param name="guidUserId">用户ID</param>
        /// <returns>用户列表</returns>
        public static DataTable GetUserFunction(Guid guidUserId)
        {
            string sqlText=string.Format(@" select a.Role_ID,a.Function_ID,a.OpCode,b.[Name] 
             from ACL_Role_Function as a inner join ACL_Function as b  on a.Function_ID=b.ID  
             where a.Role_ID=(select RoleID from ACL_User
             where UserId='{0}') ", guidUserId);
            return AppPublic.appSQL.Query(sqlText).Tables[0];
        }

        /// <summary>
        /// 根据用户和密码获取用户信息
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <param name="LoginPwd">密码</param>
        /// <returns>用户信息</returns>
        public static DataTable GetUserInfo(string LoginName,string LoginPwd)
        {
            string SqlText = string.Format(@"SELECT a.[UserID],a.[LoginName],a.[LoginPwd],a.[RoleID],a.[FullName],a.[OUID],b.[Name] RoleName,c.[Name] OUName
            FROM [dbo].[ACL_User] as a  left join ACL_Role as b on a.RoleID=b.ID
                                        left join ACL_OU as c on a.OUID=c.ID
            where LoginName='{0}' and LoginPwd='{1}'  and a.Deleted=0 and a.[Enabled]=1", LoginName, LoginPwd);

            return AppPublic.appSQL.Query(SqlText).Tables[0];
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="oldPwd">原密码</param>
        /// <param name="newPwd">新密码</param>
        public static bool ModifyUserPwd(Guid userID, String oldPwd, string newPwd)
        {
            string sqlText = @"UPDATE [dbo].[ACL_User]SET [LoginPwd] = @newPwd
                               WHERE [UserID] = @UserID and [LoginPwd]=@oldPwd ";
            SqlParameter s1 = new SqlParameter("@UserID", userID);
            SqlParameter s2 = new SqlParameter("@newPwd", newPwd);
            SqlParameter s3 = new SqlParameter("@oldPwd", oldPwd);
            int i = AppPublic.appSQL.ExecuteSql(sqlText, new SqlParameter[] { s1, s2, s3 });
            if (i > 0)
                return true;
            else
                return false;
        }

       /// <summary>
       /// 检查用户是否在黑白名单，反回可否登录
       /// </summary>
       /// <param name="UserID"> 用户ID</param>
       /// <returns></returns>
        public static bool BlackIPIsLogin(Guid UserID)
        {
            string IPStart = "";
            string IPEnd = "";
            string sqlText = string.Format(@"select [ID],[Name],[AuthorizeType],[IsEnabled],[IPStart],[IPEnd],[Note],[Creator],[Creator_ID],[CreateTime],[SysID] 
from ACL_BlackIP_User as a inner join ACL_BlackIP as b on a.BlackIP_ID=b.ID
where a.[User_ID]='{0}'",UserID);
            DataTable dt = AppPublic.appSQL.Query(sqlText).Tables[0];
            if (dt == null || dt.Rows.Count == 0)
            {
                return true;
            }

            DataRow[] rows = dt.Select("AuthorizeType=1");
            foreach (DataRow r in rows)
            {
                IPStart = r["IPStart"].ToString();
                IPEnd = r["IPEnd"].ToString();
                if (appPublic.validateIPContains(IPStart, IPEnd, appPublic.getLocalIP()))
                {
                    return true;
                }
            }

            DataRow[] rows1 = dt.Select("AuthorizeType=0");
            foreach (DataRow r in rows1)
            {
                IPStart = r["IPStart"].ToString();
                IPEnd = r["IPEnd"].ToString();
                if (appPublic.validateIPContains(IPStart, IPEnd, appPublic.getLocalIP()))
                {
                    return false;
                }
            }

            return true;
        }
        
      
        /// <summary>
        /// 更新用户最后一次登录信息
        /// </summary>
        public static bool UpdateLastLoginInf()
        {
            string sqlText = @"UPDATE [dbo].[ACL_User]
                               SET [LastLoginTime] =@LastLoginTime
                                  ,[LastLoginMac] = @LastLoginMac
                                  ,[LastLoginIP] = @LastLoginIP
                             WHERE [UserID] = @UserID";
            SqlParameter s1 = new SqlParameter("@UserID", appSession._UserID);
            SqlParameter s2 = new SqlParameter("@LastLoginTime", DateTime.Now);
            SqlParameter s3 = new SqlParameter("@LastLoginMac", appSession._MACAddress);
            SqlParameter s4 = new SqlParameter("@LastLoginIP", appSession._IPAddress);
            int i = AppPublic.appSQL.ExecuteSql(sqlText, new SqlParameter[] { s1, s2, s3,s4 });
            if (i > 0)
                return true;
            else
                return false;
        }
       
    }
}
