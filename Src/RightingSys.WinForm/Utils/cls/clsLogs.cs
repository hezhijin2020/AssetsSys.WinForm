using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.WinForm.Utils.cls
{
    public class clsLogs
    {
        private static readonly log4net.ILog appLog = log4net.LogManager.GetLogger("appLogs");
        private static readonly log4net.ILog LogOpration = log4net.LogManager.GetLogger("LogOpration");
        private static readonly log4net.ILog LogEvent = log4net.LogManager.GetLogger("LogEvent");
        private static readonly log4net.ILog LogSQL = log4net.LogManager.GetLogger("LogSQL");


        #region  程序的日志信息
        //一般日志信息
        public static void LogInfo(string msg)
        {
            if (appLog.IsInfoEnabled)
            {
                appLog.Info(msg);
            }
        }
        public static void LogInfo(string msg,Exception ex)
        {
            if (appLog.IsInfoEnabled)
            {
                appLog.Info(msg,ex);
            }
        }

        //调试日志信息
        public static void LogDebug(string msg)
        {
            if (appLog.IsDebugEnabled)
            {
                appLog.Debug(msg);
            }
        }
        public static void LogDebug(string msg, Exception ex = null)
        {
            appLog.Debug(msg, ex);
        }

        //错误日志信息
        public static void LogError(string msg)
        {
            if (appLog.IsErrorEnabled)
            {
                appLog.Error(msg);
            }
        }
        public static void LogError(string msg, Exception ex = null)
        {
            appLog.Error(msg, ex);
        }


        // 致命日志信息
        public static void LogFatal(string msg)
        {
            if (appLog.IsFatalEnabled)
            {
                appLog.Fatal(msg);
            }
        }
        public static void LogFatal(string msg, Exception ex = null)
        {
            appLog.Fatal(msg, ex);
        }

        //警告日志信息
        public static void LogWarn(string msg)
        {
            if (appLog.IsWarnEnabled)
            {
                appLog.Warn(msg);
            }
        }
        public static void LogWarn(string msg, Exception ex = null)
        {
            appLog.Warn(msg, ex);
        }

        #endregion

        #region  LogOpration
        public static void LogOpInfo(string OpName,DateTime OpDate)
        {
            string msg = string.Format(" --[操作名称]：{0} --[操作时间]：{1} --[用户]：{2} --[网卡MAC]：{3} --[网络IP]：{4} ",OpName,OpDate.ToString("yyyy-MM-dd HH:mm:ss"), clsSession._LoginName, clsSession._MACAddress, clsSession._IPAddress);
            if (LogOpration.IsInfoEnabled)
            {
                LogOpration.Info(msg);
            }
        }
        #endregion

        #region LogEvent

        public static void EventInfo(string msg)
        {
            if (LogEvent.IsInfoEnabled)
            {
                LogEvent.Info(msg);
            }
        }
        public static void EventDebug(string msg)
        {
            if (LogEvent.IsDebugEnabled)
            {
                LogEvent.Debug(msg);
            }
        }
        public static void EventError(string msg)
        {
            if (LogEvent.IsErrorEnabled)
            {
                LogEvent.Error(msg);
            }
        }
        public static void EventFatal(string msg)
        {

            if (LogEvent.IsFatalEnabled)
            {
                LogEvent.Fatal(msg);
            }
        }
        public static void EventWarn(string msg)
        {

            if (LogEvent.IsWarnEnabled)
            {
                LogEvent.Warn(msg);
            }
        }

        #endregion

        #region LogSQL

        public static void SQLInfo(string msg)
        {
            if (LogSQL.IsInfoEnabled)
            {
                LogSQL.Info(msg);
            }
        }
        public static void SQLDebug(string msg)
        {
            if (LogSQL.IsDebugEnabled)
            {
                LogSQL.Debug(msg);
            }
        }
        public static void SQLError(string msg)
        {
            if (LogSQL.IsErrorEnabled)
            {
                LogSQL.Error(msg);
            }
        }
        public static void SQLFatal(string msg)
        {

            if (LogSQL.IsFatalEnabled)
            {
                LogSQL.Fatal(msg);
            }
        }
        public static void SQLWarn(string msg)
        {

            if (LogSQL.IsWarnEnabled)
            {
                LogSQL.Warn(msg);
            }
        }
        #endregion

        #region SQL数据库操作日志
        
        public static void Add_LoginLog(string LoginOrExit)
        {
            try
            {
                SqlParameter s1 = new SqlParameter("@UserID", clsSession._UserId);
                SqlParameter s2 = new SqlParameter("@LoginName", clsSession._LoginName);
                SqlParameter s3 = new SqlParameter("@FullName", clsSession._FullName);
                SqlParameter s4 = new SqlParameter("@OUID", clsSession._DepartmentId);
                SqlParameter s5 = new SqlParameter("@OuName", clsSession._DepartmentName);
                SqlParameter s6 = new SqlParameter("@IPAddress", clsSession._IPAddress);
                SqlParameter s7 = new SqlParameter("@MacAddress", clsSession._MACAddress);
                SqlParameter s8 = new SqlParameter("@OpTime", DateTime.Now);
                SqlParameter s9 = new SqlParameter("@SysID", clsSession._SystemId);
                SqlParameter s10 = new SqlParameter("@SysName", clsSession._SystemName);
                SqlParameter s11 = new SqlParameter("@LogDesc", LoginOrExit);


                string sqlText = @"INSERT INTO [dbo].[ACL_LoginLog]
           ([UserID]
           ,[LoginName]
           ,[FullName]
           ,[OUID]
           ,[OuName]
           ,[IPAddress]
           ,[MacAddress]
           ,[OpTime]
           ,[SysID]
           ,[SysName]
           ,[LogDesc])
     VALUES
           (@UserID
           ,@LoginName
           ,@FullName
           ,@OUID
           ,@OuName
           ,@IPAddress
           ,@MacAddress
           ,@OpTime
           ,@SysID
           ,@SysName
           ,@LogDesc)";

               // apps.ExecuteSql(sqlText, new SqlParameter[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11 });
            }
            catch (Exception e)
            {
                clsPublic.ShowException(e, "提示");
                appLog.Error(e.Message);
            }
}
       
        public static void Add_OperationLog(string sLogDesc,DateTime OpTime, string sTableName, string sOperationType, string sSqlText)
        {
            try
            {
                SqlParameter s1 = new SqlParameter("@UserID", clsSession._UserId);
                SqlParameter s2 = new SqlParameter("@LoginName", clsSession._LoginName);
                SqlParameter s3 = new SqlParameter("@FullName", clsSession._FullName);
                SqlParameter s4 = new SqlParameter("@OUID", clsSession._DepartmentId);
                SqlParameter s5 = new SqlParameter("@OuName", clsSession._DepartmentName);
                SqlParameter s6 = new SqlParameter("@IPAddress", clsSession._IPAddress);
                SqlParameter s7 = new SqlParameter("@MacAddress", clsSession._MACAddress);
                SqlParameter s8 = new SqlParameter("@OpTime", DateTime.Now);
                SqlParameter s9 = new SqlParameter("@SysID", clsSession._SystemId);
                SqlParameter s10 = new SqlParameter("@SysName", clsSession._SystemName);
                SqlParameter s11 = new SqlParameter("@LogDesc", sLogDesc);
                SqlParameter s12 = new SqlParameter("@TableName", sTableName);
                SqlParameter s13 = new SqlParameter("@OperationType", sOperationType);
                SqlParameter s14 = new SqlParameter("@SqlText", sSqlText);


                string sqlText = @"INSERT INTO [dbo].[ACL_OperationLog]
           ([LogDesc],[UserID],[LoginName],[FullName],[OUID],[OuName],[TableName],[OperationType],[SQLText],[IPAddress],[MacAddress],[SysID],[SysName])
         VALUES
           (@LogDesc,@UserID,@LoginName,@FullName,@OUID,@OuName,@TableName,@OperationType,@SQLText,@IPAddress,@MacAddress,@SysID,@SysName)";

               // appSQL.ExecuteSql(sqlText, new SqlParameter[] { s1, s2, s3, s4, s5, s6, s7, s9, s10, s11, s12, s13, s14 });
                LogOpInfo(sLogDesc, OpTime);
            }
            catch (Exception e)
            {
                clsPublic.ShowException(e, "提示");
                appLog.Error(e.Message);
            }
        }

        #endregion
    }
}
