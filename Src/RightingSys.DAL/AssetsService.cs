using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{
    /// <summary>
    /// 资产服务类
    /// </summary>
    public class AssetsService
    {  /// <summary>
       /// 新增
       /// </summary>
       /// <param name="model">实体</param>
       /// <returns></returns>
        public bool AddNew(Models.ys_Assets model)
        {
            Dictionary<SqlParameter[], string> sqlDic = new Dictionary<SqlParameter[], string>();
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_Assets]
           ([Id]
           ,[Barcode]
           ,[Name]
           ,[Model]
           ,[CompanyId]
           ,[CategoryId]
           ,[DepartmentId]
           ,[UserId]
           ,[Buyday]
           ,[Location]
           ,[StockId]
           ,[Price]
           ,[Description]
           ,[CreateTime]
           ,[XmlInf]
           ,[StatusId]
           ,[IsRemoved])
     VALUES
           (@Id
           ,@Barcode
           ,@Name
           ,@Model
           ,@CompanyId
           ,@CategoryId
           ,@DepartmentId
           ,@UserId
           ,@Buyday
           ,@Location
           ,@StockId
           ,@Price
           ,@Description
           ,@CreateTime
           ,@XmlInf
           ,@StatusId
           ,@IsRemoved)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@Barcode", model.Barcode);
            SqlParameter s3 = new SqlParameter("@Name", model.Name);
            SqlParameter s4 = new SqlParameter("@Model", model.Model);
            SqlParameter s5 = new SqlParameter("@CategoryId", model.CategoryId);
            SqlParameter s6 = new SqlParameter("@CompanyId", model.CompanyId);
            SqlParameter s7 = new SqlParameter("@DepartmentId", model.DepartmentId);
            SqlParameter s8 = new SqlParameter("@UserId", model.UserId);
            SqlParameter s9 = new SqlParameter("@Buyday", model.Buyday);
            SqlParameter s10 = new SqlParameter("@Location", model.Location);
            SqlParameter s16 = new SqlParameter("@StockId", model.StockId);
            SqlParameter s17 = new SqlParameter("@Price", model.Price);
            SqlParameter s11 = new SqlParameter("@Description", model.Description);
            SqlParameter s12= new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@XmlInf", model.XmlInf);
            SqlParameter s14 = new SqlParameter("@StatusId", model.StatusId);
            SqlParameter s15 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4,s5, s6, s7, s8,s9,s10,s11,s12,s13,s14,s15,s16,s17};

            KeyValuePair<SqlParameter[], string> item = StatusChangeSerivce.AddNew("登记", "LK"+DateTime.Now.ToString("yyyyMMdd"), model.Id,model.OperatorId.ToString(),model.OperatorName);
            sqlDic.Add(item.Key, item.Value);
            sqlDic.Add(cmdPara, sqlText);

            return Models.SqlHelper.ExecuteTransaction1(sqlDic,false) > 0 ? true : false;

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_Assets model)
        {
            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_Assets]
   SET [Barcode] = @Barcode
      ,[Name] = @Name
      ,[Model] = @Model
      ,[CompanyId] = @CompanyId
      ,[CategoryId] = @CategoryId
      ,[DepartmentId] = @DepartmentId
      ,[UserId] = @UserId
      ,[Buyday] = @Buyday
      ,[Location] = @Location
      ,[StockId] = @StockId
      ,[Price] = @Price
      ,[Description] = @Description
      ,[CreateTime] = @CreateTime
      ,[XmlInf] = @XmlInf
      ,[StatusId] = @StatusId
      ,[IsRemoved] = @IsRemoved
 WHERE [Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@Barcode", model.Barcode);
            SqlParameter s3 = new SqlParameter("@Name", model.Name);
            SqlParameter s4 = new SqlParameter("@Model", model.Model);
            SqlParameter s5 = new SqlParameter("@CategoryId", model.CategoryId);
            SqlParameter s6 = new SqlParameter("@CompanyId", model.CompanyId);
            SqlParameter s7 = new SqlParameter("@DepartmentId", model.DepartmentId);
            SqlParameter s8 = new SqlParameter("@UserId", model.UserId);
            SqlParameter s9 = new SqlParameter("@Buyday", model.Buyday);
            SqlParameter s10 = new SqlParameter("@Location", model.Location);
            SqlParameter s16 = new SqlParameter("@StockId", model.StockId);
            SqlParameter s17 = new SqlParameter("@Price", model.Price);
            SqlParameter s11 = new SqlParameter("@Description", model.Description);
            SqlParameter s12 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@XmlInf", model.XmlInf);
            SqlParameter s14 = new SqlParameter("@StatusId", model.StatusId);
            SqlParameter s15 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4,s5,s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;
        }
        public bool Delete(Guid Id)
        {
            string sqlText = @"UPDATE[dbo].[ys_Assets] SET [IsRemoved] = 1 WHERE[Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id", Id);
            SqlParameter[] cmdPara = new SqlParameter[] { s1 };

            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;

        }

        /// <summary>
        /// 获取最大的条码ID号
        /// </summary>
        /// <returns></returns>
        public string GetMaxBarcode()
        {
            string sqlText = @"select Max(Barcode) from ys_Assets";
            object objMax= Models.SqlHelper.ExecuteScalar(sqlText);
            if (objMax == null || objMax.ToString() == "")
            {
                return "";
            }
            else {
                return objMax.ToString();
            }
        }

        public IList<Models.ys_Assets> GetAllList()
        {
            string sqlText = @"SELECT * FROM vw_Assets where IsRemoved=0";
            System.Data.DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText);
            return Models.SqlHelper.DataTableToList<Models.ys_Assets>(dt);
        }
    }
}
