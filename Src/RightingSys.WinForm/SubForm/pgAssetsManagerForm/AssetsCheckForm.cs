using RightingSys.WinForm.AppPublic.Enum;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using DevExpress.XtraReports.UI;
using System.Data;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsCheckForm : BaseForm
    {
        Models.ys_CheckOrder model = new Models.ys_CheckOrder();
        BLL.CheckOrderManager manager = new BLL.CheckOrderManager();
        List<Models.ys_CheckOrder> allList = new List<Models.ys_CheckOrder>();

        public AssetsCheckForm()
        {
            InitializeComponent();
            Checkday.EditValue = DateTime.Now;
            txtOperatorName.Text = AppPublic.appSession._FullName;
            Query();

        }

        /// <summary>
        /// 功能初始化
        /// </summary>
        public override void InitFeatureButton()
        {
            base.SetFeatureButton(FeatureButton.Add,FeatureButton.Query,FeatureButton.Save,FeatureButton.Delete,FeatureButton.Approve,FeatureButton.UnApprove,FeatureButton.Export,FeatureButton.Print);
        }

        /// <summary>
        /// 盘点单打印
        /// </summary>
        public override void Print()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                var CheckNo = gvData.GetFocusedRowCellValue("CheckNo").ToString();
                Models.ys_CheckOrder model = allList.FirstOrDefault(a => a.CheckNo == CheckNo);
                DevReport.rptCheckOrder rpt = new DevReport.rptCheckOrder(model);
                rpt.ShowPreview();
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        public override void Export()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            fileDialog.FileName = "盘点单";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gcData.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// 盘点审核
        /// </summary>
        public override void Approve()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                Guid Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                model = allList.FirstOrDefault(a => a.Id == Id);
                if (model != null)
                {
                    if (model.IsAudit)
                    {
                        MessageBox.Show("盘点单已审核不能更改"); return;
                    }
                    AssetsCheckApproveForm sub = new AssetsCheckApproveForm(model);
                    sub.ShowDialog();
                }
            }
          
        }

        /// <summary>
        /// 盘点反审核
        /// </summary>
        public override void UnApprove()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                Guid Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                Models.ys_CheckOrder _model = allList.FirstOrDefault(a => a.Id == Id);
                if (_model != null)
                {
                    if (!model.IsAudit)
                    {
                        MessageBox.Show("盘点单未审核不能反审核"); return;
                    }
                    DataTable Dt = manager.GetAllTable(_model.Id);
                    _model.OperatorId = AppPublic.appSession._UserId;
                    _model.OperatorName = AppPublic.appSession._FullName;
                    string msg = string.Format("本次盘点资产{0}件，已盘{1}件，盘差{2}件 --- 是否反审核？", Dt.Rows.Count, Dt.Select("IsSelect=true").Length, Dt.Select("IsSelect=false").Length);
                    if (AppPublic.appPublic.GetMessageBoxYesNoResult(msg))
                    {
                        List<Models.ys_CheckOrderDeail> list = new List<Models.ys_CheckOrderDeail>();

                        Dt.DefaultView.RowFilter = "IsSelect=False";
                        DataTable newdt = Dt.DefaultView.ToTable();
                        foreach (DataRow r in newdt.Rows)
                        {
                            Models.ys_CheckOrderDeail d = new Models.ys_CheckOrderDeail();
                            d.AssetsId = (System.Guid)r["AssetsId"];
                            d.OldStatusId = r["OldStatusId"].ToString();
                            d.CheckId = (System.Guid)r["CheckId"];
                            list.Add(d);
                        }
                        _model.Details = list;
                        if (manager.UnApprove(_model))
                        {
                            MessageBox.Show("成功");
                        }
                        else
                        {
                            MessageBox.Show("失败");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public override void Query()
        {
            gcData.DataSource = allList = manager.GetAllList();
        }
        /// <summary>
        /// 保存方法 
        /// </summary>
        public override void Save()
        {

            if (model.IsAudit)
            {
                MessageBox.Show("盘点单已审核不能更改"); return;
            }
            if (txtCheckNo.Text == "")
            {
                MessageBox.Show("没有要保存的数据");return;
            }
            if (model.Id == Guid.Empty)
            {
                if (manager.IsExistsUnAuditCheckNo())
                {
                    MessageBox.Show("上次盘点未审核，不能新增盘点单！");return;
                }
                model.Id = Guid.NewGuid();
                model.CheckNo = manager.GetNewCheckNo();
                model.Checkday = Checkday.DateTime;
                model.Description = txtDescription.Text;
                model.OperatorId = AppPublic.appSession._UserId;
                model.OperatorName = AppPublic.appSession._FullName;
                model.IsAudit = false;
                model.IsAuditday = DateTime.Parse("2020-01-01");
                if (manager.AddNew(model))
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            else
            {
              
                model.Checkday = Checkday.DateTime;
                model.Description = txtDescription.Text;
                model.OperatorId = AppPublic.appSession._UserId;
                model.OperatorName = AppPublic.appSession._FullName;
                if (manager.Modify(model))
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            Query();
        }

        /// <summary>
        /// 新增方法
        /// </summary>
        public override void AddNew()
        {
            model = new Models.ys_CheckOrder();
            this.txtCheckNo.Text = "新单号";
            model.Id = Guid.Empty;
            Checkday.EditValue = DateTime.Now;
            txtDescription.Text = "";
            cIsAudit.Checked = false;
            Checkday.ReadOnly = false;
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
        /// 选择行改变事件
        /// </summary>
        private void gvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                Guid Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                model = allList.FirstOrDefault(a => a.Id == Id);
                if (model != null)
                {
                    txtCheckNo.Text = model.CheckNo;
                    Checkday.EditValue = model.Checkday;
                    txtOperatorName.Text = model.OperatorName;
                    txtDescription.Text = model.Description;
                    cIsAudit.Checked = model.IsAudit;
                    Checkday.ReadOnly = true;
                }
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
            else {
                cIsAudit.Text = "未审核";
            }
        }
        
        /// <summary>
        /// 双击进入盘点明细
        /// </summary>
        private void gvData_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvData.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内 
                if (hInfo.InRow)
                {
                    //取得选定行信息 
                    Guid checkId = (Guid)gvData.GetRowCellValue(gvData.FocusedRowHandle, "Id");
                    AssetsCheckEditForm sub = new AssetsCheckEditForm(checkId);
                    sub.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 选择行改变事件
        /// </summary>
        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                Guid Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                model = allList.FirstOrDefault(a => a.Id == Id);
                if (model != null)
                {
                    txtCheckNo.Text = model.CheckNo;
                    Checkday.EditValue = model.Checkday;
                    txtOperatorName.Text = model.OperatorName;
                    txtDescription.Text = model.Description;
                    cIsAudit.Checked = model.IsAudit;
                    Checkday.ReadOnly = true;
                }
            }
        }
    }
}
