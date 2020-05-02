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
    public class ApplyOrderService
    {
        #region  新增订单事务处理

        Dictionary< SqlParameter[],string> sqlDic = new Dictionary<SqlParameter[],string>();

        /// <summary>
        /// 新增领用信息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddNew(Models.ys_ApplyOrder model)
        {
            AddDicByOrder(model);
            foreach (Models.ys_ApplyOrderDetail d in model.Detail)
            {
                AddDicByOrderDetail(d);
                AddDicByUpdateAssets(d.AssetsId,model.ApplyDepartmentId,model.ApplyUserId,model.Location);
            }
           return  Models.SqlHelper.ExecuteTransaction1(sqlDic,false) > 0 ? true :false ;
        }

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="assetsId">资产Id</param>
        /// <param name="departmentId">部门Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="Location">使用地点</param>
        public void AddDicByUpdateAssets(Guid assetsId,Guid departmentId,Guid userId,string Location)
        {
            string sqlText = @"update ys_Assets 
               set  StatusId='ZY'
                   ,DepartmentId=@DepartmentId
                   ,UserId=@UserId
                   ,Location=@Location 
                   where StatusId='XZ' and Id=@Id and IsRemoved=0";

            SqlParameter s1 = new SqlParameter("@Id",assetsId);
            SqlParameter s2 = new SqlParameter("@DepartmentId",departmentId);
            SqlParameter s3 = new SqlParameter("@UserId",userId);
            SqlParameter s4 = new SqlParameter("@Location",Location);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4};
            sqlDic.Add(cmdPara,sqlText);
        }

        /// <summary>
        /// 订单明细信息
        /// </summary>
        /// <param name="model">明细实体</param>
        public void AddDicByOrderDetail(Models.ys_ApplyOrderDetail model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_ApplyOrderDetail]
           ([Id]
           ,[ApplyId]
           ,[AssetsId]
           ,[OldStatusId])
     VALUES
           (@Id
           ,@ApplyId
           ,@AssetsId
           ,@OldStatusId)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@ApplyId", model.ApplyId);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@OldStatusId", model.OldStatusId);
            SqlParameter s5 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s6 = new SqlParameter("@IsRemoved", model.IsRemoved);
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6};
            sqlDic.Add(cmdPara, sqlText);
        }

        /// <summary>
        /// 订单信息
        /// </summary>
        /// <param name="model">明细实体</param>
        private void AddDicByOrder(Models.ys_ApplyOrder model)
        {
         string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_ApplyOrder]
           ([Id]
           ,[ApplyNo]
           ,[ApplyUserId]
           ,[OperatorId]
           ,[ApplyDepartmentId]
           ,[Location]
           ,[Applyday]
           ,[Description]
           ,[IsAudit]
           ,[IsRemoved]
           ,[CreateTime])
     VALUES
           (@Id
           ,@ApplyNo
           ,@ApplyUserId
           ,@OperatorId
           ,@ApplyDepartmentId
           ,@Location
           ,@Applyday
           ,@Description
           ,@IsAudit
           ,@IsRemoved
           ,@CreateTime)";

            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@ApplyNo", model.ApplyNo);
            SqlParameter s3 = new SqlParameter("@ApplyUserId", model.ApplyUserId);
            SqlParameter s4 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s5 = new SqlParameter("@ApplyDepartmentId", model.ApplyDepartmentId);
            SqlParameter s6 = new SqlParameter("@Location", model.Location);
            SqlParameter s7 = new SqlParameter("@Applyday", model.Applyday);
            SqlParameter s8 = new SqlParameter("@Description", model.Description);
            SqlParameter s9 = new SqlParameter("@IsAudit", model.IsAudit);
            SqlParameter s10 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s11 = new SqlParameter("@IsRemoved", model.IsRemoved);

            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11};
            sqlDic.Add(cmdPara, sqlText);

        }

        #endregion

        /// <summary>
        /// 获取当前最大单号
        /// </summary>
        /// <returns></returns>
        public string GetMaxApplyNo()
        {
            string sqlText = " select max(ApplyNo) from ys_ApplyOrder ";
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
        public IList<Models.ys_ApplyOrder> GetAllList()
        {
            string sqlText = @"select a.Id,a.ApplyNo,a.Applyday,a.Location,a.ApplyDepartmentId,a.ApplyUserId,a.OperatorId,a.Description,a.IsAudit
             from ys_ApplyOrder as a  left join ys_ApplyOrderDetail as b on a.Id=b.ApplyId where a.IsRemoved=0";

            System.Data.DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText);
            return  Models.SqlHelper.DataTableToList<Models.ys_ApplyOrder>(dt);
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable()
        {
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_ApplyOrder] where IsRemoved=0 order by ApplyNo";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }

        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetTableOneById(Guid Id)
        {
            string sqlText = @"SELECT * FROM [AssetsSys].[dbo].[vw_ApplyOrder] where IsRemoved=0 and Id='"+Id+"'";
            return Models.SqlHelper.ExecuteDataTable(sqlText);
        }
    }
}
