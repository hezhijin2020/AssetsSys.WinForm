using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 资产类别
    /// </summary>
   public class ys_AssetsCategory:BaseEntity
    {
        /// <summary>
        /// 上级类别ID
        /// </summary>
        public Guid ParentId { get; set; } = Guid.Empty;
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public string SortCode { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string SimpleCode { get; set; }

    }
}
