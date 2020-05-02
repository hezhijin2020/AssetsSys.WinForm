using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 维修类实体
    /// </summary>
    public class ys_RepairOrder:BaseEntity
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string RepairNo { get; set; }

        /// <summary>
        /// 资产Id
        /// </summary>
        public Guid AssetsId { get; set; }

        /// <summary>
        /// 维修机构ID
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// 维修机构名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 报修人员ID
        /// </summary>
        public Guid RepairUserId { get; set; }

        /// <summary>
        /// 报修人员名称
        /// </summary>
        public string RepairUserName { get; set; }

        /// <summary>
        /// 报修人员名称
        /// </summary>
        public Guid FinishUserId { get; set; }

        /// <summary>
        /// 报修人员名称
        /// </summary>
        public string FinishUserName { get; set; }

        /// <summary>
        /// 经办人Id
        /// </summary>
        public Guid   OperatorId { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 报修时间
        /// </summary>
        public DateTime Repairday { get; set; }

        /// <summary>
        /// 维修原因
        /// </summary>
        public string RepairReason { get; set; }

        /// <summary>
        /// 维修描述
        /// </summary>
        public string RepairDescription { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime Finishday { get; set; }
        
        /// <summary>
        /// 维修价格
        /// </summary>
        public decimal RepairPrice { get; set; } = 0;

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsFinish { get; set; } = false;
    }
}
