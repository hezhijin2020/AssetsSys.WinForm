using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    public class ys_CheckOrderDeail:BaseEntity
    {
       /// <summary>
       /// 盘点单ID
       /// </summary>
        public Guid CheckId { get; set; }

        /// <summary>
        /// 资产Id
        /// 
        /// </summary>
        public Guid AssetsId { get; set; }

        /// <summary>
        /// 资产状态
        /// </summary>
        public string OldStatusId { get; set; }

        /// <summary>
        /// 是否已盘
        /// </summary>
        public bool IsCheck { get; set; } = false;

        /// <summary>
        /// 盘点时间
        /// </summary>
        public DateTime IsCheckTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 盘点员ID
        /// </summary>
        public Guid CheckUserId { get; set; }

        /// <summary>
        /// 盘点员
        /// </summary>
        public string CheckUserName { get; set; }
        
    }
}
