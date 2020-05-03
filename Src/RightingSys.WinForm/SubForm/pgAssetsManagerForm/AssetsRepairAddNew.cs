using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsRepairAddNew : BaseForm
    {

        #region  声明变量
        List<Models.ys_Assets> Allview = new List<Models.ys_Assets>();
        List<Models.ys_RepairOrder> selectview = new List<Models.ys_RepairOrder>();
        BLL.AssetsManager assetsManager = new BLL.AssetsManager();
        BLL.RepairOrderManager manager = new BLL.RepairOrderManager();
        #endregion

        public AssetsRepairAddNew()
        {
            InitializeComponent();
            Initial();
        }

        public string NewRepairNo { get { return manager.GetNewRepairNo(); } }
        
        private void Initial()
        {
            txtOperatorUser.Text = AppPublic.appSession._LoginName;

            AppPublic.Control.InitalControlHelper.ACL_User_GridLookUpEdit(cbxRepairUser);

            tRepairday.DateTime = DateTime.Now;

            AppPublic.Control.InitalControlHelper.Assets_GridLookUpEdit(cbxAsset,new AssetsStatus[]{AssetsStatus.ZY,AssetsStatus.XZ },false);
            cbxAsset.Properties.DataSource= Allview = AppPublic.Control.InitalControlHelper.GetAssetListByStatus(AssetsStatus.XZ, AssetsStatus.ZY);
            
            gcData.DataSource = selectview;
            AppPublic.Control.InitalControlHelper.ys_AssetsStock_GridLookUpEdit(cbxStock);
            AppPublic.Control.InitalControlHelper.ys_Company_GridLookUpEdit(cbxCompany);

            
        }
        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void sbtnSave_Click(object sender, EventArgs e)
        {
            if (manager.AddNew(selectview))
            {
                AppPublic.appPublic.ShowMessage("保存成功！", Text);
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                AppPublic.appPublic.ShowMessage("保存失败！", Text);
            }

        }

        private void sbtnAdd_Click(object sender, EventArgs e)
        { 
            if (cbxAsset.EditValue != null && txtRepairReason.Text.Trim() != "" && cbxRepairUser.EditValue != null && cbxCompany.EditValue != null)
            {
                Models.ys_Assets model = Allview.Find(s => s.Id.Equals((Guid)cbxAsset.EditValue));
                Allview.Remove(model);
                cbxAsset.EditValue = null;

                #region

                Models.ys_RepairOrder m = new Models.ys_RepairOrder();
                m.Id = Guid.NewGuid();
                m.AssetsId = model.Id;
                m.CompanyId =(Guid)cbxCompany.EditValue;
                m.CompanyName = cbxCompany.Text;
                m.OperatorId = AppPublic.appSession._UserId;
                m.OperatorName = AppPublic.appSession._FullName;
                m.Repairday = tRepairday.DateTime;
                m.RepairNo = this.NewRepairNo;
                m.RepairPrice= AppPublic.appPublic.ToDecimal(txtRepairPrice.EditValue);
                m.RepairReason = txtRepairReason.Text;
                m.RepairUserId = AppPublic.appPublic.GetObjGUID(cbxRepairUser.EditValue);
                m.RepairUserName = cbxRepairUser.Text;
                m.OldStatusId = model.StatusId;
                m.AssetsModel = model;

                #endregion
                selectview.Add(m);
                gcData.RefreshDataSource();

                cbxStock_EditValueChanged(null, null);
            }
            else {
                AppPublic.appPublic.ShowMessage("维修机构、报修人员、维修资产、维修原因不能为空！", Text);
            }
        }

        private void sbtnDelete_Click(object sender, EventArgs e)
        {
            if (gvData.FocusedRowHandle>=0)
            {
                Models.ys_RepairOrder model = selectview.Find(s => s.AssetsId.Equals(gvData.GetFocusedRowCellValue("AssetsId")));
                selectview.Remove(model);
                gcData.RefreshDataSource();
                cbxAsset.EditValue = null;

                Allview.Add(assetsManager.GetOneById(model.AssetsId));
                cbxStock_EditValueChanged(null, null);
            }

        }

        private void cbxStock_EditValueChanged(object sender, EventArgs e)
        {
            if (cbxStock.EditValue == null)
            {
                cbxAsset.Properties.DataSource = Allview;
            }
            else
            {
                cbxAsset.Properties.DataSource = Allview.FindAll(a => a.StockId.Equals(cbxStock.EditValue));

            }
           
        }
    }
}
