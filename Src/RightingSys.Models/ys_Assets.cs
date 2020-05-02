using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.Models
{
    /// <summary>
    /// 资产实体
    /// </summary>
    public class ys_Assets:BaseEntity
    {
        /// <summary>
        /// 条码唯一
        /// </summary>
        public string Barcode  {get;set;}
        /// <summary>
        /// 名称
        /// </summary>
        public string Name {get;set;}
        /// <summary>
        /// 型号
        /// </summary>
        public string Model  {get;set;}
        /// <summary>
        /// 供应商公司ID
        /// </summary>
        public Guid CompanyId  {get;set;}
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 类别ID
        /// </summary>
        public Guid CategoryId {get;set;}
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid DepartmentId { get; set; } = Guid.Empty;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName  {get;set;}
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 购买日期
        /// </summary>
        public DateTime Buyday {get;set;}
        /// <summary>
        /// 使用地点
        /// </summary>
        public string Location  {get;set;}
        /// <summary>
        /// 仓库ID
        /// </summary>
        public Guid StockId {get;set;}
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; } = 0;
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description {get;set;}
        /// <summary>
        /// 状态ID
        /// </summary>
        public string StatusId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string StatusName { get; set; }
       /// <summary>
       /// 附加信息
       /// </summary>
        public string XmlInf { get; set; }
}
}
