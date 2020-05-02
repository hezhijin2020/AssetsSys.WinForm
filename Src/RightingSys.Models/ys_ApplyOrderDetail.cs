using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 领用订单明细
    /// </summary>
    public class ys_ApplyOrderDetail:BaseEntity
    {
        /// <summary>
        /// 领用单号
        /// </summary>
        public Guid ApplyId { get; set; }

        /// <summary>
        /// 资产单号
        /// </summary>
        public Guid AssetsId { get; set; }

        /// <summary>
        /// 资产状态
        /// </summary>
        public string OldStatusId { get; set; } = "XZ";
    }
}
