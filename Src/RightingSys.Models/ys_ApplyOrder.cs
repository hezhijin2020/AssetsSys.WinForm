using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 领用订单
    /// </summary>
    public class ys_ApplyOrder:BaseEntity
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string ApplyNo { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid ApplyUserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string ApplyUserName { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public Guid ApplyDepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string ApplyDepartmentName { get; set; }

        /// <summary>
        /// 操作员Id
        /// </summary>
        public Guid OperatorId { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperatorName { get; set; }


        /// <summary>
        /// 使用地点
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 领用日期
        /// </summary>
        public DateTime Applyday { get; set; } = DateTime.Now;

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; }

        public List<Models.ys_ApplyOrderDetail> Detail { get; set; }
       
    }
}
