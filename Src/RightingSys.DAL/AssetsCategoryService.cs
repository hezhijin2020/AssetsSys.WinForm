using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{

    /// <summary>
    /// 产资类别服务类
    /// </summary>
    public class AssetsCategoryService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_AssetsCategory model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_AssetsCategory]
           ([Id]
           ,[ParentId]
           ,[CategoryName]
           ,[SortCode]
           ,[SimpleCode]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES
           (@Id
           ,@ParentId
           ,@CategoryName
           ,@SortCode
           ,@SimpleCode
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@ParentId", model.ParentId);
            SqlParameter s3 = new SqlParameter("@CategoryName", model.CategoryName);
            SqlParameter s4 = new SqlParameter("@SortCode", model.SortCode);
            SqlParameter s6 = new SqlParameter("@SimpleCode", model.SimpleCode);
            SqlParameter s7 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s8 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s6, s7, s8 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_AssetsCategory model)
        {
            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_AssetsCategory]
           SET [ParentId] = @ParentId
              ,[CategoryName] = @CategoryName
              ,[SortCode] = @SortCode
              ,[SimpleCode] = @SimpleCode
              ,[CreateTime] = @CreateTime
              ,[IsRemoved] = @IsRemoved
         WHERE [Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@ParentId", model.ParentId);
            SqlParameter s3 = new SqlParameter("@CategoryName", model.CategoryName);
            SqlParameter s4 = new SqlParameter("@SortCode", model.SortCode);
            SqlParameter s6 = new SqlParameter("@SimpleCode", model.SimpleCode);
            SqlParameter s7 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s8 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s6, s7, s8 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;
        }
        public bool Delete(Guid Id)
        {
            string sqlText = @"UPDATE[dbo].[ys_AssetsCategory] SET [IsRemoved] = 1 WHERE[Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id", Id);
            SqlParameter[] cmdPara = new SqlParameter[] { s1 };

            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;

        }
        public bool ExistsAssetsById(Guid Id)
        {
            string sqlText = " select COUNT(Id) FROM [ys_Assets] where [CategoryId]=@Id";
            SqlParameter s1 = new SqlParameter("@Id", Id);
            return Models.SqlHelper.ExecuteNoQuery(sqlText, s1) > 0 ? true : false;
        }

        public IList<Models.ys_AssetsCategory> GetAllList()
        {
            string sqlText = @"SELECT [Id]
      ,[ParentId]
      ,[CategoryName]
      ,[SortCode]
      ,[SimpleCode]
      ,[CreateTime]
      ,[IsRemoved]
  FROM [AssetsSys].[dbo].[ys_AssetsCategory] Where IsRemoved=0";
            System.Data.DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText);
            return Models.SqlHelper.DataTableToList<Models.ys_AssetsCategory>(dt);
        }
    }
}
