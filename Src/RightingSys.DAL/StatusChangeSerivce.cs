using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RightingSys.DAL
{
    public class StatusChangeSerivce
    {

        private static Dictionary<SqlParameter[], string> sqlDic = new Dictionary<SqlParameter[], string>();

        /// <summary>
        /// 静太方法写入 状态改变记录
        /// </summary>
        /// <param name="ActionName">操作</param>
        /// <param name="ActionNo">单号</param>
        /// <param name="AssetsId">资产Id</param>
        /// <param name="OperatorId">操作员</param>
        /// <param name="OperatorName">名称</param>
        /// <param name="ActionUserId">职员</param>
        /// <param name="ActionUserName">职员</param>
        /// <returns></returns>
        public static KeyValuePair<SqlParameter[],string> AddNew(string ActionName, string ActionNo, Guid AssetsId, string OperatorId = "00000000-0000-0000-0000-000000000000", string OperatorName = "", string ActionUserId = "00000000-0000-0000-0000-000000000000", string ActionUserName = "")
        {
            
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_AssetsStatusChange]
           ([Id]
           ,[ActionName]
           ,[ActionNo]
           ,[AssetsId]
           ,[ActionUserId],[ActionUserName]
           ,[OperatorId],[OperatorName]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES(@Id
           ,@ActionName
           ,@ActionNo
           ,@AssetsId
           ,@ActionUserId,@ActionUserName
           ,@OperatorId ,@OperatorName
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter[] cmdParam = new SqlParameter[]{
                new SqlParameter("@Id",Guid.NewGuid()),
                new SqlParameter("@ActionName",ActionName),
                new SqlParameter("@ActionNo",ActionNo),
                new SqlParameter("@AssetsId",AssetsId),
                new SqlParameter("@ActionUserId",ActionUserId),
                new SqlParameter("@ActionUserName",ActionUserName),
                new SqlParameter("@OperatorId",OperatorId),
                new SqlParameter("@OperatorName",OperatorName),
                new SqlParameter("@CreateTime",DateTime.Now),
                new SqlParameter("@IsRemoved",false)
            };

            KeyValuePair<SqlParameter[], string> item = new KeyValuePair<SqlParameter[], string>(cmdParam,sqlText);
            return item;
        }

        #region 注释不要
        //   /// <summary>
        //   /// 静太方法写入 状态改变记录
        //   /// </summary>
        //   /// <param name="ActionName">操作</param>
        //   /// <param name="ActionNo">单号</param>
        //   /// <param name="AssetsId">资产Id</param>
        //   /// <param name="OperatorId">操作员</param>
        //   /// <param name="OperatorName">名称</param>
        //   /// <param name="ActionUserId">职员</param>
        //   /// <param name="ActionUserName">职员</param>
        //   /// <returns></returns>
        //   public static void AddNew(string ActionName,string ActionNo,Guid AssetsId,string OperatorId= "00000000-0000-0000-0000-000000000000", string OperatorName="", string ActionUserId="00000000-0000-0000-0000-000000000000", string ActionUserName="")
        //   {
        //       string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_AssetsStatusChange]
        //      ([Id]
        //      ,[ActionName]
        //      ,[ActionNo]
        //      ,[AssetsId]
        //      ,[ActionUserId],[ActionUserName]
        //      ,[OperatorId],[OperatorName]
        //      ,[CreateTime]
        //      ,[IsRemoved])
        //VALUES(@Id
        //      ,@ActionName
        //      ,@ActionNo
        //      ,@AssetsId
        //      ,@ActionUserId,@ActionUserName
        //      ,@OperatorId ,@OperatorName
        //      ,@CreateTime
        //      ,@IsRemoved)";

        //       SqlParameter[] cmdParam = new SqlParameter[]{
        //           new SqlParameter("@Id",Guid.NewGuid()),
        //           new SqlParameter("@ActionName",ActionName),
        //           new SqlParameter("@ActionNo",ActionNo),
        //           new SqlParameter("@AssetsId",AssetsId),
        //           new SqlParameter("@ActionUserId",ActionUserId),
        //           new SqlParameter("@ActionUserName",ActionUserName),
        //           new SqlParameter("@OperatorId",OperatorId),
        //           new SqlParameter("@OperatorName",OperatorName),
        //           new SqlParameter("@CreateTime",DateTime.Now),
        //           new SqlParameter("@IsRemoved",false)
        //       };
        //       sqlDic.Add(cmdParam, sqlText);
        //   }

        //   /// <summary>
        //   /// 将记录保存到数据库
        //   /// </summary>
        //   public static void Save()
        //   {
        //       try
        //       {
        //           Models.SqlHelper.ExecuteTransaction1(sqlDic);
        //           sqlDic.Clear();
        //       }
        //       catch
        //       {
        //           sqlDic.Clear();
        //           throw new Exception("写入资产状态变更出错");
        //       }
        //   }
        #endregion



        /// <summary>
        /// 新增状态改变事件
        /// </summary>
        /// <param name="model">实体</param>
        public bool AddNew(Models.ys_AssetsStatusChange model)
        {
            string sqlText = @"INSERT INTO [AssetsSys].[dbo].[ys_AssetsStatusChange]
           ([Id]
           ,[ActionName]
           ,[ActionNo]
           ,[AssetsId]
           ,[ActionUserId],[ActionUserName]
           ,[OperatorId],[OperatorName]
           ,[CreateTime]
           ,[IsRemoved])
     VALUES(@Id
           ,@ActionName
           ,@ActionNo
           ,@AssetsId
           ,@ActionUserId,@ActionUserName
           ,@OperatorId ,@OperatorName
           ,@CreateTime
           ,@IsRemoved)";

            SqlParameter[] cmdParam = new SqlParameter[]{
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@ActionName",model.ActionName),
                new SqlParameter("@ActionNo",model.ActionNo),
                new SqlParameter("@AssetsId",model.AssetsId),
                new SqlParameter("@ActionUserId",model.ActionUserId),
                new SqlParameter("@ActionUserName",model.ActionUserName),
                new SqlParameter("@OperatorId",model.OperatorId),
                new SqlParameter("@OperatorName",model.OperatorName),
                new SqlParameter("@CreateTime",model.CreateTime),
                new SqlParameter("@IsRemoved",model.IsRemoved)
            };
            return Models.SqlHelper.ExecuteNoQuery(sqlText, cmdParam) > 0 ? true : false;
        }

        /// <summary>
        /// 获取所有的记录
        /// </summary>
        public IList<Models.ys_AssetsStatusChange> GetAllList()
        {
            List<Models.ys_AssetsStatusChange> list = new List<Models.ys_AssetsStatusChange>();

            string sqlText = @"SELECT [Id]
      ,[ActionName]
      ,[ActionNo]
      ,[AssetsId]
      ,[ActionUserName]
      ,[ActionUserId]
      ,[OperatorName]
      ,[OperatorId]
      ,[CreateTime]
      ,[IsRemoved]
  FROM [AssetsSys].[dbo].[ys_AssetsStatusChange] ";
            System.Data.DataTable dt = Models.SqlHelper.ExecuteDataTable(sqlText);
            list = Models.SqlHelper.DataTableToList<Models.ys_AssetsStatusChange>(dt).ToList();
            return list;
        }


        /// <summary>
        /// 获取所有的记录
        /// </summary>
        public System.Data.DataTable GetTableList(string where)
        {
            List<Models.ys_AssetsStatusChange> list = new List<Models.ys_AssetsStatusChange>();

            string sqlText =string.Format(@"SELECT a.[Id]
      ,a.[ActionName]
      ,a.[ActionNo]
      ,a.[AssetsId]
      ,a.[ActionUserName]
      ,a.[ActionUserId]
      ,a.[OperatorName]
      ,a.[OperatorId]
      ,a.[CreateTime]
      ,a.[IsRemoved]
      ,b.[Barcode]
      ,b.[Name]
      ,b.[Model]
      ,b.[CompanyId]
      ,b.[CompanyName]
      ,b.[CategoryId]
      ,b.[CategoryName]
      ,b.[DepartmentId]
      ,b.[DepartmentName]
      ,b.[UserId]
      ,b.[UserName]
      ,b.[Buyday]
      ,b.[Location]
      ,b.[StockId]
      ,b.[StockName]
      ,b.[Price]
      ,b.[Description]
      ,b.[XmlInf]
      ,b.[StatusId]
      ,b.[StatusName]
  FROM [AssetsSys].[dbo].[ys_AssetsStatusChange] as  a  left join vw_Assets as b on a.AssetsId=b.Id  {0}",where);

           return Models.SqlHelper.ExecuteDataTable(sqlText);
        }
    }
}
