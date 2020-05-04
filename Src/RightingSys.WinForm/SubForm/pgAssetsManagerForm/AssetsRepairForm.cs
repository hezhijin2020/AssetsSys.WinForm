using DevExpress.XtraReports.UI;
using RightingSys.WinForm.AppPublic.Enum;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsRepairForm : BaseForm
    {
        BLL.RepairOrderManager  manager = new BLL.RepairOrderManager();
        public AssetsRepairForm()
        {
            InitializeComponent();
        }

        public override void InitFeatureButton()
        {
            base.SetFeatureButton(FeatureButton.Add, FeatureButton.Query,FeatureButton.Export,FeatureButton.Print);
        }

        /// <summary>
        /// 新增订单
        /// </summary>
        public override void AddNew()
        {
            AssetsRepairAddNewForm sub = new AssetsRepairAddNewForm();
            if (sub.ShowDialog() == DialogResult.OK)
            {
                Query();
            }
        }

        /// <summary>
        /// 查询记录
        /// </summary>
        public override void Query()
        {
            gcData.DataSource = manager.GetAllTable();
            gvData.BestFitColumns();
        }

        /// <summary>
        /// 导出订单信息
        /// </summary>
        public override void Export()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            fileDialog.FileName = "资产维修信息";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gcData.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 打印订单
        /// </summary>
        public override void Print()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                var RepairNo = gvData.GetFocusedRowCellValue("RepairNo").ToString();
                DevReport.rptRepairOrder rpt = new DevReport.rptRepairOrder(RepairNo);
                rpt.ShowPreview();
            }
        }

        /// <summary>
        /// 双击修改
        /// </summary>
        private void gvData_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(bool)gvData.GetFocusedRowCellValue("IsFinish"))
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo viewInfo = gvData.CalcHitInfo(new Point(e.X, e.Y));
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    if (viewInfo.InRow)
                    {
                        Guid ID = AppPublic.appPublic.GetObjGUID(gvData.GetFocusedRowCellValue("Id"));
                        AssetsRepairFinishForm sub = new AssetsRepairFinishForm(ID);
                        if (sub.ShowDialog() == DialogResult.OK)
                        {
                            Query();
                        }
                    }
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
        /// 自定义单元格样式
        /// </summary>
        private void gvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "IsFinish")
            {
                if (e.CellValue.Equals(true))
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }
    }
}
