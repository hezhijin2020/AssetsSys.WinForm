using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    public class ys_AssetsStatusChange : BaseEntity
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string ActionNo { get; set; }
        /// <summary>
        /// 资产Id
        /// </summary>
        public Guid AssetsId { get; set; }

        /// <summary>
        /// 职员
        /// </summary>
        public Guid ActionUserId { get; set; }
        /// <summary>
        /// 职员
        /// </summary>
        public string ActionUserName { get; set; }

    }
}
