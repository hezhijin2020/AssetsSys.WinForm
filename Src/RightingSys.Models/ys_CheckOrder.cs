using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    public class ys_CheckOrder:BaseEntity
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string CheckNo { get; set; }

        public DateTime Checkday { get; set; } = DateTime.Now;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; } = false;

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime IsAuditday { get; set; } = DateTime.Parse("2020-01-01");

    }
}
