using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RightingSys.BLL
{
    public class CheckOrderManager
    {
        DAL.CheckOrderService sev = new DAL.CheckOrderService();

        /// <summary>
        /// 新增盘点单 
        /// </summary>
        /// <param name="model">盘点单实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_CheckOrder model)
        {
           return sev.AddNew(model);
        }

        /// <summary>
        /// 订单修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_CheckOrder model)
        {
            return sev.Modify(model);
        }

        /// <summary>
        /// 新增盘点机明细
        /// </summary>
        /// <param name="model">资产明细</param>
        /// <returns></returns>
        public bool AddNewDetail(Models.ys_CheckOrderDeail model)
        {
            return sev.AddNewDetail(model);
        }

        /// <summary>
        /// 删除盘点单明细
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool DeleteDetail(Models.ys_CheckOrderDeail model)
        {
            return sev.DeleteDetail(model);
        }

        /// <summary>
        /// 获取所有的盘点单
        /// </summary>
        /// <returns></returns>
        public List<Models.ys_CheckOrder> GetAllList()
        {
          return  sev.GetAllList().Where(a => a.IsRemoved == false).ToList();
        }

        /// <summary>
        /// 获取盘点单
        /// </summary>
        /// <returns></returns>
        public Models.ys_CheckOrder GetOneByCheckId(Guid checkId)
        {
            return sev.GetAllList().FirstOrDefault(a => a.Id == checkId);
        }

        /// <summary>
        /// 获取盘点单明细
        /// </summary>
        /// <param name="checkId">盘点单ID</param>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable(Guid checkId)
        {
            return sev.GetAllTable(checkId);
        }

        /// <summary>
        /// 获取新单号
        /// </summary>
        /// <returns></returns>
        public string GetNewCheckNo()
        {
            string MaxNo = sev.GetMaxCheckNo();
            if (MaxNo == "")
            {
                return "PD" + DateTime.Now.ToString("yyMMdd") + "001";
            }
            else
            {
                string daypart = MaxNo.ToString().Substring(2, 6);
                int num = int.Parse(MaxNo.ToString().Substring(8, 3));
                if (daypart.Equals(DateTime.Now.ToString("yyMMdd")))
                {
                    return "PD" + daypart + (num + 1).ToString().PadLeft(3, '0');
                }
                else
                {
                    return "PD" + DateTime.Now.ToString("yyMMdd") + "001";
                }
            }
        }

        /// <summary>
        /// 根据单号保存盘点明细
        /// </summary>
        /// <param name="dt">盘点明细</param>
        /// <param name="checkId">单号Id</param>
        /// <returns></returns>
        public bool SaveDetail(DataTable dt)
        {
            return sev.SaveDetail(dt);
        }
    }
}
