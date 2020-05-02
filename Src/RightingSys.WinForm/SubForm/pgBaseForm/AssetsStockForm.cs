
using RightingSys.WinForm.AppPublic.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgBaseForm
{
    public partial class AssetsStockForm : BaseForm
    {

        private bool IsAddNew = false;
        BLL.AssetsStockManager StockManager = new BLL.AssetsStockManager();
        Models.ys_AssetsStock model = new Models.ys_AssetsStock();
        BLL.UserManager userManager = new BLL.UserManager();
        public AssetsStockForm()
        {
            InitializeComponent();
            Query();
        }
        public override void InitFeatureButton()
        {
            base.SetFeatureButton(new FeatureButton[] { FeatureButton.Add, FeatureButton.Delete, FeatureButton.Query });
        }
        public override void AddNew()
        {
            IsAddNew = true;
            model = new Models.ys_AssetsStock();
            model.Id = Guid.NewGuid();
            txtStockName.Text = cboxMgUser.Text = txtID.Text = "";
            txtStockName.Focus();
        }
        public override void Delete()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                Guid ID = (Guid)gvData.GetFocusedRowCellValue("Id");
                if (StockManager.ExistsAssetsById(ID))
                {
                    AppPublic.appPublic.ShowMessage("已被引用不能删除！", Text);return;
                }
                if (AppPublic.appPublic.GetMessageBoxYesNoResult("是否删除，删除将不能恢复？", Text))
                {
                    if (StockManager.Delete(ID))
                    {
                        Query();
                        AppPublic.appPublic.ShowMessage("删除成功！！", Text);
                    }
                    else
                    {
                        AppPublic.appPublic.ShowMessage("删除失败！！", Text);
                    }
                }

            }
        }
        public override void Query()
        {
            gcData.DataSource = StockManager.GetAllList();
            cboxMgUser.Properties.DataSource = userManager.GetAllList();
        }
        
        private void sbtnSave_Click(object sender, EventArgs e)
        {
            if (txtStockName.Text.Trim() == "")
            {
                AppPublic.appPublic.ShowMessage("名称不能为空", Text);
                return;
            }
            model.StockName = txtStockName.Text.Trim();
            model.ManagerId = (Guid)cboxMgUser.EditValue;
            model.ManagerName = cboxMgUser.Text;
            if (IsAddNew && StockManager.AddNew(model))
            {
                AppPublic.appPublic.ShowMessage("新增成功", Text);
                Query();
            }
            else
            {
                if (StockManager.Modify(model))
                {
                    AppPublic.appPublic.ShowMessage("修改成功", Text);
                    Query();
                }
            }
        }
      
        private void gvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                IsAddNew = false;
                txtStockName.Focus();
                txtID.EditValue = model.Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                txtStockName.Text = model.StockName = gvData.GetFocusedRowCellValue("StockName").ToString();
                cboxMgUser.EditValue = model.ManagerId = AppPublic.appPublic.GetObjGUID(gvData.GetFocusedRowCellValue("ManagerId"));

            }
        }

        private void gvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
