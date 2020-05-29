using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsCheckApproveForm : BaseForm
    {
        Models.ys_CheckOrder _model;
        BLL.CheckOrderManager manager = new BLL.CheckOrderManager();
        DataTable dtAll = new DataTable();
        public AssetsCheckApproveForm(Models.ys_CheckOrder model)
        {
            InitializeComponent(); _model = model;
            Query();
        }

        public override void Query()
        {
            txtCheckNo.Text = _model.CheckNo;
            Checkday.EditValue = _model.Checkday;
            txtOperatorName.Text = _model.OperatorName;
            txtDescription.Text = _model.Description;
            cIsAudit.Checked = _model.IsAudit;
            gcData.DataSource = dtAll = manager.GetAllTable(_model.Id);

            gvData.GroupPanelText= string.Format("本次盘点资产{0}件，已盘{1}件，盘差{2}件", dtAll.Rows.Count, dtAll.Select("IsSelect=true").Length, dtAll.Select("IsSelect=false").Length);
        }

        /// <summary>
        ///资产明细过虑方法
        /// </summary>
        private void FilterGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (FilterGroup.EditValue.ToString() == "True")
            {
                dtAll.DefaultView.RowFilter = "IsSelect=true";
                gcData.DataSource = dtAll.DefaultView;
            }
            else if (FilterGroup.EditValue.ToString() == "False")
            {
                dtAll.DefaultView.RowFilter = "IsSelect=false";
                gcData.DataSource = dtAll.DefaultView;
            }
            else
            {
                dtAll.DefaultView.RowFilter = "";
                gcData.DataSource = dtAll.DefaultView;
            }
        }

        /// <summary>
        /// 盘点审核
        /// </summary>
        private void btnApprove_Click(object sender, System.EventArgs e)
        {
            _model.OperatorId = AppPublic.appSession._UserId;
            _model.IsAuditday = DateTime.Now;
            _model.IsAudit = true;
            _model.OperatorName = AppPublic.appSession._FullName;
            string msg = string.Format("本次盘点资产{0}件，已盘{1}件，盘差{2}件 --- 是否审核？", dtAll.Rows.Count, dtAll.Select("IsSelect=true").Length, dtAll.Select("IsSelect=false").Length);
            if (AppPublic.appPublic.GetMessageBoxYesNoResult(msg))
            {
                List<Models.ys_CheckOrderDeail> list = new List<Models.ys_CheckOrderDeail>();
                DataTable Dt = dtAll.Copy();
                Dt.DefaultView.RowFilter = "IsSelect=False";
                DataTable newdt = Dt.DefaultView.ToTable();
                foreach (DataRow r in newdt.Rows)
                {
                    Models.ys_CheckOrderDeail d = new Models.ys_CheckOrderDeail();
                    d.AssetsId = (System.Guid)r["AssetsId"];
                    d.CheckId = (System.Guid)r["CheckId"];
                    list.Add(d);
                }
                _model.Details = list;
                if (manager.Approve(_model))
                {
                    MessageBox.Show("成功");
                    dtAll.AcceptChanges();
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("失败");
                }

            }
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        private void gvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 取消审核
        /// </summary>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
