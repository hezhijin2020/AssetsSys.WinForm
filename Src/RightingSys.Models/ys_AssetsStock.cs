using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 仓库实体
    /// </summary>
    public  class ys_AssetsStock:BaseEntity
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 管理员ID
        /// </summary>
        public Guid ManagerId{ get; set; }
        /// <summary>
        /// 管理员名称
        /// </summary>
        public string ManagerName { get; set; }

    }
}
