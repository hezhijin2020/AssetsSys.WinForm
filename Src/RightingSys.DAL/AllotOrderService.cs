
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{
    /// <summary>
    /// 调拔服务类
    /// </summary>
    public class AllotOrderService
    {
        #region  新增订单事务处理

        Dictionary<SqlParameter[],string> sqlDic = new Dictionary<SqlParameter[],string>();

        /// <summary>
        /// 新增调拔信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_AllotOrder model)
        {
            AddDicByOrder(model);
            foreach (Models.ys_AllotOrderDetail d in model.Detail)
            {
                KeyValuePair<SqlParameter[], string> item = StatusChangeSerivce.AddNew("调拨", model.AllotNo, d.AssetsId, model.OperatorId.ToString(), model.OperatorName, model.AllotUserId.ToString(), model.AllotUserName);
                sqlDic.Add(item.Key,item.Value);

                AddDicByOrderDetail(d);
                AddDicByUpdateAssets(d.AssetsId,model.AllotDepartmentId,model.AllotUserId,model.Location);
            }
           return  Models.SqlHelper.ExecuteTransaction1(sqlDic,false) > 0 ? true :false ;
        }

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="assetsId">资产Id</param>
        public void AddDicByUpdateAssets(Guid assetsId,Guid departmentId,Guid userId,string Location)
        {
            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_Assets]
   SET [DepartmentId] = @DepartmentId
      ,[UserId] = @UserId
      ,[Location]=@Location
 WHERE [Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id",assetsId);
            SqlParameter s2 = new SqlParameter("@DepartmentId",departmentId);
            SqlParameter s3 = new SqlParameter("@UserId", userId);
            SqlParameter s4 = new SqlParameter("@Location", Location);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3,s4};
            sqlDic.Add(cmdPara,sqlText);
        }

        /// <summary>
        /// 订单明细信息
        /// </summary>
        /// <param name="model">明细实体</param>
        public void AddDicByOrderDetail(Models.ys_AllotOrderDetail model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_AllotOrderDetail]
           ([Id]
           ,[AllotId]
           ,[AssetsId]
           ,[OldUserName]
           ,[OldUserId]
           ,[OldDepartmentName]
           ,[OldDepartmentId]
           ,[OldLocation]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES
           (@Id
           ,@AllotId
           ,@AssetsId
           ,@OldUserName
           ,@OldUserId
           ,@OldDepartmentName
           ,@OldDepartmentId
           ,@OldLocation
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@AllotId", model.AllotId);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@OldUserName", model.OldUserName==null?"":model.OldUserName);
            SqlParameter s5 = new SqlParameter("@OldUserId", model.OldUserId);
            SqlParameter s6 = new SqlParameter("@OldDepartmentName", model.OldDepartmentName);
            SqlParameter s7 = new SqlParameter("@OldDepartmentId", model.OldDepartmentId);
            SqlParameter s8 = new SqlParameter("@OldLocation", model.OldLocation);
            SqlParameter s9 = new SqlParameter("@IsRemoved", model.IsRemoved);
            SqlParameter s10 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6,s7,s8,s9,s10};
            sqlDic.Add(cmdPara, sqlText);
        }

        /// <summary>
        /// 订单信息
        /// </summary>
        /// <param name="model">明细实体</param>
        private void AddDicByOrder(Models.ys_AllotOrder model)
        {
         string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_AllotOrder]
           ([Id]
           ,[AllotNo]
           ,[AllotUserId]
           ,[AllotDepartmentId]
           ,[OperatorId]
           ,[Allotday]
           ,[Location]
           ,[Description]
           ,[IsAudit]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES
           (@Id
           ,@AllotNo
           ,@AllotUserId
           ,@AllotDepartmentId
           ,@OperatorId
           ,@Allotday
           ,@Location
           ,@Description
           ,@IsAudit
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@AllotNo", model.AllotNo);
            SqlParameter s3 = new SqlParameter("@AllotUserId", model.AllotUserId);
            SqlParameter s4 = new SqlParameter("@AllotDepartmentId", model.AllotDepartmentId);
            SqlParameter s6 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s8 = new SqlParameter("@Allotday", model.Allotday);
            SqlParameter s9 = new SqlParameter("@Location", model.Location);
            SqlParameter s10 = new SqlParameter("@Description", model.Description);
            SqlParameter s11 = new SqlParameter("@IsAudit", model.IsAudit);
            SqlParameter s12 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4,s6, s8,s9, s10, s11,s12,s13};
            sqlDic.Add(cmdPara, sqlText);

        }

        #endregion

        /// <summary>
        /// 获取当前最大单号
        /// </summary>
        /// <returns></returns>
        public string GetMaxAllotNo()
        {
            string sqlText = " select max(AllotNo) from ys_AllotOrder ";
            object obj= Models.SqlHelper.ExecuteScalar(sqlText);
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
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable()
        {
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_AllotOrder] where IsRemoved=0 order by AllotNo";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetTableOneById(Guid Id)
        {
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_AllotOrder] where IsRemoved=0 and Id='" + Id+"'";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }
    }
}
