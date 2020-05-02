using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{

    /// <summary>
    /// 仓库服务类
    /// </summary>
    public class AssetsStockService
    {

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_AssetsStock model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_AssetsStock]
           ([Id]
           ,[StockName]
           ,[ManagerId]
           ,[ManagerName]
           ,[IsRemoved]
           ,[CreateTime])
     VALUES
          ( @Id
           ,@StockName
           ,@ManagerId
           ,@ManagerName
           ,@IsRemoved
           ,@CreateTime)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@StockName", model.StockName);
            SqlParameter s3 = new SqlParameter("@ManagerId", model.ManagerId);
            SqlParameter s4 = new SqlParameter("@ManagerName", model.ManagerName);
            SqlParameter s7 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s8 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4,s7, s8 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_AssetsStock model)
        {
            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_AssetsStock]
   SET [StockName] = @StockName
      ,[ManagerId] = @ManagerId
      ,[ManagerName] = @ManagerName
      ,[IsRemoved] = @IsRemoved
      ,[CreateTime] = @CreateTime
 WHERE [Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@StockName", model.StockName);
            SqlParameter s3 = new SqlParameter("@ManagerId", model.ManagerId);
            SqlParameter s4 = new SqlParameter("@ManagerName", model.ManagerName);
            SqlParameter s7 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s8 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s7, s8 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;
        }
        public bool Delete(Guid Id)
        {
            string sqlText = @"UPDATE[dbo].[ys_AssetsStock] SET [IsRemoved] = 1 WHERE[Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id", Id);
            SqlParameter[] cmdPara = new SqlParameter[] { s1 };

            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;

        }
        public bool ExistsAssetsById(Guid Id)
        {
            string sqlText = " select COUNT(Id) FROM [ys_Assets] where [StockId]=@Id";
            SqlParameter s1 = new SqlParameter("@Id", Id);
            return Models.SqlHelper.ExecuteNoQuery(sqlText, s1) > 0 ? true : false;
        }

        public IList<Models.ys_AssetsStock> GetAllList()
        {
            string sqlText = @"SELECT [Id]
      ,[StockName]
      ,[ManagerId]
      ,[ManagerName]
      ,[IsRemoved]
      ,[CreateTime]
  FROM [AssetsSys].[dbo].[ys_AssetsStock] Where IsRemoved=0";
            System.Data.DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText);
            return Models.SqlHelper.DataTableToList<Models.ys_AssetsStock>(dt);
        }
    }
}
