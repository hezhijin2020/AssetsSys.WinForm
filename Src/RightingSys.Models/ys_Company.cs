using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 供应商公司
    /// </summary>
    public class ys_Company:BaseEntity
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        ///联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        ///电话
        /// </summary>
        public string Tell { get; set; }
        /// <summary>
        ///地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///描述信息
        /// </summary>
        public string Description { get; set; }

    }
}
