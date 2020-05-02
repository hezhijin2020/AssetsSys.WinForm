using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.BLL
{
    public class AssetsStockManager
    {
        DAL.AssetsStockService dal = new DAL.AssetsStockService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_AssetsStock model)
        {
          return  dal.AddNew(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_AssetsStock model)
        {
            return dal.Modify(model);
        }
        public bool Delete(Guid Id)
        {
            return dal.Delete(Id);
        }
        public bool ExistsAssetsById(Guid Id)
        {
            return dal.ExistsAssetsById(Id);
        }
        public Models.ys_AssetsStock GetOneById(Guid Id)
        {
            return dal.GetAllList().FirstOrDefault(s=>s.Id==Id);
        }
        public List<Models.ys_AssetsStock> GetAllList()
        {
            return dal.GetAllList().OrderBy(a => a.StockName).ToList();
        }
    }
}
