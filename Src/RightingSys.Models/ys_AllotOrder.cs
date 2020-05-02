using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 借用实体类
    /// </summary>
    public class ys_AllotOrder:BaseEntity
    {
         /// <summary>
         /// 借用单号
         /// </summary>
        public string AllotNo { get; set; }

       /// <summary>
       /// 借用人ID
       /// </summary>
        public Guid AllotUserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string AllotUserName { get; set; }

        /// <summary>
        /// 借用部门
        /// </summary>
        public Guid AllotDepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string AllotDepartmentName { get; set; }

        /// <summary>
        /// 操作人员Id
        /// </summary>
        public Guid OperatorId { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 借用时间
        /// </summary>
        public DateTime Allotday { get; set; } = DateTime.Now;
        
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 使用的地点
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; } = true;

        public List<ys_AllotOrderDetail> Detail { get; set; }
    }
}
