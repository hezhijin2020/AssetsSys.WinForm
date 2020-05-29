
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using RightingSys.WinForm.AppPublic.Enum;

namespace RightingSys.WinForm.AppPublic
{
    public static class appPublic
    {
        public const string NORIGHT = "权限不足!";

        public const string CAUTION = "Caution";

        public const string ERROR = "Error";

        public const string GuidZero = "00000000-0000-0000-0000-000000000000";

        public const string AppName = "YSPOS";

        public static string Culture = "zh-CN";

        public static System.Resources.ResourceManager manGlb;

        private static string _appDir = string.Empty;

       // private static AlertControl _AlertMsgbox = null;

        public static System.Globalization.CultureInfo CurrentCultureInfo
        {
            get;
            set;
        }


        
        public static bool IsDataTableChanged(DataTable dt)
        {
            DataTable changes = dt.GetChanges(DataRowState.Added | DataRowState.Deleted | DataRowState.Modified);
            return changes != null && changes.Rows.Count != 0;
        }

        public static bool TypeIsCurrOrSubClass(System.Type t1, System.Type parType)
        {
            return t1 == parType || t1.IsSubclassOf(parType);
        }

        public static bool IsNullableType(System.Type theType)
        {
            return theType.IsGenericType && theType.GetGenericTypeDefinition().Equals(typeof(System.Nullable<>));
        }

        public static bool ClassInteritFromInterface(System.Type ClsType, System.Type IntfType)
        {
            if (!IntfType.IsInterface)
            {
                return false;
            }
            System.Type @interface = ClsType.GetInterface(IntfType.ToString());
            return @interface.Equals(IntfType);
        }

        public static DataTable ToDataTable(System.Collections.IList list)
        {
            DataTable dataTable = new DataTable();
            if (list.Count > 0)
            {
                System.Reflection.PropertyInfo[] properties = list[0].GetType().GetProperties();
                System.Reflection.PropertyInfo[] array = properties;
                for (int i = 0; i < array.Length; i++)
                {
                    System.Reflection.PropertyInfo propertyInfo = array[i];
                    if (!appPublic.IsNullableType(propertyInfo.PropertyType))
                    {
                        dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
                    }
                }
                for (int j = 0; j < list.Count; j++)
                {
                    System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
                    System.Reflection.PropertyInfo[] array2 = properties;
                    for (int k = 0; k < array2.Length; k++)
                    {
                        System.Reflection.PropertyInfo propertyInfo2 = array2[k];
                        if (!appPublic.IsNullableType(propertyInfo2.PropertyType))
                        {
                            object value = propertyInfo2.GetValue(list[j], null);
                            arrayList.Add(value);
                        }
                    }
                    object[] values = arrayList.ToArray();
                    dataTable.LoadDataRow(values, true);
                }
            }
            return dataTable;
        }

        //public static DataTable ToDataTable(System.Collections.IList list, System.Collections.Generic.List<string> ValidFields)
        //{
        //    DataTable dataTable = new DataTable();
        //    bool flag = ValidFields != null && 0 < ValidFields.Count;
        //    if (list.Count > 0)
        //    {
        //        System.Reflection.PropertyInfo[] properties = list[0].GetType().GetProperties();
        //        System.Reflection.PropertyInfo[] array = properties;
        //        for (int i = 0; i < array.Length; i++)
        //        {
        //            System.Reflection.PropertyInfo propertyInfo = array[i];
        //            if (!appPublic.IsNullableType(propertyInfo.PropertyType) && (!flag || ValidFields.Contains(propertyInfo.Name, new StringCompareNoCase())))
        //            {
        //                dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
        //            }
        //        }
        //        for (int j = 0; j < list.Count; j++)
        //        {
        //            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
        //            System.Reflection.PropertyInfo[] array2 = properties;
        //            for (int k = 0; k < array2.Length; k++)
        //            {
        //                System.Reflection.PropertyInfo propertyInfo2 = array2[k];
        //                if (!appPublic.IsNullableType(propertyInfo2.PropertyType) && (!flag || ValidFields.Contains(propertyInfo2.Name, new StringCompareNoCase())))
        //                {
        //                    object value = propertyInfo2.GetValue(list[j], null);
        //                    arrayList.Add(value);
        //                }
        //            }
        //            object[] values = arrayList.ToArray();
        //            dataTable.LoadDataRow(values, true);
        //        }
        //    }
        //    return dataTable;
        //}



        public static bool DataTypeIsNumber(System.Type DataType)
        {
            return appPublic.DataTypeIsFloat(DataType) || appPublic.DataTypeIsInt(DataType);
        }
        
        public static System.Collections.Generic.List<T> GetListBlock<T>(System.Collections.Generic.List<T> Lst, int TotalCount, int RowsPerBlock, int CurrIndex)
        {
            System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();
            int num = (CurrIndex - 1) * RowsPerBlock;
            int num2 = num + RowsPerBlock - 1;
            int num3 = num;
            while (num3 <= num2 && num3 < TotalCount)
            {
                list.Add(Lst[num3]);
                num3++;
            }
            return list;
        }

        public static bool GetArrayFromTo(int TotalCount, int RowsPerBlock, int CurrIndex, out int From, out int To)
        {
            From = (CurrIndex - 1) * RowsPerBlock;
            To = From + RowsPerBlock - 1;
            if (To > TotalCount)
            {
                To = TotalCount - 1;
            }
            return From >= 0 && From < TotalCount && To >= 0 && To < TotalCount;
        }

        public static int GetBlockCount(int TotalCount, int RowsPerBlock)
        {
            if (TotalCount % RowsPerBlock != 0)
            {
                return TotalCount / RowsPerBlock + 1;
            }
            return TotalCount / RowsPerBlock;
        }

        public static System.Collections.Generic.List<string> GetDateArrangeList(System.DateTime DtF, System.DateTime DtTo)
        {
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            System.DateTime t = appPublic.GetDateOnly(DtF);
            while (t <= DtTo)
            {
                list.Add(t.ToString("yyyy-MM-dd"));
                t = t.AddDays(1.0);
            }
            return list;
        }

        public static System.Collections.Generic.List<System.DateTime> GetDateArrangeLst(System.DateTime DtF, System.DateTime DtTo)
        {
            System.Collections.Generic.List<System.DateTime> list = new System.Collections.Generic.List<System.DateTime>();
            System.DateTime dateTime = appPublic.GetDateOnly(DtF);
            while (dateTime <= DtTo)
            {
                list.Add(dateTime);
                dateTime = dateTime.AddDays(1.0);
            }
            return list;
        }

        public static System.DateTime TruncateToHalfHour(System.DateTime dt)
        {
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;
            int hour = dt.Hour;
            int num = dt.Minute;
            if (num >= 30)
            {
                num = 30;
            }
            else
            {
                num = 0;
            }
            return new System.DateTime(year, month, day, hour, num, 0);
        }

        public static System.DateTime TruncateToHour(System.DateTime dt)
        {
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;
            int hour = dt.Hour;
            return new System.DateTime(year, month, day, hour, 0, 0);
        }

        public static System.Collections.Generic.List<string> CutFixxedLenStr(string objString, int length)
        {
            if (string.Empty.Equals(objString))
            {
                return null;
            }
            objString = objString.Replace("&nbsp;", " ");
            objString = objString.Replace("&gt;", ">");
            objString = objString.Replace("&lt;", "<");
            char[] array = objString.ToCharArray();
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("gb2312");
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            string text = string.Empty;
            int num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int num2 = encoding.GetBytes(array, i, 1).Length;
                if (num + num2 > length)
                {
                    list.Add(text);
                    num = 0;
                    text = string.Empty;
                    i--;
                }
                else
                {
                    text += string.Format("{0}", objString[i]);
                    num += num2;
                }
            }
            if (!string.Empty.Equals(text, System.StringComparison.OrdinalIgnoreCase))
            {
                list.Add(text);
            }
            return list;
        }

        public static System.Collections.Generic.List<string> CutFixxedLenStrEn(string objStr, int length)
        {
            objStr = objStr.Replace("  ", " ").Replace("   ", " ").Replace("。", ".").Replace("！", "!").Replace("，", ",");
            int length2 = objStr.Length;
            if (string.Empty.Equals(objStr, System.StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            string[] array = objStr.Split(new char[]
            {
                ' ',
                ',',
                ';',
                '?',
                '!'
            });
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            string text = string.Empty;
            int num = 0;
            int num2 = 0;
            int i = 0;
            int num3 = array.Length;
            while (i < num3)
            {
                string text2 = array[i];
                if (string.Empty.Equals(text2))
                {
                    num2++;
                }
                else
                {
                    int length3 = text2.Length;
                    if (num + length3 > length)
                    {
                        list.Add(text);
                        text = string.Empty;
                        num = 0;
                        i--;
                    }
                    else
                    {
                        text += text2;
                        num2 += length3 + 1;
                        num += length3;
                        if (length2 > num2)
                        {
                            text += string.Format("{0}", objStr[num2 - 1]);
                            num++;
                        }
                    }
                }
                i++;
            }
            if (!string.Empty.Equals(text, System.StringComparison.OrdinalIgnoreCase))
            {
                list.Add(text);
            }
            return list;
        }

        public static string CutFixLenStrEn(string str, int Len)
        {
            System.Collections.Generic.List<string> list = appPublic.CutFixxedLenStrEn(str, Len);
            string text = string.Empty;
            if (list != null)
            {
                foreach (string current in list)
                {
                    text += current;
                    text += System.Environment.NewLine;
                }
            }
            return text;
        }

        public static string GetTopNChars(string str, int TopN)
        {
            int length = str.Length;
            if (length <= TopN)
            {
                return str;
            }
            return str.Substring(0, TopN);
        }

        public static bool StringArrHasValue(string[] Arr, string Value, bool IgoreCase)
        {
            if (Arr == null || Arr.Length == 0)
            {
                return false;
            }
            int num = Arr.Length;
            for (int i = 0; i < num; i++)
            {
                if (string.Compare(Arr[i], Value, IgoreCase) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static int TimesInStr(string text1, string text2)
        {
            int num = 0;
            int num2 = text1.IndexOf(text2);
            while (num2 != -1)
            {
                int num3 = text1.IndexOf(text2) + text2.Length;
                int length = text1.Length - num3;
                if (num3 != -1)
                {
                    text1 = text1.Substring(num3, length);
                }
                num2 = text1.IndexOf(text2);
                num++;
            }
            return num;
        }

        public static bool IsPrintableChar(char chr)
        {
            return char.IsDigit(chr) || char.IsLetter(chr) || char.IsNumber(chr) || char.IsPunctuation(chr) || char.IsSeparator(chr) || char.IsSymbol(chr) || char.IsWhiteSpace(chr);
        }

        public static bool StringHasDuplicate(params string[] obj)
        {
            int num = obj.Length;
            if (num <= 1)
            {
                return false;
            }
            StringDictionary stringDictionary = null;
            bool result;
            try
            {
                stringDictionary = new StringDictionary();
                for (int i = 0; i < num; i++)
                {
                    stringDictionary.Add(obj[i], i.ToString());
                }
                result = false;
            }
            catch
            {
                result = true;
            }
            finally
            {
                if (stringDictionary != null)
                {
                    stringDictionary = null;
                }
            }
            return result;
        }

        public static bool StringHasDuplicate(bool IgnoreBlank, params string[] obj)
        {
            int num = obj.Length;
            if (num <= 1)
            {
                return false;
            }
            StringDictionary stringDictionary = null;
            bool result;
            try
            {
                stringDictionary = new StringDictionary();
                for (int i = 0; i < num; i++)
                {
                    if (!IgnoreBlank || !(obj[i] == ""))
                    {
                        stringDictionary.Add(obj[i], i.ToString());
                    }
                }
                result = false;
            }
            catch
            {
                result = true;
            }
            finally
            {
                if (stringDictionary != null)
                {
                    stringDictionary = null;
                }
            }
            return result;
        }

        public static string DBCToSBC(string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == ' ')
                {
                    array[i] = '\u3000';
                }
                else if (array[i] < '\u007f' && array[i] > ' ')
                {
                    array[i] += 'ﻠ';
                }
            }
            return new string(array);
        }

        public static string SBCToDBC(string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '\u3000')
                {
                    array[i] = ' ';
                }
                else if (array[i] > '＀' && array[i] < '｟')
                {
                    array[i] -= 'ﻠ';
                }
            }
            return new string(array);
        }

        public static string GetSQLString(string Value, bool IsString)
        {
            if (!IsString)
            {
                return Value;
            }
            return string.Format("'{0}'", Value);
        }

        public static bool StringArrayHasDumplicateValue(string[] Arr, bool IngoreCase)
        {
            int num = Arr.Length;
            if (num < 1)
            {
                return false;
            }
            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    if (string.Compare(Arr[i], Arr[j], IngoreCase) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string StringToSqlFormat(string Str)
        {
            return string.Format("'{0}'", Str.Trim().Replace("'", "''"));
        }

        public static void AddArrayToLst(System.Collections.ArrayList Lst, string[] Arr)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                string text = Arr[i];
                if (!(text == "") && !Lst.Contains(text))
                {
                    Lst.Add(text);
                }
            }
        }

        public static string[] ConvertLstToArr(System.Collections.ArrayList Lst)
        {
            int count = Lst.Count;
            string[] array;
            if (count == 0)
            {
                array = new string[]
                {
                    "NULL"
                };
                return array;
            }
            array = new string[count];
            int num = 0;
            foreach (object current in Lst)
            {
                array[num++] = current.ToString();
            }
            return array;
        }

        public static string ConvertLstToStrComm(System.Collections.ArrayList Lst)
        {
            string text = "";
            foreach (object current in Lst)
            {
                text = text + current.ToString() + ";";
            }
            return text;
        }

        public static string IsStringEmpty(string Str, string Instead)
        {
            if (Str.Trim() == string.Empty)
            {
                return Instead;
            }
            return Str;
        }

        public static void AddArrayToLst(System.Collections.ArrayList Lst, string ArrWithComm)
        {
            string[] arr = ArrWithComm.Split(new char[]
            {
                ';'
            });
            appPublic.AddArrayToLst(Lst, arr);
        }

        public static bool CreateIPC(string dest, string UserName, string Password, string MapLetter)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            string text = "/c net use ";
            if (MapLetter != "")
            {
                text = text + MapLetter + " ";
            }
            text += dest;
            if (UserName != "")
            {
                text += string.Format(" {0} /user:{1}", Password, UserName);
            }
            process.StartInfo.Arguments = text;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string text2 = process.StandardOutput.ReadToEnd();
            return 0 > text2.IndexOf("error");
        }

        public static string ShowNoRight(string Right)
        {
            return "权限不足! (" + Right + ")";
        }

        public static string GetStringFormat(int Index)
        {
            return "{" + Index.ToString() + "}";
        }

        public static string GetListElementToString<T>(System.Collections.Generic.IList<T> MyList, string EleName)
        {
            string text = "";
            if (MyList == null)
            {
                return "";
            }
            System.Reflection.PropertyInfo property = typeof(T).GetProperty(EleName);
            if (property == null)
            {
                return "";
            }
            foreach (T current in MyList)
            {
                text += property.GetValue(current, null) == null ? "Null" : property.GetValue(current, null).ToString();
                text += ";";
            }
            return text;
        }

        public static T GetListElement<T, M>(System.Collections.Generic.List<T> MyList, string PropertyName, M Value)
        {
            if (MyList == null || MyList.Count == 0)
            {
                return default(T);
            }
            System.Reflection.PropertyInfo property = typeof(T).GetProperty(PropertyName);
            if (null == property)
            {
                return default(T);
            }
            foreach (T current in MyList)
            {
                M m = (M)((object)property.GetValue(current, null));
                if (m.Equals(Value))
                {
                    return current;
                }
            }
            return default(T);
        }

        public static bool ListHasPropertyValue<T>(System.Collections.Generic.IList<T> MyList, string PropertyName, string Value)
        {
            if (MyList == null)
            {
                return false;
            }
            System.Reflection.PropertyInfo property = typeof(T).GetProperty(PropertyName);
            if (property == null)
            {
                return false;
            }
            foreach (T current in MyList)
            {
                if (property.GetValue(current, null).ToString() == Value)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ListHasPropertyValueIgCase<T>(System.Collections.Generic.IList<T> MyList, string PropertyName, string Value)
        {
            if (MyList == null)
            {
                return false;
            }
            System.Reflection.PropertyInfo property = typeof(T).GetProperty(PropertyName);
            if (property == null)
            {
                return false;
            }
            foreach (T current in MyList)
            {
                if (string.Compare(property.GetValue(current, null).ToString().Trim(), Value.Trim()) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetStringListString(System.Collections.Generic.List<string> Lst, string bracket, string sep)
        {
            if (Lst == null)
            {
                return "";
            }
            string text = "";
            int count = Lst.Count;
            for (int i = 0; i < count; i++)
            {
                text += string.Format("{0}{1}{0}", bracket, Lst[i]);
                if (i == count - 1)
                {
                    break;
                }
                text += sep;
            }
            return text;
        }

        public static System.Reflection.FieldInfo GetListFieldInfo<T>(System.Collections.Generic.IList<T> MyList, string FieldName)
        {
            if (MyList == null)
            {
                return null;
            }
            System.Reflection.FieldInfo[] fields = typeof(T).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            System.Reflection.FieldInfo result = null;
            System.Reflection.FieldInfo[] array = fields;
            for (int i = 0; i < array.Length; i++)
            {
                System.Reflection.FieldInfo fieldInfo = array[i];
                if (fieldInfo.Name == FieldName)
                {
                    result = fieldInfo;
                    break;
                }
            }
            return result;
        }

        public static bool ListHasFieldValue<T>(System.Collections.Generic.IList<T> MyList, string FieldName, string Value)
        {
            System.Reflection.FieldInfo listFieldInfo = appPublic.GetListFieldInfo<T>(MyList, FieldName);
            if (listFieldInfo == null)
            {
                return false;
            }
            foreach (T current in MyList)
            {
                if (listFieldInfo.GetValue(current).ToString() == Value)
                {
                    return true;
                }
            }
            return false;
        }

        
        public static bool IsNullOrDBNull(object obj)
        {
            return obj == null || System.DBNull.Value == obj;
        }

        public static bool IsGuid(string Str, out System.Guid Ret)
        {
            System.Guid.TryParse("00000000-0000-0000-0000-000000000000", out Ret);
            return System.Guid.TryParse(Str, out Ret);
        }

        public static bool IsGuid(string Str)
        {
            System.Guid guid = System.Guid.NewGuid();
            return System.Guid.TryParse(Str, out guid);
        }

        public static string Serialize(object o)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            using (System.IO.StringWriter stringWriter = new System.IO.StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(stringWriter, o);
            }
            return stringBuilder.ToString();
        }

        public static T Deserialize<T>(string s)
        {
            XmlDocument xmlDocument = new XmlDocument();
            T result;
            try
            {
                xmlDocument.LoadXml(s);
                using (XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument.DocumentElement))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    object obj = xmlSerializer.Deserialize(xmlNodeReader);
                    result = (T)((object)obj);
                }
            }
            catch
            {
                result = default(T);
            }
            return result;
        }

        public static string Guid2Str(System.Guid guidVal)
        {
            return guidVal.ToString().ToUpper();
        }
        public static string ToCurrencyString(string txt)
        {
            float num = 0f;
            if (!float.TryParse(txt, out num))
            {
                num = 0f;
            }
            return num.ToString("c");
        }
        public static string ToCurrencyString(object obj)
        {
            float num = 0f;
            if (!float.TryParse(appPublic.GetObjectString(obj), out num))
            {
                num = 0f;
            }
            return num.ToString("c");
        }

        public static void BinarySerialize(object obj, string fileName)
        {
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.Open(fileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, obj);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        public static T BinaryDeserialize<T>(string fileName)
        {
            T t = default(T);
            System.IO.Stream stream = null;
            T result;
            try
            {
                stream = System.IO.File.Open(fileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                t = (T)((object)binaryFormatter.Deserialize(stream));
                result = t;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return result;
        }

        public static string ToOracleSql(string strSQL)
        {
            return strSQL.Replace('\n', ' ').Replace('\r', ' ');
        }

        public static bool StrAreSameUpperTrim(string str1, string str2)
        {
            return 0 == string.Compare(str1.Trim(), str2.Trim(), true);
        }

        public static bool StrAreSame(string str1, string str2)
        {
            return 0 == string.Compare(str1, str2);
        }

        public static bool StrAreSameIngoreCase(string str1, string str2)
        {
            return str1.Equals(str2, System.StringComparison.OrdinalIgnoreCase);
        }

        public static string ByteArrayToString(byte[] Arr)
        {
            string text = "";
            for (int i = 0; i < Arr.Length; i++)
            {
                text += (char)Arr[i];
            }
            return text;
        }

        public static string StrArrayToString2(string[] Arr, string Sep)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            if (Arr == null || Arr.Length == 0)
            {
                return string.Empty;
            }
            int i = 0;
            int num = Arr.Length;
            while (i < num)
            {
                if (!(Arr[i] == ""))
                {
                    stringBuilder.Append(Arr[i]);
                    if (i < num - 1)
                    {
                        stringBuilder.Append(Sep);
                    }
                }
                i++;
            }
            return stringBuilder.ToString();
        }

        public static string StrArrayToString(string[] Arr, string Sep)
        {
            if (Arr == null || Arr.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(Sep, Arr);
        }

        public static string StrLstToString2(System.Collections.Generic.List<string> lst, string sep)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            if (lst == null || lst.Count == 0)
            {
                return string.Empty;
            }
            int i = 0;
            int count = lst.Count;
            while (i < count)
            {
                if (!(lst[i] == ""))
                {
                    stringBuilder.Append(lst[i]);
                    if (i < count - 1)
                    {
                        stringBuilder.Append(sep);
                    }
                }
                i++;
            }
            return stringBuilder.ToString();
        }

        public static string StrLstToString(System.Collections.Generic.List<string> lst, string sep)
        {
            if (lst == null || lst.Count == 0)
            {
                return string.Empty;
            }
            return string.Join(sep, lst.ToArray<string>());
        }

        public static T GetEnumItemByValue<T>(int Value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new System.Exception("Not enum!");
            }
            return (T)((object)System.Enum.ToObject(typeof(T), Value));
        }

        public static T GetEnumByKey<T>(string Key)
        {
            if (!typeof(T).IsEnum)
            {
                throw new System.Exception("Not enum!");
            }
            return (T)((object)System.Enum.Parse(typeof(T), Key));
        }

        public static void GetInherittedControls<T>(System.Windows.Forms.Control parCon, ref System.Collections.Generic.List<System.Windows.Forms.Control> Ret)
        {
            if (Ret == null)
            {
                Ret = new System.Collections.Generic.List<System.Windows.Forms.Control>();
            }
            foreach (System.Windows.Forms.Control control in parCon.Controls)
            {
                bool flag = control is T;
                if (flag)
                {
                    Ret.Add(control);
                }
                if (control.Controls.Count > 0)
                {
                    appPublic.GetControls<T>(control, ref Ret);
                }
            }
        }

        public static bool MenuLastItemIsSeparator(System.Windows.Forms.ContextMenuStrip menu)
        {
            if (menu == null)
            {
                return true;
            }
            int count = menu.Items.Count;
            if (count == 0)
            {
                return false;
            }
            System.Windows.Forms.ToolStripSeparator toolStripSeparator = menu.Items[count - 1] as System.Windows.Forms.ToolStripSeparator;
            return null != toolStripSeparator;
        }
        
        
        private static string GetShortExec(string Prog)
        {
            int num = Prog.LastIndexOf(".");
            if (num <= 0)
            {
                return Prog;
            }
            return Prog.Substring(0, num);
        }

        private static string GetFileNameOnly(string fileName)
        {
            return appPublic.GetShortExec(new System.IO.FileInfo(fileName).Name);
        }

        public static bool ProgInMemory(string Exe)
        {
            return Process.GetProcessesByName(appPublic.GetShortExec(Exe)).Length > 0;
        }

        public static bool ProgInMemoryExptId(string Exe, int Id)
        {
            Process[] processesByName = Process.GetProcessesByName(appPublic.GetShortExec(Exe));
            int num = processesByName.Length;
            for (int i = 0; i < num; i++)
            {
                if (processesByName[i].Id != Id)
                {
                    return true;
                }
            }
            return false;
        }

        public static string ContactFilePath(string path1, string path2)
        {
            if (path1.Trim() == "")
            {
                return path2;
            }
            if (path2.Trim() == "")
            {
                return path1;
            }
            if (path1.EndsWith("\\"))
            {
                return path1 + path2;
            }
            return path1 + "\\" + path2;
        }
        
        public static bool IsDigitKey(System.Windows.Forms.Keys key)
        {
            return (key >= System.Windows.Forms.Keys.D0 && key <= System.Windows.Forms.Keys.D9) || (key >= System.Windows.Forms.Keys.NumPad0 && key <= System.Windows.Forms.Keys.NumPad9);
        }

        public static bool IsDecimalKey(System.Windows.Forms.Keys key)
        {
            return key == System.Windows.Forms.Keys.Decimal;
        }

        public static bool IsControlKey(System.Windows.Forms.Keys key)
        {
            return key == System.Windows.Forms.Keys.Delete || key == System.Windows.Forms.Keys.Up || key == System.Windows.Forms.Keys.Down || key == System.Windows.Forms.Keys.Back || key == System.Windows.Forms.Keys.Return || key == System.Windows.Forms.Keys.Left || key == System.Windows.Forms.Keys.Right || key == System.Windows.Forms.Keys.Escape;
        }

        public static bool HasDecimal(string Input)
        {
            return Input.IndexOf('.') >= 0;
        }

        public static bool HasSubNum(string Input)
        {
            return Input.IndexOf('-') >= 0;
        }

        public static bool IsSubNum(System.Windows.Forms.Keys key)
        {
            return key == System.Windows.Forms.Keys.Subtract;
        }

        public static decimal Truncate(decimal Num, int Length)
        {
            if (Length < 0)
            {
                return Num;
            }
            if (Length == 0)
            {
                return System.Math.Truncate(Num);
            }
            int num = 1;
            for (int i = 1; i <= Length; i++)
            {
                num *= 10;
            }
            return System.Math.Truncate(Num * num) / num;
        }

        public static double Truncate(double Num, int Length)
        {
            if (Length < 0)
            {
                return Num;
            }
            if (Length == 0)
            {
                return System.Math.Truncate(Num);
            }
            int num = 1;
            for (int i = 1; i <= Length; i++)
            {
                num *= 10;
            }
            return System.Math.Truncate(Num * (double)num) / (double)num;
        }

        public static float Truncate(float Num, int Length)
        {
            if (Length < 0)
            {
                return Num;
            }
            if (Length == 0)
            {
                return (float)System.Math.Truncate((decimal)Num);
            }
            int num = 1;
            for (int i = 1; i <= Length; i++)
            {
                num *= 10;
            }
            return (float)(System.Math.Truncate((decimal)(Num * (float)num)) / num);
        }

        public static bool DataTypeIsFloat(System.Type DataType)
        {
            return DataType == typeof(double) || DataType == typeof(float) || DataType == typeof(float) || DataType == typeof(decimal);
        }

        public static bool DataTypeIsInt(System.Type DataType)
        {
            return DataType == typeof(int) || DataType == typeof(short) || DataType == typeof(int) || DataType == typeof(long) || DataType == typeof(byte);
        }

        public static int TruncateToMod(int Value, int Mod)
        {
            int num = Value / Mod;
            return num * Mod;
        }

        public static double Round(double value, int decimals)
        {
            if (value < 0.0)
            {
                return System.Math.Round(value + 5.0 / System.Math.Pow(10.0, (double)(decimals + 1)), decimals, System.MidpointRounding.AwayFromZero);
            }
            return System.Math.Round(value, decimals, System.MidpointRounding.AwayFromZero);
        }

        public static decimal Round(decimal value, int decimals)
        {
            double value2 = (double)value;
            double num = appPublic.Round(value2, decimals);
            return (decimal)num;
        }

        public static float Round(float value, int decimals)
        {
            double value2 = (double)value;
            double num = appPublic.Round(value2, decimals);
            return (float)num;
        }


        public static System.Windows.Forms.TreeNode FindTreeNodeByTag(System.Windows.Forms.TreeNode thisNode, string Content)
        {
            if (thisNode == null)
            {
                return null;
            }
            if (thisNode.Tag == null || thisNode.Tag == System.DBNull.Value)
            {
                return null;
            }
            if (thisNode.Tag.ToString().ToUpper().Equals(Content.ToUpper()))
            {
                return thisNode;
            }
            foreach (System.Windows.Forms.TreeNode thisNode2 in thisNode.Nodes)
            {
                System.Windows.Forms.TreeNode treeNode = appPublic.FindTreeNodeByTag(thisNode2, Content);
                if (treeNode != null)
                {
                    return treeNode;
                }
            }
            return null;
        }

        public static void CheckTreeNode(System.Windows.Forms.TreeNode thisNode, bool Checked)
        {
            if (thisNode.Nodes.Count == 0)
            {
                return;
            }
            foreach (System.Windows.Forms.TreeNode treeNode in thisNode.Nodes)
            {
                treeNode.Checked = Checked;
                appPublic.CheckTreeNode(treeNode, Checked);
            }
        }

        public static string GetDataGridViewColumnByBindCol(System.Windows.Forms.DataGridView dgvr, string BindCol)
        {
            string text = "";
            for (int i = 0; i < dgvr.Columns.Count; i++)
            {
                text = dgvr.Columns[i].Name;
                if (string.Compare(text, BindCol, true) == 0)
                {
                    return text;
                }
            }
            return text;
        }

        public static void SendTabs(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        public static void SelectAllText()
        {
            System.Windows.Forms.SendKeys.Send("{HOME}+{END}");
        }

        public static void GetControls<T>(System.Windows.Forms.Control parCon, ref System.Collections.Generic.List<System.Windows.Forms.Control> Ret)
        {
            if (Ret == null)
            {
                Ret = new System.Collections.Generic.List<System.Windows.Forms.Control>();
            }
            foreach (System.Windows.Forms.Control control in parCon.Controls)
            {
                if (control.GetType() == typeof(T))
                {
                    Ret.Add(control);
                }
                if (control.Controls.Count > 0)
                {
                    appPublic.GetControls<T>(control, ref Ret);
                }
            }
        }

        public static bool ControlHasEventHandler(Component ctl, string EventName)
        {
            System.Reflection.PropertyInfo property = typeof(Component).GetProperty("Events", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            EventHandlerList eventHandlerList = (EventHandlerList)property.GetValue(ctl, null);
            System.Reflection.FieldInfo field = typeof(Component).GetField(EventName, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            if (field == null)
            {
                return false;
            }
            System.Delegate @delegate = eventHandlerList[field.GetValue(null)];
            return @delegate != null && @delegate.GetInvocationList().Length > 0;
        }

        public static bool ControlHasEventHandler<T>(Component ctl, string EventName)
        {
            System.Type typeFromHandle = typeof(T);
            if (!typeFromHandle.IsSubclassOf(typeof(Component)))
            {
                return false;
            }
            System.Reflection.PropertyInfo property = typeFromHandle.GetProperty("Events", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            EventHandlerList eventHandlerList = (EventHandlerList)property.GetValue(ctl, null);
            System.Reflection.FieldInfo field = typeFromHandle.GetField(EventName, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            if (field == null)
            {
                return false;
            }
            System.Delegate @delegate = eventHandlerList[field.GetValue(null)];
            return @delegate != null && @delegate.GetInvocationList().Length > 0;
        }

        public static void RemoveEventHandler<T>(Component cpt, string EventName)
        {
            System.Type typeFromHandle = typeof(T);
            if (!typeFromHandle.IsSubclassOf(typeof(Component)))
            {
                return;
            }
            System.Reflection.PropertyInfo property = typeFromHandle.GetProperty("Events", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            EventHandlerList eventHandlerList = (EventHandlerList)property.GetValue(cpt, null);
            System.Reflection.FieldInfo field = typeof(T).GetField(EventName, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            if (field == null)
            {
                return;
            }
            System.Delegate @delegate = eventHandlerList[field.GetValue(null)];
            if (@delegate != null)
            {
                System.Delegate[] invocationList = @delegate.GetInvocationList();
                for (int i = 0; i < invocationList.Length; i++)
                {
                    System.Delegate obj = invocationList[i];
                    field.SetValue(obj, null);
                }
            }
        }

        public static bool ControlHasEventHandler(GridView ctl, string EventName)
        {
            System.Reflection.PropertyInfo property = typeof(GridView).GetProperty("Events", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            EventHandlerList eventHandlerList = (EventHandlerList)property.GetValue(ctl, null);
            System.Reflection.FieldInfo field = typeof(GridView).GetField(EventName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            if (field == null)
            {
                return false;
            }
            System.Delegate @delegate = eventHandlerList[field.GetValue(null)];
            return @delegate != null && @delegate.GetInvocationList().Length > 0;
        }
        
        public static DataSet GetDS(DataTable Dt)
        {
            if (Dt == null || Dt.Columns.Count == 0)
            {
                return null;
            }
            if (Dt.DataSet != null)
            {
                return Dt.DataSet;
            }
            return new DataSet("DataBase")
            {
                Tables =
                {
                    Dt
                }
            };
        }

        public static System.IO.MemoryStream XmlReader2MemoryStream(XmlReader rd)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            string s = rd.ReadInnerXml();
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(s);
            memoryStream.Write(bytes, 0, bytes.Length);
            return memoryStream;
        }

        public static bool FileExists(string FileName)
        {
            return System.IO.File.Exists(FileName);
        }

        public static T ObjectClone<T>(T obj) where T : class
        {
            byte[] array = appPublic.ObjectToBytes(obj);
            if (array != null && 0 < array.Length)
            {
                return appPublic.BytesToObject<T>(array);
            }
            return default(T);
        }



        #region 大小写转换
        public static string ConvertSum(string str)
        {
            if (!appPublic.IsPositveDecimal(str))
            {
                return "";
            }
            if (double.Parse(str) > 999999999999.99)
            {
                return "Number is too big!";
            }
            string[] array = str.Split(new char[]
            {
                (new char[]
                {
                    '.'
                })[0]
            });
            if (array.Length == 1)
            {
                return appPublic.ConvertData(str) + "圓整";
            }
            string str2 = appPublic.ConvertData(array[0]) + "圓";
            return str2 + appPublic.ConvertXiaoShu(array[1]);
        }

        public static string DigitRemoveZero(float Num)
        {
            string text = Num.ToString();
            if (text.IndexOf('.') < 0)
            {
                return text;
            }
            text = text.TrimEnd(new char[]
            {
                '0'
            });
            return text.TrimEnd(new char[]
            {
                '.'
            });
        }

        private static bool IsPositveDecimal(string str)
        {
            decimal d;
            try
            {
                d = decimal.Parse(str);
            }
            catch (System.Exception)
            {
                return false;
            }
            return d > 0m;
        }

        private static string ConvertData(string str)
        {
            string text = "";
            int length = str.Length;
            if (length <= 4)
            {
                text = appPublic.ConvertDigit(str);
            }
            else if (length <= 8)
            {
                string str2 = str.Substring(length - 4, 4);
                text = appPublic.ConvertDigit(str2);
                str2 = str.Substring(0, length - 4);
                text = appPublic.ConvertDigit(str2) + "萬" + text;
                text = text.Replace("零萬", "萬");
                text = text.Replace("零零", "零");
            }
            else if (length <= 12)
            {
                string str2 = str.Substring(length - 4, 4);
                text = appPublic.ConvertDigit(str2);
                str2 = str.Substring(length - 8, 4);
                text = appPublic.ConvertDigit(str2) + "萬" + text;
                str2 = str.Substring(0, length - 8);
                text = appPublic.ConvertDigit(str2) + "億" + text;
                text = text.Replace("零億", "億");
                text = text.Replace("零萬", "零");
                text = text.Replace("零零", "零");
                text = text.Replace("零零", "零");
            }
            length = text.Length;
            string a;
            if (length >= 2 && (a = text.Substring(length - 2, 2)) != null)
            {
                if (!(a == "佰零"))
                {
                    if (!(a == "仟零"))
                    {
                        if (!(a == "萬零"))
                        {
                            if (a == "億零")
                            {
                                text = text.Substring(0, length - 2) + "億";
                            }
                        }
                        else
                        {
                            text = text.Substring(0, length - 2) + "萬";
                        }
                    }
                    else
                    {
                        text = text.Substring(0, length - 2) + "仟";
                    }
                }
                else
                {
                    text = text.Substring(0, length - 2) + "佰";
                }
            }
            return text;
        }

        private static string ConvertXiaoShu(string str)
        {
            int length = str.Length;
            if (length == 1)
            {
                return appPublic.ConvertChinese(str) + "角";
            }
            string str2 = str.Substring(0, 1);
            string text = appPublic.ConvertChinese(str2) + "角";
            str2 = str.Substring(1, 1);
            text = text + appPublic.ConvertChinese(str2) + "分";
            text = text.Replace("零分", "");
            return text.Replace("零角", "");
        }

        private static string ConvertDigit(string str)
        {
            int length = str.Length;
            string text = "";
            switch (length)
            {
                case 1:
                    text = appPublic.ConvertChinese(str);
                    break;
                case 2:
                    text = appPublic.Convert2Digit(str);
                    break;
                case 3:
                    text = appPublic.Convert3Digit(str);
                    break;
                case 4:
                    text = appPublic.Convert4Digit(str);
                    break;
            }
            text = text.Replace("拾零", "拾");
            length = text.Length;
            return text;
        }

        private static string Convert4Digit(string str)
        {
            string str2 = str.Substring(0, 1);
            string str3 = str.Substring(1, 1);
            string str4 = str.Substring(2, 1);
            string str5 = str.Substring(3, 1);
            string text = "";
            text = text + appPublic.ConvertChinese(str2) + "仟";
            text = text + appPublic.ConvertChinese(str3) + "佰";
            text = text + appPublic.ConvertChinese(str4) + "拾";
            text += appPublic.ConvertChinese(str5);
            text = text.Replace("零仟", "零");
            text = text.Replace("零佰", "零");
            text = text.Replace("零拾", "零");
            text = text.Replace("零零", "零");
            text = text.Replace("零零", "零");
            return text.Replace("零零", "零");
        }

        private static string Convert3Digit(string str)
        {
            string str2 = str.Substring(0, 1);
            string str3 = str.Substring(1, 1);
            string str4 = str.Substring(2, 1);
            string text = "";
            text = text + appPublic.ConvertChinese(str2) + "佰";
            text = text + appPublic.ConvertChinese(str3) + "拾";
            text += appPublic.ConvertChinese(str4);
            text = text.Replace("零佰", "零");
            text = text.Replace("零拾", "零");
            text = text.Replace("零零", "零");
            return text.Replace("零零", "零");
        }

        private static string Convert2Digit(string str)
        {
            string str2 = str.Substring(0, 1);
            string str3 = str.Substring(1, 1);
            string text = "";
            text = text + appPublic.ConvertChinese(str2) + "拾";
            text += appPublic.ConvertChinese(str3);
            text = text.Replace("零拾", "零");
            return text.Replace("零零", "零");
        }

        private static string ConvertChinese(string str)
        {
            string result = "";
            switch (str)
            {
                case "0":
                    result = "零";
                    break;
                case "1":
                    result = "壹";
                    break;
                case "2":
                    result = "贰";
                    break;
                case "3":
                    result = "叁";
                    break;
                case "4":
                    result = "肆";
                    break;
                case "5":
                    result = "伍";
                    break;
                case "6":
                    result = "陆";
                    break;
                case "7":
                    result = "柒";
                    break;
                case "8":
                    result = "捌";
                    break;
                case "9":
                    result = "玖";
                    break;
            }
            return result;
        }
        #endregion

        #region 加密码方法
        public static string DecryptString(string str)
        {
            if (str.Length % 4 != 0)
            {
                throw new System.ArgumentException("not BASE64 coding!", "str");
            }
            if (!Regex.IsMatch(str, "^[A-Z0-9/+=]*$", RegexOptions.IgnoreCase))
            {
                throw new System.ArgumentException("not BASE64 coding!", "str");
            }
            string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/=";
            int num = str.Length / 4;
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList(num * 3);
            char[] array = str.ToCharArray();
            for (int i = 0; i < num; i++)
            {
                byte[] array2 = new byte[]
                {
                    (byte)text.IndexOf(array[i * 4]),
                    (byte)text.IndexOf(array[i * 4 + 1]),
                    (byte)text.IndexOf(array[i * 4 + 2]),
                    (byte)text.IndexOf(array[i * 4 + 3])
                };
                byte[] array3 = new byte[3];
                array3[0] = (byte)((int)array2[0] << 2 ^ (array2[1] & 48) >> 4);
                if (array2[2] != 64)
                {
                    array3[1] = (byte)((int)array2[1] << 4 ^ (array2[2] & 60) >> 2);
                }
                else
                {
                    array3[2] = 0;
                }
                if (array2[3] != 64)
                {
                    array3[2] = (byte)((int)array2[2] << 6 ^ (int)array2[3]);
                }
                else
                {
                    array3[2] = 0;
                }
                arrayList.Add(array3[0]);
                if (array3[1] != 0)
                {
                    arrayList.Add(array3[1]);
                }
                if (array3[2] != 0)
                {
                    arrayList.Add(array3[2]);
                }
            }
            byte[] bytes = (byte[])arrayList.ToArray(System.Type.GetType("System.Byte"));
            return System.Text.Encoding.Default.GetString(bytes);
        }
        public static string EncryptString(string str)
        {
            char[] array = new char[]
            {
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z',
                'A',
                'B',
                'C',
                'D',
                'E',
                'F',
                'G',
                'H',
                'I',
                'J',
                'K',
                'L',
                'M',
                'N',
                'O',
                'P',
                'Q',
                'R',
                'S',
                'T',
                'U',
                'V',
                'W',
                'X',
                'Y',
                'Z',
                '0',
                '1',
                '2',
                '3',
                '4',
                '5',
                '6',
                '7',
                '8',
                '9',
                '+',
                '/',
                '='
            };
            byte b = 0;
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList(System.Text.Encoding.Default.GetBytes(str));
            int count = arrayList.Count;
            int num = count / 3;
            int num2;
            if ((num2 = count % 3) > 0)
            {
                for (int i = 0; i < 3 - num2; i++)
                {
                    arrayList.Add(b);
                }
                num++;
            }
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(num * 4);
            for (int j = 0; j < num; j++)
            {
                byte[] array2 = new byte[]
                {
                    (byte)arrayList[j * 3],
                    (byte)arrayList[j * 3 + 1],
                    (byte)arrayList[j * 3 + 2]
                };
                int[] array3 = new int[4];
                array3[0] = array2[0] >> 2;
                array3[1] = ((int)(array2[0] & 3) << 4 ^ array2[1] >> 4);
                if (!array2[1].Equals(b))
                {
                    array3[2] = ((int)(array2[1] & 15) << 2 ^ array2[2] >> 6);
                }
                else
                {
                    array3[2] = 64;
                }
                if (!array2[2].Equals(b))
                {
                    array3[3] = (int)(array2[2] & 63);
                }
                else
                {
                    array3[3] = 64;
                }
                stringBuilder.Append(array[array3[0]]);
                stringBuilder.Append(array[array3[1]]);
                stringBuilder.Append(array[array3[2]]);
                stringBuilder.Append(array[array3[3]]);
            }
            return stringBuilder.ToString();
        }
        public static string EncryptBy16MD5(string strProclaimed)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return System.BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(System.Text.Encoding.Default.GetBytes(strProclaimed)), 4, 8);
        }
        public static string EncryptBy32MD5(string strProclaimed)
        {
            System.Security.Cryptography.MD5 mD = System.Security.Cryptography.MD5.Create();
            string text = "";
            byte[] array = mD.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strProclaimed));
            for (int i = 0; i < array.Length; i++)
            {
                text += array[i].ToString("x");
            }
            return text;
        }
        #endregion

        #region  正则表达式验证
        public static string RegexMatched(string Str, string RegStr)
        {
            Regex regex = new Regex(RegStr);
            return regex.Match(Str).Value;
        }

        public static string RegexMatchedIngoreCase(string Str, string RegStr)
        {
            Regex regex = new Regex(RegStr, RegexOptions.IgnoreCase);
            return regex.Match(Str).Value;
        }

        public static bool RegexMatched2(string Str, string RegStr)
        {
            Regex regex = new Regex(RegStr);
            return regex.Match(Str).Value != "";
        }

        public static bool RegexMatchedIngoreCase2(string Str, string RegStr)
        {
            Regex regex = new Regex(RegStr, RegexOptions.IgnoreCase);
            return regex.Match(Str).Value != "";
        }
        #endregion

        #region 系统进程方法
        public static void BeginProcess(string ProgName, string WorkDirectory, string FileName)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = ProgName;
                if (WorkDirectory != "")
                {
                    process.StartInfo.WorkingDirectory = WorkDirectory;
                }
                FileName = " " + FileName;
                process.StartInfo.Arguments = FileName;
                process.Start();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void BeginProcess(string ProgName, string WorkDirectory)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = ProgName;
                if (WorkDirectory != "")
                {
                    process.StartInfo.WorkingDirectory = WorkDirectory;
                }
                process.Start();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void BeginProcessNoCmdWin(string ProgName, string WorkDirectory)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = ProgName;
                if (WorkDirectory != "")
                {
                    process.StartInfo.WorkingDirectory = WorkDirectory;
                }
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void BeginProcessArgs(string ProgName, string Args, string WorkDir, bool HideMe = false)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = ProgName;
                if (WorkDir != "")
                {
                    process.StartInfo.WorkingDirectory = WorkDir;
                }
                if ("" != Args)
                {
                    process.StartInfo.Arguments = Args;
                }
                process.StartInfo.UseShellExecute = true;
                if (HideMe)
                {
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                }
                process.Start();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void BeginProcessArgs(string ProgName, string Args, string WorkDir)
        {
            appPublic.BeginProcessArgs(ProgName, Args, WorkDir, true);
        }

        public static void BeginProcessWithStart(string WorkDirectory, string FileName)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = "cmd.exe";
                if (WorkDirectory != "")
                {
                    process.StartInfo.WorkingDirectory = WorkDirectory;
                }
                FileName = string.Format(" /C \"start {0}\"", FileName);
                process.StartInfo.Arguments = FileName;
                process.Start();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static bool ProgRunned(string Prog, bool Kill)
        {
            string shortExec = appPublic.GetShortExec(Prog);
            Process[] processesByName = Process.GetProcessesByName(shortExec);
            Process[] array = processesByName;
            for (int i = 0; i < array.Length; i++)
            {
                Process process = array[i];
                if (string.Compare(process.ProcessName, shortExec, true) == 0)
                {
                    if (Kill)
                    {
                        process.Kill();
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool FileNameIsSame(string fileName1, string fileName2)
        {
            return 0 == string.Compare(fileName1, fileName2, true);
        }

        public static bool ProgramRunned(string ProgFullName, bool Kill)
        {
            string fileNameOnly = appPublic.GetFileNameOnly(ProgFullName);
            Process[] processesByName = Process.GetProcessesByName(fileNameOnly);
            if (processesByName == null || processesByName.Length == 0)
            {
                return false;
            }
            bool result = false;
            int num = processesByName.Length;
            for (int i = 0; i < num; i++)
            {
                Process process = processesByName[i];
                if (appPublic.FileNameIsSame(ProgFullName, process.MainModule.FileName))
                {
                    result = true;
                    if (Kill)
                    {
                        process.Kill();
                    }
                }
            }
            return result;
        }

        public static int ProgProcessCount(string Prog)
        {
            string shortExec = appPublic.GetShortExec(Prog);
            Process[] processesByName = Process.GetProcessesByName(shortExec);
            if (processesByName == null || processesByName.Length == 0)
            {
                return 0;
            }
            return processesByName.Length;
        }

        public static string GetCurrentProgName()
        {
            return Process.GetCurrentProcess().ProcessName.ToUpper();
        }
        #endregion

        #region 格式转换

        public static bool IsObjectNull(object obj)
        {
            return obj == null || obj == System.DBNull.Value;
        }

        public static object ObjectToGuidObj(object obj)
        {
            if (appPublic.IsObjectNull(obj))
            {
                return System.DBNull.Value;
            }
            return appPublic.GetObjGUID(obj);
        }

        public static string GetObjectString(object obj)
        {
            if (obj != null && obj != System.DBNull.Value && !(obj.ToString() == ""))
            {
                return obj.ToString();
            }
            return "";
        }

        public static string GetObjectString(object obj, string EmptyIf)
        {
            string objectString = appPublic.GetObjectString(obj);
            if (string.Empty.Equals(objectString))
            {
                return EmptyIf;
            }
            return objectString;
        }

        public static string GetObjStrUpperTrim(object obj)
        {
            return appPublic.GetObjectString(obj).Trim().ToUpper();
        }

        public static string GetObjStrUpperTrim(object obj, string EmptyIf)
        {
            string objStrUpperTrim = appPublic.GetObjStrUpperTrim(obj);
            if (string.Empty.Equals(objStrUpperTrim))
            {
                return EmptyIf;
            }
            return objStrUpperTrim;
        }

        public static System.Guid GetObjGUID(object obj)
        {
            string objectString = appPublic.GetObjectString(obj);
            System.Guid result;
            if (!System.Guid.TryParse(objectString, out result))
            {
                result = System.Guid.Parse("00000000-0000-0000-0000-000000000000");
            }
            return result;
        }

        public static string GetObjGUIDString(object obj)
        {
            return GetObjGUID(obj).ToString();
        }

        public static object DBNullIf(object obj)
        {
            if (obj == null || System.DBNull.Value == obj)
            {
                return System.DBNull.Value;
            }
            return obj;
        }

        public static T BytesToObject<T>(byte[] Bytes) where T : class
        {
            T result;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(Bytes))
            {
                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                result = (T)((object)formatter.Deserialize(memoryStream));
            }
            return result;
        }

        public static byte[] ObjectToBytes(object obj)
        {
            byte[] buffer;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                buffer = memoryStream.GetBuffer();
            }
            return buffer;
        }

        public static int GetIntValue(object Val)
        {
            if (System.DBNull.Value == Val || Val == null)
            {
                return 0;
            }
            int result = 0;
            if (!int.TryParse(Val.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        public static float GetSingleValue(object Val)
        {
            if (System.DBNull.Value == Val || Val == null)
            {
                return 0f;
            }
            float result = 0f;
            if (!float.TryParse(Val.ToString(), out result))
            {
                return 0f;
            }
            return result;
        }
        public static float ToSingle(string txt)
        {
            float result = 0f;
            if (!float.TryParse(txt, out result))
            {
                result = 0f;
            }
            return result;
        }
        public static decimal ToDecimal(object obj)
        {
            if (appPublic.IsNullOrDBNull(obj))
            {
                return 0.0m;
            }
            return System.Convert.ToDecimal(obj);
        }
        public static System.DateTime ToDateTime(object obj)
        {
            if (appPublic.IsNullOrDBNull(obj))
            {
                return new System.DateTime(1900, 1, 1);
            }
            return System.Convert.ToDateTime(obj);
        }
        public static bool TryParseInt(object obj, out int Ret)
        {
            Ret = 0;
            return !appPublic.IsNullOrDBNull(obj) && int.TryParse(obj.ToString(), out Ret);
        }
        #endregion

        #region 常用的日期函数
        public static int GetQuater(System.DateTime dt)
        {
            int month = dt.Month;
            if (month >= 1 && month <= 3)
            {
                return 1;
            }
            if (month >= 4 && month <= 6)
            {
                return 2;
            }
            if (month >= 7 && month <= 9)
            {
                return 3;
            }
            return 4;
        }

        public static string GetQuaterDesc(System.DateTime dt)
        {
            int quater = appPublic.GetQuater(dt);
            return string.Format("Seazon {0}", quater);
        }

        public static string GetYearQuater(System.DateTime dt)
        {
            int quater = appPublic.GetQuater(dt);
            return string.Format("{0} Seazon {1}", dt.Year, quater);
        }

        public static void DisposeObject(object obj)
        {
            if (obj == null)
            {
                return;
            }
            System.IDisposable disposable = obj as System.IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        public static void SendMail(string fromAddress, string[] toAddresses, string[] ccAddress, string smtpAddress, int smtpPort, bool isSSL, string username, string password, string subject, string body)
        {
            MailMessage mailMessage = null;
            SmtpClient smtpClient = null;
            try
            {
                mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromAddress);
                for (int i = 0; i < toAddresses.Length; i++)
                {
                    string address = toAddresses[i];
                    mailMessage.To.Add(new MailAddress(address));
                }
                for (int j = 0; j < ccAddress.Length; j++)
                {
                    string text = ccAddress[j];
                    if (!(text == ""))
                    {
                        mailMessage.CC.Add(new MailAddress(text));
                    }
                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                smtpClient = new SmtpClient(smtpAddress);
                smtpClient.Port = smtpPort;
                smtpClient.Timeout = 2147483647;
                smtpClient.EnableSsl = isSSL;
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.Send(mailMessage);
            }
            finally
            {
                if (mailMessage != null)
                {
                    mailMessage.Dispose();
                    mailMessage = null;
                }
                if (smtpClient != null)
                {
                    smtpClient = null;
                }
            }
        }

        public static void SendMail(string fromAddress, string toAddr, string ccAddr, string smtpAddress, int smtpPort, bool isSSL, string username, string password, string subject, string body)
        {
            MailMessage mailMessage = null;
            SmtpClient smtpClient = null;
            try
            {
                mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromAddress);
                string[] array = toAddr.Split(new char[]
                {
                    ';'
                });
                string[] array2 = ccAddr.Split(new char[]
                {
                    ';'
                });
                string[] array3 = array;
                for (int i = 0; i < array3.Length; i++)
                {
                    string address = array3[i];
                    mailMessage.To.Add(new MailAddress(address));
                }
                string[] array4 = array2;
                for (int j = 0; j < array4.Length; j++)
                {
                    string text = array4[j];
                    if (!(text == ""))
                    {
                        mailMessage.CC.Add(new MailAddress(text));
                    }
                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                smtpClient = new SmtpClient(smtpAddress);
                smtpClient.Port = smtpPort;
                smtpClient.Timeout = 2147483647;
                smtpClient.EnableSsl = isSSL;
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.Send(mailMessage);
            }
            finally
            {
                if (mailMessage != null)
                {
                    mailMessage.Dispose();
                    mailMessage = null;
                }
                if (smtpClient != null)
                {
                    smtpClient = null;
                }
            }
        }

        public static int WeekOfYear(System.DateTime curDay)
        {
            int num = System.Convert.ToInt32(System.Convert.ToDateTime(curDay.Year.ToString() + "-1-1").DayOfWeek);
            int dayOfYear = curDay.DayOfYear;
            int num2 = dayOfYear - (7 - num);
            if (num2 <= 0)
            {
                return 1;
            }
            int num3 = num2 / 7;
            if (num2 % 7 != 0)
            {
                num3++;
            }
            return num3 + 1;
        }

        public static int WeeksOfYear(int Year)
        {
            System.DateTime curDay = new System.DateTime(Year, 12, 31);
            return appPublic.WeekOfYear(curDay);
        }

        public static void WeekRange(System.DateTime dt, out System.DateTime Start, out System.DateTime End)
        {
            Start = dt;
            End = dt;
            int num = System.Convert.ToInt32(dt.DayOfWeek);
            int num2 = -1 * num;
            int num3 = 6 - num;
            Start = (Start = dt.AddDays((double)(num2 + 1)).Date);
            End = dt.AddDays((double)(num3 + 1)).Date;
        }

        public static void PreWeekRange(System.DateTime dt, out System.DateTime Start, out System.DateTime End)
        {
            Start = dt;
            End = dt;
            appPublic.WeekRange(dt, out Start, out End);
            Start = Start.AddDays(-7.0);
            End = End.AddDays(-7.0);
        }

        public static void PreCountWeekRange(System.DateTime dt, int count, out System.DateTime Start, out System.DateTime End)
        {
            if (count <= 0)
            {
                count = 1;
            }
            Start = dt;
            End = dt;
            appPublic.WeekRange(dt, out Start, out End);
            Start = Start.AddDays((double)(-7 * count));
            End = End.AddDays((double)(-7 * count));
        }

        public static void GetMeanMonArrange(System.DateTime dt, int FirstDay, out System.DateTime StartDate, out System.DateTime EndDate)
        {
            StartDate = dt;
            EndDate = dt;
            StartDate = new System.DateTime(dt.Year, dt.Month, FirstDay);
            EndDate = StartDate.AddMonths(1).AddDays(-1.0);
        }

        public static void GetMeanMonArrange(string YYYYMM, int FirstDay, out System.DateTime StartDate, out System.DateTime EndDate)
        {
            if (YYYYMM.Length != 6)
            {
                throw new System.Exception("YYYYMM Format Error!");
            }
            int year = System.Convert.ToInt32(YYYYMM.Substring(0, 4));
            int month = System.Convert.ToInt32(YYYYMM.Substring(4, 2));
            System.DateTime dt = new System.DateTime(year, month, FirstDay);
            appPublic.GetMeanMonArrange(dt, FirstDay, out StartDate, out EndDate);
        }
        
        public static double DateDiff(string howtocompare, System.DateTime startDate, System.DateTime endDate)
        {
            double result = 0.0;
            try
            {
                System.TimeSpan timeSpan = new System.TimeSpan(startDate.Ticks - endDate.Ticks);
                switch (howtocompare)
                {
                    case "m ":
                        result = System.Convert.ToDouble(timeSpan.TotalMinutes);
                        goto IL_17B;
                    case "s ":
                        result = System.Convert.ToDouble(timeSpan.TotalSeconds);
                        goto IL_17B;
                    case "t ":
                        result = System.Convert.ToDouble(timeSpan.Ticks);
                        goto IL_17B;
                    case "mm ":
                        result = System.Convert.ToDouble(timeSpan.TotalMilliseconds);
                        goto IL_17B;
                    case "yyyy ":
                        result = System.Convert.ToDouble(timeSpan.TotalDays / 365.0);
                        goto IL_17B;
                    case "MM":
                        result = System.Convert.ToDouble(timeSpan.TotalDays / 365.0 * 12.0);
                        goto IL_17B;
                    case "q ":
                        result = System.Convert.ToDouble(timeSpan.TotalDays / 365.0 / 4.0);
                        goto IL_17B;
                }
                result = System.Convert.ToDouble(timeSpan.TotalDays);
            IL_17B:;
            }
            catch
            {
                result = -1.0;
                throw;
            }
            return result;
        }

        public static void MonthRange(System.DateTime dt, out System.DateTime Start, out System.DateTime End)
        {
            int year = dt.Year;
            int month = dt.Month;
            Start = new System.DateTime(year, month, 1);
            int day = 30;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    day = 31;
                    break;
                case 2:
                    if (System.DateTime.IsLeapYear(year))
                    {
                        day = 29;
                    }
                    else
                    {
                        day = 28;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    day = 30;
                    break;
            }
            End = new System.DateTime(year, month, day);
        }

        public static void PreMonthRange(System.DateTime dt, out System.DateTime Start, out System.DateTime End)
        {
            int arg_07_0 = dt.Year;
            int arg_0F_0 = dt.Month;
            dt = dt.AddMonths(-1);
            appPublic.MonthRange(dt, out Start, out End);
        }

        public static void GetYearWeekArrange(int Year, int Week, out System.DateTime Start, out System.DateTime End)
        {
            System.DateTime d = new System.DateTime(Year, 1, 1);
            d += new System.TimeSpan((Week - 1) * 7, 0, 0, 0);
            Start = d.AddDays((double)(-(double)d.DayOfWeek + 1));
            End = d.AddDays((double)(System.DayOfWeek.Saturday - d.DayOfWeek + 1));
        }

        public static System.DateTime GetDateOnly(System.DateTime dt)
        {
            return System.Convert.ToDateTime(dt.ToString("yyyy-MM-dd"));
        }

        public static void QuaterRange(System.DateTime dt, out System.DateTime Start, out System.DateTime End)
        {
            Start = dt;
            End = dt;
            int month = dt.Month;
            string s = "";
            string s2 = "";
            if (month >= 1 && month <= 3)
            {
                s = string.Format("{0}-1-1 ", System.DateTime.Now.Year.ToString());
                s2 = string.Format("{0}-3-31 ", System.DateTime.Now.Year.ToString());
            }
            else if (month >= 4 && month <= 6)
            {
                s = string.Format("{0}-4-1 ", System.DateTime.Now.Year.ToString());
                s2 = string.Format("{0}-6-30 ", System.DateTime.Now.Year.ToString());
            }
            else if (month >= 7 && month <= 9)
            {
                s = string.Format("{0}-7-1 ", System.DateTime.Now.Year.ToString());
                s2 = string.Format("{0}-9-30 ", System.DateTime.Now.Year.ToString());
            }
            else if (month >= 10 && month <= 12)
            {
                s = string.Format("{0}-10-1 ", System.DateTime.Now.Year.ToString());
                s2 = string.Format("{0}-12-31 ", System.DateTime.Now.Year.ToString());
            }
            System.DateTime.TryParse(s, out Start);
            System.DateTime.TryParse(s2, out End);
        }

        public static System.DateTime ReplaceDate(System.DateTime dtDest, string dtDateInstead)
        {
            System.DateTime today = System.DateTime.Today;
            if (!System.DateTime.TryParse(dtDateInstead, out today))
            {
                throw new System.Exception("Parameter Error");
            }
            return appPublic.ReplaceDate(dtDest, today);
        }

        public static System.DateTime ReplaceDate(System.DateTime dtDest, System.DateTime dtDateInstead)
        {
            return new System.DateTime(dtDateInstead.Year, dtDateInstead.Month, dtDateInstead.Day, dtDest.Hour, dtDest.Minute, dtDest.Second);
        }
        public static bool DateTimeLitter2(System.DateTime dt, string Time)
        {
            string s = string.Format("{0} {1}", dt.ToString("yyyy-MM-dd"), Time);
            System.DateTime today = System.DateTime.Today;
            if (!System.DateTime.TryParse(s, out today))
            {
                throw new System.Exception("Date format error!");
            }
            return dt < today;
        }

        public static bool CheckDupDateTime(System.DateTime[,] datetimes, bool IncludeEqual)
        {
            if (datetimes.GetUpperBound(1) != 1)
            {
                throw new System.Exception("Data Error!");
            }
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            int length = datetimes.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                hashtable.Add(i.ToString(), new System.DateTime[]
                {
                    datetimes[i, 0],
                    datetimes[i, 1]
                });
            }
            return appPublic.CheckDupDateTimePri(hashtable, IncludeEqual);
        }

        private static bool CheckDupDateTimePri(System.Collections.Hashtable Times, bool IncludeEqual)
        {
            foreach (System.Collections.DictionaryEntry dictionaryEntry in Times)
            {
                string text = dictionaryEntry.Key.ToString();
                System.DateTime[] array = (System.DateTime[])dictionaryEntry.Value;
                foreach (System.Collections.DictionaryEntry dictionaryEntry2 in Times)
                {
                    if (!(dictionaryEntry2.Key.ToString().ToUpper() == text.ToUpper()))
                    {
                        System.DateTime[] array2 = (System.DateTime[])dictionaryEntry2.Value;
                        if (!IncludeEqual)
                        {
                            if (array[0] > array2[0] && array[0] < array2[1])
                            {
                                bool result = true;
                                return result;
                            }
                            if (array[1] > array2[0] && array[1] < array2[1])
                            {
                                bool result = true;
                                return result;
                            }
                        }
                        else
                        {
                            if (array[0] >= array2[0] && array[0] <= array2[1])
                            {
                                bool result = true;
                                return result;
                            }
                            if (array[1] >= array2[0] && array[1] <= array2[1])
                            {
                                bool result = true;
                                return result;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static int WeekDay(System.DateTime Dt)
        {
            int result = 0;
            switch (Dt.DayOfWeek)
            {
                case System.DayOfWeek.Sunday:
                    result = 7;
                    break;
                case System.DayOfWeek.Monday:
                    result = 1;
                    break;
                case System.DayOfWeek.Tuesday:
                    result = 2;
                    break;
                case System.DayOfWeek.Wednesday:
                    result = 3;
                    break;
                case System.DayOfWeek.Thursday:
                    result = 4;
                    break;
                case System.DayOfWeek.Friday:
                    result = 5;
                    break;
                case System.DayOfWeek.Saturday:
                    result = 6;
                    break;
            }
            return result;
        }

        public static string WeekDayDesc(System.DateTime Dt)
        {
            int dw = appPublic.WeekDay(Dt);
            return appPublic.WeekDayDesc(dw);
        }
        public static string WeekDayDesc(int Dw)
        {
            return appPublic.WeekDayDescLong(Dw);
        }

        public static string WeekDayDescLong(int Dw)
        {
            string text = "";
            if (1 == Dw)
            {
                text += "Mon";
            }
            else if (2 == Dw)
            {
                text += "Tues";
            }
            else if (3 == Dw)
            {
                text += "Wed";
            }
            else if (4 == Dw)
            {
                text += "Thur";
            }
            else if (5 == Dw)
            {
                text += "Fri";
            }
            else if (6 == Dw)
            {
                text += "Sat";
            }
            else if (7 == Dw)
            {
                text += "Sun";
            }
            return text;
        }

        public static string WeekDayDescZh(int Dw)
        {
            string text = "";
            if (1 == Dw)
            {
                text += "星期一";
            }
            else if (2 == Dw)
            {
                text += "星期二";
            }
            else if (3 == Dw)
            {
                text += "星期三";
            }
            else if (4 == Dw)
            {
                text += "星期四";
            }
            else if (5 == Dw)
            {
                text += "星期五";
            }
            else if (6 == Dw)
            {
                text += "星期六";
            }
            else if (7 == Dw)
            {
                text += "星期日";
            }
            return text;
        }
        public static string WeekDayDescZh(System.DateTime Dt)
        {
            int dw = appPublic.WeekDay(Dt);
            return appPublic.WeekDayDescZh(dw);
        }

        ///   <summary> 
        ///  获取某一日期是该年中的第几周
        ///   </summary> 
        ///   <param name="dt"> 日期 </param> 
        ///   <returns> 该日期在该年中的周数 </returns> 
        public static int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        /// <summary>
        /// 获取某一日期是该年中的第几周
        /// </summary>
        ///  <param name="dt"> 日期 </param> 
        ///   <returns> 该日期在该月中的周数 </returns> 
        public static int GetWeekOfMonth(DateTime daytime)
        {
            int dayInMonth = daytime.Day;
            //本月第一天
            DateTime firstDay = daytime.AddDays(1 - daytime.Day);
            //本月第一天是周几
            int weekday = (int)firstDay.DayOfWeek == 0 ? 7 : (int)firstDay.DayOfWeek;
            //本月第一周有几天
            int firstWeekEndDay = 7 - (weekday - 1);
            //当前日期和第一周之差
            int diffday = dayInMonth - firstWeekEndDay;
            diffday = diffday > 0 ? diffday : 1;
            //当前是第几周,如果整除7就减一天
            int WeekNumInMonth = ((diffday % 7) == 0
             ? (diffday / 7 - 1)
             : (diffday / 7)) + 1 + (dayInMonth > firstWeekEndDay ? 1 : 0);
            return WeekNumInMonth;
        }

        /// <summary>
        /// 得到本周第一天(以星期天为第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDaySun(DateTime datetime)
        {
            //星期天为第一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (-1) * weeknow;

            //本周第一天
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 得到本周第一天(以星期一为第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 得到本周最后一天(以星期六为最后一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekLastDaySat(DateTime datetime)
        {
            //星期六为最后一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (7 - weeknow) - 1;

            //本周最后一天
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        /// <summary>
        /// 得到本周最后一天(以星期天为最后一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekLastDaySun(DateTime datetime)
        {
            //星期天为最后一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最后一天
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        #endregion

        #region 文件目录操作
        public static string GetSaveXlsFileName(string DefaultFileName)
        {
            return appPublic.GetSaveFileName("EXCEL File(*.xls)|*.xls", "", DefaultFileName);
        }

        public static string GetOpenXlsFileName(string DefaultFileName)
        {
            return appPublic.GetOpenFileName("EXCEL File(*.xls)|*.xls", DefaultFileName);
        }
        public static string GetParentDir(string Dir)
        {
            string text = Dir;
            if (!text.EndsWith("\\"))
            {
                text += "\\";
            }
            text += "..\\";
            return System.IO.Path.GetFullPath(text);
        }

        public static void WriteLog(string fileName, System.Exception ex)
        {
            appPublic.WriteTextFileLine(fileName, string.Format("Message:{0} Source:{1} TargetSite:{2} StackTrace:{3}", new object[]
            {
                ex.Message,
                ex.Source,
                ex.TargetSite.ToString(),
                ex.StackTrace
            }), true);
        }

        public static void CheckFolderExists(string Folder)
        {
            if (!System.IO.Directory.Exists(Folder))
            {
                System.IO.Directory.CreateDirectory(Folder);
            }
        }

        public static string GetFolder(string FileName)
        {
            System.IO.FileInfo fileInfo = null;
            string directoryName;
            try
            {
                fileInfo = new System.IO.FileInfo(FileName);
                directoryName = fileInfo.DirectoryName;
            }
            finally
            {
                if (fileInfo != null)
                {
                    fileInfo = null;
                }
            }
            return directoryName;
        }

        public static void CheckFolderExistsViaFileName(string FileName)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(FileName);
            if (fileInfo != null)
            {
                appPublic.CheckFolderExists(fileInfo.DirectoryName);
            }
        }

        public static void CheckFolderExists(string BaseDir, string SubDir)
        {
            string folder = string.Format("{0}\\{1}", BaseDir, SubDir);
            appPublic.CheckFolderExists(folder);
        }
        public static string NewLine
        {
            get
            {
                return System.Environment.NewLine;
            }
        }

        public static string AppDir
        {
            get
            {
                if (string.Empty.Equals(appPublic._appDir))
                {
                    appPublic._appDir = appPublic.GetApplicationBaseDir();
                }
                return appPublic._appDir;
            }
        }
        public static void OpenFile(string FileName)
        {
            FileName = FileName.ToLower();
            FileName = FileName.Replace("documents and settings", "docume~1");
            Process process = null;
            try
            {
                process = new Process();
                process.StartInfo.FileName = "Cmd.exe";
                process.StartInfo.Arguments = string.Format(" /c start {0}", FileName);
                process.Start();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (process != null)
                {
                    process.Dispose();
                }
            }
        }

        public static string ReadTextFile(string FileName)
        {
            if (!appPublic.FileExists(FileName))
            {
                throw new System.Exception("No files exists!");
            }
            System.IO.StreamReader streamReader = null;
            string result;
            try
            {
                streamReader = new System.IO.StreamReader(FileName, System.Text.Encoding.UTF8);
                result = streamReader.ReadToEnd();
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }
            return result;
        }

        public static void WriteTextFile(string FileName, string ConTent)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                streamWriter = new System.IO.StreamWriter(FileName, false);
                streamWriter.Write(ConTent);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }

        public static void WriteTextFile(string FileName, string ConTent, bool Append)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                streamWriter = new System.IO.StreamWriter(FileName, Append);
                streamWriter.Write(ConTent);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }

        public static void WriteTextFileLine(string FileName, string ConTent, bool Append)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(FileName);
                if (fileInfo.Exists && (double)((float)fileInfo.Length / 1048576f) > 1.0)
                {
                    streamWriter = new System.IO.StreamWriter(FileName, false);
                }
                else
                {
                    streamWriter = new System.IO.StreamWriter(FileName, Append);
                }
                streamWriter.WriteLine(ConTent);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }

        public static string GetPathOnly(string FullFileName)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(FullFileName);
            return fileInfo.DirectoryName;
        }

        public static string GetShortFileName(string FileName)
        {
            int num = FileName.LastIndexOf('\\');
            if (num < 0)
            {
                return FileName;
            }
            return FileName.Substring(num + 1, FileName.Length - num - 1);
        }

        public static string CombineDir(params string[] Para)
        {
            return System.IO.Path.Combine(Para);
        }

        public static void CheckDownUrl(ref string Url, ref string ToDir)
        {
            if (Url.StartsWith("\\\\"))
            {
                Url = Url.Replace('/', '\\');
            }
            else
            {
                Url = Url.Replace('\\', '/');
            }
            ToDir = ToDir.Replace('/', '\\');
        }
        public static string GetOpenFileName(string Filter, string FileName = "")
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = null;
            string result;
            try
            {
                openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Filter = Filter;
                if (!string.Empty.Equals(FileName))
                {
                    openFileDialog.FileName = FileName;
                }
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    result = openFileDialog.FileName;
                }
                else
                {
                    result = string.Empty;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (openFileDialog != null)
                {
                    openFileDialog.Dispose();
                }
            }
            return result;
        }

        public static string GetOpenFileName(string Filter, string InitDir, string FileName = "")
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = null;
            string result;
            try
            {
                openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Filter = Filter;
                openFileDialog.InitialDirectory = InitDir;
                if (!string.Empty.Equals(FileName))
                {
                    openFileDialog.FileName = FileName;
                }
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    result = openFileDialog.FileName;
                }
                else
                {
                    result = string.Empty;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (openFileDialog != null)
                {
                    openFileDialog.Dispose();
                }
            }
            return result;
        }

        public static string GetSaveFileName(string Filter, string InitDir)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = null;
            string result;
            try
            {
                saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = Filter;
                saveFileDialog.InitialDirectory = InitDir;
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    result = saveFileDialog.FileName;
                }
                else
                {
                    result = "";
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (saveFileDialog != null)
                {
                    saveFileDialog.Dispose();
                }
            }
            return result;
        }

        public static string GetSaveFileName(string Filter, string InitDir, string InitFileName)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = null;
            string result;
            try
            {
                saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = Filter;
                if (InitDir != "")
                {
                    saveFileDialog.InitialDirectory = InitDir;
                }
                if (InitFileName != "")
                {
                    saveFileDialog.FileName = InitFileName;
                }
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    result = saveFileDialog.FileName;
                }
                else
                {
                    result = "";
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (saveFileDialog != null)
                {
                    saveFileDialog.Dispose();
                }
            }
            return result;
        }

        public static string GetSaveFileName(string Filter)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = null;
            string result;
            try
            {
                saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = Filter;
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    result = saveFileDialog.FileName;
                }
                else
                {
                    result = "";
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (saveFileDialog != null)
                {
                    saveFileDialog.Dispose();
                }
            }
            return result;
        }

        public static void DeleteFile(string FileName)
        {
            try
            {
                if (System.IO.File.Exists(FileName))
                {
                    System.IO.File.Delete(FileName);
                }
            }
            catch
            {
            }
        }

        public static string GetApplicationBaseDir()
        {
            string text = System.AppDomain.CurrentDomain.BaseDirectory;
            if (!text.EndsWith("\\"))
            {
                text += "\\";
            }
            return text;
        }

        #endregion

        #region  提示消息片处理方法
        public static bool GetMessageBoxYesNoResult(string Question, string Caption="询问")
        {
            return DevExpress.XtraEditors.XtraMessageBox.Show(Question, Caption, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
        }
        public static void ShowException(System.Exception ex, string Caption)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, (Caption.Trim() == "") ? appSession._SystemName : Caption, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
        }
        public static void ShowException(string Content, string Caption)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(Content, (Caption.Trim() == "") ?appSession._SystemName : Caption, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
        }
        public static void ShowException2(System.Exception ex, string Caption)
        {
            string content = string.Format("Message:{0} {1} Source:{2} {1} StackTrace:{3}", new object[]
            {
                ex.Message,
                System.Environment.NewLine,
                ex.Source,
                ex.StackTrace
            });
            appPublic.ShowMessage(MessageBoxIcon.Hand, content, Caption);
        }
        public static void ShowMessage(string Content, string Caption)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(Content, (Caption.Trim() == "") ? "YSPOS" : Caption, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
        }
        public static void ShowMessage(MessageBoxIcon type, string Content, string Caption)
        {
            System.Windows.Forms.MessageBoxIcon icon;
            if (type == MessageBoxIcon.Exclamation)
            {
                icon = System.Windows.Forms.MessageBoxIcon.Exclamation;
            }
            else if (type == MessageBoxIcon.Hand)
            {
                icon = System.Windows.Forms.MessageBoxIcon.Hand;
            }
            else
            {
                icon = System.Windows.Forms.MessageBoxIcon.Asterisk;
            }
            DevExpress.XtraEditors.XtraMessageBox.Show(Content, (Caption.Trim() == "") ? "YSPOS" : Caption, System.Windows.Forms.MessageBoxButtons.OK, icon);
        }
        public static void ShowAlert(System.Windows.Forms.Form frm, string Caption, string Content)
        {
            //if (appPublic._AlertMsgbox == null)
            //{
            //    appPublic._AlertMsgbox = new AlertControl();
            //    appPublic._AlertMsgbox.AutoFormDelay = 2000;
            //}
            //appPublic._AlertMsgbox.Show(frm, (Caption.Trim() == "") ? "YSPOS" : Caption, Content);
        }
        #endregion

        #region  获取和设置对象属性
        public static object GetObjectPropertyValue<T>(T t, string propertyname)
        {
            System.Type typeFromHandle = typeof(T);
            System.Reflection.PropertyInfo property = typeFromHandle.GetProperty(propertyname);
            if (property == null)
            {
                return null;
            }
            return property.GetValue(t, null);
        }

        public static object GetObjectFieldValue<T>(T t, string Fieldname)
        {
            System.Type typeFromHandle = typeof(T);
            System.Reflection.FieldInfo[] fields = typeFromHandle.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            System.Reflection.FieldInfo[] array = fields;
            for (int i = 0; i < array.Length; i++)
            {
                System.Reflection.FieldInfo fieldInfo = array[i];
                if (fieldInfo.Name == Fieldname)
                {
                    return fieldInfo.GetValue(t);
                }
            }
            return null;
        }

        public static void SetObjectPropertyValue<T>(T t, string propertyname, object value)
        {
            System.Type typeFromHandle = typeof(T);
            System.Reflection.PropertyInfo property = typeFromHandle.GetProperty(propertyname);
            if (null != property && property.CanWrite)
            {
                property.SetValue(t, value, null);
            }
        }

        public static void SetObjectFieldValue<T>(T t, string FieldName, object value)
        {
            System.Type typeFromHandle = typeof(T);
            System.Reflection.FieldInfo[] fields = typeFromHandle.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            System.Reflection.FieldInfo[] array = fields;
            for (int i = 0; i < array.Length; i++)
            {
                System.Reflection.FieldInfo fieldInfo = array[i];
                if (fieldInfo.Name == FieldName)
                {
                    fieldInfo.SetValue(t, value);
                    break;
                }
            }
        }
        #endregion

        #region  反射
        public static object ReflectionMakeObj(string FileName, string Class)
        {
            if (!appPublic.FileExists(FileName))
            {
                return null;
            }
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(FileName);
            System.Type type = assembly.GetType(Class, true, true);
            return System.Activator.CreateInstance(type);
        }

        public static object ReflectionMakeObj(string FileName, string Class, object[] Args)
        {
            if (!appPublic.FileExists(FileName))
            {
                return null;
            }
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(FileName);
            System.Type type = assembly.GetType(Class, true, true);
            return System.Activator.CreateInstance(type, Args);
        }

        public static object ReflectionInvokeMethods(string fileName, string className, string Method, object[] Args)
        {
            if (!appPublic.FileExists(fileName))
            {
                return null;
            }
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(fileName);
            System.Type type = assembly.GetType(className, true, true);
            return type.InvokeMember(Method, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod, null, null, Args);
        }
        #endregion

        #region 图片无损压缩

        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public static bool CompressImage(string sFile, string dFile, int flag = 90, int size = 300, bool sfsc = true)
        {
            //如果是第一次调用，原始图像的大小小于要压缩的大小，则直接复制文件，并且返回true
            FileInfo firstFileInfo = new FileInfo(sFile);
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            if (sfsc == true && firstFileInfo.Length < size * 1024)
            {
                firstFileInfo.CopyTo(dFile);
                return true ;
            }
          
            ImageFormat tFormat = iSource.RawFormat;
            int dHeight = iSource.Height / 2;
            int dWidth = iSource.Width / 2;
            int sW = 0, sH = 0;
            //按比例缩放
            System.Drawing.Size tem_size = new System.Drawing.Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            System.Drawing.Bitmap ob = new System.Drawing.Bitmap(dWidth, dHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(ob);

            g.Clear(System.Drawing.Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            
            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, System.Drawing.GraphicsUnit.Pixel);

            //g.DrawImage(iSource, 0, 0, iSource.Width, iSource.Height,System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                    FileInfo fi = new FileInfo(dFile);
                    if (fi.Length > 1024 * size)
                    {
                        flag = flag - 10;
                        CompressImage(sFile, dFile, flag, size, false);
                    }
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }

        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public static string CompressImage(string sFile, int flag = 90, int size = 300, bool sfsc = true)
        {
            string tempFile = Application.StartupPath+"\\jpgtemp\\temp.jpg";
            //如果是第一次调用，原始图像的大小小于要压缩的大小，则直接复制文件，并且返回true
            FileInfo firstFileInfo = new FileInfo(sFile);
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            if (sfsc == true && firstFileInfo.Length < size * 1024)
            {
                firstFileInfo.CopyTo(tempFile, true);
                return tempFile;
            }

            ImageFormat tFormat = iSource.RawFormat;
            int dHeight = iSource.Height / 2;
            int dWidth = iSource.Width / 2;
            int sW = 0, sH = 0;
            //按比例缩放
            System.Drawing.Size tem_size = new System.Drawing.Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            System.Drawing.Bitmap ob = new System.Drawing.Bitmap(dWidth, dHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(ob);

            g.Clear(System.Drawing.Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, System.Drawing.GraphicsUnit.Pixel);

            //g.DrawImage(iSource, 0, 0, iSource.Width, iSource.Height,System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }

                if (jpegICIinfo != null)
                {
                    ob.Save(tempFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                    FileInfo fi = new FileInfo(tempFile);
                    if (fi.Length > 1024 * size)
                    {
                        flag = flag - 10;
                        CompressImage(sFile, flag, size, false);
                    }
                }
                else
                {
                    ob.Save(tempFile, tFormat);
                }
                return tempFile;
            }
            catch
            {
                return "" ;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }

        /// <summary>
        /// 修改图片的大小
        /// </summary>
        /// <param name="b"></param>
        /// <param name="destHeight"></param>
        /// <param name="destWidth"></param>
        /// <returns></returns>
        public static Bitmap GetThumbnail(Bitmap b, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = b;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放           
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量         
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量     
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp;
        }

        #endregion
        
        #region 时分与数字的转换
        /// <summary>
        /// 把分钟的数值转换成时间
        /// </summary>
        /// <param name="Minutes">分钟 的数值</param>
        /// <returns>时间（忽略日期部分2000-01-01）</returns>
        public static DateTime IntMinutesToTime(int Minutes)
        {
            int h = 0, m = 0;
            if (Minutes < 60)
            {
                m = Minutes;
            }
            else
            {
                h = Minutes / 60;
                m = Minutes % 60;
            }
            string Time = "2000-01-01 " + h.ToString().PadLeft(2, '0') + ":" + m.ToString().PadLeft(2, '0') + ":00";

            return DateTime.Parse(Time);
        }

        /// <summary>
        /// 把提供的日期的小时和分钟数转换成分钟显示、得到一个数值
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>日期 '时'、'分'部分 转换成分钟的数值</returns>
        public static int TimeToIntMinutes(DateTime time)
        {
            int h = 0, m = 0;
            h = time.Hour * 60;
            m = time.Minute;
            return h + m;
        }

        #endregion

        #region 获取IP 和MAC地址

        #region 方法1
        public static string GetIPAddress()
        {
            IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            return hostAddresses[0].ToString();
        }

        public static string GetIPAddress2()
        {
            IPAddress[] addressList = Dns.GetHostEntry(appPublic.GetHostName()).AddressList;
            int num = addressList.Length;
            for (int i = 0; i < num; i++)
            {
                if (!addressList[i].IsIPv6LinkLocal && !addressList[i].IsIPv6Multicast && !addressList[i].IsIPv6SiteLocal)
                {
                    string text = addressList[i].ToString();
                    if (!text.StartsWith("169.254") && !text.Contains(':'))
                    {
                        return text;
                    }
                }
            }
            return addressList[0].ToString();
        }

        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        public static string GetHostName(int MaxLen)
        {
            string hostName = appPublic.GetHostName();
            int length = hostName.Trim().Length;
            return hostName.Substring(0, (length >= MaxLen) ? MaxLen : length);
        }
        #endregion

        #region  方法2

        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        //获取本机的IP
        /// <summary>  
        /// 获取当前使用的IP  
        /// </summary>  
        /// <returns></returns>  
        public static string getLocalIP()
        {
            string strHostName = Dns.GetHostName(); //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName); //取得本机IP

            foreach (IPAddress ips in ipEntry.AddressList)
            {
                if (ips.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ips.ToString();
                }
            }

            return "";
        }


        //获取本机的MAC
        public static string getLocalMac()
        {
            string mac = null;
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            return (mac);
        }

        //获取远程主机IP

        public static string[] getRemoteIP(string RemoteHostName)
        {
            IPHostEntry ipEntry = Dns.GetHostByAddress(RemoteHostName);
            IPAddress[] IpAddr = ipEntry.AddressList;
            string[] strAddr = new string[IpAddr.Length];
            for (int i = 0; i < IpAddr.Length; i++)
            {
                strAddr[i] = IpAddr[i].ToString();
            }
            return (strAddr);
        }
        //获取远程主机MAC

        public static string getRemoteMac(string localIP, string remoteIP)
        {
            Int32 ldest = inet_addr(remoteIP); //目的ip 

            Int32 lhost = inet_addr(localIP); //本地ip


            try
            {
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                return Convert.ToString(macinfo, 16);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error:{0}", err.Message);
            }
            return 0.ToString();
        }


        public static bool IsIP(string IP)
        {
            if (string.IsNullOrEmpty(IP))
            {
                return false;
            }

            IP = IP.Trim();
            string PATTERN = @"^((25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))";
            return Regex.IsMatch(IP, PATTERN);
        }

        public static bool validateIP(string startIP, string endIP)
        {
            // 分离出ip中的四个数字位
            string[] startIPArray = startIP.Split('.');
            string[] endIPArray = endIP.Split('.');

            // 取得各个数字
            long[] startIPNum = new long[4];
            long[] endIPNum = new long[4];
            for (int i = 0; i < 4; i++)
            {
                startIPNum[i] = long.Parse(startIPArray[i].Trim());
                endIPNum[i] = long.Parse(endIPArray[i].Trim());
            }

            // 各个数字乘以相应的数量级
            long startIPNumTotal = startIPNum[0] * 256 * 256 * 256 + startIPNum[1] * 256 * 256 + startIPNum[2] * 256 + startIPNum[3];
            long endIPNumTotal = endIPNum[0] * 256 * 256 * 256 + endIPNum[1] * 256 * 256 + endIPNum[2] * 256 + endIPNum[3];

            if (startIPNumTotal > endIPNumTotal)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool validateIPContains(string startIP, string endIP,string hostIP)
        {
            // 分离出ip中的四个数字位
            string[] startIPArray = startIP.Split('.');
            string[] endIPArray = endIP.Split('.');
            string[] hostIPArray = hostIP.Split('.');
            // 取得各个数字
            long[] startIPNum = new long[4];
            long[] endIPNum = new long[4];
            long[] hostIPNum = new long[4];
            for (int i = 0; i < 4; i++)
            {
                startIPNum[i] = long.Parse(startIPArray[i].Trim());
                endIPNum[i] = long.Parse(endIPArray[i].Trim());
                hostIPNum[i]= long.Parse(hostIPArray[i].Trim());
            }

            // 各个数字乘以相应的数量级
            long startIPNumTotal = startIPNum[0] * 256 * 256 * 256 + startIPNum[1] * 256 * 256 + startIPNum[2] * 256 + startIPNum[3];
            long endIPNumTotal = endIPNum[0] * 256 * 256 * 256 + endIPNum[1] * 256 * 256 + endIPNum[2] * 256 + endIPNum[3];
            long hostIPNumTotal = hostIPNum[0] * 256 * 256 * 256 + hostIPNum[1] * 256 * 256 + hostIPNum[2] * 256 + hostIPNum[3];

            if (startIPNumTotal<=hostIPNumTotal&&endIPNumTotal>=hostIPNumTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion 

        #endregion

        #region 实体列表与DataTable互换
        /// <summary>
        /// DataTable转换成实体列表
        /// </summary>
        /// <typeparam name="T">实体 T </typeparam>
        /// <param name="table">datatable</param>
        /// <returns></returns>
        public static IList<T> DataTableToList<T>(DataTable table)
            where T : class
        {
            //if (!IsHaveRows(table))
            if (table == null || table.Rows.Count == 0)
                return new List<T>();

            IList<T> list = new List<T>();
            T model = default(T);
            foreach (DataRow dr in table.Rows)
            {
                model = Activator.CreateInstance<T>();

                foreach (DataColumn dc in dr.Table.Columns)
                {
                    object drValue = dr[dc.ColumnName];
                    PropertyInfo pi = model.GetType().GetProperty(dc.ColumnName);

                    if (pi != null && pi.CanWrite && (drValue != null && !Convert.IsDBNull(drValue)))
                    {
                        pi.SetValue(model, drValue, null);
                    }
                }

                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 实体列表转换成DataTable
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="list"> 实体列表</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(IList<T> list)
            where T : class
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            int length = myPropertyInfo.Length;
            bool createColumn = true;

            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();
                for (int i = 0; i < length; i++)
                {
                    PropertyInfo pi = myPropertyInfo[i];
                    string name = pi.Name;
                    if (createColumn)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                if (createColumn)
                {
                    createColumn = false;
                }

                dt.Rows.Add(row);
            }
            return dt;

        }
        #endregion

        #region 身份证验证

        private static bool CheckIDCard(string CardNo)
        {
            if (CardNo.Length == 18)
            {
                return CheckIDCard18(CardNo);
            }
            else if (CardNo.Length == 15)
            {
                return CheckIDCard15(CardNo);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证18位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        public static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 验证15位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        public static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        public static DateTime GetIDCardToBirthday(string IDCard)
        {
            string BirthDay = " ";
            string strYear;
            string strMonth;
            string strDay;
            if (IDCard.Length == 15)
            {
                strYear = IDCard.Substring(6, 4);
                strMonth = IDCard.Substring(8, 2);
                strDay = IDCard.Substring(10, 2);
                BirthDay = strYear + "- " + strMonth + "- " + strDay;
            }
            if (IDCard.Length == 18)
            {
                strYear = IDCard.Substring(6, 4);
                strMonth = IDCard.Substring(10, 2);
                strDay = IDCard.Substring(12, 2);
                BirthDay = strYear + "- " + strMonth + "- " + strDay;
            }
            return ToDateTime(BirthDay);
        }
        #endregion

        #region  DEV常用的方法

        /// <summary>
        /// 打印预览功能
        /// </summary>
        /// <param name="panel">打印控件</param>
        /// <param name="title">标题</param>
        /// <param name="pageSize">纸张类型</param>
        /// <param name="margins">边距</param>
        public static void DevPreview(IPrintable panel, string title = null, bool landscape = false, PaperKind pageSize = PaperKind.A4, System.Drawing.Printing.Margins margins = null)
        {
            PrintingSystem ps = new PrintingSystem();
            CompositeLink link = new DevExpress.XtraPrintingLinks.CompositeLink(ps);
            PrintableComponentLink printableLink = new PrintableComponentLink() { Component = panel };
            ps.Links.Add(link);
            link.Links.Add(printableLink);
            link.Landscape = landscape;//横向
            link.PaperKind = pageSize;//设置纸张大小
            if (margins == null)
                margins = new System.Drawing.Printing.Margins(10, 10, 50, 50);
            link.Margins = margins;
            //判断是否有标题，有则设置
            if (!string.IsNullOrEmpty(title))
            {

                PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();
                phf.Header.Content.AddRange(new string[] { "操作人员：" + AppPublic.appSession._LoginName, title, string.Format("打印时间:{0}", DateTime.Now.ToString("yyyy-MM-dd")) });
                phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
                phf.Header.LineAlignment = BrickAlignment.Center;
                link.CreateMarginalFooterArea += new CreateAreaEventHandler(link_CreateMarginalFooterArea);
            }
            link.CreateDocument(); //建立文档
            ps.PreviewRibbonFormEx.Show();//进行预览 
        }

        static void link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick vPageInfoBrick1 = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "第{0}页，共{1}页", Color.Black,
               new RectangleF(0, 0, 100, 21), BorderSide.None);
            vPageInfoBrick1.LineAlignment = BrickAlignment.Center;
            vPageInfoBrick1.Alignment = BrickAlignment.Center;
            vPageInfoBrick1.AutoWidth = true;
            vPageInfoBrick1.Font = new System.Drawing.Font("宋体", 11f, FontStyle.Bold);

        }

        public static void DevExprot(GridControl gcControl)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gcControl.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

     
    }
}
