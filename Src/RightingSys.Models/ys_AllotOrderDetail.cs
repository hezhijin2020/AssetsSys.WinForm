using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 借用单明细
    /// </summary>
    public class ys_AllotOrderDetail : BaseEntity
    {
        /// <summary>
        /// 借用ID
        /// </summary>
        public Guid AllotId { get; set; }

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
        /// 借用前位置
        /// </summary>
        public string OldLocation { get; set; }
        
    }
}
