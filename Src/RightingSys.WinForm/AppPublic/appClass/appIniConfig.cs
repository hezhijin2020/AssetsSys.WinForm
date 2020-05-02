using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RightingSys.WinForm.AppPublic
{
    /// <summary>
    /// 系统配置文件读取写入
    /// </summary>
    public static class appIniConfig
    {
        //private static string inipath= Application.StartupPath + "\\AppConfig.ini";
        public static string Inipath
        {
            get
            {
                if (!appPublic.FileExists(appSession._AppConfigPath))
                {
                    File.Create(appSession._AppConfigPath);
                }
                return appSession._AppConfigPath;
            }
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="section">要写入的段落名</param>
        /// <param name="key">要读取的键</param>
        /// <param name="val">key所对应的值</param>
        /// <param name="filePath">INI文件的完整路径和文件名</param>
        /// <returns>0、1带表成功和失败</returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="section">要读取的段落名</param>
        /// <param name="key">要读取的键</param>
        /// <param name="def">读取异常的情况下的缺省值</param>
        /// <param name="retVal">key所对应的值，如果该key不存在则返回空值</param>
        /// <param name="size">值允许的大小</param>
        /// <param name="filePath">INI文件的完整路径和文件名</param>
        /// <returns>key所对应的值的长度</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
       
        #region 不加密
        public static void IniWriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, Inipath);
        }
        public static string IniReadValue(string section, string key,string retval)
        {
            StringBuilder temp = new StringBuilder(500);
            int length = GetPrivateProfileString(section, key, retval, temp, 500, Inipath);
            return temp.ToString();
        }
        #endregion

        #region 加密
        public static void IniWriteValueEncrypt(string section, string key, string value)
        {
            WritePrivateProfileString(section, key,appPublic.EncryptString(value), Inipath);
        }
        public static string IniReadValueDecrypt(string section, string key, string retval)
        {
            StringBuilder temp = new StringBuilder(500);
            int length = GetPrivateProfileString(section, key, retval, temp, 500, Inipath);
            return appPublic.DecryptString(temp.ToString());
        }
        #endregion
        
        #region  用户主题配置、读取写入
        public static string ReadDefaultSkinName()
        {
            try
            {
                return appIniConfig.IniReadValue("UserSkin", "DefaultSkin", "Springtime");
            }
            catch
            {
                return "";
            }
        }
        public static void WriteDefaultSkinName(string SkinName)
        {
            appIniConfig.IniWriteValue("UserSkin", "DefaultSkin", SkinName);
        }
        #endregion
        
    }
}
