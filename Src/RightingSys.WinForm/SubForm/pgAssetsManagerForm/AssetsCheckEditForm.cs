using RightingSys.WinForm.Utils.cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsCheckEditForm : Form
    {
        BLL.CheckOrderManager manager = new BLL.CheckOrderManager();
        Models.ys_CheckOrder model = new Models.ys_CheckOrder();
        System.Data.DataTable dtAll = new DataTable();

        public AssetsCheckEditForm()
        {
            InitializeComponent();
            Checkday.EditValue = DateTime.Now;
            txtOperatorName.Text = clsSession._FullName;
        }

        /// <summary>
        /// 修改盘点单
        /// </summary>
        /// <param name="checkId">单号Id</param>
        public AssetsCheckEditForm(Guid checkId):this()
        {
            model = manager.GetOneByCheckId(checkId);
            if (model != null)
            {
                txtCheckNo.Text = model.CheckNo;
                Checkday.EditValue = model.Checkday;
                txtOperatorName.Text = model.OperatorName;
                txtDescription.Text = model.Description;
                cIsAudit.Checked = model.IsAudit;
                gcData.DataSource = dtAll = manager.GetAllTable(checkId);
                if (model.IsAudit)
                {
                    gvData.OptionsBehavior.Editable = false;
                }
                
            }
        }

        /// <summary>
        /// 取消修改
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///资产明细过虑方法
        /// </summary>
        private void FilterGroup_SelectedIndexChanged(object sender, EventArgs e)
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
        /// 盘点值改变事件
        /// </summary>
        private void gvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "IsSelect")
            {
                object time = DateTime.Now;
                object userid = clsSession._UserId;
                object username = clsSession._FullName;
                if (!(bool)e.Value)
                {
                    time = null;userid = null;username = null;
                }
                gvData.SetRowCellValue(e.RowHandle,"IsCheckTime", time);
                gvData.SetRowCellValue(e.RowHandle, "CheckUserId",userid);
                gvData.SetRowCellValue(e.RowHandle, "CheckUserName", username);
                gcData.RefreshDataSource();
            }
        }

        /// <summary>
        /// 关闭窗体前询问是否保存数据
        /// </summary>
        private void AssetsCheckEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (clsPublic.IsDataTableChanged(dtAll))
            {
                if (DialogResult.Yes == MessageBox.Show("数据是否保存？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    btnSave_Click(null,null);
                }
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsPublic.IsDataTableChanged(dtAll))
            {
                DataTable Dt = dtAll.Copy();
                Dt.DefaultView.RowFilter = "IsSelect=true";
                DataTable newdt = Dt.DefaultView.ToTable();
               if ( manager.SaveDetail(newdt))
                {
                    MessageBox.Show("成功");
                    dtAll.AcceptChanges();
                    //base.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            else {
                MessageBox.Show("没有要保存的数据");
            }
        }

        /// <summary>
        /// 显示盘点机的审核情况
        /// </summary>
        private void cIsAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (cIsAudit.Checked)
            {
                cIsAudit.Text = "已审核";
            }
            else
            {
                cIsAudit.Text = "未审核";
            }
        }
    }
}
