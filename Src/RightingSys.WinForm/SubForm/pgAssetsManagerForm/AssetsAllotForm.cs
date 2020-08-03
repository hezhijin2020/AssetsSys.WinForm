using DevExpress.XtraReports.UI;
using RightingSys.WinForm.Utils.clsEnum;
using System;
using System.Windows.Forms;
namespace RightingSys.WinForm.SubForm.pgAssetsManagerForm
{
    public partial class AssetsAllotForm : BaseForm
    {

        BLL.AllotOrderManager manager = new BLL.AllotOrderManager();
        public AssetsAllotForm()
        {
            InitializeComponent();
            Query();
        }

        public override void InitFeatureButton()
        {
            base.SetFeatureButton(FeatureButton.Add,FeatureButton.Query,FeatureButton.Export,FeatureButton.Print);
        }

        public override void AddNew()
        {
            AssetsAllotEditForm sub = new AssetsAllotEditForm();
            if (sub.ShowDialog() == DialogResult.OK)
            {
                Query();
            }
        }

        public override void Query()
        {
            gcData.DataSource = manager.GetAllTable();
            gvData.BestFitColumns();
        }

        public override void Export()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            fileDialog.FileName = "资产调拔信息";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gcData.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void Print()
        {
            if (gvData.FocusedRowHandle >= 0)
            {
                var Id = (Guid)gvData.GetFocusedRowCellValue("Id");
                DevReport.rptAllotOrder rpt = new DevReport.rptAllotOrder(Id);
                rpt.ShowPreview();
            }
        }

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
