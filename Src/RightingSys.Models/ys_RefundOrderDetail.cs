using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 退库单明细
    /// </summary>
    public class ys_RefundOrderDetail:BaseEntity
    {
        /// <summary>
        /// 资产Id
        /// </summary>
       public Guid AssetsId { get; set; }
        /// <summary>
        /// 单号Id
        /// </summary>
       public Guid RefundId { get; set; }
        /// <summary>
        /// 老用户ID
        /// </summary>
        public Guid OldUserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string OldUserName { get; set; }

        /// <summary>
        /// 老部门Id
        /// </summary>
        public Guid OldDepartmentId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string OldDepartmentName { get; set; }

        /// <summary>
        /// 老位置
        /// </summary>
        public string OldLocation { get; set; }
        /// <summary>
        /// 老状态Id
        /// </summary>
        public string OldStatusId { get; set; }
        /// <summary>
        /// 老状态
        /// </summary>
        public string OldStatusName { get; set; }
    }
}
