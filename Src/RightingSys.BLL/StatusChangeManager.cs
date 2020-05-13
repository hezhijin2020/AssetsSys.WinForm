using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.BLL
{
    public class StatusChangeManager
    {
         DAL.StatusChangeSerivce sev = new DAL.StatusChangeSerivce();
        /// <summary>
        /// 新增状态改变事件
        /// </summary>
        /// <param name="model">实体</param>
        public bool AddNew(Models.ys_AssetsStatusChange model)
        {
            return sev.AddNew(model);
        }

        /// <summary>
        /// 获取所有的记录
        /// </summary>
        public IList<Models.ys_AssetsStatusChange> GetAllList()
        {
            return sev.GetAllList().Where(a => a.IsRemoved == false).ToList();
        }
    }
}
