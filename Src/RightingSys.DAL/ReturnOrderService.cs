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
    public class ReturnOrderService
    {
        #region  新增订单事务处理

        Dictionary<SqlParameter[], string> sqlDic = new Dictionary< SqlParameter[],string>();

        /// <summary>
        /// 新增领用信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_ReturnOrder model)
        {
            AddDicByOrder(model);
            foreach (Models.ys_ReturnOrderDetail d in model.Detail)
            {
                KeyValuePair<SqlParameter[], string> item = StatusChangeSerivce.AddNew("归还",model.ReturnNo, d.AssetsId, model.OperatorId.ToString(), model.OperatorName, model.ReturnUserId.ToString(), model.ReturnUserName);
                sqlDic.Add(item.Key, item.Value);

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
            Models.ys_BorrowOrderDetail mlast = GetLastOneByAssetsId(assetsId);

            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_Assets]
   SET [DepartmentId] = @DepartmentId
      ,[UserId] = @UserId
      ,[StatusId] = @StatusId
 WHERE [Id] = @Id";

            if (mlast != null)
            {
                SqlParameter s1 = new SqlParameter("@Id", assetsId);
                SqlParameter s2 = new SqlParameter("@DepartmentId", mlast.OldDepartmentId);
                SqlParameter s3 = new SqlParameter("@UserId", mlast.OldUserId);
                SqlParameter s5 = new SqlParameter("@StatusId", mlast.OldStatusId);
                SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s5 };

                sqlDic.Add(cmdPara, sqlText);
            }
            else
            {
                throw new Exception("没有找到资产ID为："+assetsId+" 借用记录");
            }
          
        }

        /// <summary>
        /// 订单明细信息
        /// </summary>
        /// <param name="model">明细实体</param>
        public void AddDicByOrderDetail(Models.ys_ReturnOrderDetail model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_ReturnOrderDetail]
           ([Id]
           ,[ReturnId]
           ,[AssetsId]
           ,[OldUserId]
           ,[OldUserName]
           ,[OldDepartmentId]
           ,[OldDepartmentName]
           ,[OldStatusName]
           ,[OldStatusId]
           ,[IsRemoved]
           ,[CreateTime])
     VALUES(@Id
           ,@ReturnId
           ,@AssetsId
           ,@OldUserId
           ,@OldUserName
           ,@OldDepartmentId
           ,@OldDepartmentName
           ,@OldStatusName
           ,@OldStatusId
           ,@IsRemoved
           ,@CreateTime)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@ReturnId", model.ReturnId);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@OldUserName", model.OldUserName);
            SqlParameter s5 = new SqlParameter("@OldUserId", model.OldUserId);
            SqlParameter s6 = new SqlParameter("@OldDepartmentName", model.OldDepartmentName);
            SqlParameter s7 = new SqlParameter("@OldDepartmentId", model.OldDepartmentId);
            SqlParameter s9 = new SqlParameter("@OldStatusId", model.OldStatusId);
            SqlParameter s12 = new SqlParameter("@OldStatusName", model.OldStatusName);
            SqlParameter s10 = new SqlParameter("@IsRemoved", model.IsRemoved);
            SqlParameter s11 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6,s7,s9,s12,s10,s11};
            sqlDic.Add(cmdPara, sqlText);
        }

        /// <summary>
        /// 订单信息
        /// </summary>
        /// <param name="model">明细实体</param>
        private void AddDicByOrder(Models.ys_ReturnOrder model)
        {
         string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_ReturnOrder]
           ([Id]
           ,[ReturnNo]
           ,[ReturnUserId]
           ,[ReturnDepartmentId]
           ,[OperatorId]
           ,[Returnday]
           ,[Description]
           ,[IsAudit]
           ,[IsRemoved]
           ,[CreateTime])
     VALUES(@Id
           ,@ReturnNo
           ,@ReturnUserId
           ,@ReturnDepartmentId
           ,@OperatorId
           ,@Returnday
           ,@Description
           ,@IsAudit
           ,@IsRemoved
           ,@CreateTime)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@ReturnNo", model.ReturnNo);
            SqlParameter s3 = new SqlParameter("@ReturnUserId", model.ReturnUserId);
            SqlParameter s4 = new SqlParameter("@ReturnDepartmentId", model.ReturnDepartmentId);
            SqlParameter s6 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s8 = new SqlParameter("@Returnday", model.Returnday);
            SqlParameter s10 = new SqlParameter("@Description", model.Description);
            SqlParameter s11 = new SqlParameter("@IsAudit", model.IsAudit);
            SqlParameter s12 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4,s6, s8, s10, s11,s12,s13};
            sqlDic.Add(cmdPara, sqlText);

        }

        #endregion

        /// <summary>
        /// 获取当前最大单号
        /// </summary>
        /// <returns></returns>
        public string GetMaxReturnNo()
        {
            string sqlText = " select max(ReturnNo) from ys_ReturnOrder ";
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
        /// 获取最近的借用记录
        /// </summary>
        /// <param name="assetsId">资产Id</param>
        /// <returns></returns>
        public Models.ys_BorrowOrderDetail GetLastOneByAssetsId(Guid assetsId)
        {
            string sqlText = @"select * from ys_BorrowOrderDetail where AssetsId=@AssetsId and BorrowId=(select Id 
from ys_BorrowOrder
where BorrowNo = ( select MAX(BorrowNo)
from[dbo].vw_BorrowOrder
 where assetsId =@AssetsId))";
            System.Data.DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText,new SqlParameter("@AssetsId",assetsId));
           return Models.SqlHelper.DataTableToList<Models.ys_BorrowOrderDetail>(dt).FirstOrDefault();
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable()
        {
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_ReturnOrder] where IsRemoved=0 order by ReturnNo";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetTableOneById(Guid Id)
        {
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_ReturnOrder] where IsRemoved=0 and Id='" + Id+"'";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }
    }
}
