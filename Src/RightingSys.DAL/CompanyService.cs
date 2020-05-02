using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{
    /// <summary>
    /// 供应商管理
    /// </summary>
    public class CompanyService
    {

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_Company model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_Company]
           ([Id]
           ,[CompanyName]
           ,[Contact]
           ,[Tell]
           ,[Address]
           ,[Description]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES
           (@Id
           ,@CompanyName
           ,@Contact
           ,@Tell
           ,@Address
           ,@Description
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@CompanyName", model.CompanyName);
            SqlParameter s3 = new SqlParameter("@Contact", model.Contact);
            SqlParameter s4 = new SqlParameter("@Tell", model.Tell);
            SqlParameter s5 = new SqlParameter("@Address", model.Address);
            SqlParameter s6 = new SqlParameter("@Description", model.Description);
            SqlParameter s7 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s8 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4,s5,s6,s7, s8 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_Company model)
        {
            string sqlText = @"  UPDATE[AssetsSys].[dbo].[ys_Company]
           SET[CompanyName] = @CompanyName
              ,[Contact] = @Contact
              ,[Tell] = @Tell
              ,[Address] = @Address
              ,[Description] = @Description
              ,[CreateTime] = @CreateTime
              ,[IsRemoved] = @IsRemoved
        WHERE[Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@CompanyName", model.CompanyName);
            SqlParameter s3 = new SqlParameter("@Contact", model.Contact);
            SqlParameter s4 = new SqlParameter("@Tell", model.Tell);
            SqlParameter s5 = new SqlParameter("@Address", model.Address);
            SqlParameter s6 = new SqlParameter("@Description", model.Description);
            SqlParameter s7 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s8 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6, s7, s8 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;
        }
        public bool Delete(Guid Id)
        {
            string sqlText = @"UPDATE[dbo].[ys_Company] SET [IsRemoved] = 1 WHERE[Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id", Id);
            SqlParameter[] cmdPara = new SqlParameter[] { s1 };

            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;

        }
        public bool ExistsAssetsById(Guid Id)
        {
            string sqlText = " select COUNT(Id) FROM [ys_Assets] where [CompanyId]=@Id";
            SqlParameter s1 = new SqlParameter("@Id", Id);
            return Models.SqlHelper.ExecuteNoQuery(sqlText, s1) > 0 ? true : false;
        }

        public IList<Models.ys_Company> GetAllList()
        {
            string sqlText = @"SELECT [Id]
      ,[CompanyName]
      ,[Contact]
      ,[Tell]
      ,[Address]
      ,[Description]
      ,[CreateTime]
      ,[IsRemoved]
  FROM [AssetsSys].[dbo].[ys_Company] Where IsRemoved=0";
            System.Data.DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText);
            return Models.SqlHelper.DataTableToList<Models.ys_Company>(dt);
        }
    }
}
