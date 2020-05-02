
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
    public class BorrowOrderService
    {
        #region  新增订单事务处理

        Dictionary<SqlParameter[],string> sqlDic = new Dictionary< SqlParameter[],string>();

        /// <summary>
        /// 新增领用信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_BorrowOrder model)
        {
            AddDicByOrder(model);
            foreach (Models.ys_BorrowOrderDetail d in model.Detail)
            {
                AddDicByOrderDetail(d);
                AddDicByUpdateAssets(d.AssetsId,model.BorrowDepartmentId,model.BorrowUserId,"JY");
            }
           return  Models.SqlHelper.ExecuteTransaction1(sqlDic,false) > 0 ? true :false ;
        }

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="assetsId">资产Id</param>
        public void AddDicByUpdateAssets(Guid assetsId,Guid departmentId,Guid userId,string statusId)
        {
            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_Assets]
   SET [DepartmentId] = @DepartmentId
      ,[UserId] = @UserId
      ,[StatusId] = @StatusId
 WHERE [Id] = @Id";

            SqlParameter s1 = new SqlParameter("@Id",assetsId);
            SqlParameter s2 = new SqlParameter("@DepartmentId",departmentId);
            SqlParameter s3 = new SqlParameter("@UserId", userId);
            SqlParameter s5 = new SqlParameter("@StatusId", statusId);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s5};
            sqlDic.Add(cmdPara,sqlText);
        }

        /// <summary>
        /// 订单明细信息
        /// </summary>
        /// <param name="model">明细实体</param>
        public void AddDicByOrderDetail(Models.ys_BorrowOrderDetail model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_BorrowOrderDetail]
           ([Id]
           ,[BorrowId]
           ,[AssetsId]
           ,[OldUserName]
           ,[OldUserId]
           ,[OldDepartmentName]
           ,[OldDepartmentId]
           ,[OldLocation]
           ,[OldStatusId]
           ,[OldStatusName]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES
           (@Id
           ,@BorrowId
           ,@AssetsId
           ,@OldUserName
           ,@OldUserId
           ,@OldDepartmentName
           ,@OldDepartmentId
           ,@OldLocation
           ,@OldStatusId
           ,@OldStatusName
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@BorrowId", model.BorrowId);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@OldUserName", model.OldUserName);
            SqlParameter s5 = new SqlParameter("@OldUserId", model.OldUserId);
            SqlParameter s6 = new SqlParameter("@OldDepartmentName", model.OldDepartmentName);
            SqlParameter s7 = new SqlParameter("@OldDepartmentId", model.OldDepartmentId);
            SqlParameter s8 = new SqlParameter("@OldLocation", model.OldLocation);
            SqlParameter s9 = new SqlParameter("@OldStatusId", model.OldStatusId);
            SqlParameter s12 = new SqlParameter("@OldStatusName", model.OldStatusName);
            SqlParameter s10 = new SqlParameter("@IsRemoved", model.IsRemoved);
            SqlParameter s11 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6,s7,s8,s9,s12,s10,s11};
            sqlDic.Add(cmdPara, sqlText);
        }

        /// <summary>
        /// 订单信息
        /// </summary>
        /// <param name="model">明细实体</param>
        private void AddDicByOrder(Models.ys_BorrowOrder model)
        {
         string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_BorrowOrder]
           ([Id]
           ,[BorrowNo]
           ,[BorrowUserId]
           ,[BorrowDepartmentId]
           ,[OperatorId]
           ,[Borrowday]
           ,[Planday]
           ,[Description]
           ,[IsAudit]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES
           (@Id
           ,@BorrowNo
           ,@BorrowUserId
           ,@BorrowDepartmentId
           ,@OperatorId
           ,@Borrowday
           ,@Planday
           ,@Description
           ,@IsAudit
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@BorrowNo", model.BorrowNo);
            SqlParameter s3 = new SqlParameter("@BorrowUserId", model.BorrowUserId);
            SqlParameter s4 = new SqlParameter("@BorrowDepartmentId", model.BorrowDepartmentId);
            SqlParameter s6 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s8 = new SqlParameter("@Borrowday", model.Borrowday);
            SqlParameter s9 = new SqlParameter("@Planday", model.Planday);
            SqlParameter s10 = new SqlParameter("@Description", model.Description);
            SqlParameter s11 = new SqlParameter("@IsAudit", model.IsAudit);
            SqlParameter s12 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4,s6, s8, s9, s10, s11,s12,s13};
            sqlDic.Add(cmdPara, sqlText);

        }

        #endregion

        /// <summary>
        /// 获取当前最大单号
        /// </summary>
        /// <returns></returns>
        public string GetMaxBorrowNo()
        {
            string sqlText = " select max(BorrowNo) from ys_BorrowOrder ";
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
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_BorrowOrder] where IsRemoved=0 order by BorrowNo";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetTableOneById(Guid Id)
        {
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_BorrowOrder] where IsRemoved=0 and Id='" + Id+"'";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }
    }
}
