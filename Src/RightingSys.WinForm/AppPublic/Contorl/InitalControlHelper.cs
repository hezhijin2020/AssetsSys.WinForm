using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RightingSys.WinForm.AppPublic.Control
{
    public static class InitalControlHelper
    {
        #region ACL_User
        public static void ACL_User_GridLookUpEdit(DevExpress.XtraEditors.GridLookUpEdit Control,bool IsBindingData=true)
        {
            #region 列名
            DevExpress.XtraGrid.Columns.GridColumn ID=  new DevExpress.XtraGrid.Columns.GridColumn();
            ID.Name = "Id";
            ID.Visible = false;
            ID.FieldName = "Id";
            ID.Caption = "编号";
            ID.VisibleIndex = -1;

            DevExpress.XtraGrid.Columns.GridColumn StaffCode = new DevExpress.XtraGrid.Columns.GridColumn();
            StaffCode.Name = "SimpleCode";
            StaffCode.FieldName = "SimpleCode";
            StaffCode.Caption = "简码";
            StaffCode.VisibleIndex = 0;
            StaffCode.Width = 60;
            StaffCode.Visible = true;


            DevExpress.XtraGrid.Columns.GridColumn Name = new DevExpress.XtraGrid.Columns.GridColumn();
            Name.Name = "FullName";
            Name.FieldName = "FullName";
            Name.Caption = "职员";
            Name.VisibleIndex = 1;
            Name.Visible = true;


            DevExpress.XtraGrid.Columns.GridColumn DeptNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            DeptNAME.Name = "DepartmentName";
            DeptNAME.FieldName = "DepartmentName";
            DeptNAME.VisibleIndex = 2;
            DeptNAME.Caption = "部门";
            DeptNAME.Visible = true;

            Control.Properties.PopupView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { ID, StaffCode, Name, DeptNAME });

            #endregion

            Control.Properties.DisplayMember = "FullName";
            Control.Properties.ValueMember = "Id";
            Control.Properties.ImmediatePopup = true;
            Control.Properties.NullText = "";
            Control.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Control.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            Control.Properties.View.OptionsView.ColumnAutoWidth = false;
            if (IsBindingData)
            {
                Control.Properties.DataSource = InitalControlHelper.GetAllUser();
            }
        }
        
        public static List<Models.ACL_User> GetAllUser()
        {
            BLL.UserManager userManager = new BLL.UserManager();
            return userManager.GetAllList();
        }

        #endregion

        #region Acl_Department
        public static void ACL_Department_TreeListLookUpEdit(DevExpress.XtraEditors.TreeListLookUpEdit Control)
        {
            #region 列名
            DevExpress.XtraTreeList.Columns.TreeListColumn ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ID.Name = "Id";
            ID.FieldName = "Id";
            ID.Caption = "编号";
            ID.VisibleIndex = -1;
            ID.Visible = false;

            DevExpress.XtraTreeList.Columns.TreeListColumn Name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            Name.Name = "DepartmentName";
            Name.FieldName = "DepartmentName";
            Name.Caption = "部门";
            Name.VisibleIndex = 0;
            Name.Width = 100;
            Name.Visible = true;

            Control.Properties.TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[]{ ID, Name});

            #endregion

            Control.Properties.DisplayMember = "DepartmentName";
            Control.Properties.ValueMember = "Id";
            Control.Properties.TreeList.KeyFieldName = "Id";
            Control.Properties.TreeList.ParentFieldName = "ParentId";
            Control.Properties.ImmediatePopup = true;
            Control.Properties.NullText = "";
            Control.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Control.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            Control.Properties.DataSource = GetAllDepartment();
        }

        public static List<Models.ACL_Department> GetAllDepartment()
        {
            return new BLL.DepartmentManager().GetAllList();

        }
        #endregion

        #region ys_company
        public static void ys_Company_GridLookUpEdit(DevExpress.XtraEditors.GridLookUpEdit Control)
        {
            #region 列名
            DevExpress.XtraGrid.Columns.GridColumn ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ID.Name = "Id";
            ID.Visible = true;
            ID.FieldName = "Id";
            ID.Caption = "编号";
            ID.VisibleIndex = -1;

            DevExpress.XtraGrid.Columns.GridColumn Name = new DevExpress.XtraGrid.Columns.GridColumn();
            Name.Name = "CompanyName";
            Name.FieldName = "CompanyName";
            Name.Caption = "名称";
            Name.VisibleIndex = 0;
            Name.Width = 160;
            Name.Visible = true;

            DevExpress.XtraGrid.Columns.GridColumn code = new DevExpress.XtraGrid.Columns.GridColumn();
            code.Name = "Contact";
            code.FieldName = "Contact";
            code.Caption = "联系人";
            code.VisibleIndex = 1;
            code.Width = 60;
            code.Visible = true;

            Control.Properties.PopupView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { ID, Name, code });

            #endregion
            Control.Properties.ImmediatePopup = true;
            Control.Properties.NullText = "";
            Control.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Control.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            Control.Properties.DisplayMember = "CompanyName";
            Control.Properties.ValueMember = "Id";
            Control.Properties.View.OptionsView.ColumnAutoWidth = false;
            Control.Properties.DataSource = InitalControlHelper.GetAllCompany();

        }
        public static List<Models.ys_Company> GetAllCompany()
        {
            return new BLL.CompanyManager().GetAllList();
        }
        #endregion

        #region  ys_AssetsCategory
        public static void ys_AssetsCategory_TreeListLookUpEdit(DevExpress.XtraEditors.TreeListLookUpEdit Control)
        {
            #region 列名
            DevExpress.XtraTreeList.Columns.TreeListColumn ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ID.Name = "Id";
            ID.FieldName = "Id";
            ID.Caption = "编号";
            ID.VisibleIndex = 0;
            ID.Visible = true;

            DevExpress.XtraTreeList.Columns.TreeListColumn Name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            Name.Name = "CategoryName";
            Name.FieldName = "CategoryName";
            Name.Caption = "类别";
            Name.VisibleIndex = 1;
            Name.Width = 100;
            Name.Visible = true;

            DevExpress.XtraTreeList.Columns.TreeListColumn Code = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            Code.Name = "SimpleCode";
            Code.FieldName = "SimpleCode";
            Code.Caption = "简码";
            Code.VisibleIndex = 2;
            Code.Width = 100;
            Code.Visible = true;

            Control.Properties.TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { ID, Name,Code });

            #endregion

            Control.Properties.DisplayMember = "CategoryName";
            Control.Properties.ValueMember = "Id";
            Control.Properties.TreeList.KeyFieldName = "Id";
            Control.Properties.TreeList.ParentFieldName = "ParentId";
            Control.Properties.ImmediatePopup = true;
            Control.Properties.NullText = "";
            Control.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Control.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            Control.Properties.DataSource = InitalControlHelper.GetAllAssetsCategory();
        }
        public static List<Models.ys_AssetsCategory> GetAllAssetsCategory()
        {
            return new BLL.AssetsCategoryManager().GetAllList();
        }
        #endregion
        
        #region ys_AssetsStock
        public static void ys_AssetsStock_GridLookUpEdit(DevExpress.XtraEditors.GridLookUpEdit Control)
        {
            #region 列名
            DevExpress.XtraGrid.Columns.GridColumn ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ID.Name = "Id";
            ID.Visible = true;
            ID.FieldName = "Id";
            ID.Caption = "编号";
            ID.VisibleIndex =-1;
            ID.Width = 40;
            
            DevExpress.XtraGrid.Columns.GridColumn Name = new DevExpress.XtraGrid.Columns.GridColumn();
            Name.Name = "StockName";
            Name.FieldName = "StockName";
            Name.Caption = "仓库";
            Name.VisibleIndex = 1;
            Name.Visible = true;
            Name.Width = 120;


            DevExpress.XtraGrid.Columns.GridColumn User = new DevExpress.XtraGrid.Columns.GridColumn();
            User.Name = "ManagerName";
            User.FieldName = "ManagerName";
            User.VisibleIndex = 2;
            User.Caption = "管理员";
            User.Visible = true;

            Control.Properties.PopupView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { ID, Name, User });

            #endregion

            Control.Properties.DisplayMember = "StockName";
            Control.Properties.ValueMember = "Id";
            Control.Properties.ImmediatePopup = true;
            Control.Properties.NullText = "";
            Control.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Control.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            Control.Properties.View.OptionsView.ColumnAutoWidth = false;
            Control.Properties.DataSource = GetAllAssetsStock();

        }

        public static List<Models.ys_AssetsStock> GetAllAssetsStock()
        {
            return new BLL.AssetsStockManager().GetAllList();
        }
        #endregion

        #region ys_AssetsStatus
        public static void ys_AssetsStatus_GridLookUpEdit(DevExpress.XtraEditors.GridLookUpEdit Control)
        {
            #region 列名
            DevExpress.XtraGrid.Columns.GridColumn ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ID.Name = "Id";
            ID.Visible = true;
            ID.FieldName = "Id";
            ID.Caption = "编号";
            ID.VisibleIndex = -1;

            DevExpress.XtraGrid.Columns.GridColumn Name = new DevExpress.XtraGrid.Columns.GridColumn();
            Name.Name = "StatusName";
            Name.FieldName = "StatusName";
            Name.Caption = "名称";
            Name.VisibleIndex = 0;
            Name.Width =100;
            Name.Visible = true;

            Control.Properties.PopupView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { ID, Name});

            #endregion
            Control.Properties.ImmediatePopup = true;
            Control.Properties.NullText = "";
            Control.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Control.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            Control.Properties.DisplayMember = "StatusName";
            Control.Properties.ValueMember = "Id";
            Control.Properties.View.OptionsView.ColumnAutoWidth = false;
            Control.Properties.DataSource =InitalControlHelper.GetAllAssetsStatus();
        }
        public static System.Data.DataTable GetAllAssetsStatus()
        {
            return Models.SqlHelper.ExecuteDataTable(@"SELECT [Id]
      ,[StatusName]
      ,[SimpleCode]
      ,[IsRemoved]
      ,[CreateTime]
  FROM [AssetsSys].[dbo].[ys_AssetStatus] where IsRemoved=0");
        }

        #endregion

        #region FA_Asset

        public static void Assets_GridLookUpEdit(DevExpress.XtraEditors.GridLookUpEdit Control,AssetsStatus[] statuses, bool IsBindingData=true)
        {
            #region 列名 

            DevExpress.XtraGrid.Columns.GridColumn StatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            StatusName.Name = "StatusName";
            StatusName.Visible = true;
            StatusName.FieldName = "StatusName";
            StatusName.Caption = "状态";
            StatusName.VisibleIndex = 0;
            StatusName.Width = 40;


            DevExpress.XtraGrid.Columns.GridColumn ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ID.Name = "Id";
            ID.Visible = false;
            ID.FieldName = "Id";
            ID.Caption = "编号";
            ID.VisibleIndex = -1;
            ID.Width = 40;

            DevExpress.XtraGrid.Columns.GridColumn Name = new DevExpress.XtraGrid.Columns.GridColumn();
            Name.Name = "Name";
            Name.FieldName = "Name";
            Name.Caption = "名称";
            Name.VisibleIndex = 2;
            Name.Width = 80;
            Name.Visible = true;

            DevExpress.XtraGrid.Columns.GridColumn code = new DevExpress.XtraGrid.Columns.GridColumn();
            code.Name = "Barcode";
            code.FieldName = "Barcode";
            code.Caption = "编码";
            code.VisibleIndex = 3;
            code.Width = 120;
            code.Visible = true;

            DevExpress.XtraGrid.Columns.GridColumn model = new DevExpress.XtraGrid.Columns.GridColumn();
            model.Name = "Model";
            model.Visible = true;
            model.FieldName = "Model";
            model.Caption = "型号";
            model.VisibleIndex = 4;

            DevExpress.XtraGrid.Columns.GridColumn Dept = new DevExpress.XtraGrid.Columns.GridColumn();
            Dept.Name = "DepartmentName";
            Dept.FieldName = "DepartmentName";
            Dept.Caption = "部门";
            Dept.VisibleIndex = 5;
            Dept.Visible = true;

            DevExpress.XtraGrid.Columns.GridColumn staff = new DevExpress.XtraGrid.Columns.GridColumn();
            staff.Name = "UserName";
            staff.FieldName = "UserName";
            staff.Caption = "人员";
            staff.VisibleIndex = 6;
            staff.Visible = true;

            DevExpress.XtraGrid.Columns.GridColumn stock = new DevExpress.XtraGrid.Columns.GridColumn();
            stock.Name = "StockName";
            stock.FieldName = "StockName";
            stock.Caption = "仓库";
            stock.VisibleIndex = 7;
            stock.Visible = true;

            Control.Properties.PopupView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { StatusName, ID, Name, code, model, Dept, staff, stock });

            #endregion
            Control.Properties.ImmediatePopup = true;
            Control.Properties.NullText = "";
            Control.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Control.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            Control.Properties.DisplayMember = "Name";
            Control.Properties.ValueMember = "Id";
            Control.Properties.View.OptionsView.ColumnAutoWidth = false;

            if (IsBindingData)
            {
                if (statuses == null || statuses.Length <= 0)
                {
                    Control.Properties.DataSource = InitalControlHelper.GetAssetListByStatus(statuses);
                }
                else
                {
                    Control.Properties.DataSource = InitalControlHelper.GetAssetListByStatus(statuses);
                }
               
            }
        }
        
        /// <summary>
        /// 获取所有资产信息
        /// </summary>
        public static List<Models.ys_Assets> GetAssetsAllList()
        {
            BLL.AssetsManager assetsManager = new BLL.AssetsManager();
            return assetsManager.GetAllList();
        }

        /// <summary>
        ///获取指定状态的资产集合
        /// </summary>
        /// <param name="enums">状态集合</param>
        /// <returns></returns>
        public static List<Models.ys_Assets> GetAssetListByStatus(params Utils.clsEnum.AssetsStatus[] enums)
        {
            string[] subs = new string[enums.Length];
            for( int i=0;i< enums.Length;i++)
            {
                subs[i]= enums[i].ToString();
            }

           return   InitalControlHelper.GetAssetsAllList().FindAll(a =>(subs).Contains(a.StatusId));
        }
        #endregion
    }
}
