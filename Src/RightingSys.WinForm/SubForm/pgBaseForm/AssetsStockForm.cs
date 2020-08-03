using RightingSys.WinForm.Utils.cls;
using RightingSys.WinForm.Utils.clsEnum;
using System;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm.pgBaseForm
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
                    clsPublic.ShowMessage("已被引用不能删除！", Text);return;
                }
                if (clsPublic.GetMessageBoxYesNoResult("是否删除，删除将不能恢复？", Text))
                {
                    if (StockManager.Delete(ID))
                    {
                        Query();
                        clsPublic.ShowMessage("删除成功！！", Text);
                    }
                    else
                    {
                        clsPublic.ShowMessage("删除失败！！", Text);
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
                clsPublic.ShowMessage("名称不能为空", Text);
                return;
            }
            model.StockName = txtStockName.Text.Trim();
            model.ManagerId = (Guid)cboxMgUser.EditValue;
            model.ManagerName = cboxMgUser.Text;
            if (IsAddNew && StockManager.AddNew(model))
            {
                clsPublic.ShowMessage("新增成功", Text);
                Query();
            }
            else
            {
                if (StockManager.Modify(model))
                {
                    clsPublic.ShowMessage("修改成功", Text);
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
                cboxMgUser.EditValue = model.ManagerId = clsPublic.GetObjGUID(gvData.GetFocusedRowCellValue("ManagerId"));

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
