using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 报废单实体
    /// </summary>
    public class ys_ScrapOrder:BaseEntity
    {

        /// <summary>
        /// 单号
        /// </summary>
        public string ScrapNo { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public Guid AssetsId { get; set; }

        /// <summary>
        /// 资产状态
        /// </summary>
        public string OldStatusId { get; set; }

        /// <summary>
        /// 申请人员Id
        /// </summary>
        public Guid ScrapUserId { get; set; }

        /// <summary>
        /// 申请人员
        /// </summary>
        public string ScrapUserName { get; set; }

        /// <summary>
        /// 报废时间
        /// </summary>
        public DateTime Scrapday { get; set; } = DateTime.Now;

        /// <summary>
        /// 经办人Id
        /// </summary>
        public Guid OperatorId { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string ScrapDescription { get; set; } = "设备使命完成，淘汰";

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; }


    }
}
