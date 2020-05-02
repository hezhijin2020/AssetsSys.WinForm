using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.BLL
{
    public class RefundOrderManager
    {
        DAL.RefundOrderService sev = new DAL.RefundOrderService();



        /// <summary>
        /// 新增领用信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_RefundOrder model)
        {
           return sev.AddNew(model);
        }

        /// <summary>
        /// 获取新单号
        /// </summary>
        /// <returns></returns>
        public string GetNewRefundNo()
        {
            string MaxNo = sev.GetMaxRefundNo();
            if (MaxNo=="")
            {
                return "TK" + DateTime.Now.ToString("yyMMdd") + "001";
            }
            else
            {
                string daypart = MaxNo.ToString().Substring(2, 6);
                int num = int.Parse(MaxNo.ToString().Substring(8, 3));
                if (daypart.Equals(DateTime.Now.ToString("yyMMdd")))
                {
                    return "TK" + daypart + (num + 1).ToString().PadLeft(3, '0');
                }
                else
                {
                    return "TK" + DateTime.Now.ToString("yyMMdd") + "001";
                }
            }
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
