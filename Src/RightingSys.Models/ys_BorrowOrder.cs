using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 借用实体类
    /// </summary>
    public class ys_BorrowOrder:BaseEntity
    {
         /// <summary>
         /// 借用单号
         /// </summary>
        public string BorrowNo { get; set; }

       /// <summary>
       /// 借用人ID
       /// </summary>
        public Guid BorrowUserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string BorrowUserName { get; set; }

        /// <summary>
        /// 借用部门
        /// </summary>
        public Guid BorrowDepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string BorrowDepartmentName { get; set; }


        /// <summary>
        /// 借用时间
        /// </summary>
        public DateTime Borrowday { get; set; } = DateTime.Now;

        /// <summary>
        /// 预计归还时间
        /// </summary>
        public DateTime Planday { get; set; } = DateTime.Now;


        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; } = true;

        public List<ys_BorrowOrderDetail> Detail { get; set; }
    }
}
