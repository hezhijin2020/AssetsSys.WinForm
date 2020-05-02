using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RightingSys.WinForm.Utils.cls
{
    public class EnumHelper
    {
        #region 方法一

        /// <summary>
        /// 获取枚举有所有项目
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>数据集</returns>
        public static System.Collections.ArrayList GetName(Type enumType)
        {
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            string[] n = System.Enum.GetNames(enumType);
            foreach (string item in n)
                arr.Add(item);
            return arr;

        }

        /// <summary>
        /// 根据提供的枚举名称，返回枚举类
        /// </summary>
        /// <typeparam name="T"> 枚举类</typeparam>
        /// <param name="strEnum">枚举名称</param>
        /// <returns>枚举</returns>
        public static T ToEnum<T>(string strEnum)
        {
            T t = (T)Enum.Parse(typeof(T), strEnum);
            return t;
        }

        /// <summary>
        /// 把枚举转成哈希表
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>数据集</returns>
        public static System.Collections.Hashtable EnumToHashtable(Type enumType)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            Array arr = System.Enum.GetValues(enumType);
            for (int i = 0; i < arr.Length; i++)
                ht.Add(Convert.ToInt16(arr.GetValue(i)), arr.GetValue(i).ToString());
            return ht;
        }

        #endregion

        #region 方法二

        /// <summary>
        /// 返回枚举值的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举值。</param>
        /// <returns>枚举值的描述信息。</returns>
        public static string GetEnumDescriptionByInt<T>(int value)
        {
            Type enumType = typeof(T);
            DescriptionAttribute attr = null;

            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                }
            }

            // 返回结果
            if (attr != null && !string.IsNullOrEmpty(attr.Description))
                return attr.Description;
            else
                return string.Empty;
        }

        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="e">要获取描述信息的枚举项。</param>
        /// <returns>枚举项的描述信息。</returns>
        public static string GetEnumDescriptionByEnum(Enum e)
        {
            if (e == null)
            {
                return string.Empty;
            }
            Type enumType = e.GetType();
            DescriptionAttribute attr = null;

            // 获取枚举字段。
            FieldInfo fieldInfo = enumType.GetField(e.ToString());
            if (fieldInfo != null)
            {
                // 获取描述的属性。
                attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
            }

            // 返回结果
            if (attr != null && !string.IsNullOrEmpty(attr.Description))
                return attr.Description;
            else
                return string.Empty;
        }

        /// <summary>
        /// 获取枚举描述列表，并转化为键值对
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isHasAll">是否包含“全部”</param>
        /// <param name="filterItem">过滤项</param>
        /// <returns></returns>
        public static List<EnumKeyValue> EnumDescToList<T>(bool isHasAll, params string[] filterItem)
        {
            List<EnumKeyValue> list = new List<EnumKeyValue>();

            // 如果包含全部则添加
            if (isHasAll)
            {
                list.Add(new EnumKeyValue() { Key = 0, Name = "全部" });
            }

            #region 方式一
            foreach (var item in typeof(T).GetFields())
            {
                // 获取描述
                var attr = item.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;
                if (attr != null && !string.IsNullOrEmpty(attr.Description))
                {
                    // 跳过过滤项
                    if (Array.IndexOf<string>(filterItem, attr.Description) != -1)
                    {
                        continue;
                    }
                    // 添加
                    EnumKeyValue model = new EnumKeyValue();
                    model.Key = (int)Enum.Parse(typeof(T), item.Name);
                    model.Name = attr.Description;
                    list.Add(model);
                }
            }
            #endregion

            #region 方式二
            //foreach (int item in Enum.GetValues(typeof(T)))
            //{
            //    // 获取描述
            //    FieldInfo fi = typeof(T).GetField(Enum.GetName(typeof(T), item));
            //    var attr = fi.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
            //    if (attr != null && !string.IsNullOrEmpty(attr.Description))
            //    {
            //        // 跳过过滤项
            //        if (Array.IndexOf<string>(filterItem, attr.Description) != -1)
            //        {
            //            continue;
            //        }
            //        // 添加
            //        EnumKeyValue model = new EnumKeyValue();
            //        model.Key = item;
            //        model.Name = attr.Description;
            //        list.Add(model);
            //    }
            //} 
            #endregion

            return list;
        }

        /// <summary>
        /// 获取枚举值列表，并转化为键值对
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isHasAll">是否包含“全部”</param>
        /// <param name="filterItem">过滤项</param>
        /// <returns></returns>
        public static List<EnumKeyValue> EnumToList<T>(bool isHasAll, params string[] filterItem)
        {
            List<EnumKeyValue> list = new List<EnumKeyValue>();

            // 如果包含全部则添加
            if (isHasAll)
            {
                list.Add(new EnumKeyValue() { Key = 0, Name = "全部" });
            }

            foreach (int item in Enum.GetValues(typeof(T)))
            {
                string name = Enum.GetName(typeof(T), item);
                // 跳过过滤项
                if (Array.IndexOf<string>(filterItem, name) != -1)
                {
                    continue;
                }
                // 添加
                EnumKeyValue model = new EnumKeyValue();
                model.Key = item;
                model.Name = name;
                list.Add(model);
            }

            return list;
        }
        #endregion
    }

    /// <summary>
    /// 枚举键值对
    /// </summary>
    public class EnumKeyValue
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }

}
