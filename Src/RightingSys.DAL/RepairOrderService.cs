using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{
    /// <summary>
    /// 维修服务类
    /// </summary>
    public class RepairOrderService
    {

        Dictionary<SqlParameter[], string> dicCmd = new Dictionary<SqlParameter[], string>();

        #region 新增事务
        /// <summary>
        /// 新增维修记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddNew(IList<Models.ys_RepairOrder> listModel)
        {
            foreach (Models.ys_RepairOrder r in listModel)
            {
                AddDicByRepairOrder(r);
                AddDicByUpdateAssets(r);
            }
            return Models.SqlHelper.ExecuteTransaction1(dicCmd) > 0 ? true : false;
        }

        /// <summary>
        /// 新增维修记录
        /// </summary>
        /// <param name="model"></param>
        public void AddDicByRepairOrder(Models.ys_RepairOrder model)
        {
            #region sqltext
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_RepairOrder]
               ([Id]
               ,[RepairNo]
               ,[AssetsId]
               ,[CompanyId]
               ,[CompanyName]
               ,[RepairUserId]
               ,[RepairUserName]
               ,[Repairday]
               ,[OperatorId]
               ,[OperatorName]
               ,[RepairPrice]
               ,[RepairReason]
               ,[IsRemoved]
               ,[CreateTime]
               ,[OldStatusId])
         VALUES(@Id
               ,@RepairNo
               ,@AssetsId
               ,@CompanyId
               ,@CompanyName
               ,@RepairUserId
               ,@RepairUserName
               ,@Repairday
               ,@OperatorId
               ,@OperatorName
               ,@RepairPrice
               ,@RepairReason
               ,@IsRemoved
               ,@CreateTime
               ,@OldStatusId)";
            #endregion

            #region  sqlParam
            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@RepairNo", model.RepairNo);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@CompanyId", model.CompanyId);
            SqlParameter s5 = new SqlParameter("@CompanyName", model.CompanyName);
            SqlParameter s6 = new SqlParameter("@RepairUserId", model.RepairUserId);
            SqlParameter s7 = new SqlParameter("@RepairUserName", model.RepairUserName);
            SqlParameter s8 = new SqlParameter("@Repairday", model.Repairday);
            SqlParameter s9 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s10 = new SqlParameter("@OperatorName", model.OperatorName);
            SqlParameter s11 = new SqlParameter("@RepairPrice", model.RepairPrice);
            SqlParameter s12 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@IsRemoved", model.IsRemoved);
            SqlParameter s14 = new SqlParameter("@RepairReason", model.RepairReason);
            SqlParameter s15 = new SqlParameter("@OldStatusId", model.OldStatusId);
            #endregion
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14,s15 };
            dicCmd.Add(cmdPara, sqlText);
        }
        
        /// <summary>
        /// 更新资产状态
        /// </summary>
        /// <param name="model"></param>
        public void AddDicByUpdateAssets(Models.ys_RepairOrder model)
        {
            if (model.IsFinish)
            {
                string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_Assets]
                    SET [StatusId] = @StatusId
                        WHERE [Id] = @Id";
                SqlParameter s1 = new SqlParameter("@Id", model.AssetsId);
                SqlParameter s2 = new SqlParameter("@StatusId", model.OldStatusId);
                SqlParameter[] cmdPara = new SqlParameter[] { s1, s2 };
                dicCmd.Add(cmdPara, sqlText);
            }
            else
            {
                string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_Assets]
                    SET [StatusId] = @StatusId
                        WHERE [Id] = @Id";
                SqlParameter s1 = new SqlParameter("@Id", model.AssetsId);
                SqlParameter s2 = new SqlParameter("@StatusId", "WX");
                SqlParameter[] cmdPara = new SqlParameter[] { s1, s2 };
                dicCmd.Add(cmdPara, sqlText);
            }
           
        }
        #endregion

        #region 完成事务
        /// <summary>
        /// 修改维修记录
        /// </summary>
        /// <param name="listModel"></param>
        /// <returns></returns>
        public bool Modify(IList<Models.ys_RepairOrder> listModel)
        {
            foreach (Models.ys_RepairOrder r in listModel)
            {
                AddDicByUpdateAssets(r);
                AddDicModifyByRepairOrder(r);
            }
            return Models.SqlHelper.ExecuteTransaction1(dicCmd,false) > 0 ? true : false;
        }


        /// <summary>
        /// 修改指定的维修记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public void AddDicModifyByRepairOrder(Models.ys_RepairOrder model)
        {
            #region sqltext

            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_RepairOrder]
                   SET [RepairNo] = @RepairNo
                      ,[AssetsId] = @AssetsId
                      ,[CompanyId] = @CompanyId
                      ,[CompanyName] = @CompanyName
                      ,[RepairUserId] = @RepairUserId
                      ,[RepairUserName] = @RepairUserName
                      ,[Repairday] = @Repairday
                      ,[OperatorId] = @OperatorId
                      ,[OperatorName] = @OperatorName
                      ,[RepairPrice] = @RepairPrice
                      ,[RepairReason] = @RepairReason
                      ,[RepairDescription] = @RepairDescription
                      ,[FinishUserId] = @FinishUserId
                      ,[FinishUserName] = @FinishUserName
                      ,[Finishday] = @Finishday
                      ,[IsFinish] = @IsFinish
                      ,[IsRemoved] = @IsRemoved
                      ,[CreateTime] = @CreateTime
                 WHERE [Id] = @Id";
            #endregion

            #region  sqlParam
            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@RepairNo", model.RepairNo);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@CompanyId", model.CompanyId);
            SqlParameter s5 = new SqlParameter("@CompanyName", model.CompanyName);
            SqlParameter s6 = new SqlParameter("@RepairUserId", model.RepairUserId);
            SqlParameter s7 = new SqlParameter("@RepairUserName", model.RepairUserName);
            SqlParameter s8 = new SqlParameter("@Repairday", model.Repairday);
            SqlParameter s9 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s10 = new SqlParameter("@OperatorName", model.OperatorName);
            SqlParameter s11 = new SqlParameter("@RepairPrice", model.RepairPrice);
            SqlParameter s12 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@IsRemoved", model.IsRemoved);
            SqlParameter s14 = new SqlParameter("@Finishday", model.Finishday);
            SqlParameter s15 = new SqlParameter("@FinishUserId", model.FinishUserId);
            SqlParameter s16 = new SqlParameter("@FinishUserName", model.FinishUserName);
            SqlParameter s17 = new SqlParameter("@IsFinish", model.IsFinish);
            SqlParameter s19 = new SqlParameter("@RepairDescription", model.RepairDescription);
            SqlParameter s20 = new SqlParameter("@RepairReason", model.RepairReason);
            #endregion
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17,s19,s20 };
            dicCmd.Add(cmdPara, sqlText);
        }

        #endregion
        /// <summary>
        /// 获取最大的订单号
        /// </summary>
        /// <returns></returns>
        public string GetMaxRepairNo()
        {
            string sqlText = @"select Max(RepairNo) from ys_RepairOrder";
            object objMax = Models.SqlHelper.ExecuteScalar(sqlText);
            if (objMax == null || objMax.ToString() == "")
            {
                return "";
            }
            else
            {
                return objMax.ToString();
            }
        }

        /// <summary>
        /// 获取指定ID维修记录信息
        /// </summary>
        /// <param name="Id">维修Id</param>
        /// <returns></returns>
        public Models.ys_RepairOrder GetOneById(Guid Id)
        {
            string sqlText = "select *from ys_RepairOrder where Id=@Id";
            DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText, new System.Data.SqlClient.SqlParameter("@Id", Id));
            return Models.SqlHelper.DataTableToList<Models.ys_RepairOrder>(dt)[0];
        }

        /// <summary>
        /// 根据订单号获取维修信息
        /// </summary>
        /// <param name="RepairNo">订单号</param>
        /// <returns></returns>
        public IList<Models.ys_RepairOrder> GetOneByRepairNo(string RepairNo)
        {
            string sqlText = "select *from ys_RepairOrder where RepairNo=@RepairNo";
            DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText, new System.Data.SqlClient.SqlParameter("@RepairNo", RepairNo));
            return Models.SqlHelper.DataTableToList<Models.ys_RepairOrder>(dt);
        }

        /// <summary>
        /// 根据订单号获取维修信息
        /// </summary>
        /// <param name="RepairNo">订单号</param>
        /// <returns></returns>
        public DataTable GetTableOneByRepairNo(string RepairNo)
        {
           string sqlText = "select *from vw_RepairOrder where RepairNo=@RepairNo";
           return Models.SqlHelper.ExecuteDataTable(sqlText, new System.Data.SqlClient.SqlParameter("@RepairNo", RepairNo));
        }

        /// <summary>
        /// 获取所有的维修订单
        /// </summary>
        /// <returns></returns>
        public IList<Models.ys_RepairOrder> GetAllList()
        {
            string sqlText = "select *from vw_RepairOrder";
            DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText);
            return Models.SqlHelper.DataTableToList<Models.ys_RepairOrder>(dt).Where(a=>a.IsRemoved==false).ToList();
        }
        /// <summary>
        /// 获取所有的维修订单
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable()
        {
            string sqlText = "select *from vw_RepairOrder where IsRemoved=0";
            return  Models.SqlHelper.ExecuteDataTable(sqlText);
        }

    }
}
