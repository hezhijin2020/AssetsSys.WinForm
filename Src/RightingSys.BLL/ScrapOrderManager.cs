using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.BLL
{
    /// <summary>
    /// 维修管理类
    /// </summary>
    public class ScrapOrderManager
    {
        DAL.ScrapOrderService sev = new DAL.ScrapOrderService(); 

        /// <summary>
        /// 新增维修记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddNew(IList<Models.ys_ScrapOrder> listModel)
        {
            return sev.AddNew(listModel);
        }

        /// <summary>
        /// 修改维修记录
        /// </summary>
        /// <param name="listModel"></param>
        /// <returns></returns>
        public bool Modify(IList<Models.ys_ScrapOrder> listModel)
        {
            return sev.Modify(listModel);
        }

        /// <summary>
        /// 修改指定的维修记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_ScrapOrder model)
        {
            return sev.Modify(new List<Models.ys_ScrapOrder> { model});
        }

        /// <summary>
        /// 获取最大的订单号
        /// </summary>
        /// <returns></returns>
        public string GetNewScrapNo()
        {
            string MaxNo = sev.GetMaxScrapNo();
            if (MaxNo == "")
            {
                return "BF" + DateTime.Now.ToString("yyMMdd") + "001";
            }
            else
            {
                string daypart = MaxNo.ToString().Substring(2, 6);
                int num = int.Parse(MaxNo.ToString().Substring(8, 3));
                if (daypart.Equals(DateTime.Now.ToString("yyMMdd")))
                {
                    return "BF" + daypart + (num + 1).ToString().PadLeft(3, '0');
                }
                else
                {
                    return "BF" + DateTime.Now.ToString("yyMMdd") + "001";
                }
            }
        }

        /// <summary>
        /// 获取指定ID维修记录信息
        /// </summary>
        /// <param name="Id">维修Id</param>
        /// <returns></returns>
        public Models.ys_ScrapOrder GetOneById(Guid Id)
        {
            return sev.GetOneById(Id);
        }

        /// <summary>
        /// 根据订单号获取维修信息
        /// </summary>
        /// <param name="RepairNo">订单号</param>
        /// <returns></returns>
        public IList<Models.ys_ScrapOrder> GetOneByScrapNo(string ScrapNo)
        {
            return sev.GetOneByScrapNo(ScrapNo);
        }

        /// <summary>
        /// 根据订单号获取维修信息
        /// </summary>
        /// <param name="RepairNo">订单号</param>
        /// <returns></returns>
        public DataTable GetTableOneByScrapNo(string ScrapNo)
        {
            return sev.GetTableOneByScrapNo(ScrapNo);
        }

        /// <summary>
        /// 获取所有的维修订单
        /// </summary>
        /// <returns></returns>
        public List<Models.ys_ScrapOrder> GetAllList()
        {
            return sev.GetAllList().ToList();
        }


        /// <summary>
        /// 获取所有的维修订单
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable()
        {
            return sev.GetAllTable();
        }
    }
}
