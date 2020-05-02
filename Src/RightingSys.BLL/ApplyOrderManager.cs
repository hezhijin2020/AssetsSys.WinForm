using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.BLL
{
    public class ApplyOrderManager
    {
        DAL.ApplyOrderService sev = new DAL.ApplyOrderService();



        /// <summary>
        /// 新增领用信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_ApplyOrder model)
        {
           return sev.AddNew(model);
        }

        /// <summary>
        /// 获取新单号
        /// </summary>
        /// <returns></returns>
        public string GetNewApplyNo()
        {
            string MaxNo = sev.GetMaxApplyNo();
            if (MaxNo=="")
            {
                return "LY" + DateTime.Now.ToString("yyMMdd") + "001";
            }
            else
            {
                string daypart = MaxNo.ToString().Substring(2, 6);
                int num = int.Parse(MaxNo.ToString().Substring(8, 3));
                if (daypart.Equals(DateTime.Now.ToString("yyMMdd")))
                {
                    return "LY" + daypart + (num + 1).ToString().PadLeft(3, '0');
                }
                else
                {
                    return "LY" + DateTime.Now.ToString("yyMMdd") + "001";
                }
            }
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        public List<Models.ys_ApplyOrder> GetAllList()
        {
           return sev.GetAllList().ToList();
        }

        /// <summary>
        /// 跟据Id订单信息
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public Models.ys_ApplyOrder GetOneById(Guid Id)
        {
            return sev.GetAllList().FirstOrDefault(a => a.Id == Id);
        }

        /// <summary>
        /// 跟据ApplyNo订单信息
        /// </summary>
        /// <param name="AppleNo">订单号</param>
        /// <returns></returns>
        public Models.ys_ApplyOrder GetOneByApplyNo(string AppleNo)
        {
            return sev.GetAllList().FirstOrDefault(a => a.ApplyNo == AppleNo);
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable()
        {
           return sev.GetAllTable();
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetTableOneById(Guid id)
        {
            return sev.GetTableOneById(id);
        }
    }
}
