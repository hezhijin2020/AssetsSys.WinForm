using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{
    /// <summary>
    /// 领用服务类
    /// </summary>
    public class RefundOrderService
    {
        #region  新增订单事务处理

        Dictionary< SqlParameter[], string> sqlDic = new Dictionary< SqlParameter[],string>();

        /// <summary>
        /// 新增领用信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_RefundOrder model)
        {
            AddDicByOrder(model);
            foreach (Models.ys_RefundOrderDetail d in model.Detail)
            {
                AddDicByOrderDetail(d);
                AddDicByUpdateAssets(d.AssetsId);
            }
           return  Models.SqlHelper.ExecuteTransaction1(sqlDic,false) > 0 ? true :false ;
        }

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="assetsId">资产Id</param>
        public void AddDicByUpdateAssets(Guid assetsId)
        {
            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_Assets]
   SET [DepartmentId] = @DepartmentId
      ,[UserId] = @UserId
      ,[Location] = @Location
      ,[StatusId] = 'XZ'
 WHERE [Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id",assetsId);
            SqlParameter s2 = new SqlParameter("@DepartmentId",Guid.Empty);
            SqlParameter s3 = new SqlParameter("@UserId",Guid.Empty);
            SqlParameter s4 = new SqlParameter("@Location","");

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4};
            sqlDic.Add(cmdPara, sqlText);
        }

        /// <summary>
        /// 订单明细信息
        /// </summary>
        /// <param name="model">明细实体</param>
        public void AddDicByOrderDetail(Models.ys_RefundOrderDetail model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_RefundOrderDetail]
           ([Id]
           ,[AssetsId]
           ,[RefundId]
           ,[OldUserName]
           ,[OldUserId]
           ,[OldDepartmentName]
           ,[OldDepartmentId]
           ,[OldLocation]
           ,[OldStatusId]
           ,[IsRemoved]
           ,[CreateTime])
     VALUES
           (@Id
           ,@AssetsId
           ,@RefundId
           ,@OldUserName
           ,@OldUserId
           ,@OldDepartmentName
           ,@OldDepartmentId
           ,@OldLocation
           ,@OldStatusId
           ,@IsRemoved
           ,@CreateTime)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s3 = new SqlParameter("@RefundId", model.RefundId);
            SqlParameter s4 = new SqlParameter("@OldUserName", model.OldUserName);
            SqlParameter s5 = new SqlParameter("@OldUserId", model.OldUserId);
            SqlParameter s6 = new SqlParameter("@OldDepartmentName", model.OldDepartmentName);
            SqlParameter s7 = new SqlParameter("@OldDepartmentId", model.OldDepartmentId);
            SqlParameter s8 = new SqlParameter("@OldLocation", model.OldLocation);
            SqlParameter s9 = new SqlParameter("@OldStatusId", model.OldStatusId);
            SqlParameter s10 = new SqlParameter("@IsRemoved", model.IsRemoved);
            SqlParameter s11 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6,s7,s8,s9,s10,s11};
            sqlDic.Add(cmdPara, sqlText);
        }

        /// <summary>
        /// 订单信息
        /// </summary>
        /// <param name="model">明细实体</param>
        private void AddDicByOrder(Models.ys_RefundOrder model)
        {
         string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_RefundOrder]
           ([Id]
           ,[RefundNo]
           ,[Refundday]
           ,[RefundUserId]
           ,[OperatorId]
           ,[Description]
           ,[IsAudit]
           ,[IsRemoved]
           ,[CreateTime])
     VALUES
           (@Id
           ,@RefundNo
           ,@Refundday
           ,@RefundUserId
           ,@OperatorId
           ,@Description
           ,@IsAudit
           ,@IsRemoved
           ,@CreateTime)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@RefundNo", model.RefundNo);
            SqlParameter s3 = new SqlParameter("@Refundday", model.Refundday);
            SqlParameter s4 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s6 = new SqlParameter("@RefundUserId", model.RefundUserId);
            SqlParameter s8 = new SqlParameter("@Description", model.Description);
            SqlParameter s9 = new SqlParameter("@IsAudit", model.IsAudit);
            SqlParameter s10 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s11 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4,s6, s8, s9, s10, s11};
            sqlDic.Add(cmdPara, sqlText);

        }

        #endregion

        /// <summary>
        /// 获取当前最大单号
        /// </summary>
        /// <returns></returns>
        public string GetMaxRefundNo()
        {
            string sqlText = " select max(RefundNo) from ys_RefundOrder ";
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
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_RefundOrder] where IsRemoved=0 order by RefundNo";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetTableOneById(Guid Id)
        {
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_RefundOrder] where IsRemoved=0 and Id='" + Id+"'";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }
    }
}
