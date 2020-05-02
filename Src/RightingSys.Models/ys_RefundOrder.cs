using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 退库单
    /// </summary>
    public class ys_RefundOrder:BaseEntity
    {

        /// <summary>
        /// 退库单号
        /// </summary>
        public string RefundNo { get; set; }
        /// <summary>
        /// 退库时间
        /// </summary>
        public DateTime Refundday { get; set; }
        /// <summary>
        /// 退库人ID
        /// </summary>
        public Guid RefundUserId { get; set; }
        /// <summary>
        /// 退库人
        /// </summary>
        public string RefundUserName { get; set; }
        /// <summary>
        /// 操作员Id
        /// </summary>
        public Guid OperatorId { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; }

        public List<ys_RefundOrderDetail> Detail { get; set; }

    }
}
