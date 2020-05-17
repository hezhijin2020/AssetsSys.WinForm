using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{
    /// <summary>
    /// 盘点服务类
    /// </summary>
    public class CheckOrderService
    {
        /// <summary>
        /// 新增盘点单 
        /// </summary>
        /// <param name="model">盘点单实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_CheckOrder model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_CheckOrder]
           ([Id]
           ,[CheckNo]
           ,[Checkday]
           ,[Description]
           ,[OperatorId]
           ,[OperatorName]
           ,[IsAudit]
           ,[IsRemoved]
           ,[CreateTime])
     VALUES
           (@Id
           ,@CheckNo
           ,@Checkday
           ,@Description
           ,@OperatorId
           ,@OperatorName
           ,@IsAudit
           ,@IsRemoved
           ,@CreateTime)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@CheckNo", model.CheckNo);
            SqlParameter s3 = new SqlParameter("@Description", model.Description);
            SqlParameter s4 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s6 = new SqlParameter("@OperatorName", model.OperatorName);
            SqlParameter s8 = new SqlParameter("@IsAudit", model.IsAudit);
            SqlParameter s9 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s10 = new SqlParameter("@IsRemoved", model.IsRemoved);
            SqlParameter s11 = new SqlParameter("@Checkday", model.Checkday);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s6, s8,s9,s10,s11 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;
        }

        /// <summary>
        /// 订单修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Modify(Models.ys_CheckOrder model)
        {
            SqlParameter[] Param = new SqlParameter[] {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Description",model.Description),
                new SqlParameter("@OperatorId",model.OperatorId),
                new SqlParameter("@OperatorName",model.OperatorName),
                new SqlParameter("@IsRemoved",model.IsRemoved),
                new SqlParameter("@Checkday",model.Checkday)
                    };


            return Models.SqlHelper.ExecuteNoQuery(@"UPDATE [AssetsSys].[dbo].[ys_CheckOrder]
   SET [Description] = @Description
      ,[OperatorId] = @OperatorId
      ,[OperatorName] = @OperatorName
      ,[IsRemoved] = @IsRemoved
      ,[Checkday] = @Checkday
 WHERE [Id] = @Id", Param) > 0 ? true : false;
        }

        /// <summary>
        /// 新增盘点机明细
        /// </summary>
        /// <param name="model">资产明细</param>
        /// <returns></returns>
        public bool AddNewDetail(Models.ys_CheckOrderDeail model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_CheckOrderDetail]
           ([Id]
           ,[CheckId]
           ,[AssetsId]
           ,[OldStatusId]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES
           (@Id
           ,@CheckId
           ,@AssetsId
           ,@OldStatusId
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@CheckId", model.CheckId);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@OldStatusId", model.OldStatusId);
            SqlParameter s5 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s6 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;
        }

        /// <summary>
        /// 删除盘点单明细
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool DeleteDetail(Models.ys_CheckOrderDeail model)
        {
            string sqlText = @"DELETE FROM [AssetsSys].[dbo].[ys_CheckOrderDetail] WHERE [CheckId]=@CheckId and [AssetsId]=@AssetsId ";

            SqlParameter s1 = new SqlParameter("@CheckId", model.CheckId);
            SqlParameter s2 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2 };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdPara) > 0 ? true : false;
        }
        
        /// <summary>
        /// 获取所有的盘点单
        /// </summary>
        /// <returns></returns>
        public IList<Models.ys_CheckOrder> GetAllList()
        {
            string sqtText = @"SELECT [Id]
      ,[CheckNo]
      ,[Description]
      ,[OperatorId]
      ,[OperatorName]
      ,[IsAuditday]
      ,[IsAudit]
      ,[IsRemoved]
      ,[CreateTime]
      ,[Checkday]
  FROM [AssetsSys].[dbo].[ys_CheckOrder]";

           System.Data.DataTable dt= Models.SqlHelper.ExecuteDataTable(sqtText);
            return Models.SqlHelper.DataTableToList<Models.ys_CheckOrder>(dt);

        }

        /// <summary>
        /// 获取盘点单明细
        /// </summary>
        /// <param name="checkId">盘点单ID</param>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable(Guid checkId)
        {
            string sqlText = string.Format(@"SELECT CAST((case when b.CheckId is  null then 0 else 1 end) as bit )IsSelect
      ,a.[Id]
      ,a.[Barcode]
      ,a.[Name]
      ,a.[Model]
      ,a.[CompanyId]
      ,a.[CompanyName]
      ,a.[CategoryId]
      ,a.[CategoryName] 
      ,a.[DepartmentId]
      ,a.[DepartmentName]
      ,a.[UserId]
      ,a.[UserName]
      ,a.[Buyday]
      ,a.[Location]
      ,a.[StockId]
      ,a.[StockName]
      ,a.[Price]
      ,a.[Description]
      ,a.[StatusId]
      ,a.[StatusName]
      , '{0}' CheckId
      ,b.CreateTime
      ,b.OldStatusId
from vw_Assets as a left join ys_CheckOrderDetail as b on a.Id=b.AssetsId",checkId);


            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }

        /// <summary>
        /// 获取当前最大单号
        /// </summary>
        /// <returns></returns>
        public string GetMaxCheckNo()
        {
            string sqlText = " select max(CheckNo) from ys_CheckOrder ";
            object obj = Models.SqlHelper.ExecuteScalar(sqlText);
            if (obj != null && obj.ToString() != "")
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 盘点单明细更改保存
        /// </summary>
        /// <param name="dt">盘点明细</param>
        /// <returns></returns>

        public bool SaveDetail(DataTable dt)
        {
            Dictionary<string, SqlParameter[]> array = new Dictionary<string, SqlParameter[]>();
            array.Add("if   object_id('tempdb..#pdaCheck') is not null drop table #pdaCheck", null);
            array.Add(" create table #pdaCheck (AssetsId uniqueidentifier, CheckId uniqueidentifier,OldStatusId nchar(2), CreateTime datetime)", null);
            foreach (System.Data.DataRow r in dt.Rows)
            {
                array.Add(string.Format("insert into #pdaCheck values('{0}','{1}','{2}','{3}')", r["Id"], r["CheckId"], r["StatusId"],r["CreateTime"]), null);
            }
            array.Add(string.Format(@"MERGE into ys_CheckOrderDetail  as target   using #pdaCheck as source on (target.AssetsId=source.AssetsId and target.CheckId=source.CheckId )
                         when not matched by target and source.CheckId='{0}'  then    insert (CheckId,AssetsId,OldStatusId,CreateTime)    values(source.CheckId,source.AssetsId,source.OldStatusId,source.CreateTime)  
                         when not matched by source and target.CheckId='{0}' then    delete    output $action ,inserted.CheckId ,deleted.CheckId,inserted.AssetsId ,deleted.AssetsId;", dt.Rows[0]["CheckId"]), null);

            return Models.SqlHelper.ExecuteTransaction(array) > 0 ? true : false;
        }
    }
}
