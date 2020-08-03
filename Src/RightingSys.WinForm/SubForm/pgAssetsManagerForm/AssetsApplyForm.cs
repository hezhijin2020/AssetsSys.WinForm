using DevExpress.XtraReports.UI;
using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Windows.Forms;

namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsApplyForm : BaseForm
    {

        BLL.ApplyOrderManager manager = new BLL.ApplyOrderManager();
        public AssetsApplyForm()
        {
            InitializeComponent();
            Query();
        }

        public override void InitFeatureButton()
        {
            base.SetFeatureButton(FeatureButton.Add,FeatureButton.Query,FeatureButton.Export,FeatureButton.Print);
        }

        /// <summary>
        /// 新增订单
        /// </summary>
        public override void AddNew()
        {
            AssetsApplyEditForm sub = new AssetsApplyEditForm();
            if (sub.ShowDialog() == DialogResult.OK)
            {
                Query();
            }
        }
        /// <summary>
        /// 查询信息
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
            fileDialog.FileName = "资产领用信息";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gcData.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 打印订单信息
        /// </summary>
        public override void Print()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                var Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                DevReport.rptApplyOrder rpt = new DevReport.rptApplyOrder(Id);
                rpt.ShowPreview();
            }
        }

        /// <summary>
        /// 自定义单元格合并
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvData_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            int row1 = e.RowHandle1;
            int row2 = e.RowHandle2;
            string value1 = gvData.GetDataRow(row1)["Id"].ToString();
            string value2 = gvData.GetDataRow(row2)["Id"].ToString();
            if (value1 != value2)
            {
                e.Handled = true;
            }
        }
    }
}
