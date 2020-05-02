using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.BLL
{
    public class AssetsManager
    {
        DAL.AssetsService dal = new DAL.AssetsService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_Assets model)
        {
          return  dal.AddNew(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_Assets model)
        {
            return dal.Modify(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id">资产Id</param>
        /// <returns></returns>
        public bool Delete(Guid Id)
        {
            return dal.Delete(Id);
        }
     /// <summary>
     /// 获取指定ID实体
     /// </summary>
     /// <param name="Id">资产Id</param>
     /// <returns></returns>
        public Models.ys_Assets GetOneById(Guid Id)
        {
            return dal.GetAllList().FirstOrDefault(s=>s.Id==Id);
        }

        /// <summary>
        /// 获取所有资产信息
        /// </summary>
        /// <returns></returns>
        public List<Models.ys_Assets> GetAllList()
        {
            return dal.GetAllList().OrderBy(a => a.Barcode).ToList();
        }

        /// <summary>
        /// 获取新的条码
        /// </summary>
        /// <returns></returns>
        public string GetNewBarcode()
        {
            string MaxBarcode = dal.GetMaxBarcode();
            int NumMax = MaxBarcode == "" ? 1 :int.Parse(MaxBarcode.Substring(8, 4));
            string Barcode = string.Format("YS{0}{1}", DateTime.Now.ToString("yyMMdd"), (NumMax+1).ToString().PadLeft(4, '0'));
            return Barcode;
        }

    }
}
