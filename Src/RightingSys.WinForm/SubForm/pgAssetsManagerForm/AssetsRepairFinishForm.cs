
using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsRepairFinishForm : BaseForm
    {
        #region  声明变量

        Models.ys_RepairOrder model = new Models.ys_RepairOrder();
        BLL.RepairOrderManager manager = new BLL.RepairOrderManager();

        #endregion
        public AssetsRepairFinishForm(Guid Id)
        {
            InitializeComponent();
            Initial(Id);
        }
        private void Initial(Guid Id)
        {
            AppPublic.Control.InitalControlHelper.ys_Company_GridLookUpEdit(cbxCompany);
            AppPublic.Control.InitalControlHelper.Assets_GridLookUpEdit(cbxAssets, new AssetsStatus[]{AssetsStatus.WX});

            model = manager.GetOneById(Id);
            txtWXID.Text = model.RepairNo;
            dBeginday.DateTime = model.Repairday;
            txtOperatorUser.EditValue = model.OperatorName;
            txtRepairUser.EditValue = model.RepairUserName;
            txtRepairReason.EditValue = model.RepairReason;
            txtPrice.EditValue = model.RepairPrice;
            txtRepairDescription.Text = model.RepairDescription;
            cbxCompany.EditValue = model.CompanyId;
            cbxAssets.EditValue = model.AssetsId;
            
        }
        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }
        private void sbtnfinish_Click(object sender, EventArgs e)
        {
            if (txtRepairDescription.Text.Trim() != "" && txtRepairReason.Text.Trim() != "")
            {
                model.RepairDescription = txtRepairDescription.Text.Trim();
                model.RepairReason = txtRepairReason.Text.Trim();

                model.FinishUserName = AppPublic.appSession._FullName;
                model.FinishUserId = AppPublic.appSession._UserId;

                model.RepairPrice = AppPublic.appPublic.ToDecimal(txtPrice.Text);
                model.CompanyId = AppPublic.appPublic.GetObjGUID(cbxCompany.EditValue);

                if (manager.Modify(model))
                {
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("资产状态改变，失败.", Text);
                    base.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
