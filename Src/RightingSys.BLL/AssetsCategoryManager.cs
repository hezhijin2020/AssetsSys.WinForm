using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.BLL
{
    public class AssetsCategoryManager
    {
        DAL.AssetsCategoryService dal = new DAL.AssetsCategoryService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_AssetsCategory model)
        {
          return  dal.AddNew(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_AssetsCategory model)
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
        public Models.ys_AssetsCategory GetOneById(Guid Id)
        {
            return dal.GetAllList().FirstOrDefault(s=>s.Id==Id);
        }
        public List<Models.ys_AssetsCategory> GetAllList()
        {
            return dal.GetAllList().OrderBy(a => a.SortCode).ToList();
        }
    }
}
