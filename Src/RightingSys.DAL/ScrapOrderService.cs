using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{
    /// <summary>
    /// 报废服务类
    /// </summary>
    public class ScrapOrderService
    {

        Dictionary<SqlParameter[], string> dicCmd = new Dictionary<SqlParameter[], string>();

        #region 新增事务
        /// <summary>
        /// 新增报废记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddNew(IList<Models.ys_ScrapOrder> listModel)
        {
            foreach (Models.ys_ScrapOrder r in listModel)
            {
                AddDicByRepairOrder(r);
                AddDicByUpdateAssets(r);
            }
            return Models.SqlHelper.ExecuteTransaction1(dicCmd) > 0 ? true : false;
        }

        /// <summary>
        /// 新增报废记录
        /// </summary>
        /// <param name="model"></param>
        public void AddDicByRepairOrder(Models.ys_ScrapOrder model)
        {
            #region sqltext
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_ScrapOrder]
           ([Id]
           ,[ScrapNo]
           ,[AssetsId]
           ,[OldStatusId]
           ,[SrcapUserId]
           ,[SrcapUserName]
           ,[Scrapday]
           ,[OperatorId]
           ,[OperatorName]
           ,[SrcapDescription]
           ,[IsAudit]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES(@Id
           ,@ScrapNo
           ,@AssetsId
           ,@OldStatusId
           ,@SrcapUserId
           ,@SrcapUserName
           ,@Scrapday
           ,@OperatorId
           ,@OperatorName
           ,@SrcapDescription
           ,@IsAudit
           ,@CreateTime
           ,@IsRemoved)";
            #endregion

            #region  sqlParam
            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@ScrapNo", model.ScrapNo);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@OldStatusId", model.OldStatusId);
            SqlParameter s5 = new SqlParameter("@ScrapUserId", model.ScrapUserId);
            SqlParameter s6 = new SqlParameter("@ScrapUserName", model.ScrapUserName);
            SqlParameter s7 = new SqlParameter("@Scrapday", model.Scrapday);
            SqlParameter s8 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s9 = new SqlParameter("@OperatorName", model.OperatorName);
            SqlParameter s10 = new SqlParameter("@ScrapDescription", model.ScrapDescription);
            SqlParameter s11 = new SqlParameter("@IsAudit", model.IsAudit);
            SqlParameter s12 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@IsRemoved", model.IsRemoved);
            #endregion
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13};
            dicCmd.Add(cmdPara, sqlText);
        }
        
        /// <summary>
        /// 更新资产状态
        /// </summary>
        /// <param name="model"></param>
        public void AddDicByUpdateAssets(Models.ys_ScrapOrder model)
        {
            if (model.IsAudit)
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
                SqlParameter s2 = new SqlParameter("@StatusId", "BF");
                SqlParameter[] cmdPara = new SqlParameter[] { s1, s2 };
                dicCmd.Add(cmdPara, sqlText);
            }
        }
        #endregion

        #region 完成事务
        /// <summary>
        /// 修改报废记录
        /// </summary>
        /// <param name="listModel"></param>
        /// <returns></returns>
        public bool Modify(IList<Models.ys_ScrapOrder> listModel)
        {
            foreach (Models.ys_ScrapOrder r in listModel)
            {
                AddDicByUpdateAssets(r);
                AddDicModifyByRepairOrder(r);
            }
            return Models.SqlHelper.ExecuteTransaction1(dicCmd,false) > 0 ? true : false;
        }


        /// <summary>
        /// 修改指定的报废记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public void AddDicModifyByRepairOrder(Models.ys_ScrapOrder model)
        {
            #region sqltext

            string sqlText = @"UPDATE [AssetsSys].[dbo].[ys_ScrapOrder]
                   SET [ScrapNo] = @ScrapNo
                      ,[AssetsId] = @AssetsId
                      ,[OldStatusId] = @OldStatusId
                      ,[SrcapUserId] = @SrcapUserId
                      ,[SrcapUserName] = @SrcapUserName
                      ,[Scrapday] = @Scrapday
                      ,[OperatorId] = @OperatorId
                      ,[OperatorName] = @OperatorName
                      ,[SrcapDescription] = @SrcapDescription
                      ,[IsAudit] = @IsAudit
                      ,[CreateTime] = @CreateTime
                      ,[IsRemoved] = @IsRemoved
                 WHERE [Id] = @Id";
            #endregion

            #region  sqlParam
            SqlParameter s1 = new SqlParameter("@Id", model.Id);
            SqlParameter s2 = new SqlParameter("@ScrapNo", model.ScrapNo);
            SqlParameter s3 = new SqlParameter("@AssetsId", model.AssetsId);
            SqlParameter s4 = new SqlParameter("@OldStatusId", model.OldStatusId);
            SqlParameter s5 = new SqlParameter("@ScrapUserId", model.ScrapUserId);
            SqlParameter s6 = new SqlParameter("@ScrapUserName", model.ScrapUserName);
            SqlParameter s7 = new SqlParameter("@Scrapday", model.Scrapday);
            SqlParameter s8 = new SqlParameter("@OperatorId", model.OperatorId);
            SqlParameter s9 = new SqlParameter("@OperatorName", model.OperatorName);
            SqlParameter s10 = new SqlParameter("@ScrapDescription", model.ScrapDescription);
            SqlParameter s11 = new SqlParameter("@IsAudit", model.IsAudit);
            SqlParameter s12 = new SqlParameter("@CreateTime", model.CreateTime);
            SqlParameter s13 = new SqlParameter("@IsRemoved", model.IsRemoved);
            #endregion
            SqlParameter[] cmdPara = new SqlParameter[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13 };
            dicCmd.Add(cmdPara, sqlText);
        }

        #endregion
        /// <summary>
        /// 获取最大的订单号
        /// </summary>
        /// <returns></returns>
        public string GetMaxScrapNo()
        {
            string sqlText = @"select Max(ScrapNo) from ys_ScrapOrder";
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
        /// 获取指定ID报废记录信息
        /// </summary>
        /// <param name="Id">报废Id</param>
        /// <returns></returns>
        public Models.ys_ScrapOrder GetOneById(Guid Id)
        {
            string sqlText = "select *from ys_ScrapOrder where Id=@Id";
            DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText, new System.Data.SqlClient.SqlParameter("@Id", Id));
            return Models.SqlHelper.DataTableToList<Models.ys_ScrapOrder>(dt)[0];
        }

        /// <summary>
        /// 根据订单号获取报废信息
        /// </summary>
        /// <param name="ScrapNo">订单号</param>
        /// <returns></returns>
        public IList<Models.ys_ScrapOrder> GetOneByScrapNo(string ScrapNo)
        {
            string sqlText = "select *from ys_RepairOrder where ScrapNo=@ScrapNo";
            DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText, new System.Data.SqlClient.SqlParameter("@ScrapNo", ScrapNo));
            return Models.SqlHelper.DataTableToList<Models.ys_ScrapOrder>(dt);
        }

        /// <summary>
        /// 根据订单号获取报废信息
        /// </summary>
        /// <param name="RepairNo">订单号</param>
        /// <returns></returns>
        public DataTable GetTableOneByScrapNo(string ScrapNo)
        {
           string sqlText = "select * from vw_ScrapOrder where ScrapNo=@ScrapNo";
           return Models.SqlHelper.ExecuteDataTable(sqlText, new System.Data.SqlClient.SqlParameter("@ScrapNo", ScrapNo));
        }

        /// <summary>
        /// 获取所有的报废订单
        /// </summary>
        /// <returns></returns>
        public IList<Models.ys_ScrapOrder> GetAllList()
        {
            string sqlText = "select *from vw_ScrapOrder";
            DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText);
            return Models.SqlHelper.DataTableToList<Models.ys_ScrapOrder>(dt).Where(a=>a.IsRemoved==false).ToList();
        }
        /// <summary>
        /// 获取所有的报废订单
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllTable()
        {
            string sqlText = "select *from vw_ScrapOrder where IsRemoved=0";
            return  Models.SqlHelper.ExecuteDataTable(sqlText);
        }

    }
}
