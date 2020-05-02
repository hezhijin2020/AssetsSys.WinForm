using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 状态实体
    /// </summary>
    public class ys_AssetsStatus : BaseEntity
    {
        /// <summary>
        /// 状态名称
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string StatusCode { get; set; }
    }
}
