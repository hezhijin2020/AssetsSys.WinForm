using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 借用单明细
    /// </summary>
    public class ys_ReturnOrderDetail: BaseEntity
    {
        /// <summary>
        /// 借用归还ID
        /// </summary>
        public Guid ReturnId { get; set; }

        /// <summary>
        /// 资产ID
        /// </summary>
        public Guid AssetsId { get; set; }

        /// <summary>
        /// 借用前用户ID
        /// </summary>
        public Guid OldUserId { get; set; } = Guid.Empty;
        public string OldUserName { get; set; } = "";

        /// <summary>
        /// 借用前部门id
        /// </summary>
        public Guid OldDepartmentId { get; set; } = Guid.Empty;

        public string OldDepartmentName { get; set; } = "";
        /// <summary>
        /// 借用前状态
        /// </summary>
        public string OldStatusId { get; set; } = "JY";
        public string OldStatusName { get; set; } = "借用";

    }
}
